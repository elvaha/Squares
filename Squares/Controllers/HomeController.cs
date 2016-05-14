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

        public ActionResult Gallery()
        {
            Gallery gal = new Gallery();
            List<Set> gallery = gal.Sets();

            return View(gallery);
        }

        public ActionResult Designer(String SetId)
        {
            DataClassesSquaresDataContext db = new DataClassesSquaresDataContext();
            Set set = db.Sets.Single(x => x.SetId == SetId);

            return View(set);
        }
    }
}