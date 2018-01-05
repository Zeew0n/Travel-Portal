#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
     
    public class DashboardProvider
    {
        EntityModel ent = new EntityModel();
        public string ItemIds { get; set; }
        public IEnumerable<GetAirlineAdminDashBoard_Result> GetDashboardData()
        {
            return ent.GetAirlineAdminDashBoard();
        }
        public List<Agents> ListAllAgent()
        {

            return ent.Agents.ToList();
        }
        public List<TravelPortalEntity.UserTypes> ListAllUserType()
        {
            return ent.UserTypes.ToList();
        }
        public IEnumerable<Air_GetAvailableBalance_Result > GetAvailableBalanceForAgent(int agentid)
        {
            return ent.Air_GetAvailableBalance(agentid);
        }
        //AgentMessageBoards

        public IEnumerable<AgentMessageBoards> GetAgentMessageType()
       {
             return ent.AgentMessageBoards.AsEnumerable();
       }

        public IQueryable<PNRs> ListAllTicketIssuedByAgent(int AgentId,int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = 5; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = ent.PNRs.Where(x => x.AgentId == AgentId).Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<PNRs> pagingdata = ent.PNRs.Where(x => x.AgentId == AgentId).OrderByDescending(t => t.CreatedDate).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
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