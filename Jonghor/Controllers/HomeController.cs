using System;
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
            
            return View("Homepage");
        }

        public ActionResult GetHome()
        {
            return View("Host_Homepage");
        }
    }
}