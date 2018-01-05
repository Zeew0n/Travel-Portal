using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class TicketStatusHistoryModel
    {
        [Required]
        public DateTime FromDate { get; set;}
        [Required]
        public DateTime ToDate { get; set;}

        public long MPNRId { get; set;}
        public string Branch { get; set;}
        public string Distributor { get; set;}
        public string Agent { get; set;}

        public string Airline { get; set;}
        public string Sector { get; set;}
        public string Status { get; set;}
        public string ServiceProviderName { get; set; }

        public IEnumerable<TicketStatusHistoryModel> TicketStatusHistoryList { get; set;}
        
    }
}