using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentCLApprovedProvider
    {
        EntityModel entity = new EntityModel();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();


        public List<AgentCLApprovedModel> GetAgentCLApprovedList(DateTime fromdate, DateTime todate, int? userId, int? distributorID, int? agentId)
        {
            var data = entity.GL_GetAgentCLApprovedList(fromdate, todate, userId, distributorID, agentId);

            List<AgentCLApprovedModel> model = new List<AgentCLApprovedModel>();

            foreach (var item in data.Select(x => x))
            {
                var AgentCLApprovedModel = new AgentCLApprovedModel
                {
                    DistributorName = item.DistributorName,
                    BranchOfficeName = item.BranchOfficeName,
                    AgentName = item.AgentName,
                    AgentCode = item.Code,
                    Currency = item.Currency,
                    Amount = item.Amount,
                    Type = item.Type,
                    Requestion = item.Requeston,
                    CheckerDate = item.CheckerDate,
                    CheckedBy = item.CheckedBy,
                    Comments = item.Comments,
                    EffectiveFrom = item.EffectiveFrom,
                    ExpireOn = item.ExpireOn
                };
                model.Add(AgentCLApprovedModel);
            }
            return model;
        }

        public IQueryable<Distributors> GetAllDistributorsByBranchOfficeId(int branchOfficeId)
        {
            return entity.Distributors.Where(x => x.BranchOfficeId == branchOfficeId).AsQueryable();
        }

        public IQueryable<Agents> GetAgentsByDistributorId(int distributorId)
        {
            return entity.Agents.Where(x => x.DistributorId == distributorId).AsQueryable();
        }

        public IQueryable<UsersDetails> GetDistributorUsers(int? distributorId)
        {
            var data = from t1 in entity.UsersDetails
                       join t2 in entity.aspnet_UsersAgentRelation on t1.UserId equals t2.UserId
                       join t3 in entity.Agents on t2.AgentId equals t3.AgentId
                       where t3.DistributorId == distributorId 
                       //&& t1.UserTypeId == 6
                       select t1;
            return data.AsQueryable();
            //return entity.UsersDetails.Where(x => x.UserTypeId == 6).AsQueryable();
        }
    }
}