using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Mvc;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Models
{

    [MetadataType(typeof(HotelPhotoCategoryValidation))]
    public partial class HotelPhotoCategories
    {
        public Int64 PhotoCategoryId { get; set; }

        public IEnumerable<HotelPhotoCategories> PhotoCategoryList { get; set; }

        [DataMember]
        public IEnumerable<HotelInfos> HotelNameList { get; set; }

        public string CategoryName { get; set; }

        public Int64 HotelId { get; set; }

        public string HotelName { get; set; }

        public string Details { get; set; }

        public bool isActive { get;set; }
    }

    public class HotelPhotoCategoryValidation
    {
        [Required(ErrorMessage = "Hotel is Required")]
        [DisplayName("Hotel")]
        public Int64 HotelId { get; set; }

        [Required(ErrorMessage = "Photo Category Required")]        
        [DisplayName("Photo Category Name")]
        public string CategoryName { get; set; }        

        [DisplayName("Is Active")]
        public bool isActive { get; set; }

    }
}