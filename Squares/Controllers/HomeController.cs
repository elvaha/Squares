using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Squares.Models;

namespace Squares.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Class = "index";
            Gallery toprated = new Gallery();

            return View(toprated);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Class = "about";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Class = "contact";

            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Gallery(string sort)
        {
            ViewBag.Class = "gallery";

            Gallery gal = new Gallery();

            return View(gal.getGalleryItems(sort));
        }

        [HttpGet]
        public ActionResult Gallery(string searchParam, string searchPlace)
        {
            Gallery gal = new Gallery();

            return View(gal.SearchGallery("ARTIST", searchPlace));
        }

        public ActionResult Designer(String SetId)
        {
            SquaresDataContext db = new SquaresDataContext();

            Set set = db.Sets.Single(x => x.SetId == SetId);
            
            return View(set);
        }

        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }
    }
}