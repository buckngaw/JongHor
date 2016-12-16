using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Room_ReservedLayer
    {
        public List<Room_Reserved> GetRoom_Reserved()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Room_Reserved> dormDal = jonghor.Room_Reserved;

            return dormDal.ToList<Room_Reserved>();
        }

        public List<Room_Reserved> GetRoomReservedByDormID(int dormId)
        {
            JongHorDBEntities1 db = new JongHorDBEntities1();

            var roomReservedDB = db.Room_Reserved.Where(r => r.Room.Dorm_ID == dormId);

            return roomReservedDB.ToList<Room_Reserved>();
        }
        
    }
}