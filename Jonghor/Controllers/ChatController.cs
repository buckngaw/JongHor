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
        public ActionResult Checkbox(MessageHTML m, string checkblock, string receiver)
        {

            switch (checkblock)
            {
                case "AllRoom":
                    return CheckAllRoom(m);
                case "SelectRoom":
                    return CheckSpecificRoom(m,receiver);
            }
           //  return "";
            return new EmptyResult();

        }



        //send message to all room
       public ActionResult CheckAllRoom(MessageHTML m)
        {
            MessageLayer memlayer = new MessageLayer();
            List<Message> mlist = memlayer.GetMessage();

            DormLayer layer = new DormLayer();
            Dorm dorm = layer.GetDorm(Session["UserName"].ToString());
            int sender_dorm = dorm.Dorm_ID;

            int mlistid = mlist.Count;
            Message mem = new Message();
            RoomLayer RoomDB = new RoomLayer();
            List<Room> RoomList = RoomDB.GetStatusRoom(); //only room that have person live
               foreach (Room r in RoomList)
              {
                if(r.Dorm_ID == sender_dorm) {
                    PersonLayer PL = new PersonLayer();
                    List<Person> personoomList = PL.GetPerson();
                    foreach (Person person in personoomList)
                    {
                        
                            if (person.Room_ID == r.Room_ID)
                        {
                            mem = new Message();
                            mem.Receiver_Username = person.Username;
                            mem.Sender_Username = Session["UserName"].ToString();
                            mem.MessageID = mlistid + 1;
                            mem.Title = m.Subject;
                            mem.Text = m.Message;
                            mem.Isread = 0;
                            mem.Date = DateTime.Now.ToString("dd-MM-yyyy") + " " +
                                  DateTime.Today.ToString("HH:mm:ss tt");  //Date + Time

                            db.Message.Add(mem);
                            db.SaveChanges();
                            mlistid++;

                        }
                        

                            
                    }
                }
                  

                
            }


            //return mem.Receiver_Username + " " + mem.Sender_Username + " " +
            //   " " + mem.Date ;
            return RedirectToAction("SubmitSent", new
            {
                action = 1

            });
        }



        //send message to specific room

         public ActionResult CheckSpecificRoom(MessageHTML m,string receiver)
         {
             Message mem = new Message();
             bool CheckRoom = false;
             string NotFoundRoom = "This room is available";
            MessageLayer memlayer = new MessageLayer();
            List<Message> mlist = memlayer.GetMessage();


            DormLayer layer = new DormLayer();
            Dorm dorm = layer.GetDorm(Session["UserName"].ToString());
            int sender_dorm = dorm.Dorm_ID;


            /// scan username of room
            RoomLayer Rl = new RoomLayer();
             List<Room> roomList = Rl.GetStatusRoom(); //get only unavailable room
            foreach (Room room in roomList)
            {

                if (room.Dorm_ID == sender_dorm)
                {
                    //int.Parse(receiver)

                    if (room.Room_number == receiver)
                    {
                        PersonLayer PL = new PersonLayer();
                        List<Person> personoomList = PL.GetPerson();
                        foreach (Person person in personoomList)
                        {

                            if (person.Room_ID == room.Room_ID)
                            {
                                mem.Receiver_Username = person.Username;
                                CheckRoom = true;
                            }
                        }
                    }
                    

                }
            }
             ///

                 mem.Sender_Username = Session["UserName"].ToString(); 
                 mem.MessageID = mlist.Count + 1;       
                 mem.Title = m.Subject;
                mem.Isread = 0;
                mem.Text = m.Message;
                 mem.Date = DateTime.Now.ToString("dd-MM-yyyy") + " " +
                     DateTime.Today.ToString("HH:mm:ss tt");  //Date + Time
             if(CheckRoom == true)
             {
                 db.Message.Add(mem);
                 db.SaveChanges();

                return RedirectToAction("Index", new
                {
                    action = 1
                    
                });

                
             }
             else
             {
                return View("Messenger");
                //return NotFoundRoom;
            }

           // return mem.Receiver_Username + " " + mem.Sender_Username + " " +
             //    " " + mem.Date;




         }

        public ActionResult Index()
         {
             return View("Messenger");
         }
     }
    }