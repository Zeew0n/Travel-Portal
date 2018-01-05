using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class GDSHitsModel
    {
        [DisplayName("Agent Name")]
        public string AgentName { get; set; }
        public int? Agentid { get; set; }

        [HiddenInput]
        public int? hdfAgentId { get; set; }
       

        public string ServiceProvider { get; set; }

        [DisplayName("TransactionName")]
        public string TransactionName { get; set; }

        [DisplayName("GDSHitCount")]
        public int GDSHitCount { get; set; }

        [DisplayName("RequestedDate")]
        public string RequestedDate { get; set; }

        
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }
       
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public IEnumerable<GDSHitsModel> GDSHitLists { get; set; }
    }

    public class TransactionHitsExportModel
    {
        public int GDSHitsCount { get; set; }
        public string TransactionName { get; set; }

       

    }
}