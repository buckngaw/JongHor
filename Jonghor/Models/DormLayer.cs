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
    }

    

}   