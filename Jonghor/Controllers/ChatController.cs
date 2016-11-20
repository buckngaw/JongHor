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
        public string Checkbox(MessageHTML m, string checkblock, string receiver)
        {

            switch (checkblock)
            {
                case "AllRoom":
                   // return CheckAllRoom(m);
                    case "SelectRoom":
                     return CheckSpecificRoom(m,receiver);
            }
             return "";
            //return new EmptyResult();

        }

        //send message to all room
       public ActionResult CheckAllRoom(MessageHTML m)
        {
            MessageLayer memlayer = new MessageLayer();
            List<Message> mlist = memlayer.GetMessage();

            Message mem = new Message();
            RoomLayer RoomDB = new RoomLayer();
            List<Room> RoomList = RoomDB.GetStatusRoom();
               foreach (Room r in RoomList)
              {
                  PersonLayer PL = new PersonLayer();
                  List<Person> personoomList = PL.GetPerson();
                  foreach (Person person in personoomList)
                  {
                      if (person.Room_ID == r.Room_ID)
                      {
                          mem.Receiver_Username = person.Username;
                          mem.Sender_Username = "host";                      
                          mem.MessageID = mlist.Count + 1;
                          mem.Title = m.Subject;
                          mem.Text = m.Message;
                          mem.Date = DateTime.Now.ToString("dd-MM-yyyy") + " " +
                              DateTime.Today.ToString("HH:mm:ss tt");  //Date + Time

                          db.Message.Add(mem);
                          db.SaveChanges();

                      }
                  }


              }



            return View("Messenger");
        }

        //send message to specific room

         public String CheckSpecificRoom(MessageHTML m,string receiver)
         {
             Message mem = new Message();
             bool CheckRoom = false;
             string NotFoundRoom = "This room is available";
            MessageLayer memlayer = new MessageLayer();
            List<Message> mlist = memlayer.GetMessage();


            /// scan username of room
            RoomLayer Rl = new RoomLayer();
             List<Room> roomList = Rl.GetStatusRoom(); //get only unavailable room
             foreach (Room room in roomList)
             { if (room.Room_ID == int.Parse(receiver))
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
                 else
                 {
                     CheckRoom = false;
                 }
             }
             ///

                 mem.Sender_Username = "Host"; 
                 mem.MessageID = mlist.Count + 1;       
                 mem.Title = m.Subject;
                 mem.Text = m.Message;
                 mem.Date = DateTime.Now.ToString("dd-MM-yyyy") + " " +
                     DateTime.Today.ToString("HH:mm:ss tt");  //Date + Time
             if(CheckRoom == true)
             {
                 db.Message.Add(mem);
                 db.SaveChanges();

                 //return View("Messenger");
             }
             else
             {
                 return NotFoundRoom;
             }

             return mem.Sender_Username+" send message to   "+ mem.Receiver_Username
                 +" subject :  "+ mem.Title+"  "+mem.Text+" when  :"+mem.Date;




         }

        public ActionResult Index()
         {
             return View("Messenger");
         }
     }
    }