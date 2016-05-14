using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SquaresDataLibrary;

namespace Squares.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Class = "index";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Class = "about";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Class = "gallery";
            /*
            Gallery gal = new Gallery();
            List<Set> gallery = gal.Sets();
            */
            return View();
        }

        public ActionResult Designer(String SetId)
        {
            ViewBag.Class = "gallery";

            DataClassesSquaresDataContext db = new DataClassesSquaresDataContext();
            Set set = db.Sets.Single(x => x.SetId == SetId);
            
            return View(set);
        }
    }
}