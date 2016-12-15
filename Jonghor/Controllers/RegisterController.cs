using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;
using System.Threading.Tasks;

namespace Jonghor.Controllers
{
    public class RegisterController : Controller
    {
        private JongHorDBEntities1 db = new JongHorDBEntities1();

        [HttpGet]
        public JsonResult IsUserExists(String Username)
        {
            return Json(!db.Person.Any(x => x.Username == Username), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult IsSSNExists(String Ssn)
        {
            return Json(!db.Person.Any(x => x.Ssn == Ssn), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Registation()
        {
            return View("Register");
        }

        public ActionResult CreateUser(Person p)
        {
            PersonBusinessLayer bal = new PersonBusinessLayer();
            if (bal.IsValidUser(p))
            {
                ModelState.AddModelError("CredentialError", "Username is Exits");
                return View("Register");
            }
            else if (bal.IsValidSsn(p))
            {
                ModelState.AddModelError("CredentialError2", "SSN is Exits");
                return View("Register");
            }
            else
            {
                db.Person.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }      
        }

        // GET: Register
        public ActionResult Index()
        {      
            Response.Write("<script>alert('Register Successed')</script>");
            return View("../Home/Homepage");
        }

        // GET: Register/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Floor");
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,Room_ID,Name,Surname,Phone,Ssn")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Floor", person.Room_ID);
            return View(person);
        }

        // GET: Register/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Floor", person.Room_ID);
            return View(person);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,Room_ID,Name,Surname,Phone,Ssn")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Floor", person.Room_ID);
            return View(person);
        }

        // GET: Register/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
