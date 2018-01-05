using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using TBO.Passenger;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel
{
    public class OfflineBookPassengerModel
    {
        public OfflineBookPassengerModel()
        {
            FareDetail = new OfflineBookFareDetailModel();
        }

        #region IDs

        public string AirlineId { get; set; }
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }

        public string CityId { get; set; }
        public string CityCode { get; set; }
        public string City { get; set; }

        public string StateId { get; set; }
        public string StateCode { get; set; }
        public string State { get; set; }

        #endregion

        public Salutations Prefix { get; set; }
        public string PrefixId { get; set; }
        public IEnumerable<SelectListItem> PrefixList { get; set; }

        public string PassengerPrefix { get; set; }
        
        [Required(ErrorMessage = "*")]
        [DisplayName("Name")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Surname")]
        public string LastName { get; set; }


        
        public string Gender { get; set; }
        
        public string DOB { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Pax Type")]
        public PassengerType   PaxType { get; set; }

        public IEnumerable<SelectListItem> PaxTypeList { get; set; }

         

       

        public int? NationalityId { get; set; }
        public string Nationality { get; set; }

        public string PhoneType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Country { get; set; } 
        public string Street { get; set; }

        public string PassportNumber { get; set; }
        public DateTime? PassportExpDate { get; set; } 
        public int? PassportIssuedCountryId { get; set; }
        public string PassportValidForCountry { get; set; }
        public DateTime? PassportIssuedDate { get; set; }

        public DateTime? VisaIssuedDate { get; set; }
        public DateTime? VisaExpiryDate { get; set; }
        public string VisaIssuedCountry { get; set; }
        public string VisaValidForCountry { get; set; }

        public string FrequentFlyerAirlineCode { get; set; }
        public int? FrequentFlyerAirlineId { get; set; }

        public Meal Meal { get; set; }

        public Seat Seat { get; set; }

        public string OtherServiceInfo { get; set; }

        public string SpecialServiceRequest { get; set; }

        public string FrequentFlyerNo { get; set; }
        public string FrequentFlyerAirline { get; set; }

        [DisplayName("Fare Details")]
        public OfflineBookFareDetailModel FareDetail { get; set; }

        public List<OfflineBookFareDetailModel> FareDetails { get; set; }
        //[DisplayName("Upload eTicket")]
        //public HttpPostedFileBase eTicket { get; set; }
    }
}