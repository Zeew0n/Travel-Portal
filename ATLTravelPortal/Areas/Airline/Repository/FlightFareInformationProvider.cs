using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class FlightFareInformationProvider
    {

        EntityModel ent = new EntityModel();
        public List<AirlineCities> GetCityList()
        {
            var result = ent.AirlineCities.OrderBy(x => x.CityCode);
            return result.ToList();
        }


        public List<AirlineCities> GetDepartCityList()
        {
            var result = ent.AirlineCities.Where(x=>(x.CityID==2035 || x.CityID==1318));
            return result.ToList();
        }

        public List<AirlineCities> GetArriveCityList()
        {
            var result = ent.AirlineCities.Where(x => (x.CityID == 1592 || x.CityID == 3572));
            return result.ToList();
        }
    }
}