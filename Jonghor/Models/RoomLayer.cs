using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Jonghor.ViewModel;
using Jonghor.Models;

namespace Jonghor.Models
{
    public class RoomLayer
    {
        public List<Room> GetRoom()
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Room> dormDal = jonghor.Room;

            return dormDal.ToList<Room>();
        }

        //for send message to unavailable room
        public List<Room> GetStatusRoom()
        {
            JongHorDBEntities1 jonghor1 = new JongHorDBEntities1();            
            DbSet<Room> RoomList = jonghor1.Room;

            List<Room> status = new List<Room>();
            foreach (Room r in RoomList)
            {
                if(r.Status == (int)Status.NotAvaliable || r.Status == (int)Status.WaitRoomMate)
                {
                    status.Add(r);
                }

            }


            return status.ToList<Room>();
        }
    }
}