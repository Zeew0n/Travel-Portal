using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class WaitListRequestModel
    {
        [Required]
        [DisplayName("Agent")]
        public string AgentName { get; set; }

        [DisplayName("Airline Type")]
        public string AirlineTypeName { get; set; }

        public long PNRId { get; set; }
        public string GDSRefrenceNumber { get; set; }
        public string PassengerName { get; set; }
        public string Sector { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; }
        public string TicketStatusName { get; set; }
      
        public IEnumerable<WaitListRequestModel> WaitListRequestList { get; set; }

        //Export
        public string ExportTypeExcel { get; set; }
        public string ExportTypeWord { get; set; }
        public string ExportTypeCSV { get; set; }
        public string ExportTypePdf { get; set; }
        public IEnumerable<WaitListRequestModel> WaitListRequestListExport { get; set; }

    }
}