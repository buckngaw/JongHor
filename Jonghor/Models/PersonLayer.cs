using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class PersonLayer
    {
        public List<Person> GetPerson()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Person> dormDal = jonghor.Person;

            return dormDal.ToList<Person>();
        }
    }
}