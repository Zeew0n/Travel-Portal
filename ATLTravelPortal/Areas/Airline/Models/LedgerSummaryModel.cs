using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class LedgerSummaryModel
    {
        public int? AgentId { get; set; }
        public int? ProductId { get; set; }
        public string AgentName { get; set; }
        public string ProductName { get; set; }
        public string Mode { get; set; }
        public string ModeName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public int Agentid { get; set; }
        public decimal? Balance
        {
            get;
            set;
        }
        public IEnumerable<LedgerSummaryModel> LedgerSummaryList { get; set; }
    }
}