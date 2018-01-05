using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class BookedTicketModel
    {
        public DateTime BookedDate { get; set; }
        public long PNRId { get; set; }
        public string PNR { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public int DepartureCityId { get; set; }
        public string ArrivalCity { get; set; }
        public int ArrivalCityId { get; set; }
        public DateTime FlightDate { get; set; }
        public decimal QuotedFare { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public bool ReservationStatus { get; set; }
        public string StatusName { get; set; }
        public string TravelDetails { get; set; }
        public string AgentDetails { get; set; }
        public string PassengerDetails { get; set; }
        public decimal Fare { get; set; }
        public decimal Tax { get; set; }
        public string FullName { get; set; }
        public decimal TotalFare { get; set; }
        public string AgentName { get; set; }
        public DateTime FlightTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string CabinName { get; set; }
        public string AirlineName { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PassengerType { get; set; }
        public string TicketNumber { get; set; }
        public string Status { get; set; }
        
        //public IEnumerable<BookedTicketModel> BookedTickeList { get; set; }
        public List<BookedTicketModel> BookedTicketList { get; set; }

    }
    public class PNR
    {
        public long PNRId { get; set; }
        public string[] Passengers { get; set; }
        public string[] Segments { get; set; }
    }
}