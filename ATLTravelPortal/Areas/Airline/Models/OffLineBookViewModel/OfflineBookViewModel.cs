using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using TravelPortalEntity;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel
{
    public class OfflineBookInputModel
    {
        #region Create
        [Required(ErrorMessage = "*")]
        [DisplayName("Booking Type")]
        public string BookingType { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Journey Type")]
        public string JourneyType { get; set; }
        #endregion

        #region Search Book
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        #endregion
    }

    public class OfflineBookViewModel
    {
        public OfflineBookViewModel()
        {
            input = new OfflineBookInputModel();
            PNRDetails = new List<OfflineBookPNRDetailsModel>();
            UserDetail = new UserDetail();
            SelectListCollection = new SelectListCollection();
        }
        public OfflineBookInputModel input { get; set; }
        public SelectListCollection SelectListCollection { get; set; }
        public List<OfflineBookPNRDetailsModel> PNRDetails { get; set; }
        public UserDetail UserDetail { get; set; }
        public IEnumerable<SelectListItem> BookingBourceList { get; set; }
        public long MPNRId { get; set; }
        public string TicketStatus { get; set; }
        public int TicketStatusId { get; set; }
        public string BookingRefNo { get; set; }
        public DateTime BookedDate { get; set; }
        public string BookedBy { get; set; }
        public DateTime IssuedDate { get; set; }
        public int UpdatedBy { get; set; }
        public int ServiceProviderId { get; set; }
        public string ServiceProviderName { get; set; }
        public string PassengerName { get; set; }
        public string Sector { get; set; }

       
        public string PnrInfoPrefix { get; set; }
        public IEnumerable<SelectListItem> PnrInfoPrefixList { get; set; }

      
        public string PnrInfoFirstName { get; set; }

       
        public string PnrInfoMiddleName { get; set; }

      
        public string PnrInfoLastName { get; set; }



        public List<OfflineBookViewModel> OfflineBookTicketList { get; set; }
        public List<OfflineBookViewModel> PNRBookedList { get; set; }

        public OfflineBookPNRDetailsModel PNRInformation { get; set; }


        public HttpPostedFileBase ticket { get; set; }


       public  List<OfflineBookFareDetailModel> FarePassengerInfo { get; set; }

       public AvailableBalanceViewModel AvailableBalance { get; set; }
       public bool isDeleted { get; set; }
    }

    public class UserDetail
    {
        public Guid SessionId { get; set; }
        public string AgentName { get; set; }
        public String AgencyDescription { get; set; }
     
        public int AgentId { get; set; }
        public int AppUserId { get; set; }
        public int AdminUserId { get; set; }
        public string UserName { get; set; }
        public HttpPostedFileBase eTicket { get; set; }
        public string AgentPhone { get; set; }

        public string UserFullName { get; set; }
        public string UserAddress { get; set; }
        public string UserMobileNumber { get; set; }
        public string UserPhoneNumber { get; set; }


        public int BranchId { get; set; }
        public int DistributorId { get; set; }
        public string BranchOfficeName { get; set; }
        public string DistributorOfficeName { get; set; }

    }

    public class SelectListCollection
    {
      
        public SelectList PaxTypeList = ToSelectList.GetPaxTypeList();
        public SelectList TicketStatusList = ToSelectList.GetTicketStatusList();
        public SelectList AirlineList = ToSelectList.GetAirlineList();
        public SelectList CityList = ToSelectList.GetCityList();
        public SelectList CountryList = ToSelectList.GetCountryList();
        public SelectList MealList = ToSelectList.GetMealList();
        public SelectList NationalityList = ToSelectList.GetNationalityList();
        public SelectList PrefixList = ToSelectList.GetPrefixList();
        public SelectList SeatList = ToSelectList.GetSeatList();
        public SelectList StateList = ToSelectList.GetStateList();
        public SelectList CurrencyList = ToSelectList.GetCurrencyList();
        public SelectList BICList = ToSelectList.GetBICTypeList();
        public SelectList BookingSourceList = ToSelectList.GetBookingSourceList();
    }

    public class OfflineBookPNRDetailsModel
    {
        public OfflineBookPNRDetailsModel()
        {
            PassengerDetail = new List<OfflineBookPassengerModel>();
            SegmentDetail = new List<OfflineBookSegmentModel>();
            //FareDetail = new 
        }

        public long PNRId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Ticket Status")]
        public int TicketStatusId { get; set; }

        public string TicketStatus { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Booked Date")]
        public DateTime BookedDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("PNR")]
        //[RegularExpression("^[a-z A-Z 0-9]")]
        public string PNR { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Booking Source")]
        public string BookingSource { get; set; }

        [DisplayName("Passenger Details")]
        public List<OfflineBookPassengerModel> PassengerDetail { get; set; }

        [DisplayName("Segment Details")]
        public List<OfflineBookSegmentModel> SegmentDetail { get; set; }

         [DisplayName("Fare Details")]
        public List<OfflineBookFareDetailModel> FareDetail { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Prefix")]
        public string PnrInfoPrefix { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("First Name")]
        public string PnrInfoFirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Middle Name")]
        public string PnrInfoMiddleName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Last Name")]
        public string PnrInfoLastName { get; set; }

        public string PCC { get; set; }
        public string Remarks { get; set; }
    }
}