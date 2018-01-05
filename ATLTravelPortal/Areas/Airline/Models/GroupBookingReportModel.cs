using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public enum Baggage
    {
        Yes,
        No
    }

    public class GroupBookingReportModel
    {
        public string StartCity { get; set; }

        public string EndCity { get; set; }

        public string DepartureDate { get; set; }

        public int NoOfAdults { get; set; }

        public int NoOfChildren { get; set; }

        public int NoOfInfants { get; set; }

        public int ChoosenCabinClass { get; set; }

        public int SN0 { get; set; }


        /// <summary>
        /// ///////////////////
        /// </summary>
        ////////////////////////////////////Region Air_GroupBooking//////////////////////////////////////

        public int? GroupBookingId { get; set; }


        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [DisplayName("Contact Phone")]
        public string ContactPhone { get; set; }

        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Suburb/Town/City")]
        public string SuburbTownCity { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Group Type")]
        public int? GroupTypeId { get; set; }
        public string GroupTypeName { get; set; }
        public IEnumerable<SelectListItem> GroupTypeNameList { get; set; }

        [DisplayName("Excess Baggage")]
        // public bool? ExcessBaggage { get; set; }
        public Baggage rdbExcessBaggage { get; set; }

        public bool? isExcessBaggage { get; set; }



        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Contact E-Mail")]
        public string ContactEMail { get; set; }

        [DisplayName("Mobile Phone")]
        public string MobilePhone { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Post Code")]
        public string PostCode { get; set; }

        [DisplayName("Country")]
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public IEnumerable<SelectListItem> CountryNameList { get; set; }

        [DisplayName("Any other comments or special requirements")]
        public string Comments { get; set; }

        public int CreatedBy { get; set; }

        public IPagedList<GroupBookingReportModel> GroupBookingList { get; set; }


        [DisplayName("Status:")]
        public int StatusId { get; set; }

        public string PostComment { get; set; }
        public int hdfPostComment { get; set; }

        public bool isDelete { get; set; }

        public int? groupbookingcommentid { get; set; }
        public string CreatedName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        public IEnumerable<GroupBookingReportModel> GroupBookingCommtList { get; set; }



        /////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// ///////////////////
        /// </summary>
        ////////////////////////////////////Region Air_GroupBookingItinerary//////////////////////////////////////

        public int GroupBookingItineraryId { get; set; }

        public string GroupBookingName { get; set; }

        [DisplayName("From")]
        public int FromCityId { get; set; }
        public string FromCityName { get; set; }
        public IEnumerable<SelectListItem> FromCityNameList { get; set; }

        [DisplayName("To")]
        public int ToCityId { get; set; }
        public string ToCityName { get; set; }
        public IEnumerable<SelectListItem> ToCityNameList { get; set; }

        [DisplayName("Departure Date")]
        public DateTime DepartDate { get; set; }

        [DisplayName("Adults")]
        public int AdultsId { get; set; }
        public string AdultsName { get; set; }

        [DisplayName("Children")]
        public int ChildrenId { get; set; }
        public string ChildrenName { get; set; }

        [DisplayName("Infants")]
        public int InfantsId { get; set; }
        public string InfantsName { get; set; }

        [DisplayName("Cabin Class")]
        public string CabinClass { get; set; }

        public IEnumerable<GroupBookingReportModel> ItineraryList { get; set; }


        public int hdfFromCityId { get; set; }
        public int hdfToCityId { get; set; }
        public string hdfFromCityName { get; set; }
        public string hdfToCityName { get; set; }



        ////////////////////////////////////////////////////////////////////////////////////////////////
    }
}