using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public enum Status
    {
        Avaliable, NotAvaliable, WaitRoomMate, Reserved
    }

    public class RoomViewModel
    {
        public RoomViewModel(string room_ID, ICollection<Person> person, int status, int id)
        {
            RoomNo = room_ID + "";
            PeopleNames = person.ToList<Person>().Select(p => p.Name).ToList<string>();
            PeoplePhone = person.ToList<Person>().Select(p => p.Phone).ToList<string>();
            Status = ((Status)status).ToString();
            Room_ID = id;
        }

        public string RoomNo { get; set; }
        public List<string> PeopleNames { get; set; }
        public string Status { get; set; }
        public int Room_ID { get; set; }
        public List<string> PeoplePhone { get; set; }
    }
}