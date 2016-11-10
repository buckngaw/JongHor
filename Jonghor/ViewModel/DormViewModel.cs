using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class DormViewModel
    {
        public List<Dorm> GetDormList()
        {
            List<Dorm> dorms = new List<Dorm>();
            Dorm dorm = new Dorm();
            dorm.Name = "MorChor";
            dorms.Add(dorm);
            dorm = new Dorm();
            dorm.Name = "VK";
            dorms.Add(dorm);
            return dorms;
        }
    }
}