using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OCDSApi.Models;
using OCDSApi.Utilities;
using static System.String;

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
            DateTime temp;
            if (!IsNullOrEmpty(dateStart) && DateTime.TryParse(dateStart, out temp))
            {
                dateStart = temp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ");
            }
            if (!IsNullOrEmpty(dateEnd) && DateTime.TryParse(dateEnd, out temp))
            {
                dateEnd = temp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ");
            }
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