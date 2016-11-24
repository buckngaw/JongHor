using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.ViewModel;

namespace Jonghor.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            if(Session["UserName"] != null)
            {
                UserMessengerViewModel user = new UserMessengerViewModel(Session["UserName"].ToString());
                return View("Message_Host",user);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}