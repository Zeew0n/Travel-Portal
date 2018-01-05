using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AdminUserManagementModel
    {
        [Match("Password", "ConfirmPassword", ErrorMessage = "Password must match")]
        public class CreateAdminAspUser
        {
            public CreateAdminAspUser()
            {
                GetUserRolesList = new List<CreateAdminAspUser>();
            }
            public List<AgentProductViewModel> AgentProductList { get; set; }

            public string AgentRole { get; set; }
            public int UserAppId { get; set; }

            public Guid UserId { get; set; }
            //public Guid UserId { get; set; }
            [Required(ErrorMessage = "*")]
            public int ProductId { get; set; }


            // [Required(ErrorMessage = "*")]
            public Guid RoleId { get; set; }
           

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

            // [Required(ErrorMessage = "*")]
            public string Address { get; set; }

            // [Required(ErrorMessage = "*")]
            [RegularExpression("^[0-9]{10}", ErrorMessage = "Only 10 digit number")]
            public string MobileNo { get; set; }

            public string PhoneNo { get; set; }

            [Required(ErrorMessage = "*")]
            public string RoleName { get; set; }

            public bool chkProductId { get; set; }

            public int CreatedBy { get; set; }

            public UsersDetails UserInfo { get; set; }
            public aspnet_Users GetUserName { get; set; }
            public aspnet_Membership GetEmail { get; set; }

            public List<RoleBasedRoleModel> AdminProductList { get; set; }
            public List<RoleBasedRoleModel> ProductBaseRoleList { get; set; }

            public IEnumerable<SelectListItem> RoleList { get; set; }

            public string RolesName { get; set; }
            public string RolesOn { get; set; }
            public List<CreateAdminAspUser> GetUserRolesList { get; set; }

            public IEnumerable<vw_aspnet_MembershipUsers> getUserRegistrationlist { get; set; }

            public bool IsSalesMarketingUser { get; set; }

        }

       
       
    }
    public static class ModelUserProductExtension
    {
        public static bool IsActiveUserProduct(int ProductId, List<RoleBasedRoleModel> ProductIdHelper)
        {
            bool flag = false;
            List<int> ProductIds = ProductIdHelper.Select(ii => ii.ProductId).ToList();
            foreach (int aPid in ProductIds)
            {
                if (ProductId == aPid)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}