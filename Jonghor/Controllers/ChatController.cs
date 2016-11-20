using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;

namespace Jonghor.Controllers
{
    public class ChatController : Controller
    {
        private JongHorDBEntities1 db = new JongHorDBEntities1();

        // GET: Chat
        //String -> ActionResult
        public String Checkbox(MessageHTML m,string checkblock)
        {
           
                switch (checkblock)
                {
                    case "AllRoom":
                    // return CheckAllRoom(m);
                    case "SelectRoom":
                        return CheckSpecificRoom(m);
                }
                //return new EmptyResult();
            

            return "";

        }

        //send message to all room
        public  ActionResult CheckAllRoom(MessageHTML m)
        {
            Message mem = new Message();
            mem.Sender_Username = "Host";
            mem.Receiver_Username = "";
            mem.Title = m.Subject;
            mem.Text = m.Message;
            mem.Date = "1/1/2559";  //Real Time

            db.Message.Add(mem);
            return View("Messenger");
        }

        //send message to specific room
        //String -> ActionResult
        public String CheckSpecificRoom(MessageHTML m)
        {
            Message mem = new Message();
            mem.Sender_Username = "Host";
            mem.Receiver_Username = "";
            mem.Title = m.Subject;
            mem.Text = m.Message;
            mem.Date = "1/1/2559";  //Real Time

            db.Message.Add(mem);
            return m.Message + " " + m.Subject;
            //return View("Messenger");
        }

        public ActionResult Index()
        {
            return View("Messenger");
        }
    }
}