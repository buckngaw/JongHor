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

        //public Employee SaveEmployee(Employee e)
        //{
        //    SalesERPDAL salesDal = new SalesERPDAL();
        //    salesDal.Employees.Add(e);
        //    salesDal.SaveChanges();
        //    return e;
        //}
    }
}