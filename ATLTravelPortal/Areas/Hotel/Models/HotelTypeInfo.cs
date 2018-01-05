using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    [MetadataType(typeof(HotelTypeInfoValidation))]
    public partial class HotelTypeInfos
    {
        public int HotelTypeId { get; set; }

        public string  HotelTypeName { get; set; }

        public string Description { get; set; }

       public bool isActive{ get; set; }
    }

    //[Bind(Exclude="ID")]
    public class HotelTypeInfoValidation
    {
        [Required(ErrorMessage = "Hotel Type Name Required")]
        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [DisplayName("Hotel Type Name")]
        public string HotelTypeName { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        [DisplayName("Description")]
        public string Description { get; set; }


        [DisplayName("Is Active")]
        public bool isActive { get; set; }

      
    }
}