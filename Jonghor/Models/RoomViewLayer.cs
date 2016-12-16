using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jonghor.Models
{
    public class RoomViewLayer
    {
        public Room room;
        public int Reserved_num = 0;
        public int filter = 0;

        public List<RoomViewLayer> GetRoomViewByDorm(int Dorm_ID)
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Room> RoomQuery = jonghor.Room;
            DbSet<Room_Type> RoomTypeQuery = jonghor.Room_Type;
            DbSet<Room_Reserved> RoomReservedQuery = jonghor.Room_Reserved;

            List<RoomViewLayer> Roomview = new List<RoomViewLayer>();

            foreach (Room room in RoomQuery)
            {
                RoomViewLayer roomviewlayer = new RoomViewLayer();
                if (room.Dorm_ID == Dorm_ID)
                {

                    roomviewlayer.room = room;


                    foreach (Room_Reserved roomreserved in RoomReservedQuery)
                    {
                        if (room.Room_ID == roomreserved.Room_ID)
                        {
                            roomviewlayer.Reserved_num += roomreserved.Count;
                        }
                    }

                    if (Reserved_num < roomviewlayer.room.Room_Type.Max)
                    { Roomview.Add(roomviewlayer); }

                }

            }

            return Roomview;
        }
        public RoomViewLayer GetRoomViewByRoom(int Room_ID)
        {
            JongHorDBEntities1 jonghor = new JongHorDBEntities1();

            DbSet<Room> RoomQuery = jonghor.Room;
            DbSet<Room_Reserved> RoomReservedQuery = jonghor.Room_Reserved;

            RoomViewLayer roomviewlayer = new RoomViewLayer();

            foreach (Room room in RoomQuery)
            {

                if (room.Room_ID == Room_ID)
                {
                    roomviewlayer.room = room;
                  

                    foreach (Room_Reserved roomreserved in RoomReservedQuery)
                    {
                        if (room.Room_ID == roomreserved.Room_ID)
                        {
                            roomviewlayer.Reserved_num += roomreserved.Count;
                        }
                    }


                }

            }

            return roomviewlayer;
        }
    }
}