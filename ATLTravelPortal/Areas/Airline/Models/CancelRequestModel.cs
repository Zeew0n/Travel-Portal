using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class CancelRequestModel
    {
        [DisplayName("Agent")]
        public string AgentName { get; set; }
        public int SNO { get; set; }

        [DisplayName("Type")]
        public string AirlineTypeName { get; set; }
        public int serviceproviderid { get; set; }

        public long? PNRId { get; set; }
        public string GDSRefrenceNumber { get; set; }
        public string PassengerName { get; set; }
        public string Sector { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; }
        public string TicketStatusName { get; set; }
        public int TicketStatusID { get; set; }

        public IPagedList<CancelRequestModel> CancelRequestList { get; set; }
        
        [Required]
        [DisplayName("Airhant Cancellation Charge")]
        public double ArihantCancellationCharge { get; set; }

        public string Remarks { get; set; }


        public int TransactionLogId { get; set; }
        public int TransactionType { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public List<CancelRequestModel> CommentList { get; set; }

    }
}