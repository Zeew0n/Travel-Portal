using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class DistributorManagementModel
    {
        #region DB Properties
        public int DistributorId { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Branch Office")]
        public int BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Distributor Code")]
        public string DistributorCode { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Distributor Name")]
        public string DistributorName { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Country")]
        public int NativeCountryId { get; set; }
        public string NativeCountryName { get; set; }

        [DisplayName("Zone")]
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }

        [DisplayName("District")]
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Email")]
        [RegularExpression(@"^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\b([,;]\s?)?)*$", ErrorMessage = "Not a valid Email")]
        public string Email { get; set; }

        [DisplayName("Fax No")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public string FaxNo { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        [DisplayName("Pan No")]
        public string PanNo { get; set; }
        [DisplayName("Web")]
        public string Web { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Status")]
        public int Status { get; set; }
        [DisplayName("Time Zone")]
        public int? TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }

        public bool isSystem { get; set; }
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [DisplayName("Distributor Class")]
        public int? DistributorClassId { get; set; }

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

        #endregion

        #region Dropdown options
        public IEnumerable<SelectListItem> BranchOffices { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Zones { get; set; }
        public IEnumerable<SelectListItem> Districts { get; set; }
        public IEnumerable<SelectListItem> TimeZones { get; set; }
        public IEnumerable<SelectListItem> StatusOption { get; set; }
        #endregion

        public IEnumerable<DistributorManagementModel> Distributors { get; set; }

        public IPagedList<DistributorManagementModel> DistributorsList { get; set; }


        #region User Registration Properties

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        [DisplayName("Full Name")]
        public String FullName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("User Name")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public String ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Email")]
        [RegularExpression(@"^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\b([,;]\s?)?)*$", ErrorMessage = "Not a valid Email")]
        public String UserEmail { get; set; }

        [DisplayName("Address")]
        public String UserAddress { get; set; }

        [Required]
        [DisplayName("Mobile")]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
        public String UserMobileNo { get; set; }

        [DisplayName("Phone")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public String UserPhoneNo { get; set; }
        #endregion
    }
}