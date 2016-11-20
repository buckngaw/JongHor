﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;
using Jonghor.ViewModel;

namespace Jonghor.ViewModel
{
    public class RoomListViewModel
    {
        public List<RoomViewModel> GetRoomListView(string userName)
        {
            //int RoomNo = 0;
            //List<string> PeopleNames = new List<string>();
            //string Status = "No";

            List<RoomViewModel> rooms = new List<RoomViewModel>();
            PersonBusinessLayer personBal = new PersonBusinessLayer();
            List<Person> people = personBal.GetPeople();
            int dormId = personBal.GetDormId(userName);

            List<int> roomNoList = new List<int>();
            RoomLayer roomBal = new RoomLayer();
            foreach (Room room in roomBal.GetRoom())
            {
                if (room.Dorm_ID == dormId)
                {
                    rooms.Add(new RoomViewModel(room.Room_ID, room.Person, room.Status));
                }
            }

            //foreach (int roomNo in roomNoList)
            //{
            //    foreach (Person person in people)
            //    {
                    
            //        if(roomNo == person.roo)
            //    }
            //}

            return rooms;
        }
    }
}