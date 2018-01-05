using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PNRsDetailsModel
    {
        public PNRsModel pnrmodel { get; set; }
        public IEnumerable<PNRSegmentsModel> pnrsegemnetmodel { get; set; }
        public IEnumerable<PassengersModel> pnrpassengermodel { get; set; }
        public FareModel faremodel { get; set; }

        [DisplayName("PNRId")]
        public Int64 PNRId { get; set; }
        public string AirLineName { get; set; }
        public string AirLineReferenceNumber { get; set; }


        public List<PNRsDetailsModel> AirlineVendorLocators { get; set; }
    }

    public class PNRsModel
    {
        
        [DisplayName("AgentId:")]
        public int AgentId { get; set; }

        [DisplayName("Agent")]
        public string AgentName { get; set; }
        
        [DisplayName("ATLTTL")]
        public string ATLTTL { get; set; }
        
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }
        
        [DisplayName("Booked By")]
        public int CreatedBy { get; set; }
        
        [DisplayName("Booked Date")]
        public DateTime CreatedDate { get; set; }
        
        [DisplayName("Dispatched Date")]
        public DateTime? DispatchedDate { get; set; }
        
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("GDS Refrence Number")]
        public string GDSRefrenceNumber { get; set; }
        
        [DisplayName("Issued Date")]
        public DateTime? IssuedDate { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        
        [DisplayName("PNRId")]
        public Int64 PNRId { get; set; }
        
        [DisplayName("Prefix")]
        public string Prefix { get; set; }
        
        [DisplayName("ServiceProviderId:")]
        public int ServiceProviderId { get; set; }
        
        [DisplayName("Ticket Status")]
        public int TicketStatusId { get; set; }
        
        [DisplayName("TTL")]
        public DateTime? TTL { get; set; }
        
        [DisplayName("Updated By")]
        public int? UpdatedBy { get; set; }
        public string Checker { get; set; }
        
        [DisplayName("Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        public IEnumerable<PNRsModel> PNRsList { get; set; }
        public string BookedBy { get; set; }
        public string BookedPerson { get; set; }
        public string TicketStatus { get; set; }
    }


    public class PNRSegmentsModel
    {
        
        [DisplayName("Airline Code")]
        public int AirlineId { get; set; }
        
        [DisplayName("Airline Refrence Number")]
        public string AirlineRefrenceNumber { get; set; }
        
        [DisplayName("Arrive City")]
        public int ArriveCityId { get; set; }
        
        [DisplayName("Arrive Date")]
        public DateTime ArriveDate { get; set; }
        
        [DisplayName("Arrive Time")]
        public TimeSpan ArriveTime { get; set; }
        
        [DisplayName("BIC")]
        public string BIC { get; set; }
        
        [DisplayName("Created By")]
        public int CreatedBy { get; set; }
        
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        
        [DisplayName("Depart City")]
        public int DepartCityId { get; set; }
        
        [DisplayName("DepartDate:")]
        public DateTime DepartDate { get; set; }
        
        [DisplayName("DepartTime")]
        public TimeSpan DepartTime { get; set; }
        
        [DisplayName("End Terminal")]
        public string EndTerminal { get; set; }
        
        [DisplayName("Flight Number")]
        public string FlightNumber { get; set; }
        
        [DisplayName("PNRId")]
        public Int64 PNRId { get; set; }
        
        [DisplayName("SectorId")]
        public Int64 SectorId { get; set; }
        
        [DisplayName("SegmentId:")]
        public Int64 SegmentId { get; set; }
        
        [DisplayName("Start Terminal")]
        public string StartTerminal { get; set; }
        
        [DisplayName("Updated By")]
        public int? UpdatedBy { get; set; }
        
        [DisplayName("Updated Date")]
        public DateTime? UpdatedDate { get; set; }


        public IEnumerable<PNRSegmentsModel> PNRSegmentsList { get; set; }
        public string AirlineCode { get; set; }
        public string ArriveCityName { get; set; }
        public string DepartCityName { get; set; }
    
    }


    public class PassengersModel
    {
        
        [DisplayName("AirlineId")]
        public int? AirlineId { get; set; }
        
        [DisplayName("Commission")]
        public double CommissionAmount { get; set; }
        
        [DisplayName("Created By")]
        public int CreatedBy { get; set; }
        
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        
        [DisplayName("DOB")]
        public DateTime? DOB { get; set; }
        
        [DisplayName("DOCA")]
        public string DOCA { get; set; }
        
        [DisplayName("DOCO")]
        public string DOCO { get; set; }
        
        [DisplayName("DOCS")]
        public string DOCS { get; set; }
        
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        
        [DisplayName("Fare")]
        public double Fare { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Frequent FlierNo")]
        public string FrequentFlierNo { get; set; }
        
        [DisplayName("FSC")]
        public double FSC { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [DisplayName("Markup Amount")]
        public double MarkupAmount { get; set; }
        
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        
        [DisplayName("Mobile No")]
        public string MobileNumber { get; set; }
        
        [DisplayName("Nationality")]
        public int? Nationality { get; set; }
        
        [DisplayName("OSI")]
        public string OSI { get; set; }
        
        [DisplayName("Other SSRCode")]
        public string OtherSSRCode { get; set; }
        
        [DisplayName("PassengerId")]
        public long PassengerId { get; set; }
        
        [DisplayName("Type")]
        public int PassengerTypeId { get; set; }
        
        [DisplayName("Passport Exp Date")]
        public DateTime? PassportExpDate { get; set; }
        
        [DisplayName("Passport No.")]
        public string PassportNumber { get; set; }
        
        [DisplayName("PNRId")]
        public long PNRId { get; set; }
        
        [DisplayName("Prefix")]
        public string Prefix { get; set; }
        
        [DisplayName("Service Charge")]
        public double ServiceCharge { get; set; }
        
        [DisplayName("SSR")]
        public string SSR { get; set; }
        
        [DisplayName("Tax")]
        public double TaxAmount { get; set; }
        
        [DisplayName("Ticket No")]
        public string TicketNumber { get; set; }
        
        [DisplayName("TicketStatusId")]
        public int TicketStatusId { get; set; }
        
        [DisplayName("Updated By")]
        public int? UpdatedBy { get; set; }
        
        [DisplayName("Updated Date")]
        public DateTime? UpdatedDate { get; set; }


        public IEnumerable<PassengersModel> PassengersList { get; set; }
        public string PassengerType { get; set; }
        public double DiscountAmount { get; set; }
    }

    public class FareModel
    {
        [DisplayName("Fare")]
        public double Fare { get; set; }

        [DisplayName("Commission/Discount")]
        public double Discount { get; set; }

        [DisplayName("Tax")]
        public double Tax { get; set; }

        [DisplayName("Service Charge")]
        public double ServiceCharge { get; set; }

        public IEnumerable<FareModel> FareList { get; set; }
    }
    public class PNRSectorModel
    {
        public long? PNRId { get; set; }
        public int PlatingCarrierID { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public string StartTerminal { get; set; }
        public string EndTerminal { get; set; }

      //  public IEnumerable<PNRSectorModel> PNRSectorList { get; set; }
    }

}