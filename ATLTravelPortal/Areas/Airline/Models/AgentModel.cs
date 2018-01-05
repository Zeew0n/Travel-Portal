using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;




namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentModel
    {
        public int AgentId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Agent")]
        public String AgentName { get; set; }

        
        [Required(ErrorMessage = "*")]
        [DisplayName("Adrress")]
        public String Address { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Phone No")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Agent Email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        public String Email { get; set; }

        //[Required(ErrorMessage = "*")]
        //[RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
        public String FaxNo { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Pan No")]
        public String PanNo { get; set; }

        [DisplayName("Web Address")]
        public String Web { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Credit Limit")]
        [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public decimal CreditLimit { get; set; }

        public int ZoneId { get; set; }
       
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int NativeCountryId { get; set; }

        public String NativeCountry { get; set; }

        public int AgentStatusid { get; set; }

        public bool isIATAAgent { get; set; }

        public String AgentCode { get; set; }

        public String AgentLogo { get; set; }

        public bool Unlimiteduser { get; set; }

        public int MaxNumberOfAgentUser { get; set; }

        [Required(ErrorMessage = "*")]
      
        public int AgentTypeId { get; set; }

        [Required(ErrorMessage = "*")]
      
        public int AgentClassId { get; set; }
     

        public int? AirlineGroupId { get; set; }
        public string AirlineGroupName { get; set; }

        public bool isApplyMarkup { get; set; }

        public decimal MaxMarkupFare { get; set; }

        public decimal MinMarkupFare { get; set; }

      //  [Required(ErrorMessage = "*")]
     //   [RegularExpression("[+]?[0-9]*\\.?[0-9]*", ErrorMessage = " Value must be a non-negative number.")]
        public decimal? TotalMarkup { get; set; }

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
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        public String EmailId { get; set; }

         //[Required(ErrorMessage = "*")]
         //[DisplayName("User Address")]
         public String Address1 { get; set; }

        //[Required(ErrorMessage = "*")]
        //[DisplayName("Mobile No")]
        //[RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
         public String MobileNo { get; set; }
        
        
        // [Required(ErrorMessage = "*")]
        //[DisplayName("User Phone No")]
        //[RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
        public String PhoneNo { get; set; }

     //    [Required(ErrorMessage = "*")]
     //    [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int RoleId { get; set; }

        public string AgentRole { get; set; }

        /// <summary>
        ///  Model for Agent Bank Information
        /// </summary>
       
        public int BankId { get; set; }

       
        public int BankBranchId { get; set; }

       
        public int BankAccountTypeId { get; set; }

     
        public string AccountName { get; set; }

         public string AccountNumber { get; set; }

         public bool IsDefault { get; set; }

      
        
        ////// Additional info

         public int CreatedBy { get; set; }
         public DateTime CreatedDate { get; set; } 
         public int UpdatedBy { get; set; }
         public DateTime UpdatedDate { get; set; }

         public List<AgentBanks> AgentBankList { get; set; }
         public List<AgentSettingsModel> agentsettinglist { get; set; }
         public List<AgentSettingsModel> Activeagentsettinglist { get; set; }
    }
}