using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusScheduleModel
    {
        public long ScheduleId { get; set; }
        [DisplayName("Operator Name")]
        [Required(ErrorMessage = "Operator Name required.")]
        public int BusMasterId { get; set; }
        public string BusMasterName { get; set; }
        public IEnumerable<SelectListItem> ddlBusMasterList { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category Name required.")]
        public int BusCategoryId { get; set; }
        public string BusCategoryName { get; set; }
        public IEnumerable<SelectListItem> ddlBusCategoryList { get; set; }

        [DisplayName("Departure City")]
        [Required(ErrorMessage = "Departure City Name required.")]
        public int DepartureCityId { get; set; }
        public string DepartureCityName { get; set; }
        public IEnumerable<SelectListItem> ddlBusCityList { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "Type Name required.")]        
        public string TypeName { get; set; }
        public IEnumerable<SelectListItem> ddlTypeList { get; set; }

        [DisplayName("Duration")]
        [Required(ErrorMessage = "Duration required.")]
        public string DurationHHMM { get; set; }

        [DisplayName("Destination City")]
        [Required(ErrorMessage = "Destination City Name required.")]
        public int DestinationCityId { get; set; }
        public string DestinationCityName { get; set; }

        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }

        [DisplayName("Departure Time")]
        [Required(ErrorMessage = "Departure Time required.")]
        public TimeSpan DepartureTime { get; set; }
        [DisplayName("Arrival Time")]
        [Required(ErrorMessage = "Arrival Time required.")]
        public TimeSpan ArrivalTime { get; set; }

        [DisplayName("Ticket Rate")]
        [Required(ErrorMessage = " Ticket Rate required.")]
        public double Rate { get; set; }
        [DisplayName("Sales Rate")]
        [Required(ErrorMessage = "Sales Rate required.")]
        public double ActualRate { get; set; }
        [DisplayName("Purchase Rate")]
        [Required(ErrorMessage = "Purchase Rate required.")]
        public double PurchaseRate { get; set; }
        [DisplayName("Agent Commission")]
        [Required(ErrorMessage = "Agent Commission required.")]
        public double AgentCommission { get; set; }
        [DisplayName("Kilometer")]
        [Required(ErrorMessage = "Kilo Meter required.")]
        public double KiloMeter { get; set; }
        public int Sno { get; set; }

        public BusMessageModel Message { get; set; }
        public IPagedList<BusScheduleModel> TabularList { get; set; }
    }
}