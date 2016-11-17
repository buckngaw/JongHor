using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;

namespace Jonghor.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string uname, string psw)
        {
            PersonBusinessLayer personBal = new PersonBusinessLayer();
            List<Person> people = personBal.GetPeople();

            foreach (Person person in people)
            {
                if(person.Name == uname)
                {
                    if(person.Password == psw)
                    {
                        return Content(uname + " login succeeded");
                    }
                    else
                    {
                        return Content("Password Incorrect");
                    }
                }
            }
            return Content("Username not found");
            
        }

        public ActionResult Searchpage()
        {
            DormViewModel dormViewModel = new DormViewModel();
            return View("Searchpage", dormViewModel);
        }
    }
}