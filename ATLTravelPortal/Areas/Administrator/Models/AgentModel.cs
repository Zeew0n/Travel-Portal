using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentModel
    {
         public int AgentId { get; set; }
         public HttpPostedFileBase AgentLogoFile { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("Agent")]
        public String AgentName { get; set; }

        
        [Required(ErrorMessage = "*")]
        [DisplayName("Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Phone No")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = "Only digit")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Agent Email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        public String Email { get; set; }

        public String FaxNo { get; set; }

        [Required]
        [DisplayName("Pan No")]
        public String PanNo { get; set; }

        [DisplayName("Web Address")]
        public String Web { get; set; }

      
        [DisplayName("Credit Limit")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public decimal CreditLimit { get; set; }

        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
       
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int NativeCountryId { get; set; }
        public string AgentCountryName { get; set; }
        public String NativeCountry { get; set; }


        public int AgentStatusid { get; set; }

        public bool isIATAAgent { get; set; }

        public String AgentCode { get; set; }

        public String AgentLogo { get; set; }

        public bool Unlimiteduser { get; set; }

        public int MaxNumberOfAgentUser { get; set; }


        public int AgentTypeId { get; set; }
        public string AgentTypeName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int AgentClassId { get; set; }

        public string AgentClassName { get; set; }

        public int? AirlineGroupId { get; set; }
        public string AirlineGroupName { get; set; }
        public List<SelectListItem> AirlineGroupList { get; set; }


        public int? TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public List<SelectListItem> TimeZoneList { get; set; }


     

        /// <summary>
        /// ///////////User Information Model
        /// </summary>
        [Required(ErrorMessage = "*")]
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
        public String ConfirmPassword { get; set; }

         [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\b([,;]\s?)?)*$", ErrorMessage = "Not a valid Email")]
        public String EmailId { get; set; }

      
         public String Address1 { get; set; }

         [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = "Only digit")]
         public String MobileNo { get; set; }
        
        
       
        public String PhoneNo { get; set; }

         [Required(ErrorMessage = "*")]
         [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int RoleId { get; set; }

        public string AgentRole { get; set; }


        public int BankId { get; set; }
        public int BankBranchId { get; set; }
        public int BankAccountTypeId { get; set; }
        /// <summary>
        /// /////////////////////////////////////////////
        /// </summary>
        public string BankTypeId { get; set; }
        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
     
        public string AccountName { get; set; }

         public string AccountNumber { get; set; }

         public bool IsDefault { get; set; }

      
        ///// Deal model //
         public int AgentDealId { get; set; }
         public string AgentDealName { get; set; }
         public int MasterDealIdOfAirlines { get; set; }
         public int MasterDealIdOfHotel { get; set; }
         public string MasterDealName { get; set; }
         public IEnumerable<SelectListItem> MasterDealNameListOfAirlines { get; set; }
         public IEnumerable<SelectListItem> MasterDealNameListOfHotels { get; set; }
        ////// Additional info

         public int CreatedBy { get; set; }
         public DateTime CreatedDate { get; set; } 
         public int UpdatedBy { get; set; }
         public DateTime UpdatedDate { get; set; }

         public List<string> agentIPList { get; set; }
         public List<string>  agentbankDetaillist { get; set; }

         public List<AgentBanks> AgentBankList { get; set; }
         public List<AgentSettingsModel> agentsettinglist { get; set; }
         public List<string> AgentSettingDetailList { get; set; }
         public List<AgentSettingsModel> Activeagentsettinglist { get; set; }
         public List<Countries> Countrylist { get; set; }
         public List<Status> Status { get; set; }
         public List<AirlineGroups> AirlineGroup { get; set; }
         public List<AgentTypes> AgentTypes { get; set; }
         public List<Zones> AgentZone { get; set; }
         public List<Districts> AgentDistrict { get; set; }
         public List<BankAccountTypes> BankAccountTypes { get; set; }
         public List<TimeZones> TimeZones { get; set; }
        

         public List<AgentProductViewModel> AgentProductList { get; set; }
         public List<RoleBasedRoleModel> ProductBaseRoleList { get; set; }

         public int CreatedbyUser { get; set; }
         public string AgentSearch { get; set; }
         public List<Agents> AgentSearchList { get; set; }
         public int ddlStatus { get; set; }

         public int BranchOfficeId { get; set; }
         public int DistributorId { get; set; }

         public string RedirectedFrom { get; set; }

         [Required]
         [DisplayName("Reffered By")]
         public int? RefferedBy { get; set; }
         public string ReferredByName { get; set; }
         public IEnumerable<SelectListItem> ReferredByList { get; set; }


         [DisplayName("ME's")]
         public int? MEsId { get; set; }
         public string MEsName { get; set; }
         public IEnumerable<SelectListItem> MEsNameList { get; set; }

    }
    public class Status
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}