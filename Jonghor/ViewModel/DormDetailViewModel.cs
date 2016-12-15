using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jonghor.Models;

namespace Jonghor.ViewModel
{
    public class DormDetailViewModel
    {
        public Dorm dorm { get; set; }
        public int maxPrice { get; set; }
        public int minPrice { get; set; }
        //public List<string> imageUrls = new List<string>();
        public string imageUrl { get; set; }
        public double avgRate { get; set; }
        public List<Dorm_Rate> dormRates = new List<Dorm_Rate>();

        

        public void SetDorm(int id)
        {
            DormLayer layer = new DormLayer();
            dorm = layer.GetDorm(id);
            SetPrice();
            SetImage();
            SetRate();
        }

        public void SetDorm(string name)
        {
            DormLayer layer = new DormLayer();
            dorm = layer.GetDorm(name);
            SetPrice();
            SetImage();
        }

        public void SetDorm(string name)
        {
            DormLayer layer = new DormLayer();
            dorm = layer.GetDorm(name);
            SetPrice();
            SetImage();
        }

        public void SetPrice()
        {
            DormLayer layer = new DormLayer();
            List<int> prices = new List<int>();
            List<Room_Type> types = layer.GetRoomTypes(dorm);
            foreach (Room_Type type in types)
            {
                prices.Add(type.Price);
            }

            if(prices.Capacity == 0) { prices.Add(0); }
            maxPrice = prices.Max();
            minPrice = prices.Min();
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

        public void SetRate()
        {
            try
            {
                dormRates = dorm.Dorm_Rate.ToList<Dorm_Rate>();
                avgRate = dormRates.Select(d => d.Score).Average();
            }
            catch
            {
                avgRate = 0;
            }
           
        }
    }
}