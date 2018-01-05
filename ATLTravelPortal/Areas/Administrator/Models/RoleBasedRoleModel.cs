using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class RoleBasedRoleModel
    {
        public Guid RoleId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string RoleName { get; set; }
        public string SubProductName { get; set; }

        public List<AgentProductViewModel> AgentProductList { get; set; }

    }
}