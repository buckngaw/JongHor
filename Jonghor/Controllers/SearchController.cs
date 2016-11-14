using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jonghor.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);

            //var db = Database.
            return View("Searchpage");
        }
    }
}