using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class ApplicationSettingViewModel
    {
        public int AppSettingId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        public int HFProductId { get; set; }

        public String ProductName { get; set; }

        [DisplayName("Enable Password Retrieval")]
        public bool? EnablePasswordRetrieval { get; set; }

        [DisplayName("Enable Password Reset")]
        public bool? EnablePasswordReset { get; set; }

        [DisplayName("Requires Question And Answer")]
        public bool? RequiresQuestionAndAnswer { get; set; }

        [DisplayName("Requires Unique Email")]
        public bool? RequiresUniqueEmail { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Max Invalid Password Attempts")]
        public int? MaxInvalidPasswordAttempts { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Min Required Password Length")]
        public int? MinRequiredPasswordLength { get; set; }

        // [Required(ErrorMessage = "*")]
        [DisplayName("Min Required Non-alphanumeric Characters")]
        public int? MinRequiredNonalphanumericCharacters { get; set; }

        //[Required(ErrorMessage = "*")]
        [DisplayName("Password Attempt Window")]
        public int? PasswordAttemptWindow { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("App Date Format")]
        public string AppDateFormat { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("SMTP Server")]
        public string SMTPServer { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("SMTP Port")]
        public int? SMTPPort { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("SMTP Username")]
        public string SMTPUsername { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("SMTP Password")]
        [DataType(DataType.Password)]
        public string SMTPPassword { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Enable Expire Password When User Not Login From Days")]
        public int? EnableExpirePasswordWhenUserNotLoginFromDays { get; set; }


        [DisplayName("Enable Auto Expire Password")]
        public bool? EnableAutoExpirePassword { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Auto Password Expiry In Days")]
        public int? AutoPasswordExpiryInDays { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Show Password Expire Notification Before Days")]
        public int? ShowPassowrdExpireNotificationBeforeDays { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Pagination")]
        public int Paggination { get; set; }
        public bool Flag { get; set; }
        public IEnumerable<SelectListItem> ddlProductList { get; set; }

        //public ApplicationSettingViewModel AppSetting { get; set; }
    }
}