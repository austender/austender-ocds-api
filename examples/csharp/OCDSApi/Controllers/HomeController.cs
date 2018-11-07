using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OCDSApi.Models;
using OCDSApi.Utilities;

namespace OCDSApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> SearchApi()
        {
            var cnId = Request["CnId"];
            var dateStart = Request["DataStart"];
            var dateEnd = Request["DateEnd"];

            var requestHelper = new RequestHelper();

            var baseUrl = "https://rrqcsg42vk.execute-api.ap-southeast-2.amazonaws.com/poc/ocds/";

            if (cnId.IsNullOrWhiteSpace() && dateStart.IsNullOrWhiteSpace() && dateEnd.IsNullOrWhiteSpace())
                return Redirect("Index");

            ApiResponse apiResponse = new ApiResponse {Releases = new List<Release>()};

            try
            {
                if (!cnId.IsNullOrWhiteSpace())
                {
                    apiResponse = await requestHelper.GetAndDecode<ApiResponse>(baseUrl + "findById/" + cnId);
                }

                //todo: we need to do the date search after POC provides the date searches api.

            }
            catch (InvalidOperationException)
            {
                apiResponse = new ApiResponse { Releases = new List<Release>() };
            }

            return View("SearchApiResult", apiResponse);
        }
    }
}