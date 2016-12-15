using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class UserEditViewModel
    {
        public Person user { get; set; }

        public void SetUser(string name)
        {
            PersonBusinessLayer layer = new PersonBusinessLayer();
            user = layer.GetUser(name);
        }
    }
}