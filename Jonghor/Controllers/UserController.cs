using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.ViewModel;
using Jonghor.Models;

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
            message.Receiver_Username = layer.GetDorm(user.Dorm_ID.Value).Person.Name;
            message.Sender_Username = user.Name;
            message.MessageID = mlistid + 1;
            message.Title = "Feedback";
            Room room = user.Room;
            message.Text = (room.Floor + "" + room.Room_ID) + detail_feedback;
            message.Isread = 0;
            message.Date = DateTime.Now.ToString("dd-MM-yyyy") + " " +
                  DateTime.Today.ToString("HH:mm:ss tt");  //Date + Time

            db.Message.Add(message);
            db.SaveChanges();
            return Content(star + " " + detail_feedback);
        }
    }
}