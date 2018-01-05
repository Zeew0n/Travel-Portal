using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class InvoiceViewModel
    {
        [DisplayName(" Email ")]
        public string Email { get; set; }

        public int ServiceProviderId { get; set; }

        public InvoiceViewModel()
        {
            PNRDetails = new List<InvoicePNRDetailModel>();

        }

        public List<InvoicePNRDetailModel> PNRDetails { get; set; }


    }

    public class InvoiceAgencyDetailModel
    {
        public string ContactPerson { get; set; }

        public string AgencyName { get; set; }

        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string PanNo { get; set; }
    }

    public class InvoiceVendorDetailModel
    {
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Email { get; set; }
        public string PanNo { get; set; }
    }

    public class InvoiceItineraryDetailModel
    {
        public InvoiceItineraryDetailModel()
        {
            Segments = new List<InvoiceItinerarySegment>();
            PassengerDetail = new List<InvoicePassenger>();
        }
        public string Sector { get; set; }
        public string TicketNo { get; set; }

        public List<InvoiceItinerarySegment> Segments { get; set; }
        public List<InvoicePassenger> PassengerDetail { get; set; }
    }

    public class InvoiceItinerarySegment
    {
        public string FlightNo { get; set; }
        public string AirlineCode { get; set; }
        public string Airline { get; set; }
        public string Class { get; set; }
        public string DepartureDate { get; set; }
    }

    public class InvoicePassenger
    {
        public string PassengerName { get; set; }
        public string PassengerType { get; set; }
        public string PaxPhone { get; set; }


        public double Fare { get; set; }
        public string TicketNo { get; set; }

        [DisplayName("Fuel Surcharge - YQ")]
        public double FuelSurcharge { get; set; }
        public double Tax { get; set; }
        public double OtherCharge { get; set; }
        public double ServiceCharge { get; set; }
        public double MarkupAmount { get; set; }
        public double FxRate { get; set; }
        
    }

    public class InvoicePNRDetailModel
    {
        public InvoicePNRDetailModel()
        {
            ItineraryDetails = new List<InvoiceItineraryDetailModel>();
        }

        public string Currency { get; set; }

        public DateTime ProcessedDate { get; set; }

        [DisplayName("Invoice No")]
        public string InvoiceNo { get; set; }

        [DisplayName("Invoice Date")]
        public DateTime InvoiceDate { get; set; }


        [DisplayName("Travel Date")]
        public DateTime TravelDate { get; set; }

        public InvoiceAgencyDetailModel AgencyDetail { get; set; }

        public InvoiceVendorDetailModel VendorDetail { get; set; }

        [DisplayName("Fare Rule")]
        public List<string> FareRules { get; set; }

        [DisplayName("Gross")]
        public double GrossAmount { get; set; }

        [DisplayName("Less Commission Earned")]
        public double CommissionEarned { get; set; }

        [DisplayName("Add Service Tax")]
        public double ServiceTax { get; set; }

        [DisplayName("Transaction Fee")]
        public double TransactionFee { get; set; }

        [DisplayName("Add TDS Deduction")]
        public double TaxDeductionAtSource { get; set; }

        [DisplayName("Billed By")]
        public string BilledBy { get; set; }

        [DisplayName("Ticketed By")]
        public string TicketedToAgent { get; set; }


        [DisplayName("Billed By")]
        public string BilledByAgent { get; set; }

        [DisplayName("Ticketed By")]
        public string TicketedToPassenger { get; set; }


        [DisplayName("Net Amount")]
        public double NetAmount { get; set; }

        [DisplayName("Net Receivable")]
        public double NetReceivable { get; set; }

        public string Journey { get; set; }



        public int PNRId { get; set; }
        public string PNR { get; set; }
        public int TicketStatusId { get; set; }
        public int MPNRId { get; set; }

        public decimal AdditionalTxnFee { get; set; }
        public decimal AirTransFee { get; set; }
        public decimal BaseFare { get; set; }
        public decimal Tax { get; set; }
        public decimal YQ { get; set; }
        public decimal OtherCharge { get; set; }
        public decimal Discount { get; set; }
        public decimal AgentServiceCharge { get; set; }
        public double AgentAirlineMarkUp { get; set; }



        public List<InvoiceItineraryDetailModel> ItineraryDetails { get; set; }

    }
}