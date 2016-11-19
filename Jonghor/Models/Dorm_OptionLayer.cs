using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Dorm_OptionLayer
    {
        public List<Dorm_Option> GetDorm_Option()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Dorm_Option> dormDal = jonghor.Dorm_Option;

            return dormDal.ToList<Dorm_Option>();
        }
    }
}