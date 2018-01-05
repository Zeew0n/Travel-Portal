using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class RolePrivilageModel
    {
        public Guid RoleTypeId { get; set; }

        public string RoleName { get; set; }



        public int PrivilegeId { get; set; }


        public string hdfControllerName { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public IEnumerable<SelectListItem> ControllerNameList { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int ActionTypeId { get; set; }
        public string ActionTypeName { get; set; }
        public string ActionName { get; set; }
        public IEnumerable<SelectListItem> ActionTypeList { get; set; }



        public string ControllerLabel { get; set; }



        public string GroupName { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<SelectListItem> GroupNameList { get; set; }

        public bool ControllerIdChecked { get; set; }

        public bool PrivilageIdChecked { get; set; }

        public int ControllerGroupId { get; set; }

        // [DisplayFormat(ConvertEmptyStringToNull = false)]
        //public int ControllerGroupSequenceNo { get; set; }

        public string ControllerGroupName { get; set; }

        public IEnumerable<RolePrivilageModel> PriviledgeSetupList { get; set; }
        public IEnumerable<RolePrivilageModel> ControlleractionMappingList { get; set; }

        public bool isExist { get; set; }

        // public IEnumerable<SelectListItem> SequenceNoList { get; set; }


        public int SeqNumber { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SubProductId { get; set; }
        public string SubProductName { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }

        public IEnumerable<SelectListItem> SubProductList { get; set; }

        public List<SelectListItem> RoleList { get; set; }
        public List<RolePrivilageModel> Modellist { get; set; }
    }
}