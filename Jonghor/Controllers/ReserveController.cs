using Jonghor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jonghor.ViewModel;
using System.Data;
using System.Data.Entity;
using System.Net;


namespace Jonghor.Controllers
{
   

    public class ReserveController : Controller
    {
        private JongHorDBEntities1 db = new JongHorDBEntities1();

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
            Session["room_id"] = room;

            return View("Reservepage", RoomDB);
        }
        public ActionResult Room(int dorm)
        {

            RoomViewLayer RoomDB = new RoomViewLayer();
            List<RoomViewLayer> RoomViewList = RoomDB.GetRoomViewByDorm(dorm);
            Session["dorm_id"] = dorm;

            return View("Room", RoomViewList);
        }

        public ActionResult Submit(string reserve)
        {
            int count = 0;
            int reserve_ID = 0;
            //new
            if (reserve == "add1"){count = 1;}
            else if (reserve == "add2"){ count = 2; }
            else if (reserve == "add3") { count = 3; }
            else if (reserve == "add4") { count = 4; }
            else if (reserve == "roommate") { count = 1; }

            Room_Reserved reserved_input = new Room_Reserved();
            reserved_input.Room_ID = int.Parse(Session["room_id"]+"");
            reserved_input.Username = Session["UserName"]+"";
            reserved_input.Count = count;

            //check Reserved_ID
            Room_ReservedLayer Room_ReservedDB = new Room_ReservedLayer();
            List<Room_Reserved> RoomDBList = Room_ReservedDB.GetRoom_Reserved();
            foreach(Room_Reserved Roomreserved in RoomDBList)
            {
                if(reserve_ID + "" == Roomreserved.Reserved_ID)
                {
                    reserve_ID++;
                }

            }

            reserved_input.Reserved_ID = reserve_ID+"";

            db.Room_Reserved.Add(reserved_input);
            db.SaveChanges();

           
            RoomViewLayer RoomDB = new RoomViewLayer();
            List<RoomViewLayer> RoomViewList = RoomDB.GetRoomViewByDorm(int.Parse(Session["dorm_id"] + ""));

            return View("Room", RoomViewList);
           // return reserve +;
        }

    }
}