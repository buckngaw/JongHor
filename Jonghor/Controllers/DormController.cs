﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;

namespace Jonghor.Controllers
{
    public class DormController : Controller
    {
        private JongHorDBEntities1 db = new JongHorDBEntities1();
        // GET: Dorm
        public ActionResult Index()
        {
            return View("Edit");
        }

        public ActionResult Edit(Dorm dorm)
        {
            Dorm dormSelect = db.Dorm.SingleOrDefault(d => d.Name == dorm.Name);
            if (dormSelect == null)
            {
                db.Dorm.Add(dorm);
                db.SaveChanges();
            }
            else
            {
                dormSelect = dorm;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}