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

        public ActionResult Login(string uname, string psw)
        {
            System.Diagnostics.Debug.WriteLine(uname + " " + psw);
            return View("Homepage");
        }

        public ActionResult Search(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);

            //var db = Database.
            return View("Homepage");
        }
    }
}