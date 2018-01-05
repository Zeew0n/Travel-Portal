using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class IssueDomesticTicketsModel
    {
        [HiddenInput]
        public Int64? MPNRId { get; set; }
        [DisplayName("Upload eTicket")]
        public HttpPostedFileBase eTicket { get; set; }
        public Int64 AgentId { get; set; }
        public string AgentName { get; set; }
        public string Phone { get; set; }
        [HiddenInput]
        public bool DoOnlyUploadETicket { get; set; }
        public IList<DomesticPnrs> DomesticPnrsList { get; set; }
    }

    public class DomesticPnrs
    {
        [HiddenInput]
        public Int64 PnrId { get; set; }

        [DisplayName("PNR Number")]
        [Required(ErrorMessage = " ")]
        public string PNR { get; set; }


        public IList<DomesticPassenger> PassengersList { get; set; }
        public IList<DomesticItinary> ItinaryList { get; set; }
    }


    public class DomesticPassenger
    {
        [HiddenInput]
        public Int64 PassengerId { get; set; }
        public string Name { get; set; }
        public string PassengerType { get; set; }
        public string EmailAddress { get; set; }
        public bool isDeleted { get; set; }
        public IList<DomesticFare> FareList { get; set; }
    }

    public class DomesticFare
    {
        [HiddenInput]
        public Int64 TicketId { get; set; }
        [Required(ErrorMessage = " ")]
        public string TicketNumber { get; set; }
        public double AdditionalTxnFee { get; set; }
        public double AirlineTransFee { get; set; }

        public double BaseFare { get; set; }
        public double Tax { get; set; }
        public double OtherCharges { get; set; }
        public double ServiceTax { get; set; }
        [Required(ErrorMessage = " ")]
        public double MarkupAmount { get; set; }
        [Required(ErrorMessage = " ")]
        public double CommissionAmount { get; set; }
        [Required(ErrorMessage = " ")]
        public double DiscountAmount { get; set; }
        public double ServiceCharge { get; set; }
        public double FSC { get; set; }

        public double SellingAdditionalTxnFee { get; set; }
        public double SellingAirlineTransFee { get; set; }
        [Required(ErrorMessage = " ")]
        public double SellingBaseFare { get; set; }
        [Required(ErrorMessage = " ")]
        public double SellingTax { get; set; }
        public double SellingOtherCharges { get; set; }
        public double SellingServiceTax { get; set; }
        [Required(ErrorMessage = " ")]
        public double SellingFSC { get; set; }

        public string Currency { get; set; }
        public bool isDeleted { get; set; }
    }

    public class DomesticItinary
    {
        [HiddenInput]
        public Int64 SegmentId { get; set; }

        [HiddenInput]
        public int AirlineId { get; set; }
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }
        public IEnumerable<SelectListItem> AirlineNameList { get; set; }

        public Int64 DepartureCityId { get; set; }
        public string From { get; set; }

        public Int64 ArrivalCityId { get; set; }
        public string To { get; set; }

        [Required(ErrorMessage = " ")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        public TimeSpan DepartureTime { get; set; }
        [Required(ErrorMessage = " ")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        [Required(ErrorMessage = " ")]
        public string BIC { get; set; }
    }
}
