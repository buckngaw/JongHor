using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class RoomType
    {
        public int RoomMax { get; set; }
        public float RoomPrice { get; set; }
        public string TypeRoom { get; set; }
        public int TypeId { get; set; }
        public string [] RoomOption { get; set; }
    }




}