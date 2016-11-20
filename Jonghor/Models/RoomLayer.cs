using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class RoomLayer
    {
        public List<Room> GetRoom()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Room> dormDal = jonghor.Room;

            return dormDal.ToList<Room>();
        }
    }
}