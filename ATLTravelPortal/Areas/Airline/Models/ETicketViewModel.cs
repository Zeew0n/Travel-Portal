using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class ETicketViewModel
    {
        public string StatusId { get; set; }
        public bool Booked { get; set; }
        public bool Booked_Cancelled { get; set; }
        public bool Booked_Rescheduled { get; set; }
        public string FlightNumber { get; set; }
        public string TerminalNumber { get; set; }

        public DateTime? DepartureDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }

        public DateTime? IssuedDate { get; set; }

        public string TicketNO { get; set; }
        public string BIC { get; set; }
        public long SectorID { get; set; }

        public double Fare { get; set; }

        public int AgentId { get; set; }

        public string AgentName { get; set; }
        public string AgentAddress { get; set; }
        public string AgentContact { get; set; }
        public string AgentIATACode { get; set; }
        public string AgentLogo { get; set; }
        public string AgentDistrict { get; set; }
        public string AgentZone { get; set; }
        public string AgentNativeCountry { get; set; }
        public int ServiceProviderId { get; set; }

        public string AirLineName { get; set; }
        public string AirLineReferenceNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public long? PNRId { get; set; }
        public string PNRContactNumber { get; set; }
        public string GDSReferenceNumber { get; set; }
        public string OperatingAirline { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public string MobileNumber { get; set; }
        
        public string PassengerType { get; set; }
        public string Email { get; set; }
        public string PassengerName { get; set; }
        public string PNRName { get; set; }
        public string PNREmailAdd { get; set; }
        public int NoOfPax { get; set; }

        public bool ShowFareOnETicket { get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("Email:")]
        public string txtEmailTo { get; set; }

        public double Tax { get; set; }
        public double TotalTax { get; set; }
        public double ServiceCharge { get; set; }

        //public IQueryable<ETicketViewModel> PassengerList { get; set; }
        //public IQueryable<ETicketViewModel> PNRSegmentList { get; set; }

        public List<ETicketViewModel> PNRSectorList { get; set; }
        public List<ETicketViewModel> PassengerList { get; set; }
        public List<ETicketViewModel> PNRSegmentList { get; set; }
        public List<ETicketViewModel> AirlineVendorLocators { get; set; }

        public long PassengerId { get; set; }
        
        public string Currency { get; set; }
        public string FrequentFlyerNo { get; set; }
        public int? FrequentFlyerAirlineId { get; set; }
        public int PassengerTypeId { get; set; }
        public string SSR { get; set; }
        public long SegmentID { get; set; }
        public int AirLineId { get; set; }
        public string FIC { get; set; }
        public string StartTerminalNumber { get; set; }
        public string EndTerminalNumber { get; set; }
        public DateTime? NVB { get; set; }
        public DateTime? NVA { get; set; }
        public string FlightDuration { get; set; }
        public bool ShowAgentLogoOnETicket { get; set; }


        //////////////////////////Indian Lcc Property////////////////////////////
        public long? MasterPNRId { get; set; }
        public string PassengerAddress { get; set; }
        public List<ETicketViewModel> PNRList { get; set; }
        public long? BookingId { get; set; }
        public string PlatingAirLineName { get; set; }
        public string VendorRemark { get; set; }
        public bool ShowServiceChargeOnETicket { get; set; }
        public bool isProduction { get; set; }
        public string FlightKey { get; set; }
        public string Baggage { get; set; }
        public string LccNVB { get; set; }
        public string LccNVA { get; set; }



        ////////////////////////////////////////////////////////////////////////


        public double Discount { get; set; }
        public double Cashback { get; set; }
        public double BranchDeal { get; set; }
        public double DistributorDeal { get; set; }
        public double TotalCalculatedDiscount { get; set; }
        public double TotalTranFee { get; set; }

        public bool IsBranchByPassDeal { get; set; }
        public bool IsDistributorByPassDeal { get; set; }
    }
}