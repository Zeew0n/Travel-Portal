using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    [MetadataType(typeof(HotelCityInfoAssociationValidation))]
    public partial class HotelCityInfoAssociation
    {
    
        public IEnumerable<HotelInfos> HotelNameList { get; set; }

        
        public IEnumerable<Htl_HotelCityInfos> HotelCityInfoList { get; set; }

       
        [HiddenInput]        
        public int HiddenCityId { get; set; }

        
        [HiddenInput]
        public Int64 HiddenHotelId { get; set; }

        public string HotelName { get; set; }

        public string CityName { get; set; }

        //public string formActionName { get; set; }
       
        //public string formControllerName { get; set; }
        
        //public string formOnSubmitAction { get; set; }
       
        //public string formSubmitBttnName { get; set; }

        public long HotelId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

    }
    public class HotelInfosNew
    {
        public long HotelId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

    }
    public class HotelCityInfoAssociationValidation
    { 

    }
}