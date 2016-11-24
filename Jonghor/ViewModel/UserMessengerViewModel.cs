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
            //hasNotify = Messages.Select(m => m.isRead).Contain(0);
        }

        public void SetMessages(string name)
        {
            MessageLayer layer = new MessageLayer();
            Messages = layer.GetMessage(name).ToList<Message>();
        }
    }
}