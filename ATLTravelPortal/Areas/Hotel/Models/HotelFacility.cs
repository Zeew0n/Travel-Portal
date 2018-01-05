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
    [MetadataType(typeof(HotelFacilityValidation))]
    public partial class HotelFacilities
    {

        public int FacilityId { get; set; }

        public string Details { get; set; }

        public string FacilityName { get; set; }
        
        public bool isActive { get; set; }
        
        //[DataMember]
        //public string formActionName { get; set; }
        //[DataMember]
        //public string formControllerName { get; set; }
        //[DataMember]
        //public string formOnSubmitAction { get; set; }
        //[DataMember]
        //public string formSubmitBttnName { get; set; }

    }
    public class HotelFacilityValidation
    { 

    }
}