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
    [MetadataType(typeof(HotelAdditionalChargeValidation))]
    public partial class HotelAdditionalCharge
    {
        public int ChargeId { get; set; }

        public string Detail { get; set; }

        public double Rate { get; set; }

        public string ChargeName { get; set; }

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

    public class HotelAdditionalChargeValidation
    {
        [Required(ErrorMessage="Required")]
        public string ChargeName { get; set; }
        
    }
}