using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;
using ATL.Core.Parser;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirPackageModel : FormPropertyModel<AirPackageModel>
    {

        public int PackageId { get; set; }
        public int SNO { get; set; }
        [Required(ErrorMessage = "Country Required")]
        [DisplayName("Country Name:")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Zone Is Required")]
        [DisplayName("Zone")]
        public int? ZoneId { get; set;}

        [Required(ErrorMessage = "City Required")]
        [DisplayName("City Name:")]
        public int CityId { get; set; }

        [DisplayName("Package Group Name:")]
        public int PackageGroupId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [DisplayName("Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Package Code Required")]
        [DisplayName("Package Code:")]
        public string PackageCode { get; set; }

        [Required(ErrorMessage = "URL Required")]
        [DisplayName("URL:")]
        public string URL { get; set; }

        [DisplayName("Tags:")]
        public string Tags { get; set; }

       
        [DisplayName("Price NPR:")]
        public double? StartingPrice { get; set; }
 
        [DisplayName("Price INR:")]
        public double? StartingINR { get; set; }
        
        [DisplayName("Price USD:")]
        public double? StartingUSD { get; set; }
        [Required(ErrorMessage = "Duration is Required")]
        [DisplayName("Duration")]
        public string Duration { get; set; }

        [DisplayName("IsB2CPackage:")]
        public bool IsB2CPackage { get; set; }

        [DisplayName("IsB2BPackage:")]
        public bool IsB2BPackage { get; set; }

        [Required(ErrorMessage = "B2CMarkup Required")]
        [DisplayName("B2CMarkup:")]
        public decimal B2CMarkup { get; set; }

        [Required(ErrorMessage = "B2BMarkUp Required")]
        [DisplayName("B2BMarkUp:")]
        public decimal B2BMarkUp { get; set; }


        [Required(ErrorMessage = "Package Summery Required")]
        [DisplayName("Package Summary:")]
        public string PackageSummary { get; set; }

        [DisplayName("Accommaodation:")]
        public string Overview { get; set; }

        [DisplayName("Itinerary:")]
        public string Itineary { get; set; }

        [DisplayName("Destination:")]
        public string Destination { get; set; }

        [DisplayName("Terms And Conditions:")]
        public string TermAndConditions { get; set; }

        [Required(ErrorMessage="Inclusive And Exclusive is Required")]
        [DisplayName("Inclusive And Exclusive:")]
        public string InclusiveAndExclusive { get; set; }

        [DisplayName("Rate:")]
        public string Rate { get; set; }

        [DisplayName("Image Floder :")]
        public string ImageFolderName { get; set; }

        [Required(ErrorMessage = "Effective From Required")]
        [DisplayName("Effective From:")]
        public DateTime EffectiveFrom { get; set; }

        [Required(ErrorMessage = "Expire On Required")]
        [DisplayName("Expire On:")]
        public DateTime ExpireOn { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [DisplayName("Is Publish:")]
        public bool IsPublish { get; set; }

        public IEnumerable<SelectListItem> ddlZoneList { get; set;}
        public List<SelectListItem> ddlCountryList { get; set; }
        public List<SelectListItem> ddlCityList { get; set; }
        public List<SelectListItem> ddlDuration { get; set; }
        //added
        public IEnumerable<SelectListItem> ddlPackageGroupName { get; set; }


    }


    public static class Package
    {

        public enum EnumPackageDuration
        {
            [StringValue("1 Night")]
            OneNight = 0,
            [StringValue("2 Nights")]
            TwoNights = 1,
            [StringValue("3 Nights")]
            ThreeNights = 2,
            [StringValue("4 Nights")]
            FourNights = 3,
        }

    }



}