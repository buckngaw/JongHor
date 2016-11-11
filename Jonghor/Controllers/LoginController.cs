using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jonghor.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string uname, string psw)
        {
            System.Diagnostics.Debug.WriteLine(uname + " " + psw);
            return View("Homepage");
        }
    }
}