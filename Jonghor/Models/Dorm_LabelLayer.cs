using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Dorm_LabelLayer
    {
        public List<Dorm_Label> GetDorm_Label()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Dorm_Label> dormDal = jonghor.Dorm_Label;

            return dormDal.ToList<Dorm_Label>();
        }
    }
}