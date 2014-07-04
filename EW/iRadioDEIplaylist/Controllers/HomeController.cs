using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iRadioDEIplaylist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ASP.NET MVC 4 EF application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our contact page.";

            return View();
        }

        public ActionResult Widget()
        {
            ViewBag.Message = "Using this widget unregistered users can search for musics in lastfm's Database.";

            return View();
        }
    }
}
