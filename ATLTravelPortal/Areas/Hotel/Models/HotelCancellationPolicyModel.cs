using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelCancellationPolicyModel
    {
        public int SearchIndex { get; set; }
        public string RatePlanCode { get; set; }
        public string RoomTypeCode { get; set; }
        public string SessiobId { get; set; }
        public int NoOfRoom { get; set; }
        public string CancellationPolicy { get; set; }
        public bool CancellationPolicyAvailable { get; set; }
        public bool HotelNormsAvailable { get; set; }
        public string HotelNorms { get; set; }
        public HotelMessageModel Message { get; set; }
        public string HotelCode { get; set; }
        public string RoomDesc { get; set; }
    }
}