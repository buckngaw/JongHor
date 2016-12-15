using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class UserProfileViewModel
    {
        public bool hasDorm { get; set; }
        public bool isRoomMateMode { get; set; }
        public int rate { get; set; }

        public void SetUser(string name)
        {
            PersonBusinessLayer layer = new PersonBusinessLayer();
            Person user = layer.GetUser(name);
            isRoomMateMode = (Status)user.Room.Status == Status.WaitRoomMate;
            hasDorm = user.Dorm_ID != null;
            if (hasDorm)
            {
                var dormRate = user.Dorm_Rate.Where(u => u.Dorm_ID == user.Dorm_ID);
                if (dormRate.Count() > 0)
                {
                    rate = (int)dormRate.ToList<Dorm_Rate>()[0].Score;
                }
                else
                {
                    rate = 0;
                }
            }
            else
            {
                rate = 0;
            }
        }
    }
}