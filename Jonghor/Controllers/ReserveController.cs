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

        public ActionResult Reserve(int room)
        {
            //new
            RoomViewLayer RoomDB = new RoomViewLayer();
            RoomDB = RoomDB.GetRoomViewByRoom(room);

            return View("Reservepage", RoomDB);
        }
        public ActionResult Room(int dorm)
        {

            RoomViewLayer RoomDB = new RoomViewLayer();
            List<RoomViewLayer> RoomViewList = RoomDB.GetRoomViewByDorm(dorm);


            return View("Room", RoomViewList);
        }

        public ActionResult Submit(int room)
        {
            //new
            RoomViewLayer RoomDB = new RoomViewLayer();
            RoomDB = RoomDB.GetRoomViewByRoom(room);

            return View("Reservepage", RoomDB);
        }

    }
}