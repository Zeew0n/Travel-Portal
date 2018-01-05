using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;



namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirPackageGroupModel
    {

        public int PackageGroupID { get; set; }
        public int SNO { get; set; }
        [Required(ErrorMessage = "Country Required")]
        [DisplayName("Country:")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Zone Required")]
        [DisplayName("Zone:")]
        public int? ZoneId { get; set; } 

        [DisplayName("City:")]
        public int? CityId { get; set; }
        public string CityName { get; set; }

        [Required(ErrorMessage = "Group Name is Required ")]
        [DisplayName("Group Name:")]
        public string GroupName { get; set; }
            
        [DisplayName("URL:")]
        public string URL { get; set; }

        [Required(ErrorMessage="Destination is Required")]
        [DisplayName("Destination:")]
        public string Destination { get; set; }

        [DisplayName("Image Folder Name:")]
        public string ImageFolderName { get; set; }

        [DisplayName("IsB2BPackage:")]
        public bool IsB2BPackage { get; set; }

        [DisplayName("IsB2CPackage:")]
        public bool IsB2CPackage { get; set; }


        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public IPagedList<AirPackageGroupModel> PackageList { get; set; }

        public IEnumerable<SelectListItem> ddlZoneList { get; set;}
        public IEnumerable<SelectListItem> ddlCountryList { get; set; }
        public IEnumerable<SelectListItem> ddlCityList { get; set; }


    }
}