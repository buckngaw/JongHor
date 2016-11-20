using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jonghor.Controllers
{
    public class DormController : Controller
    {
        // GET: Dorm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}