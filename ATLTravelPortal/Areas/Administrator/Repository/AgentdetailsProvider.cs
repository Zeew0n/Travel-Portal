
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
using System.Web.Security;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentdetailsProvider
    {
        TravelPortalEntity.EntityModel db = new TravelPortalEntity.EntityModel();

        public IQueryable <View_AgentDetails> ListAllAgentUser(int AgentId)
        {

            return db.View_AgentDetails.Where(uu => uu.AgentId == AgentId).AsQueryable();
        }
        public View_AgentDetails GetAgentAdminUser(int AgentId)
        {
            View_AgentDetails SuperAgentdetails=db.View_AgentDetails.Where(uu => (uu.AgentId == AgentId && uu.UserTypeId == 2)).FirstOrDefault();

            return SuperAgentdetails;
        }

        public IQueryable<View_AgentDetails> ListAllAgentUserByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag, int agentid)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ListAllAgentUser(agentid).Count();
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
            IQueryable<View_AgentDetails> pagingdata = ListAllAgentUser(agentid).OrderBy(t => t.AgentId).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }
        public List<RoleBasedRoleModel> GetAllRolesListForAgent(int agentid)
        {
          
            var cc = (from aa in db.aspnet_Roles
                      join bb in db.RoleUserTypeMappings
                      on aa.RoleId equals bb.RoleId
                      where (bb.CreatedBy == agentid || (bb.UserTypeId == 2 && bb.CreatedBy == 0))
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

        }
        public List<AgentBanks> GetAgentBankList(int AgentId)
        {

            return db.AgentBanks.Where(ab => ab.AgentId == AgentId).ToList();
        }
        public List<IPControlLists> GetAgentIPList(int AgentId)
        {

            return db.IPControlLists.Where(ab => ab.AgentId == AgentId).ToList();
        }

      
    }
}