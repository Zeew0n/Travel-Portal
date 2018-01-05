using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class UserTypeRoleModel
    {
        public Guid RoleId { get; set; }
        public int UserTypeId { get; set; }
        public string RoleName { get; set; }
    }
}