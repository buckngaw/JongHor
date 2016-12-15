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
            if (Session["Status"] != null && Session["Status"].ToString() == "Owner")
            {
                DormDetailViewModel dormview = new DormDetailViewModel();
                dormview.SetDorm(Session["Username"].ToString());
                return View("Host_Homepage", dormview);
            }
               
            else if (Session["Status"] != null && Session["Status"].ToString() == "User")
                return RedirectToAction("Index", "User");
            else
                return View("Homepage");
        }
        public ActionResult Roommanage()
        {
            return RedirectToAction("Index", "Host");
        }
        public ActionResult Host()
        {

            return View("Host_Homepage");
        }
    }
}