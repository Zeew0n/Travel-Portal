using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    
    [MetadataType(typeof(HotelRoomTypeValidation) )]
    public partial class HotelRoomTypes
    {
        public int HotelRoomTypeId { get; set; }

        public string Details { get; set; }

        public string TypeName { get; set; }

        public int RoomCapacity { get; set; }

        public bool isActive { get; set; }
        
      
    }

    public class HotelRoomTypeValidation
    { 

    }
}