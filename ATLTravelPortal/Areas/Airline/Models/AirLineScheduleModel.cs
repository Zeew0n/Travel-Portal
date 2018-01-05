using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirLineScheduleModel
    {
        public string FlightNumber { get; set; }
        [Required(ErrorMessage="*")]
        public TimeSpan DepartureTime { get; set; }
        [Required(ErrorMessage="*")]
        public TimeSpan ArrivalTime { get; set; }
        [Required(ErrorMessage="*")]
        public decimal Fare { get; set; }
        public int AirlineId { get; set; }
        public int DepartureCityId { get; set; }
        public int DestinationCityId { get; set; }
        public long ScheduleId { get; set; }
        public string AirLineName { get; set; }
        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }
        public bool?Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool?Tuesday { get; set; }
        public bool?Wednesday { get; set; }
        public bool?Thursday { get; set; }
        public bool?Friday { get; set; }
        public bool?Saturday { get; set; }
        public IEnumerable<AirLineScheduleModel> AirLineScheduleList { get; set; }
    }
   
}