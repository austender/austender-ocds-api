using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OCDSApi.Models;
using System.Linq;
using System.Collections.Generic;

namespace OCDSApi.Utilities
{
    public class RequestHelper
    {
        public static HttpClient HttpClient = new HttpClient();

        public async Task<T> GetAndDecode<T>(string url) where T : ApiResponse
        {
            var httpResult = "";

            HttpResponseMessage response = await HttpClient.GetAsync(url);

            // Throw an exception if the request fails 
            // (the API returns a 404 with a json message for a missing object / bad parameter, so this will catch API errors as well as network/server errors
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    httpResult = await response.Content.ReadAsStringAsync();
                }
                else {
                    throw new System.InvalidOperationException("Error getting http response: " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception e)
            {
                throw new System.InvalidOperationException(e.Message + " from " + url);
            }
            //ApiResponse apiResponse = new ApiResponse { releases = new List<Release>() };

            try
            {
                T apiResponse = JsonConvert.DeserializeObject<T>(httpResult);

                if (url.ToLower().Contains("findbyid"))
                {
                    if(apiResponse.Releases.Count > 1)
                    {
                        var amendments = apiResponse.Releases.Skip(1).Select(r => new Amendment()
                        {
                            id = r.contracts.FirstOrDefault()?.amendments.FirstOrDefault()?.id,
                            date = r.date
                        }).ToList();

                        if (amendments.Any())
                        {
                            var release = apiResponse.Releases.First();
                            release.isParent = true;
                            release.contracts.First().amendments = amendments;

                            apiResponse.Releases = apiResponse.Releases.Take(1).ToList();
                        }
                    }
                    else
                    {
                        return apiResponse;
                    }
                }
                else
                {
                    var results = new List<Release>();
                    var amendmentsList = new Dictionary<string, Amendment>();
                    var amendments = apiResponse.Releases.Where(r => r.tag.Any(t => t == "contractAmendment")).Select(r => new Amendment()
                    {
                        id = r.contracts.FirstOrDefault()?.amendments.FirstOrDefault()?.id,
                        date = r.date
                    }).ToList();

                    foreach (var release in apiResponse.Releases)
                    {
                        if (release.tag.Any(t => t == "contract"))
                        {
                            release.isParent = true;

                            release.contracts.First().amendments = amendments.Where(a => a.id.Contains(release.contracts.FirstOrDefault().id + "-A")).ToList();

                            results.Add(release);
                        }
                        else
                        {
                            results.Add(release);
                        }
                    }

                    apiResponse.Releases = results;

                    return apiResponse;
                }

                return apiResponse;
            }
            catch (Exception)
            {
                throw new System.InvalidOperationException(" from " + url);
            }

            
        }
    }
}