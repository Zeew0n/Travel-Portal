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
    [MetadataType(typeof(HotelPhotoValidation))]
    public partial class HotelPhotos
    {

        public IEnumerable<HotelInfos> HotelNameList { get; set; }


        public IEnumerable<HotelPhotoCategories> PhotoCategoryList { get; set; }


        [DataMember]
        public IEnumerable<Htl_GetHotelPhotoList_Result> HotelPhotosList { get; set; }

        public Int64 PhotoId { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        [DataMember]
        public int[] DeletedCheckedList { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        public string Picture { get; set; }

        [HiddenInput]
        [DataMember]
        public string HiddenPictureName { get; set; }

        [HiddenInput]
        [DataMember]
        public string PicturePath { get; set; }

        [DataMember]
        public string HotelName { get; set; }

      
    }

    public class HotelPhotoValidation
    {
        [DisplayName("Photo Category")]
        public string CategoryName { get; set; }

        [DisplayName("Hotel")]
        public string HotelName { get; set; }
    }
}