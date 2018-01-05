using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
   
    public class GDSHitsProvider
    {
        EntityModel_Logs entities = new EntityModel_Logs();

       

        public IEnumerable<GDSHitsModel> GetGDSHitCount(DateTime? FromDate, DateTime? ToDate, int?AgentId)
        {

           
            var data = entities.Air_GetGDSHitCount(FromDate, ToDate, AgentId).ToList();//indira change it,suraj
            List<GDSHitsModel> model = new List<GDSHitsModel>();

            foreach (var item in data)
            {
               
                var temo = new GDSHitsModel();
                temo.Agentid =(int) item.AgentId;
                temo.AgentName =GetAgentName(item.AgentId);
                temo.ServiceProvider = GetServiceProvider(item.ServiceProviderId);
                temo.TransactionName = item.TransactionName;
                temo.GDSHitCount = item.GDSHitCount.Value;

                model.Add(temo);
            }
            return model.AsEnumerable();

        }
        public IEnumerable<GDSHitsModel> GetGDSHitCountDetails(int AgentId)
        {

            var obj = entities.Air_GetGDSHitCountDetails(AgentId);
            var model = new List<GDSHitsModel>();

            foreach (var item in obj)
            {

                var temo = new GDSHitsModel();
                temo.ServiceProvider = GetServiceProvider(item.ServiceProviderId);
                temo.TransactionName = item.TransactionName;
                temo.GDSHitCount = item.GDSHitCount.Value;
                temo.RequestedDate = item.RequestedDate;
                //TotalGDSHits = TotalGDSHits + (Decimal)item.GDSHitCount;
                //temo.txtSumGDSHits = TotalGDSHits;

                model.Add(temo);
            }
            return model.AsEnumerable();

        }
        public string GetAgentName(int? AgentId)
        {
            if (AgentId != -1)
            {
                EntityModel ent = new EntityModel();
                string AgentName = ent.Agents.Where(x => x.AgentId == AgentId).Select(x => x.AgentName).FirstOrDefault();
                if (AgentName != null)
                {
                    return AgentName;
                }
                else
                {
                    return "N/A";
                }
            }
            else
            {
                return "N/A";
            }
        }
        private string GetServiceProvider(int? ServiceProviderId)
        {
            EntityModel ent = new EntityModel();
            string ServiceProvider = ent.ServiceProviders.Where(x => x.ServiceProviderId == ServiceProviderId).Select(x => x.ServiceProviderName).FirstOrDefault();
            return ServiceProvider;
            
        }
    }
}