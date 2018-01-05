using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class BranchOfficeManagementModel
    {

        public int BranchOfficeId { get; set; }

        [Required]
        [DisplayName("Branch Office")]
        public string BranchOffice { get; set; }

        [Required]
        [DisplayName("Full Name")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public String ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Mobile")]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
        public String MobileNo { get; set; }



        public string BranchOfficeCode { get; set; }

         [Required]
        [DisplayName("Native Country")]
        public int NativeCountry { get; set; }
        public string NativeCountryName { get; set; }
        public IEnumerable<SelectListItem> NativeCountryList { get; set; }

         [Required]
        [DisplayName("Zone")]
        public int? Zone { get; set; }
        public string ZoneName { get; set; }
        public IEnumerable<SelectListItem> ZoneList { get; set; }

         [Required]
        [DisplayName("District")]
        public int? District { get; set; }
        public string DistrictName { get; set; }
        public IEnumerable<SelectListItem> DistrictList { get; set; }

         [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

         [Required]
         [DisplayName("Address")]
         public string UserAddress { get; set; }

         [Required]
        [DisplayName("Phone")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public string Phone { get; set; }

         [Required]
         [DisplayName("Phone")]
         [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
         public string UserPhone { get; set; }

         [Required]
         [DisplayName("Email")]
         [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
         public string Email { get; set; }

         [Required]
         [DisplayName("Email")]
         public string UserEmail { get; set; }
        

         [DisplayName("Fax")]
         [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
         public string Fax { get; set; }

        [Required]
         [DisplayName("Pan No")]
         [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
         public string PanNo { get; set; }

         [DisplayName("Web")]
         public string Web { get; set; }

         [DisplayName("Status")]
         public int status { get; set; }
         public IEnumerable<SelectListItem> StatusList { get; set; }

         [Required]
         [DisplayName("Time Zone")]
         public int? TimeZone { get; set; }
         public string TimeZoneName { get; set; }
         public IEnumerable<SelectListItem> TimeZoneList { get; set; }

         [DisplayName("isSystem")]
         public bool isSystem { get; set; }

         public int CreatedBy { get; set; }
         public DateTime CreatedDate { get; set; }

         public int? UpdatedBy { get; set; }
         public DateTime? UpdatedDate { get; set; }

         public List<BranchOfficeManagementModel> ListBranchOffice { get; set; }


         
         [DisplayName("Branch Class")]
         public int? BranchClassId { get; set; }

        [DisplayName("Airline Deal")]
         public int MasterDealIdOfAirlines { get; set; }

        [DisplayName("Hotel Deal")]
         public int MasterDealIdOfHotel { get; set; }

        [DisplayName("Bus Deal")]
        public int MasterDealIdOfBus { get; set; }

        [DisplayName("Mobile Deal")]
        public int MasterDealIdOfMobile { get; set; }

        public IEnumerable<SelectListItem> MasterDealNameListOfAirlines { get; set; }
        public IEnumerable<SelectListItem> MasterDealNameListOfHotels { get; set; }
        public IEnumerable<SelectListItem> MasterDealNameListOfBus { get; set; }
        public IEnumerable<SelectListItem> MasterDealNameListOfMobile { get; set; }
    }
}