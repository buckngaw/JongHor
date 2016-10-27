using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class Dorm
    {

        public int DormId { get; set; }
        //Location
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Name { get; set; }
        public string Information { get; set; }
        //Social
        public string Line { get; set; }
        public string Facebbok { get; set; }
        public string Instagram { get; set; }
        public string Telephone { get; set; }

        public string Address { get; set; }

        public string Deposit { get; set;}
        //Expense Water
        public float WaterMin { get; set; }
        public float WaterPerUnit { get; set; }
        //Expense Electric
        public float ElecMin { get; set; }
        public float ElecPerUnit { get; set; }
        //Expense Internet

        //multi value
        public string [] Pictures { get; set; }
        public string [] Labels { get; set; }
        public string [] Options { get; set; }

    }
}