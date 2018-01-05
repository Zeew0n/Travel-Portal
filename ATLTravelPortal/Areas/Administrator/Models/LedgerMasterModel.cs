using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;
namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class LedgerMasterModel
    {
        public int LedgerId { get; set; }
        public int SNO { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<SelectListItem> ProductNameList { get; set; }

        public int AccGroupId { get; set; }
        public string AccGroupName { get; set; }
        public IEnumerable<SelectListItem> AccGroupNameList { get; set; }

        public int AccSubGroupId { get; set; }
        public string AccSubGroupName { get; set; }
        public IEnumerable<SelectListItem> AccSubGroupNameList { get; set; }

        public int AccTypeId { get; set; }
        public string AccTypeName { get; set; }
        public IEnumerable<SelectListItem> AccTypeNameList { get; set; }


        public string ddlAirline { get; set; }
        public int? ddlAirLines { get; set; }
        public IEnumerable<SelectListItem> ddlAirLinesList { get; set; }

        public string MapTable { get; set; }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public IEnumerable<SelectListItem> DisplayMemberList { get; set; }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }

        public int AgentId { get; set; }
        public string AgentName { get; set; }

        public int BSPId { get; set; }
        public string BSPName { get; set; }

        public int Consolidator { get; set; }
        public string ConsolidatorName { get; set; }


        public string LedgerName { get; set; }

        public int LedgerAccTypeId { get; set; }
        public string LedgerAccTypeName { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        public IPagedList<LedgerMasterModel> LedgerMasterList { get; set; }

    }
}