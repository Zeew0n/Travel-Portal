using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace  ATLTravelPortal.Areas.Airline.Models
{
    public class AdminUserManagementModel
    {
        public class CreateAdminAspUser
        {
             [Required(ErrorMessage = "*")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "*")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "*")]
            [DataType(DataType.Password)]
           // [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
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

            public int CreatedBy { get; set; }

        }
    }
}