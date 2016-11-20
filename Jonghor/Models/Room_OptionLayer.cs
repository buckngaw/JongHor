using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Room_OptionLayer
    {
        public List<Room_Option> GetRoom_Option()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Room_Option> dormDal = jonghor.Room_Option;

            return dormDal.ToList<Room_Option>();
        }
    }
}