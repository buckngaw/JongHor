using Jonghor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jonghor.Controllers
{
    public class ReserveController : Controller
    {
        // GET: Reserve
        public ActionResult Index()
        {
            return View("Room");
        }

        public ActionResult Reserve()
        {
            //new
            return View("Reservepage");
        }
        public ActionResult Room(int dorm)
        {

            RoomViewLayer DormDB = new RoomViewLayer();
            List<RoomViewLayer> DormViewList = DormDB.GetRoomViewByDorm(dorm);


            return View("Room", DormViewList);
        }

    }
}