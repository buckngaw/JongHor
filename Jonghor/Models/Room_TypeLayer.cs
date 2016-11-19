using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Room_TypeLayer
    {
        /*public int RoomMax { get; set; }
        public float RoomPrice { get; set; }
        public string TypeRoom { get; set; }
        public int TypeId { get; set; }
        public string [] RoomOption { get; set; }*/

            //h
        public List<Room_Type> GetRoom_Type()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Room_Type> dormDal = jonghor.Room_Type;

            return dormDal.ToList<Room_Type>();
        }
    }




}