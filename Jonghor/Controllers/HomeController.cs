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
            DormViewModel dormViewModel = new DormViewModel();
            return View("Homepage", dormViewModel);
        }

        public ActionResult GetHome()
        {
            return View("Host_Homepage");
        }
    }
}