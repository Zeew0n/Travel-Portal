using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirlineFlightTaxesProvider
    {
        EntityModel ent = new EntityModel();

        public void Create(string flightTaxName, bool Active)
        {
            var flightfaretax = new AirlineFlightTaxes 
            {
                FlightTaxName = flightTaxName,
                isActive = Active
            };
            ent.AddToAirlineFlightTaxes(flightfaretax);
            ent.SaveChanges();
        }

        public IEnumerable<AirlineFlightTaxesModel> GetList()
        {
            List<AirlineFlightTaxesModel> list = new List<AirlineFlightTaxesModel>();

            foreach (var item in ent.AirlineFlightTaxes)
            {
                var tempMode = new AirlineFlightTaxesModel
                {
                    FareTaxName=item.FlightTaxName,
                    isActive=item.isActive,
                    FareTaxId=item.FlightTaxId
                };
                list.Add(tempMode);
            }

            return list.AsEnumerable();
        }

        public IEnumerable<AirlineFlightTaxesModel> GetList(int fareTaxId)
        {
            List<AirlineFlightTaxesModel> list = new List<AirlineFlightTaxesModel>();

            var tem = ent.AirlineFlightTaxes.Where(x => x.FlightTaxId == fareTaxId);

            foreach (var item in tem)
            {
                 var tempMode = new AirlineFlightTaxesModel
                {
                    FareTaxName=item.FlightTaxName,
                    isActive=item.isActive,
                    FareTaxId=item.FlightTaxId
                };
                list.Add(tempMode);
            }
            return list.AsEnumerable();
        }

        public void Edit(int flightTaxId, string flightTaxName, bool Active)
        {
            var result = ent.AirlineFlightTaxes.Where(x => x.FlightTaxId == flightTaxId).FirstOrDefault();
            if (result != null)
            {
                var flightfaretax = new AirlineFlightTaxes
                {
                    FlightTaxId=flightTaxId,
                    FlightTaxName = flightTaxName,
                    isActive = Active
                };

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, flightfaretax);
                ent.SaveChanges();
            }

        }
    }
}