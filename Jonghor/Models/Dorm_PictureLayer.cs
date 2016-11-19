using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Dorm_PictureLayer
    {
        public List<Dorm_Picture> GetDorm_Picture()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Dorm_Picture> dormDal = jonghor.Dorm_Picture;

            return dormDal.ToList<Dorm_Picture>();
        }
    }
}