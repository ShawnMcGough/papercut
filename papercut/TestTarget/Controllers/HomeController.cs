using System;
using System.Net;
using System.Threading;
using System.Web.Mvc;

namespace TestTarget.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Random R = new Random();
        public ActionResult Index()
        {

            Thread.Sleep(R.Next(500, 2000));

            if (R.Next(500, 2000) % 10 == 0)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

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