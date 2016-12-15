using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.ViewModel;
using Jonghor.Models;
using System.Data.Entity.Validation;

namespace Jonghor.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserProfileViewModel userViewModel = new UserProfileViewModel();
            userViewModel.SetUser(Session["UserName"].ToString());

            if(userViewModel.hasDorm)
                return View("User", userViewModel);
            else
            {
                return View("../Home/Homepage");
            }
        }

        public ActionResult UserDetail()
        {
            return View("UserDetail");
        }

        public ActionResult FeedbackSubmit(int star, string detail_feedback)
        {
            JongHorDBEntities1 db = new JongHorDBEntities1();
            DormLayer layer = new DormLayer();
            PersonBusinessLayer personLayer = new PersonBusinessLayer();
            MessageLayer memlayer = new MessageLayer();
            List<Message> mlist = memlayer.GetMessage();
            int mlistid = mlist.Count;
            Person user = personLayer.GetUser(Session["UserName"].ToString());

            Message message = new Message();
            message.Receiver_Username = layer.GetDorm(user.Dorm_ID.Value).Person.Username;
            message.Sender_Username = user.Username;
            message.MessageID = mlistid + 1;
            message.Title = "Feedback";
            Room room = user.Room;
            message.Text = (room.Floor + "" + room.Room_ID) + ": " + detail_feedback;
            message.Isread = 0;
            message.Date = DateTime.Now.ToString("dd-MM-yyyy") + " " +
                  DateTime.Today.ToString("HH:mm:ss tt");  //Date + Time

            db.Message.Add(message);
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

            Response.Write("<script>alert('Message has been sent')</script>");
            return Index();
        }
    }
}