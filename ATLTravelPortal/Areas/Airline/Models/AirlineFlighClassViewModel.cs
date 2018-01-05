using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TravelPortalEntity;


namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirlineFlighClassViewModel
    {
        public int AirlineFlightClassId { get; set; }


        public int FlightClassId { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Domestic Airline")]
        public int AirlineId { get; set; }
        public IEnumerable<SelectListItem> DomesticAirlineList { get; set; }
        public string AirlineName { get; set; }
        public int HFAirlineId { get; set; }
       
        [Required(ErrorMessage = "* - 1 Character only")]
        [StringLength(1, ErrorMessage = "Must be 1 characters.")]
        public string FlightClassCode { get; set; }



        [Required(ErrorMessage = "*")]
        [DisplayName("Flight Type")]
        public int FlightTypeId { get; set; }
        public IEnumerable<SelectListItem> FlightTypList { get; set; }
        public string FlightTypeName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Class Type")]
        public string ClassType { get; set; }

        public IQueryable<AirlineFlighClassViewModel> AirlineFlighClass { get; set; }
        public List<AirlineFlighClassViewModel> ActiveFlightClassForAirline { get; set; }

        public IQueryable<TravelPortalEntity.Airlines> ActiveDomesticAirlineList { get; set; }
    }
    public class AirlineFlighClassExtensionModel
    {
        //////
        public static bool IsActiveAirlineFlightClasses(int FlightClassId, List<AirlineFlighClassViewModel> FlightClassIdHelper)
        {
            bool flag = false;
            List<int> FlightClassIds = FlightClassIdHelper.Select(ii => ii.FlightClassId).ToList();
            foreach (int FCid in FlightClassIds)
            {
                if (FlightClassId == FCid)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
  
}