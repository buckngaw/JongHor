using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class HostViewModel
    {
        public Dorm dorm { get; set; }
        public string imageUrl { get; set; }


        public void SetDorm(int id)
        {
            DormLayer layer = new DormLayer();
            dorm = layer.GetDorm(id);
            SetImage();
        }

        public void SetDorm(string name)
        {
            DormLayer layer = new DormLayer();
            dorm = layer.GetDorm(name);
            SetImage();
        }

        public void SetImage()
        {
            try
            {
                imageUrl = dorm.Dorm_Picture.URL_Picture;
            }
            catch
            {
                imageUrl = "http://www.novelupdates.com/img/noimagefound.jpg";
            }
        }
        
        
    }
}