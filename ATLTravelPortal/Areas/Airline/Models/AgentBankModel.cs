using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentBankModel
    {
        public int AgentBankId { get; set; }
        public int AgentId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int BankBranchId { get; set; }

        public string BankBranchName { get; set; }


        public int BankAccountTypeId { get; set; }
        public string BankAccountTypeName { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        public bool IsDefault { get; set; }
    }
}




