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

        public void SetDorm(int id)
        {
            DormLayer layer = new DormLayer();
            dorm = layer.GetDorm(id);
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
            maxPrice = prices.Max();
            minPrice = prices.Min();
        }
    }
}