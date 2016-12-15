using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jonghor.ViewModel
{
    public class HostViewModel
    {
        public string imageUrl { get; set; }
        public RoomListViewModel roomListViewModel = new RoomListViewModel();

        public void SetHost(string name)
        {
            //roomListViewModel.GetRoomListView(name, )
        }
    }
}