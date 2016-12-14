using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class UserMessengerViewModel
    {
        public List<Message> Messages { get; set; }
        public bool hasNotify { get; set; }


        public UserMessengerViewModel(string name)
        {
            SetMessages(name);
            hasNotify = Messages.Select(m => m.Isread).Contains(0);
        }

        public void SetMessages(string name)
        {
            MessageLayer layer = new MessageLayer();
            Messages = layer.GetMessage(name).ToList<Message>();
        }

        public void ResetReadMessage(string name)
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();


            //IQueryable<Message> messages = jonghor.Message.Where(m => m.Receiver_Username == name);

            foreach (var record in jonghor.Message.Where(m => m.Receiver_Username == name))
            {
                record.Isread = 1;
            }

            jonghor.SaveChanges();
        }
    }
}