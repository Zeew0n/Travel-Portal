using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
     
    public class DashboardProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public string ItemIds { get; set; }
        public IEnumerable<GetAirlineAdminDashBoard_Result> GetDashboardData()
        {
            return ent.GetAirlineAdminDashBoard();
        }
        public List<Agents> ListAllAgent()
        {

            return ent.Agents.ToList();
        }
        public List<UserTypes> ListAllUserType()
        {
            return ent.UserTypes.ToList();
        }
        //public IEnumerable<GetNetAvailableBalance_Result> GetAvailableBalanceForAgent(int agentid)
        //{
        //    return ent.GetNetAvailableBalance(agentid);
        //}
        //AgentMessageBoards

        public IEnumerable<AgentMessageBoards> GetAgentMessageType()
       {
             return ent.AgentMessageBoards.AsEnumerable();
       }

      

        //private string[] GetAgentidArray(string value)
        //{
        //    // check the action names for the project status
        //    if (string.IsNullOrEmpty(value))
        //    {
        //        value = "";
        //    }
        //    string[] stringArray = value.Split(',');
        //    for (int k = 0; k < stringArray.Length; k++)
        //    {
        //        stringArray[k] = stringArray[k].ToLower().Trim();
        //    }
        //    return stringArray;
        //}
    } 
}