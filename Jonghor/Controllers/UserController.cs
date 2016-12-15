using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.ViewModel;

namespace Jonghor.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserProfileViewModel userViewModel = new UserProfileViewModel();
            userViewModel.SetUser(Session["UserName"].ToString());

            return View("User", userViewModel);
        }

        public ActionResult UserDetail()
        {
            return View("UserDetail");
        }

        public ActionResult StarCheck()
        {
            return View("User");
        }

        public ActionResult FeedbackSubmit()
        {
            return View("User");
        }
    }
}