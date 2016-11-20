using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class RoomViewModel
    {
        public RoomViewModel(int room_ID, ICollection<Person> person, string status)
        {
            RoomNo = room_ID + "";
            PeopleNames = person.ToList<Person>().Select(p => p.Name).ToList<string>();
            Status = status;
        }

        public string RoomNo { get; set; }
        public List<string> PeopleNames { get; set; }
        public string Status { get; set; }
    }
}