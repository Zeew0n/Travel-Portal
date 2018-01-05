using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Areas.Hotel.Models;

using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    [MetadataType(typeof(HotelCityInfoValidation))]
    public partial class HotelCityInfos
    {
        public int CountryId { get; set; }

        public string CityName { get; set; }

        public string Details { get; set; }

        public bool isActive { get; set; }

        [DataMember]
       public IEnumerable<Htl_HotelCountries > HotelCountryList { get; set; }       
        
        //[DataMember]
        //public string formActionName { get; set; }

        //[DataMember]
        //public string formControllerName { get; set; }

        //[DataMember]
        //public string formOnSubmitAction { get; set; }

        //[DataMember]
        //public string formSubmitBttnName { get; set; }
    }

    public class HotelCityInfoValidation
    {

    }
    public class CityList
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}