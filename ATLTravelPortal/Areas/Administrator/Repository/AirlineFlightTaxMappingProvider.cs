using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using System.Data.Objects;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AirlineFlightTaxMappingProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();


        public void AddAirLineFlightTaxMapping(AirlineFlightTaxesMappings obj)
        {
            ent.AddToAirlineFlightTaxesMappings(obj);
            ent.SaveChanges();
        }

        public IQueryable<AirlineFlightTaxesMappings> GetAirLineFlightMapping()
        {
            return ent.AirlineFlightTaxesMappings.AsQueryable();
        }

        public List<AirlineFlightTaxesMappings> GetByFlightMapping(int id)
        {
            using (TravelPortalEntity.EntityModel entities = new TravelPortalEntity.EntityModel())
            {
                var results = from o in entities.AirlineFlightTaxesMappings
                              where o.AirlineId == id
                              select o;

                return results.ToList<AirlineFlightTaxesMappings>();
            }
        }


        public List<AirlineFlightTaxesMappings> GetExistingAirlineName()
        {
            using (TravelPortalEntity.EntityModel entities = new TravelPortalEntity.EntityModel())
            {
                var results = from o in entities.AirlineFlightTaxesMappings
                              where o.AirlineId != o.AirlineId //&& o.AirlineId == o.MappingId
                              select o;
                return results.ToList<AirlineFlightTaxesMappings>();
            }
        }


    }
}