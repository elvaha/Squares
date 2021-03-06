﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquaresAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Sets()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}