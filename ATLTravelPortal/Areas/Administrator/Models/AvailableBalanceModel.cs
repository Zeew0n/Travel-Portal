using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AvailableBalanceModel
    {
        public AvailableBalanceModel()
        {
            CurrencyList = new List<CurrencyDetail>();
        }
        //[DisplayName("Agent Name")]
        //public int AgentId { get; set; }
        //public IEnumerable<SelectListItem> AgentList { get; set; }

        public string AgentName { get; set; }

        [DisplayName("Remaining Balance")]
        public double RemainingBalance { get; set; }

        [DisplayName("Credit Limit")]
        public double CreditLimit { get; set; }


        [DisplayName("Currency")]
        public List<CurrencyDetail> CurrencyList { get; set; }

        public IEnumerable<AvailableBalanceModel> AvailableBalanceList { get; set; }


    }


    public class CurrencyDetail
    {
        public string CurrenyCode { get; set; }
        public string Amount { get; set; }
        public string CreditLimit { get; set; }
        public string LedgerAmount { get; set; }
             

    }
}
