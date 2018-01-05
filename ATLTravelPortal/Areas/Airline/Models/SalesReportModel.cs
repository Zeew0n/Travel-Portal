using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class SalesReportModel
    {    
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DisplayName("Agent")]
        public int? AgentId { get; set; }
        public string AgentCode { get; set; }

        public string AgentName { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [Required]
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        [DisplayName("AirlineID")]
        public int AirlineId { get; set; }

        [DisplayName("Code")]
        public string AirlineCode { get; set; }

        [DisplayName("Name")]
        public string AirlineName { get; set; }

        [DisplayName("Cash")]
        public double Cash { get; set; }

        [DisplayName("Tax")]
        public decimal Tax { get; set; }

        [DisplayName("Commission")]
        public decimal Commission { get; set; }


        [DisplayName("Payable")]
        public decimal Payable { get; set; }

        public string serviceProviderName { get; set; }
        public string issueFrom { get; set; }

        public IEnumerable<SalesReportModel> salesReportSummary { get; set; }
      
        private int AirlineTypes_id = 1;
        [DisplayName("AirLine Types:")]
        public int AirlineTypesId
        {
            get
            {
                return AirlineTypes_id;
            }
            set
            {
                AirlineTypes_id = value;
            }
        }

        public string AirlineTypes { get; set; }
        public IEnumerable<SelectListItem> AirlineTypesList { get; set; }

        private int currency_id = 1;
        [DisplayName("Currrency:")]
        public int? Currency
        {
            get
            {
                return currency_id;
            }
            set
            {
                currency_id = (int)value;
            }
        }

        [DisplayName("Code")]
        public string DetailsCode { get; set; }

        [DisplayName("Name")]
        public string DetailsName { get; set; }

        [DisplayName("Ticket Number")]
        public string TicketNumber { get; set; }

        [DisplayName("Issued date")]
        public DateTime IssuedDate { get; set; }


        [DisplayName("Cash")]
        public decimal DetailsCash { get; set; }

        [DisplayName("Credit")]
        public decimal DetailsCredit { get; set; }

        [DisplayName("Commission")]
        public decimal DetailsCommission { get; set; }

        [DisplayName("Tax")]
        public decimal DetailsTax { get; set; }

        [DisplayName("Payable")]
        public decimal DetailsPayable { get; set; }

        public bool showtable { get; set; }

        public IEnumerable<SalesReportModel> salesReportDetails { get; set; }

        public decimal SumAgentBillingStatement_Cash { get; set; }
        public decimal SumAgentBillingStatement_Tax { get; set; }
        public decimal SumAgentBillingStatement_Commission { get; set; }
        public decimal SumAgentBillingStatement_Payable { get; set; }


        public decimal SumAgentBillingStatementDetails_Cash { get; set; }
        public decimal SumAgentBillingStatementDetails_Tax { get; set; }
        public decimal SumAgentBillingStatementDetails_Commission { get; set; }
        public decimal SumAgentBillingStatementDetails_Payable { get; set; }

        public string BranchOfficeName { get; set; }
        public string DistributorName { get; set; }
    }
}