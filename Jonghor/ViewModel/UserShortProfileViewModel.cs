using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class UserShortProfileViewModel
    {
        public List<Message> Messages { get; set; }
        public bool HasNotify { get; set; }
        public bool OwnDorm { get; set; }

        public UserShortProfileViewModel(string name)
        {
            SetMessages(name);
            HasNotify = Messages.Select(m => m.Isread).Contains(0);
            CheckDorm(name);
        }

        private void CheckDorm(string name)
        {
            PersonBusinessLayer layer = new PersonBusinessLayer();
            Person user = layer.GetUser(name);
            OwnDorm = user.Dorm.Count > 0;
        }

        public void SetMessages(string name)
        {
            MessageLayer layer = new MessageLayer();
            Messages = layer.GetMessage(name).ToList<Message>();
        }

        public void ResetReadMessage(string name)
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();
            
            foreach (var record in jonghor.Message.Where(m => m.Receiver_Username == name))
            {
                record.Isread = 1;
            }

            jonghor.SaveChanges();
        }
    }
}