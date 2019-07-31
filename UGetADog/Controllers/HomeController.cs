using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGetADog.Models;

namespace UGetADog.Controllers
{
    public class HomeController : Controller
    {
        private UGetADogContext db = new UGetADogContext();

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

        public ActionResult Recommended_dog()
        {
            MLsController mls = new MLsController();
            Dictionary<string, double> result;
            result= mls.Calc(int.Parse(Session["ID"].ToString()));
            var test = result.ToArray();
            return Json(test, JsonRequestBehavior.AllowGet);
        }

    }
}