using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers.Pagination;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class SalesReportModel
    {
        public int? LedgerId { get; set; }
        [Required]
        public string ReportOf { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public int? CurrencyId { get; set; }
        [Required]
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }
        [Required]
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        public int ReportType { get; set;}
        public double? Airline { get; set; }
        public double? Hotel { get; set; }
        public double? Mobile { get; set; }
        public double? Bus { get; set; }
        public double? Train { get; set; }
        public double? Total { get; set; }
        public string AirlineName { get; set; }
        public string Name { get; set; }
        public string TicketNumber { get; set; }
        public double? Amount { get; set; }
        public string Sector { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string ServiceProviderName { get; set; }
        public string IssuedFrom { get; set; }
        public long MpnrId { get; set; }

        public string CityName { get; set;}
        public string CountryName { get; set;}
        public string HotelName { get; set;}
        public int NOofNight { get; set;}
        public int NoofRoom { get; set;}

        public DateTime? CreatedDate { get; set;}
        public string CustomerMobileNo { get; set;}
        public long SalesTranId { get; set;}
        public string ServiceType { get; set;}

        public int NoOfSeat { get; set;}
        public string PassengerName { get; set;}
        public string TrainName { get; set;}
        public string TrainNo { get; set;}
        public long TrainPNRId { get; set;}
        public double? TotalAmount { get; set;}
        public string BusMasterName { get; set;}
        public long BusPNRId { get; set;}


        public List<SalesReportModel> InformationList { get; set; }
        public IEnumerable<SelectListItem> CurrencyOption { get; set; }
        public IEnumerable<SelectListItem> ReportsOfOption { get; set; }
       
        public string ReportHeading { get; set; }
    }
}