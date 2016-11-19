using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(string uname, string psw, bool isRemem)
        {
            UserName = uname;
            Password = psw;
            RememberMe = isRemem;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}