using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Jonghor.Models
{
    public class PersonBusinessLayer
    {
        public List<Person> GetPeople()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Person> peopleDal = jonghor.Person;

            return peopleDal.ToList<Person>();
        }

        public int GetDormId(string username)
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            List<Dorm> dorms = jonghor.Dorm.ToList<Dorm>();

            foreach (Dorm dorm in dorms)
            {
                if(dorm.M_username == username)
                {
                    return dorm.Dorm_ID;
                }
            }

            return Dorm.NotFound;
        }
    }
}