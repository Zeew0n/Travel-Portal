using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class MassEmailingProvider
    {
        EntityModel entity = new EntityModel();

        public MassEmailingModel GetMassEmailingModel(MassEmailingModel model)
        {

            ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider mDealProvider = new ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider();
            AgentManagementRepository agentManagementRepository = new AgentManagementRepository();

            MassEmailingModel massEmailingModel = new MassEmailingModel();

            massEmailingModel.AgentClasses = GetAllAgentClasses();
            massEmailingModel.AgentDeals = mDealProvider.GetAllDealMasterForAgentClassList(1);
            massEmailingModel.Zones = new SelectList(agentManagementRepository.GetZoneList(), "ZoneId", "ZoneName");
            massEmailingModel.Districts = new SelectList(agentManagementRepository.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
            massEmailingModel.AgentTypes = new SelectList(agentManagementRepository.GetAgentType(), "AgentTypeId", "AgentTypeName");

            if (model != null)
                massEmailingModel.MessageType = model.MessageType;

            return massEmailingModel;
        }


        public IEnumerable<SelectListItem> GetAllAgentClasses()
        {
            var all = GetAgentClasses();
            var list = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentClassName,
                    Value = item.AgentClassId.ToString()
                };
                list.Add(teml);
            }
            return list.AsEnumerable();
        }

        public IQueryable<AgentClasses> GetAgentClasses()
        {
            return entity.AgentClasses.OrderBy(xx => xx.AgentClassName).AsQueryable();
        }

        public int SendMassEmails(MassEmailingModel model)
        {
            var ts = AdminSessionStore.GetTravelSession();
            System.Data.Objects.ObjectParameter numberOfEmailSent = new System.Data.Objects.ObjectParameter("NumberOfEmailSent", 0);
            string agentIds = GetAgentIds(model.SpecifiedAgents);

            entity.Core_SendMassEmails(model.AgentClassId, model.AgentTypeId, model.AgentDealId, model.DistrictId, model.ZoneId,
                !string.IsNullOrEmpty(agentIds) ? agentIds : null, model.FreeEmail, model.Subject, model.EmailMessage, ts.AppUserId, numberOfEmailSent);

            return (int)numberOfEmailSent.Value;
        }

        public int SendMassSMSs(MassEmailingModel model)
        {
            var ts = AdminSessionStore.GetTravelSession();
            string agentIds = GetAgentIds(model.SpecifiedAgents);

            var finalMobileNos = entity.Core_SendMassSMS(model.AgentClassId, model.AgentTypeId, model.AgentDealId, model.DistrictId, model.ZoneId,
                 !string.IsNullOrEmpty(agentIds) ? agentIds : null, model.FreeMobileNo,model.SMSMessage,ts.AppUserId).ToList();            

            int counter = 0;
            foreach (var mobileNo in finalMobileNos)
            {
                if (Helpers.SMS.SendSms.Send(mobileNo.MobileNumber, model.SMSMessage, model.Subject))
                {
                    counter++;
                }
            }
            return counter;
        }

        public string GetAgentIds(string agents)
        {
            if (agents != null)
            {
                string[] agentsList = agents.Split(',');
                string agentIds = null;

                foreach (string agt in agentsList)
                {
                    if (!string.IsNullOrEmpty(agt))
                    {
                        int id = GetAgentIdByAgentName(agt.Trim());
                        if (id > 0)
                            agentIds += id + ",";
                    }
                }
                agentIds = agentIds.TrimEnd(',');
                return agentIds;
            }
            return null;
        }

        public int GetAgentIdByAgentName(string AgentName)
        {
            var result = entity.Agents.Where(x => x.AgentName == AgentName).FirstOrDefault();
            if (result != null)
                return result.AgentId;
            else
                return 0;
        }

    }
}