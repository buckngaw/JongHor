using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;
using System.Web.Security;
using Jonghor.ViewModel;


namespace Jonghor.Controllers
{
    public class LoginController : Controller
    {
        //public ActionResult Index(string uname, string psw)
        //{
        //    PersonBusinessLayer personBal = new PersonBusinessLayer();
        //    List<Person> people = personBal.GetPeople();

        //    foreach (Person person in people)
        //    {
        //        if(person.Name == uname)
        //        {
        //            if(person.Password == psw)
        //            {
        //                return Content(uname + " login succeeded");
        //            }
        //            else
        //            {
        //                return Content("Password Incorrect");
        //            }
        //        }
        //    }
        //    return Content("Username not found");

        //}
        // GET: /User/
        public ActionResult Index()
        {
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult DoLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(string uname, string psw, bool isRemem = false)
        {
            UserViewModel user = new UserViewModel(uname, psw, true);
            if (ModelState.IsValid)
            {
                if (IsValid(uname, psw))
                {
                    Session["UserName"] = user.UserName;
                    if (!isOwner(uname))
                    {   
                        Session["Status"] = "User";
                    }
                    else
                    {
                        Session["Status"] = "Owner";
                        
                    }

                    UserShortProfileViewModel msgViewModel = new UserShortProfileViewModel(user.UserName);
                    Session["Notify"] = msgViewModel.HasNotify;
                    Session["UserShortProfile"] = msgViewModel;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    

                    return View("../Home/Homepage");
                }
                
            }
            return RedirectToAction("Index", "Home");
            //UserViewModel user = new UserViewModel(uname, psw, true);
            //if (ModelState.IsValid)
            //{
            //    if (IsValid(uname, psw))
            //    {
            //        FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
            //        FormsAuthentication.RedirectFromLoginPage(user.UserName, user.RememberMe);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        return Content("Login Error");
            //    }
            //}
            //return View(user);
        }

        private bool isOwner(string name)
        {
            DormLayer dormBal = new DormLayer();
            List<Dorm> dorms = dormBal.GetDorm();
            foreach (Dorm dorm in dorms)
            {
                if(dorm.M_username == name)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsValid(string uname, string psw)
        {
            PersonBusinessLayer personBal = new PersonBusinessLayer();
            List<Person> people = personBal.GetPeople();
            foreach (Person person in people)
            {
                if (person.Username == uname)
                {
                    if (person.Password == psw)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public ActionResult DoLogout()
        {
            Session.Remove("UserName");
            Session.Remove("Status");
            return RedirectToAction("Index", "Home");
        }


    }
}