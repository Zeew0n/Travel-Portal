using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Pagination;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelBookingCancelModel
    {
        public long BookingCancelId { get; set; }
        public long BookingRecordId { get; set; }
        public string GDSBookingId { get; set; }
        [Required(ErrorMessage="*")]
        public string Remark { get; set; }

        public int SNo { get; set; }
        
        public string CancelRequestId { get; set; }
        [DisplayName("Refundable Amount")]
        public decimal RefundableAmount { get; set; }
        [DisplayName("Cancellation Charge")]
        public decimal CancellationCharge { get; set; }
        [DisplayName("Cancel Status")]
        public string CancelStatus { get; set; }
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
        public bool IsProcessed { get; set; }

        public HotelBookingDetailModel BookingDetail { get; set; }
        public IPagedList<HotelBookingCancelModel> TabularList { get; set; }
        public HotelMessageModel Message { get; set; }
    }
}