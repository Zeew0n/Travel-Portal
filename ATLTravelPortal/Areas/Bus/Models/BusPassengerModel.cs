using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusPassengerModel
    {
        [HiddenInput]
        public long BusPassengerId { get; set; }
        public long BusPNRId { get; set; }

        [DisplayName("Passenger Name")]
        [Required(ErrorMessage = "*")]
        public string PassengerName { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        public int TicketStatusId { get; set; }
        [DisplayName("Status")]
        public string StatusName { get; set; }



        public string TicketNumber { get; set; }
        [Required(ErrorMessage = "*")]
        public string SeatNumber { get; set; }
       
        public string PickupPoint { get; set; }
        [Required(ErrorMessage = "*")]
        public double Fare { get; set; }
        public double Markup { get; set; }
        public double TaxAmount { get; set; }
        public double CommissionAmount { get; set; }
        public double DiscountAmount { get; set; }

        public BusMessageModel Message { get; set; }
        public IPagedList<BusPassengerModel> TabularList { get; set; }
    }
}