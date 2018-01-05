using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers.Pagination;


namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentCLApprovedModel
    {
        #region Filter parameters
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DisplayName("User")]
        public int? UserID { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("To")]
        public DateTime ToDate { get; set; }

        #endregion

        public string BranchOfficeName { get; set; }
        [DisplayName("BranchOffice")]
        public int? BranchOfficeId { get; set; }
        public string DistributorName { get; set; }
        [DisplayName("Distributor")]
        public int? DistributorID { get; set; }
        public string AgentName { get; set; }
        public string AgentCode { get; set; }
        [DisplayName("Agent")]
        public int? AgentId { get; set; }

        public string Currency { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public DateTime? Requestion { get; set; }
        public DateTime? CheckerDate { get; set; }
        public string CheckedBy { get; set; }
        public string Comments { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? ExpireOn { get; set; }

        public Int64 VoucherNo { get; set; }

        public IEnumerable<SelectListItem> UsersOption { get; set; }
        public IEnumerable<SelectListItem> BranchOfficeOption { get; set; }
        public IEnumerable<SelectListItem> DistributorOption { get; set; }
        public IEnumerable<SelectListItem> AgentOption { get; set; }

        //Export
        public string ExportTypeExcel { get; set; }
        public string ExportTypeWord { get; set; }
        public string ExportTypeCSV { get; set; }
        public string ExportTypePdf { get; set; }
        public IEnumerable<AgentCLApprovedModel> AgentCLApprovedListExport { get; set; }
        public IPagedList<AgentCLApprovedModel> AgentReceiptList { get; set; }
    }
}