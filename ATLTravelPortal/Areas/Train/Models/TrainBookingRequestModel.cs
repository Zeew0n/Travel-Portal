using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Train.Models
{
    public class TrainBookingRequestModel
    {
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }
        public long TrainPNRId { get; set; }
        public string TrainClassName { get; set; }
        public int NoOfSeat { get; set; }
        public string Sector { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string JourneyType { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "*")]
        public string FullName { get; set; }
        public TrainMessageModel Message { get; set; }
        public List<TrainPassengerModel> Passengers { get; set; }
        public int NoOfAdult { get; set; }
        public int? NoOfChild { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int SNo { get; set; }
        // public IEnumerable<SelectListItem> AirlineTypesList { get; set; }
        public IPagedList<TrainBookingRequestModel> PagedList { get; set; }
        //Export
        public string ExportTypeExcel { get; set; }
        public string ExportTypeWord { get; set; }
        public string ExportTypeCSV { get; set; }
        public string ExportTypePdf { get; set; }
        public IEnumerable<TrainBookingRequestModel> ExportList { get; set; }

        [DisplayName("Agent Name")]
        public int AgentId { get; set; }

        [DisplayName("Distrubutor Name")]
        public int DistrubutorId { get; set; }
    }
}