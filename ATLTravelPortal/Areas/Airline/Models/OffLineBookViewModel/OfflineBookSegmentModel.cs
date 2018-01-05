using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel
{
    public class OfflineBookSegmentModel                   
    {
        public string Segment { get; set; }                

        public long SegmentId { get; set; }                
        public string MPNRId { get; set; }                 
        public string PNRId { get; set; }                  
        public string SectorId { get; set; }               
        public int AirlineId { get; set; }                 
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }
        public int hdfAirlineId { get; set; }
        
        [Required(ErrorMessage = "*")]
        [DisplayName("Airline No")]
        public string FlightNumber { get; set; }           

        [Required(ErrorMessage = "*")]
        [DisplayName("Departure City")]
        public int DepartCityId { get; set; }              
        public string DepartCityCode { get; set; }
        public string DepartureCity { get; set; }
        public int hdfDepartureCityId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Departure Date")]
        public DateTime? DepartDate { get; set; }           
        public TimeSpan? DepartTime { get; set; } 
          
        public int ArrivalCityId { get; set; }             
        public string  ArrivalCityCode { get; set; }
        public string  ArrivalCity { get; set; }
        public int hdfArrivalCityId { get; set; }


        public IEnumerable<SelectListItem> DepartCityList { get; set; }
        public IEnumerable<SelectListItem> ArriveCityList { get; set; }
        public IEnumerable<SelectListItem> AirlineList { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Arrival Date")]
        public DateTime? ArrivalDate { get; set; }          
        public TimeSpan? ArrivalTime { get; set; }          
        public string BIC { get; set; }                    
        public string StartTerminal { get; set; }          
        public string EndTerminal { get; set; }

      
        [Required]
        //[RegularExpression("^[a-z A-Z 0-9]{5,6}")]
        public string AirlineRefNumber { get; set; }   
    
        public string VndRemarks { get; set; }             
        public string  Duration { get; set; }
        public TimeSpan FlightDuration { get; set; }       
        public string Baggage { get; set; }                
        public string FareBasis { get; set; }              
        public string FlightKey { get; set; }              
        public string NVB { get; set; }                    
        public string NVA { get; set; }                    
        public string UpdatedBy { get; set; }              
        public string UpdatedDate { get; set; }            
    }
}                                                          