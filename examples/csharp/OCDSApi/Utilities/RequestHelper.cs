using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OCDSApi.Models;

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
                return apiResponse;
            }
            catch (Exception)
            {
                throw new System.InvalidOperationException(" from " + url);
            }

            
        }
    }
}