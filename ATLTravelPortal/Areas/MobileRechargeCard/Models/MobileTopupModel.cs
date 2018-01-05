using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Models
{
    public class MobileTopupModel
    {
        [DisplayName("Agent")]
        public int? AgentId { get; set; }
        public string AgentName { get; set; }
        
        [DisplayName("Service Provider")]
        public int ServiceProviderId { get; set; }
        public string ServiceProvierName { get; set; }


        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

  
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public double SalesPrice { get; set; }
        [DisplayName("Is Success")]
        public bool? IsSucces { get; set; }
        public string StatusMessage { get; set; }
        public DateTime SalesDate { get; set; }


        public IEnumerable<SelectListItem> Agents { get; set; }
        public IEnumerable<SelectListItem> ServiceProviders { get; set; }
        public IEnumerable<SelectListItem> SuccessFlags { get; set; }

        public IEnumerable<MobileTopupModel> MobileTopupModelList { get; set; }

        //Export
        public string ExportTypeExcel { get; set; }
        public string ExportTypeWord { get; set; }
        public string ExportTypeCSV { get; set; }
        public string ExportTypePdf { get; set; }
    }
}