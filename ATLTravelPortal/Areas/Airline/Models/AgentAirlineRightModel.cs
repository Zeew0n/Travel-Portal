using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using TravelPortalEntity;


namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentAirlineRightModel
    {
        public long MappingId { get; set; }

        public int AirlineId { get; set; }

        public string AirlineName { get; set; }

        public bool Canview { get; set; }

        public bool CanSell { get; set; }
        public IEnumerable<ATLTravelPortal.Areas.Airline.Models.AirLines> airlinelist { get; set; }

    }
    public class AgentAirlineRightViewModel
    {
        public List<TravelPortalEntity.Airlines> AvailableAirline { get; set; }
        public List<TravelPortalEntity.Airlines> RequestedAirline { get; set; }

        public decimal RequestedTotal
        {
            get
            {
                if (RequestedAirline == null)
                    return 0m;
                else
                    return RequestedAirline.Count();
            }
        }

        public int[] AvailableSelected { get; set; }
        public int[] RequestedSelected { get; set; }
        public string SavedRequested { get; set; }
    }
}