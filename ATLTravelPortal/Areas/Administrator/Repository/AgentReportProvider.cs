using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentReportProvider
    {

        EntityModel ent = new EntityModel();

        public List<AgentReportModel> GetAgentInfo()
        {
            int sno = 0;
            var data = ent.Core_GetAgentInfo();
            List<AgentReportModel> model = new List<AgentReportModel>();
            foreach (var item in data)
            {
                sno++;
                AgentReportModel agentreportmodel = new AgentReportModel();
                agentreportmodel.SNO = sno;
                agentreportmodel.AgentName = item.AgentName;
                agentreportmodel.AgentCode = item.AgentCode;
                agentreportmodel.Address = item.Address;
                agentreportmodel.Email = item.Email;
                agentreportmodel.Phone = item.Phone;
                agentreportmodel.mobile = item.MobileNo;
                agentreportmodel.zonename = item.ZoneName;
                agentreportmodel.districtname = item.DistrictName;
                agentreportmodel.signupby = item.SignupBy;
                agentreportmodel.SignupDate =  item.SingupDate;
                agentreportmodel.Type = item.Type;
                agentreportmodel.BranchName = GetBranchNameByAgentCode(agentreportmodel.AgentCode);
                agentreportmodel.DistributorName = GetDistributorNameByAgentCode(agentreportmodel.AgentCode);
                agentreportmodel.MEsName = GetMEsNameByAgentCode(agentreportmodel.AgentCode);
                model.Add(agentreportmodel);

            }
            return model.OrderBy(x => x.AgentName).ToList();
            

        }

        public string GetBranchNameByAgentCode(string agentcode)
        {
            var res = ent.Agents.Where(x => x.AgentCode == agentcode).Select(x => x.BranchOffices.BranchOfficeName).FirstOrDefault();
            return res;
        }
        public string GetDistributorNameByAgentCode(string agentcode)
        {
            var res = ent.Agents.Where(x => x.AgentCode == agentcode).Select(x => x.Distributors.DistributorName).FirstOrDefault();
            return res;
        }
        public string GetMEsNameByAgentCode(string agentcode)
        {
            int? MEsId = ent.Agents.Where(x => x.AgentCode == agentcode).Select(x=>x.MEsId).FirstOrDefault();
            if (MEsId > 0)
            {
                string MEsName = ent.UsersDetails.Where(x => x.AppUserId == MEsId).Select(x => x.FullName).FirstOrDefault();
                return MEsName;
            }
            else
                return null;
        }
       
    }
}