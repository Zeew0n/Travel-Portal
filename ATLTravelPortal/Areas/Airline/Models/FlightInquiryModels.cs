using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class FlightInquiryModel : FormPropertyModel<FlightInquiryModel>
    {

        public int PId { get; set; }


        [DisplayName("FlightType: ")]
        public string FlightType { get; set; }

        [DisplayName("JourneyType: ")]
        public string JourneyType { get; set; }

        [DisplayName("Leaving From: ")]
        public string OriginCity { get; set; }

        [DisplayName("Going To: ")]
        public string DepartureCity { get; set; }

        [DisplayName("Departure Date: ")]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Return Date: ")]
        public DateTime? ReturnDate { get; set; }

        [DisplayName("Adults: ")]
        public int NoOfAdult { get; set; }

        [DisplayName("Children: ")]
        public int NoOfChildren { get; set; }

        [DisplayName("Infants: ")]
        public int NoOfInfant { get; set; }

        public int PassengerNumber { get; set; }

        [DisplayName("AirlinePreference: ")]
        public string AirlinePreference { get; set; }

        [DisplayName("Nationality: ")]
        public string Nationality { get; set; }

        [DisplayName("CabinClass: ")]
        public string CabinClass { get; set; }

        public string Status { get; set; }

        public int HddnOriginCityId { get; set; }

        public int HddnDepartureCityId { get; set; }

        public DateTime CreatedDate { get; set; }

        [DisplayName("ContactName: ")]
        public string ContactName { get; set; }

        [DisplayName("ContactNumber: ")]
        public string ContactNumber { get; set; }

        [DisplayName("EmailAddress: ")]
        public string EmailAddress { get; set; }

        [DisplayName("Company/Agent Name: ")]
        public string CompanyAgentName { get; set; }


        public List<FlightInquiryPaxModel> FlightInquiryPax { get; set; }


        //public List<SelectListItem> ddlAdultChildren
        //{
        //    get
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList.Add(new SelectListItem { Text = "-- Select --", Value = "" });
        //        for (int i = 0; i <= 9; i++)
        //        {
        //            ddlList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
        //        }
        //        return ddlList;
        //    }
        //}

        //public List<SelectListItem> ddlNationality
        //{
        //    get
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList.Add(new SelectListItem { Text = "Nepalese", Value = "Nepalese", Selected = true });
        //        ddlList.Add(new SelectListItem { Text = "Indian", Value = "Indian" });
        //        ddlList.Add(new SelectListItem { Text = "Other", Value = "Other" });
        //        return ddlList;

        //    }
        //}

        //public List<SelectListItem> ddlCabinClass
        //{
        //    get
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();

        //        ddlList.Add(new SelectListItem { Text = "Economy", Value = "Economy", Selected = true });
        //        ddlList.Add(new SelectListItem { Text = "Business", Value = "Business" });
        //        return ddlList;

        //    }
        //}

        //public List<SelectListItem> ddlAirlinePreference
        //{
        //    get
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList.Add(new SelectListItem { Text = "-- Select --", Value = "" });
        //        ddlList.Add(new SelectListItem { Text = "Buddha Air", Value = "Buddha Air", Selected = true });
        //        ddlList.Add(new SelectListItem { Text = "Yeti Airlines", Value = "Yeti Airlines" });
        //        return ddlList;

        //    }
        //}

        //public List<SelectListItem> ddlGender
        //{
        //    get
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList.Add(new SelectListItem { Text = "-- Select --", Value = "" });
        //        ddlList.Add(new SelectListItem { Text = "Male", Value = "Male" });
        //        ddlList.Add(new SelectListItem { Text = "Female", Value = "Female" });
        //        ddlList.Add(new SelectListItem { Text = "Other", Value = "Other" });
        //        return ddlList;

        //    }
        //}
        //public List<SelectListItem> ddlSalutationAdult
        //{
        //    get
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList.Add(new SelectListItem { Text = "Mr", Value = "Mr" });
        //        ddlList.Add(new SelectListItem { Text = "Mrs", Value = "Mrs" });
        //        ddlList.Add(new SelectListItem { Text = "Ms", Value = "Ms" });
        //        ddlList.Add(new SelectListItem { Text = "Dr", Value = "Dr" });
        //        return ddlList;

        //    }
        //}

        //public List<SelectListItem> ddlSalutationChild
        //{
        //    get
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList.Add(new SelectListItem { Text = "Master", Value = "Master" });
        //        ddlList.Add(new SelectListItem { Text = "Miss", Value = "Miss" });
        //        return ddlList;

        //    }
        //}

    }

    public class FlightInquiryPaxModel
    {

        [DisplayName("FlightInquiryPaxId: ")]
        public int FlightInquiryPaxId { get; set; }

        [DisplayName("FlightInquiryId: ")]
        public int FlightInquiryId { get; set; }

        [DisplayName("Title: ")]
        public string Title { get; set; }

        [DisplayName("FirstName: ")]
        public string FirstName { get; set; }

        [DisplayName("MiddleName: ")]
        public string MiddleName { get; set; }

        [DisplayName("LastName: ")]
        public string LastName { get; set; }

        [DisplayName("Gender: ")]
        public string Gender { get; set; }

        [DisplayName("PassengerType: ")]
        public string PassengerType { get; set; }

        [DisplayName("ContactNumber: ")]
        public string ContactNumber { get; set; }

        [DisplayName("EmailAddress: ")]
        public string EmailAddress { get; set; }

    }
}