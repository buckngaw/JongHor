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
        
        public ActionResult Filter(int Dormoption)
        {
            RoomViewLayer RoomDB = new RoomViewLayer();
            List<RoomViewLayer> RoomViewList = RoomDB.GetRoomViewByDorm((int)Session["dorm_id"]);
            List<RoomViewLayer> rooms = new List<RoomViewLayer>();
            foreach (RoomViewLayer room in RoomViewList)
            {
                if(room.room.Status == Dormoption)
                {
                    rooms.Add(room);
                }
            }
            return View("Room", rooms);
        }

        public ActionResult Submit()
        {
            int count = 0;
            int reserve_ID = 0;
            //new
            count = 1;


            Room_Reserved reserved_input = new Room_Reserved();
            reserved_input.Room_ID = int.Parse(Session["room_id"]+"");
            reserved_input.Username = Session["UserName"]+"";
            reserved_input.Count = count;

            // CHeck login
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Reserve", new
                {
                    error = 1,
                    room = int.Parse(Session["room_id"] + "")
                });
            }

            //check Reserve More 1 room  // 1 คน มี ห้อง
            Room_ReservedLayer RoomReservedLayer = new Room_ReservedLayer();
           List<Room_Reserved> RoomReservedList = RoomReservedLayer.GetRoom_Reserved();
            int ReserveCount = 0;
            foreach(Room_Reserved room in RoomReservedList)
            {
                if(reserved_input.Username == room.Username)
                {
                    ReserveCount++;
                }
                

            }
            if (ReserveCount >= 1)
            {
                return RedirectToAction("Reserve", new
                {
                    error = 3,
                    room = int.Parse(Session["room_id"] + "")
                });
            }

            //check Count
            RoomViewLayer Roomview = new RoomViewLayer();
            Roomview = Roomview.GetRoomViewByRoom(int.Parse(Session["room_id"] + ""));
              if (Roomview.room.Room_Type.Max < (Roomview.Reserved_num+count))
            {
                return RedirectToAction("Reserve", new
                {
                    error = 4,
                    room = int.Parse(Session["room_id"] + "")
                });
             // check full
            }else if(Roomview.room.Room_Type.Max == (Roomview.Reserved_num + count)) // เท่ากัน
            {
                db.Room.Find(Roomview.room.Room_ID).Status = (int)Status.NotAvaliable;
                
            }


            //check Reserved_ID
            Room_ReservedLayer Room_ReservedDB = new Room_ReservedLayer();
            List<Room_Reserved> RoomReDBList = Room_ReservedDB.GetRoom_Reserved();
            foreach(Room_Reserved Roomreserved in RoomReDBList)
            {
                if(reserve_ID  == Roomreserved.Reserve_ID)
                {
                    reserve_ID++;
                   
                }

            }

            reserved_input.Reserve_ID = reserve_ID;

          
            try
            {





                    db.Room_Reserved.Add(reserved_input);
                db.SaveChanges();

                RoomViewLayer RoomDB = new RoomViewLayer();
                List<RoomViewLayer> RoomViewList = RoomDB.GetRoomViewByDorm(int.Parse(Session["dorm_id"] + ""));

                


                return View("Room", RoomViewList);
            }
            catch
            {
               
                
                    return RedirectToAction("Reserve", new
                    {
                        error = 2,
                        room = int.Parse(Session["room_id"] + "")
                    });
                
                
               
            }

            

            // return reserve +;
        }

    }
}