using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Repository
{
   
    public class AgentActivitiesProvider
    {
        EntityModel ent = new EntityModel();


        public decimal TotalBooked = 0;
        public decimal TotalCancelled = 0;
        public decimal TotalIssued = 0;
        public decimal TotalVoid = 0;
        public decimal TotalLogin = 0;
        public decimal TotalGDSHits = 0;


        public List<AgentActivitiesModel> GetAgentActivitiesList(int? agentid, DateTime? fromdate, DateTime? todate )
        {
            var data = ent.Air_AgentActivities(agentid, fromdate, todate);

            List<AgentActivitiesModel> model = new List<AgentActivitiesModel>();

            foreach (var item in data.Select(x=>x))
            {
                var AgentActivitiesModel = new AgentActivitiesModel();
                AgentActivitiesModel.AgentName = item.AgentName;
               

                AgentActivitiesModel.Booked = item.Booked;
                TotalBooked = TotalBooked + (decimal) item.Booked;
                AgentActivitiesModel.SumBooked = TotalBooked;
               
                AgentActivitiesModel.Cancelled = item.Cancelled;
                TotalCancelled = TotalCancelled + (decimal)item.Cancelled;
                AgentActivitiesModel.SumCancelled = TotalCancelled;

                AgentActivitiesModel.Issued = item.Issued;
                TotalIssued = TotalIssued + (decimal)item.Issued;
                AgentActivitiesModel.SumIssued = TotalIssued;

                AgentActivitiesModel.Void = item.Void;
                TotalVoid = TotalVoid + (decimal) item.Void;
                AgentActivitiesModel.SumVoid = TotalVoid;

                AgentActivitiesModel.TotalLogin = item.TotalLogin;
                TotalLogin = TotalLogin + item.TotalLogin;
                AgentActivitiesModel.SumTotalLogin = TotalLogin;

                 AgentActivitiesModel.GDSHits = item.GDSHits;
                 TotalGDSHits = TotalGDSHits + (decimal)item.GDSHits;
                 AgentActivitiesModel.SumTotalGDSHits = TotalGDSHits;



                AgentActivitiesModel.LastLogin = item.LastLogin;

                model.Add(AgentActivitiesModel);
            }
            return model.ToList();
        }

    }
}