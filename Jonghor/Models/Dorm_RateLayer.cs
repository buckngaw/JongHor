using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Dorm_RateLayer
    {
        public List<Dorm_Rate> GetDorm_Rate()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Dorm_Rate> dormDal = jonghor.Dorm_Rate;

            return dormDal.ToList<Dorm_Rate>();
        }
    }
}