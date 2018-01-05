using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirlineCappingProvider
    {

        EntityModel ent = new EntityModel();

        public void Create(AirlineCappingModel model)
        {
            var objAirlineCapping = new AirlineCappings
            {
                ServiceProviderId = model.ServiceProviderId,
                AirlineId = (int) model.hdfAirlineName,
                TotalNumberOfCAP = model.TotalTicketNumber,
            };
            ent.AddToAirlineCappings(objAirlineCapping);
            ent.SaveChanges();
        }

        public IEnumerable<AirlineCappingModel> List(int ServiceProviderId)
        {
            List<AirlineCappingModel> model = new List<AirlineCappingModel>();
            var obj = ent.AirlineCappings.Where(x => x.ServiceProviderId == ServiceProviderId).ToList();
            foreach (var item in obj)
            {
                var temp = new AirlineCappingModel
                {
                    AirlineName = item.Airlines.AirlineName,
                    TotalTicketNumber = item.TotalNumberOfCAP,
                    cappingId = item.CappingId
                };
                model.Add(temp);
            }

            return model.AsEnumerable();
        }

        public AirlineCappingModel GetCappingDetails(Int64 cappingId)
        {
            AirlineCappings obj = ent.AirlineCappings.Where(x => x.CappingId == cappingId).FirstOrDefault();
            var model = new AirlineCappingModel
            {
                ServiceProviderId = obj.ServiceProviderId,
                hdfAirlineName = obj.AirlineId,
                AirlinesName = obj.Airlines.AirlineName,
                TotalTicketNumber = obj.TotalNumberOfCAP,
            };
            return model;
        }




        public int GetServiceProviderId(Int64 cappingId)
        {
            AirlineCappings obj = ent.AirlineCappings.Where(x => x.CappingId == cappingId).FirstOrDefault();
            var model = new AirlineCappingModel
            {
                ServiceProviderId = obj.ServiceProviderId
              
            };
            return model.ServiceProviderId;
        }





        public void Edit(AirlineCappingModel model)
        {
            var result = ent.AirlineCappings.Where(x => x.CappingId == model.cappingId).FirstOrDefault();
            if (result != null)
            {
                var objAirlineCapping = new AirlineCappings
            {
                CappingId=model.cappingId,
                ServiceProviderId = model.ServiceProviderId,
                AirlineId = (int)model.hdfAirlineName,
                TotalNumberOfCAP = model.TotalTicketNumber,
            };

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, objAirlineCapping);
                ent.SaveChanges();
            }


        }


        public void Delete(Int64 CappingId)
        {

            var result = ent.AirlineCappings.Where(x => x.CappingId == CappingId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();



        }


        public List<Airlines> GetAirline(string AirlineCityName, int maxResult)
        {
            return GetAllAirlineList(AirlineCityName, maxResult).ToList();
        }
        public IEnumerable<Airlines> GetAllAirlineList(string AirlineNameCode, int maxResult)
        {

            return ent.Airlines.Where(x => ((x.AirlineName.ToLower().Contains(AirlineNameCode) ||
                x.AirlineName.ToLower().Contains(AirlineNameCode) ||
                x.AirlineCode.ToUpper().Contains(AirlineNameCode) ||
                x.AirlineCode.ToUpper().Contains(AirlineNameCode.ToUpper()))) && (x.AirlineTypeId == 1)).Take(maxResult).ToList().Select(x =>
                   new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }

    }
}