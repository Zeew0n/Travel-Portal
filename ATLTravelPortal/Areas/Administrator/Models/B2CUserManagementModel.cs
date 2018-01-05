using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TravelPortalEntity;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class B2CUserManagementModel
    {
        //[Required(ErrorMessage = "*")]
       
        [DisplayName("Full Name")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "Must contain letter.")]
        public string FullName { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Mobile")]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
        public string Mobile { get; set; }

        [DisplayName("Phone")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Must contain digit.")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string EmailUserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public DateTime? CreatedDate { get; set; }

        public IPagedList<B2CUserManagementModel> ListB2CUsers { get; set; }

        public UsersDetails UserInfo { get; set; }
        public aspnet_Users GetUserName { get; set; }
        public aspnet_Membership GetEmail { get; set; }

        public List<B2CUserManagementModel> UserInfoList { get; set; }
        public List<B2CUserManagementModel> GetEmailList { get; set; }


        //LockUnlock User Variables
        public Guid UserId { get; set; }
        public string AgentName { get; set; }
        public string UserName { get; set; }

        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        public string Email { get; set; }

        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }

    }
}