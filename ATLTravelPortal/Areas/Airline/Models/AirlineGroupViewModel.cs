using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TravelPortalEntity;

using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Models
{
    
        public class AirlineGroupViewModel
        {
            public List<TravelPortalEntity.Airlines> AvailableAirline { get; set; }
            public List<TravelPortalEntity.Airlines> RequestedAirline { get; set; }
          
          

            public int RequestedTotal
            {
                get
                {
                    if (RequestedAirline == null)
                        return 0;
                    else
                        return RequestedAirline.Count();
                }
            }

            

            public int[] AvailableSelected { get; set; }
            public int[] RequestedSelected { get; set; }
            public string SavedRequested { get; set; }

             [Required(ErrorMessage = "*")]
            public string GroupName { get; set; }
        }
    
}