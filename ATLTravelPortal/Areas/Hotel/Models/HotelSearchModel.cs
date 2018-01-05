using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Areas.Hotel.Models;
using System.Runtime.Serialization;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelSearchModel
    {
        public string txtCity { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public int hdCityId { get; set; }
        public string hdCityName { get; set; }

        public string Rating { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int NoOfRooms { get; set; }

        public int Adults { get; set; }

        public int Childrens { get; set; }

        public long HotelId { get; set; }

        public string HotelName { get; set; }

        public string Address { get; set; }

        public string Details { get; set; }



        public IEnumerable<HotelSearchModel> HotelSearchResultList { get; set; }
       
    }
}