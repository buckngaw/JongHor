using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;
using System.Data.Entity.Validation;
using Jonghor.ViewModel;

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
        public ActionResult Add()
        {
            return View("Add");
        }

        public ActionResult Add(Dorm dorm)
        {
            if (Session["Status"] != null && Session["Status"].ToString() == "User")
            {
                dorm.M_username = Session["UserName"].ToString();
                dorm.Tel = "000";
                dorm.Address = "111";
                Dorm dormSelect = db.Dorm.SingleOrDefault(d => d.Name == dorm.Name);
                if (dormSelect == null)
                {
                    db.Dorm.Add(dorm);
                    Session["Status"] = "Owner";
                }
                else
                {
                    Response.Write("<script>alert('The dorm name is already exist')</script>");
                    return RedirectToAction("Index", "Home");
                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
                Response.Write("<script>alert('The dorm name is added, Status changed to Owner')</script>");
                return RedirectToAction("Index", "Home");
            }
            Response.Write("<script>alert('Error')</script>");
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Edit(Dorm dorm)
        {
            if (Session["Status"] != null && Session["Status"].ToString() == "Owner")
            {
                dorm.M_username = Session["UserName"].ToString();
                dorm.Tel = "000";
                dorm.Address = "111";
                Dorm dormSelect = db.Dorm.SingleOrDefault(d => d.Name == dorm.Name);
                if (dormSelect == null)
                {
                    db.Dorm.Add(dorm);
                }
                else
                {
                    dormSelect = dorm;
                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
                return Content("New dorm added");
            }

            return Content("Error cannot add new Dorm");
        }
        public ActionResult Roommanagement()
        {
            RoomListViewModel roomListview = new RoomListViewModel();
            string name = Session["UserName"].ToString();
            roomListview.GetRoomListView(name);

            return View("../Host/RoomManagement_Host", roomListview);
        }
        public ActionResult Roomsort(string option)
        {
            return Content(option);
        }
    }
}