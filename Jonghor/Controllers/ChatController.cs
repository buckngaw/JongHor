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
        // GET: Chat
        public ActionResult Index(MessageHTML m,string Checkbox)
        {
            switch (Checkbox)
            {
                case "all room":
                    return CheckAllRoom();
                case "specific room":
                    return CheckSpecificRoom();
            }
            return new EmptyResult();

        }

        //send message to all room
        public  ActionResult CheckAllRoom()
        {
            return View("gg");
        }

        //send message to specific room
        public ActionResult CheckSpecificRoom()
        {
            return View("gg");
        }
    }
}