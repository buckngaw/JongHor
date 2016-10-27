using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;
using Jonghor.ViewModel;

namespace Jonghor.Controllers
{
    public class JonghorController : Controller
    {
        // GET: Jonghor
        public ActionResult Index()
        {
            DormViewModel dormViewModel = new DormViewModel();
            return View("Homepage", dormViewModel);
        }
    }
}