using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public enum Status
    {
        NotAvaliable, Avaliable, WaitRoomMate
    }

    public class RoomViewModel
    {
        public RoomViewModel(int room_ID, ICollection<Person> person, int status)
        {
            RoomNo = room_ID + "";
            PeopleNames = person.ToList<Person>().Select(p => p.Name).ToList<string>();
            Status = ((Status)status).ToString();
        }

        public string RoomNo { get; set; }
        public List<string> PeopleNames { get; set; }
        public int Status { get; set; }
    }
}