using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class RolePrivilageModel
    {
        public Guid RoleTypeId { get; set; }

        public string RoleName { get; set; }
       

        public int PrivilegeId { get; set; }

        public int ControllerId { get; set; }
       
        public string ControllerName { get; set; }

        public string ControllerLabel { get; set; }

        public string ActionTypeName { get; set; }
       
        public bool ControllerIdChecked { get; set; }

        public bool PrivilageIdChecked { get; set; }

        public List<RolePrivilageModel> Modellist { get; set; }
    }
}