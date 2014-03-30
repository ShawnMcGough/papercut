using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TestTarget.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Random R = new Random();
        public ActionResult Index()
        {

            Thread.Sleep(R.Next(500, 2000));
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
    }
}