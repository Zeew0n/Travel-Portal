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
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AdminUserManagementProvider
    {
        public void CreateUser(ATLTravelPortal.Areas.Airline.Models.AdminUserManagementModel.CreateAdminAspUser obj)
        {
            EntityModel ent = new EntityModel();
            ent.CreateASPUser(obj.UserName, obj.Password, obj.Email,"ADMIN", null, obj.FullName, obj.Address, obj.MobileNo, obj.PhoneNo, (int)ATLTravelPortal.Helpers.UserTypes.User, obj.CreatedBy, "Holidays");

        }
        public IQueryable<vw_aspnet_MembershipUsers> ListAllAdminUser()
        {
            EntityModel ent = new EntityModel();
            return ent.vw_aspnet_MembershipUsers.Where(vv => vv.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.User).AsQueryable();
        }

        public IQueryable<vw_aspnet_MembershipUsers> ListAllAdminUser(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            EntityModel ent = new EntityModel();
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ent.vw_aspnet_MembershipUsers.Where(vv => vv.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.User).Count();
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
            IQueryable<vw_aspnet_MembershipUsers> pagingdata = ent.vw_aspnet_MembershipUsers.OrderBy(t => t.CreateDate).Where(vv => vv.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.User).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }
        public List<UserTypeRoleModel> GetAllRolesListForAdminUserCreation()
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.RoleUserTypeMappings
                      on aa.RoleId equals bb.RoleId
                      where (bb.UserTypeId == 3 && bb.CreatedBy == 0)
                      select new UserTypeRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

        }
    }
}