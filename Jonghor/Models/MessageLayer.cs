using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class MessageLayer
    {
        public List<Message> GetMessage()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Message> dormDal = jonghor.Message;

            return dormDal.ToList<Message>();
        }

        public IQueryable<Message> GetMessage(string name)
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            IQueryable<Message> messages = jonghor.Message.Where(m => m.Sender_Username == name);

            return messages;
        }
    }
}