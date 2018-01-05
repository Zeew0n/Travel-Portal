using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers;


namespace  ATLTravelPortal.Areas.Airline.Models
{
    public class AirLineLedgerTransactionsummaryModel
    {

        public long TranId { get; set; }

        [DisplayName("Agent")]
        public int AgentId { get; set; }

        [DisplayName("Apply Date Filter")]
        public bool AppliedDate { get; set; }

        [DisplayName("From Date")]
        public DateTime?FromDate { get; set; }

        [DisplayName("To Date")]
        public DateTime?ToDate { get; set; }

        
        [DisplayName("Tran Date")]
        public DateTime? TranDate { get; set; }


        [DisplayName("Narration1")]
        public string Narration1 { get; set; }

        [DisplayName("Narration2")]
        public string Narration2 { get; set; }

        [DisplayName("Debit Amount")]
        public decimal? DrAmount { get; set; }

        [DisplayName("Credit Amount")]
        public decimal? CrAmount { get; set; }

        [DisplayName("Dr/cr")]
        public string DrCr { get; set; }

        [DisplayName("Balance")]
        public decimal? Balance { get; set; }

        [DisplayName("PNR")]
        public Int64? PNRGroupId { get; set; }

        [DisplayName("Name")]
        public string TransactionName { get; set; }

        [DisplayName("Reference No#")]
        public string ReferenceNo { get; set; }

        public IEnumerable<AirLineLedgerTransactionsummaryModel> airlineLedgetTranList { get; set; }
    }
}