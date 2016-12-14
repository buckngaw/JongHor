using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class DormLayer
    {
        public List<Dorm> GetDorm()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Dorm> dormDal = jonghor.Dorm;

            return dormDal.ToList<Dorm>();
        }

        public Dorm GetDorm(int id)
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            IQueryable<Dorm> dorms = jonghor.Dorm.Where(d => d.Dorm_ID == id);
            if (dorms.ToList<Dorm>().Count != 0)
                return dorms.ToList<Dorm>()[0];
            else
            {
                return new Dorm();
            }
        }

        public List<Room_Type> GetRoomTypes(Dorm dorm)
        {
            JongHorDBEntities1 db = new JongHorDBEntities1();
           
            IQueryable<Room> rooms = db.Room.Where(r => r.Dorm_ID == dorm.Dorm_ID);
            List<Room_Type> types = new List<Room_Type>();
            foreach (Room room in rooms)
            {
                if(!types.Contains(room.Room_Type))
                    types.Add(room.Room_Type);
            }
            
            

            return types;
        }

    }

    

}   