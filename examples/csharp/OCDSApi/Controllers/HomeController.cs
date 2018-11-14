using System;
using System.Collections.Generic;
using System.Configuration;
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

        public ActionResult SearchByCnId()
        {
            return View();
        }

        public ActionResult SearchByPublishDate()
        {
            return View();
        }

        public async Task<ActionResult> SearchApi()
        {
            var cnId = Request["CnId"];
            var dateStart = Request["DataStart"];
            var dateEnd = Request["DateEnd"];

            var requestHelper = new RequestHelper();

            var url = "";
            if (!cnId.IsNullOrWhiteSpace())
            {
                url = ConfigurationManager.AppSettings["FindByIdUrl"] + cnId;
            }
            else if (!dateStart.IsNullOrWhiteSpace() && !dateEnd.IsNullOrWhiteSpace())
            {
                url = ConfigurationManager.AppSettings["FindByPublishDateUrl"] + dateStart + "/" + dateEnd;
            }


            ApiResponse apiResponse;

            try
            {
                apiResponse = await requestHelper.GetAndDecode<ApiResponse>(url);
            }
            catch (Exception)
            {
                apiResponse = new ApiResponse { Releases = new List<Release>() };
            }

            return View("SearchApiResult", apiResponse);
        }
    }
}