﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.ViewModel;

namespace Jonghor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Jonghor
        public ActionResult Index()
        {
            if (Session["Status"] != null && Session["Status"].ToString() == "Owner")
                return View("Host_Homepage");
            else
                return View("Homepage");
        }
    }
}