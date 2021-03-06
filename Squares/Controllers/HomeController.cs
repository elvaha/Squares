﻿using System;
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

        public ActionResult Gallery(string sort)
        {
            ViewBag.Class = "gallery";

            Gallery gal = new Gallery();

            return View(gal.getGalleryItems(sort));
        }

        [HttpPost]
        public ActionResult Gallery(searchModel model)
        {
            ViewBag.Class = "gallery";
            Gallery gal = new Gallery();
            List<Set> searchSet = gal.SearchGallery(model.searchParam, "ARTIST");

            if (searchSet == null || searchSet.Count == 0)
            {
                ViewBag.Error = "There is no matching Sets or Artist with your search Parameter";
                return View();
            }else
            {
                return View(searchSet);
            }

            
        }

        public ActionResult Designer(String SetId)
        {
            SquaresDataContext db = new SquaresDataContext();

            ViewBag.Class = "designer";

            Set set = db.Sets.Single(x => x.SetId == SetId);

            return View(set);
        }


        public ActionResult Profile(string artistId)
        {
            SquaresDataContext db = new SquaresDataContext();

            Artist artist = db.Artists.Where(x => x.ArtistId == artistId).FirstOrDefault();

            return View(artist);
        }
    }
}