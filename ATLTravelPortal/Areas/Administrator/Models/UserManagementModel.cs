using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Profile;
using System.ComponentModel.DataAnnotations;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class UserManagementModel
    {
        public class CreateAspUser
        {
            public Guid User { get; set; }
            [Required(ErrorMessage = "*")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "*")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "*")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "*")]
            [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "*")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "*")]
            public string Address { get; set; }

            [Required(ErrorMessage = "*")]
            [RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
            public string MobileNo { get; set; }

            //[Required(ErrorMessage = "*")]
            //[RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
            public string PhoneNo { get; set; }

            public int CreatedBy { get; set; }
            public string roleName { get; set; }

            [Required(ErrorMessage = "*")]
            public int AgentId { get; set; }
            public IEnumerable<SelectListItem> AgentList { get; set; }

        }
        public class MembershipUserAndRolesViewData
        {
            public bool RolesEnabled { get; set; }
            public bool RequiresQuestionAndAnswer { get; set; }
            public MembershipUser User { get; set; }
            public List<string> AllRoles { get; set; }
            public List<string> UsersRoles { get; set; }
            public ProfileInfoCollection UserProfiles { get; set; }
            public UsersDetails UserDetails { get; set; }

        }
        public class LockApprovedUserModel
        {
            public Guid UserId { get; set; }
            public int DDLOptionId { get; set; }
            public string AgentName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public bool IsApproved { get; set; }
            public bool IsLockedOut { get; set; }

        }
    }
}