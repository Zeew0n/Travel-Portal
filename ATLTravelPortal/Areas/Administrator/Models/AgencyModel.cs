using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgencyModel
    {

        [Required(ErrorMessage = " ")]
        [DisplayName("Agency Name")]
        public String AgencyName { get; set; }
        public int AgentId { get; set; }

        public int AgentStatusid { get; set; }

        public int MasterDealIdOfAirlines { get; set; }

        public int MasterDealIdOfHotel { get; set; }

        public string AgentRole { get; set; }

        public string AgencyCode { get; set; }


        [Required(ErrorMessage = " ")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        [DisplayName("Email")]
        public String Email { get; set; }


        [Required(ErrorMessage = " ")]
        [DisplayName("Pincode")]
        public String Pincode { get; set; }

        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public String Password { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Street")]
        public String Street { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("State")]
        public int State { get; set; }
        public string StateName { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Locality")]
        public String Locality { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        [DisplayName("Contact Person")]
        public String ContactPerson { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        [DisplayName("Full Name")]
        public String FullName { get; set; }


        [Required(ErrorMessage = " ")]
        [DisplayName("User Name")]
        public String UserName { get; set; }


        [Required(ErrorMessage = " ")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        [DisplayName("Father Name")]
        public String FatherName { get; set; }


        [Required(ErrorMessage = " ")]
        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Pan Card No")]
        public String PanCardNo { get; set; }

        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        public string PanHolderName { get; set; }

        public string Web { get; set; }

        public bool AgentStatus { get; set; }
        public int? AgentTypeId { get; set; }
        public int? AgentClassId { get; set; }
        public int AirlineGroupId { get; set; }
        public int MaxNoofAgentUsers { get; set; }
        public string AgentLogo { get; set; }
        public int TimeZoneId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool isApproved { get; set; }
        public int ApprovedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Referenced By")]
        public int ReferencedBy { get; set; }
        public string ReferencedByName { get; set; }
        public IEnumerable<SelectListItem> ReferenceList { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
        [DisplayName("Mobile")]
        public String Mobile { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        [DisplayName("Phone")]
        public String Phone { get; set; }

        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public String ConfirmPassword { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("City")]
        public int City { get; set; }
        public string CityName { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }

        [DisplayName("Country")]
        public int NativeCountry { get; set; }
        public string NativeCountryName { get; set; }
        public IEnumerable<SelectListItem> NativeCountryNameList { get; set; }


        public int Zone { get; set; }
        public int District { get; set; }

        public string FaxNo { get; set; }

        public string AgentSearch { get; set; }
        public bool isMigrated { get; set; }

        public int CreatedbyUser { get; set; }


        public IPagedList<AgencyModel> AgencyList { get; set; }

        public string domainname { get; set; }

        public string UrlLinktoSendLocal { get; set; }
        public string UrlLinktoSendLive { get; set; }

    }
}