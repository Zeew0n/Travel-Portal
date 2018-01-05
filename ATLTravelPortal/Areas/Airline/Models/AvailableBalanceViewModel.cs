using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AvailableBalanceViewModel
    {        
        public double? CreditLimitNPR { get; set; }
        public double? CurrentBalanceNPR { get; set; }
        public double? LeadgerBalanceNPR { get; set; }

        public double? CreditLimitUSD { get; set; }
        public double? CurrentBalanceUSD { get; set; }
        public double? LeadgerBalanceUSD { get; set; }

        public double? CreditLimitINR { get; set; }
        public double? CurrentBalanceINR { get; set; }

        public string CurrencyNPR { get; set; }
        public string CurrencyUSD { get; set; }
        public string CurrencyINR { get; set; }
        public bool isLowBalanceNPR { get; set; }
        public bool isLowBalanceUSD { get; set; }
        public bool isLowBalanceINR { get; set; }
    }
}