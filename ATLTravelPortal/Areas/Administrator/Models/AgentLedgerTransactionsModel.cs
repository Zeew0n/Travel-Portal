using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentLedgerTransactionsModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

        [DisplayName("Agent")]
        public string AgentName { get; set; }
        public int? AgentId { get; set; }
        public IEnumerable<SelectListItem> AgentList { get; set; }

        private int dis_id = 72;
        [DisplayName("Distributor")]
        //public int DistributorId
        //{
        //    get
        //    {
        //        return dis_id;
        //    }
        //    set
        //    {
        //        dis_id = value;
        //    }
        //}
        public int? DistributorId { get; set; }
        public string DistributorName { get; set; }
        public IEnumerable<SelectListItem> DistributorList { get; set; }

        [DisplayName("Branch Office")]
        public int? BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }
        public IEnumerable<SelectListItem> BranchOfficeList { get; set; }

       

        [DisplayName("Product")]
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }

        public IEnumerable<SelectListItem> Currencies { get; set; }


        private int m_id = 1;
        [DisplayName("Currency")]
        public int CurrencyId
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }


        public Int64 TranID { get; set; }
        public Int64 VoucherNumber { get; set; }
        public string Narration1 { get; set; }
        public decimal? DrAmount { get; set; }
        public decimal? CrAmount { get; set; }
        public string DrCr { get; set; }
        public decimal? Balance { get; set; }
        public Int64 RefrenceNo { get; set; }
        public DateTime? TranDate { get; set; }

        public IEnumerable<AgentLedgerTransactionsModel> LedgerList { get; set; }
        public ATLTravelPortal.Areas.Airline.Models.AvailableBalanceViewModel AvailableBalance { get; set; }
        public IEnumerable<CreditLimitModel> CreditLimitList { get; set; }
    }
}