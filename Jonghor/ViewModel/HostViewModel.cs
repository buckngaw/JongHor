using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class HostViewModel
    {
        public string imageUrl { get; set; }
        public RoomListViewModel roomListViewModel = new RoomListViewModel();

        public void SetHost(string name)
        {
            PersonBusinessLayer pBal = new PersonBusinessLayer();
            Person user = pBal.GetUser(name);
            imageUrl = user.Dorm.First().Dorm_Picture.URL_Picture;
            roomListViewModel.GetRoomListView(name, Status.Reserved);
        }
    }
}