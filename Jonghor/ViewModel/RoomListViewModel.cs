using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class RoomListViewModel
    {

        public List<RoomViewModel> Rooms = new List<RoomViewModel>();
        public List<RoomViewModel> GetRoomListView(string userName)
        {
            //int RoomNo = 0;
            //List<string> PeopleNames = new List<string>();
            //string Status = "No";
            PersonBusinessLayer personBal = new PersonBusinessLayer();
            List<Person> people = personBal.GetPeople();
            int dormId = personBal.GetDormId(userName);

            List<int> roomNoList = new List<int>();
            RoomLayer roomBal = new RoomLayer();
            foreach (Room room in roomBal.GetRoom())
            {
                if (room.Dorm_ID == dormId)
                {
                    Rooms.Add(new RoomViewModel(room.Floor + room.Room_number, room.Person,room.Status));
                }
            }

            //foreach (int roomNo in roomNoList)
            //{
            //    foreach (Person person in people)
            //    {
                    
            //        if(roomNo == person.roo)
            //    }
            //}

            return Rooms;
        }

        public void GetRoomListView(string name, Status status)
        {
            PersonBusinessLayer userBa = new PersonBusinessLayer();
            Person user = userBa.GetUser(name);
            foreach (var room in user.Dorm.First().Room)
            {
                if(room.Status == (int)status)
                {
                    Rooms.Add(new RoomViewModel(room.Floor + room.Room_number, room.Person, room.Status));
                }
            }
        }
    }
}