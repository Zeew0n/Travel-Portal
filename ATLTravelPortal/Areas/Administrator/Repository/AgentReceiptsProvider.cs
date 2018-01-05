using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentReceiptsProvider
    {

        EntityModel ent = new EntityModel();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();


        public List<AgentCLApprovedModel> GetAgentCLApprovedList(DateTime fromdate, DateTime todate, int? userId, int? distributorID, int? agentId)
        {
            var data = ent.GL_GetAgentRecepitList(fromdate, todate, userId, distributorID, agentId);

            List<AgentCLApprovedModel> model = new List<AgentCLApprovedModel>();

            foreach (var item in data)
            {
                var AgentCLApprovedModel = new AgentCLApprovedModel
                {
                    BranchOfficeName = item.BranchOfficeName,
                    DistributorName = item.DistributorName,
                    AgentName = item.AgentName,
                    AgentCode = item.AgentCode,
                    Currency = item.CurrencyCode,
                    Amount = item.Amount,
                    Comments = item.Narration1,
                    VoucherNo = item.VoucherNo,
                    CheckedBy = item.CreatedBy,
                    CheckerDate = item.CreatedDate
                };
                model.Add(AgentCLApprovedModel);
            }
            return model;
        }

        //public IEnumerable<AgentCLApprovedModel> GetAgentCLApprovedList(DateTime fromdate, DateTime todate, int? userId, int? distributorID, int? agentId)
        //{
        //    var Data = ent.GL_GetAgentRecepitList(fromdate, todate, userId, distributorID, agentId);

        //    List<AgentCLApprovedModel> agentclapprovedlist = new List<AgentCLApprovedModel>();
        //    foreach (var item in Data.Select(x => x))
        //    {
        //        AgentCLApprovedModel singleagentclapproved = new AgentCLApprovedModel()
        //        {
        //            BranchOfficeName = item.BranchOfficeName,
        //            DistributorName = item.DistributorName,
        //            AgentName = item.AgentName,
        //            AgentCode = item.AgentCode,
        //            Currency = item.CurrencyCode,
        //            Amount = item.Amount,
        //            Comments = item.Narration1,
        //            VoucherNo = item.VoucherNo,
        //            CheckedBy = item.CreatedBy,
        //            CheckerDate = item.CreatedDate
        //        };
        //        agentclapprovedlist.Add(singleagentclapproved);
        //    }
        //    return agentclapprovedlist;
        //}



    }
}