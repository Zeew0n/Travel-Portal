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
using ATLTravelPortal.Helpers.Pagination;
using System.Configuration;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class UserManagementProvider
    {
        TravelPortalEntity.EntityModel db = new TravelPortalEntity.EntityModel();
        public List<Core_Products> GetProductList()
        {
            return db.Core_Products.Where(tt => tt.isActive == true).ToList();
        }
        public IQueryable<View_AgentDetails> ListAllUser()
        {

            return db.View_AgentDetails.AsQueryable();
        }

        public IEnumerable<View_BranchDetails> GetAllBranchOfficeUsers(int BranchOfficeId)
        {

            return db.View_BranchDetails.Where(xx => xx.BranchOfficeId == BranchOfficeId).AsEnumerable();
        }

        public IEnumerable<View_DistributorDetails> GetAllDistributorOfficeUsers(int DistributorOfficeId)
        {

            return db.View_DistributorDetails.Where(xx => xx.DistributorId == DistributorOfficeId).AsEnumerable();
        }

        public IEnumerable<View_AgentDetails> GetAllAgentUsers(int AgentId)
        {

            return db.View_AgentDetails.Where(xx => xx.AgentId == AgentId).AsEnumerable();
        }

        public IQueryable<vw_aspnet_MembershipUsers> ListAllAdminUser()
        {

            return db.vw_aspnet_MembershipUsers.Where(vv => (vv.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.BackofficeUser || vv.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.MEs)).AsQueryable();
        }
        public IQueryable<vw_aspnet_MembershipUsers> ListAllRegisteredUser()
        {

            return db.vw_aspnet_MembershipUsers.Where(aa => aa.IsLockedOut == true).AsQueryable();
        }

        public aspnet_Membership GetEmail(Guid id)
        {
            return db.aspnet_Membership.SingleOrDefault(u => u.UserId == id);
        }
        public void UpdateEmail(AdminUserManagementModel.CreateAdminAspUser model)
        {
            aspnet_Membership tu = db.aspnet_Membership.Where(u => u.UserId == model.UserId).FirstOrDefault();
            tu.UserId = model.UserId;
            tu.Email = model.GetEmail.Email;
            tu.LoweredEmail = model.GetEmail.Email;
            db.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
            db.SaveChanges();
            /////
        }
        public void Save_aspUser(aspnet_Users user)
        {
            db.AddToaspnet_Users(user);
            db.SaveChanges();
        }

        public aspnet_Users GetUserinfo(Guid ID)
        {
            return db.aspnet_Users.SingleOrDefault(u => u.UserId == ID);
        }
        public string GetAgentUserNameByAgentID(int id)
        {
            return db.View_AgentDetails.Where(aa => aa.AgentId == id).OrderBy(aa => aa.CreateDate).FirstOrDefault().UserName;
        }

        public string GetAgentNameByAgentID(int id)
        {
            return db.Agents.Where(aa => aa.AgentId == id).FirstOrDefault().AgentName;
        }

        public string GetBranchNameByBranchID(int id)
        {
            return db.BranchOffices.Where(aa => aa.BranchOfficeId == id).FirstOrDefault().BranchOfficeName;
        }

        public string GetDistributorNameByDistributorID(int id)
        {
            return db.Distributors.Where(aa => aa.DistributorId == id).FirstOrDefault().DistributorName;
        }

        public string GetDistributorNameByAgentID(int id)
        {
            return db.Agents.Where(aa => aa.AgentId == id).FirstOrDefault().AgentName;
        }

        public string GetAgentEmailByAgentID(int id)
        {
            return db.Agents.Where(aa => aa.AgentId == id).FirstOrDefault().Email;
        }

        public string GetAgentUserFullNameByUserID(Guid id)
        {
            return db.UsersDetails.Where(aa => aa.UserId == id).FirstOrDefault().FullName;
        }
        public void UpdateUser(aspnet_Users table)
        {
            aspnet_Users tu = db.aspnet_Users.Where(u => u.UserId == table.UserId).FirstOrDefault();
            tu.UserId = table.UserId;
            db.ApplyCurrentValues(tu.EntityKey.EntitySetName, table);
            db.SaveChanges();
            /////
        }
        //check user
        public aspnet_Users CheckUser(string userName, string password)
        {

            aspnet_Users au = db.aspnet_Users.Include("aspnet_Membership").Where(uu => uu.UserName == userName).FirstOrDefault();

            if (au != null)
                return au;
            else
                return null;
        }
        public void UpdateUserDetailsInfo(UsersDetails table)
        {
            UsersDetails tu = db.UsersDetails.Where(u => u.UserId == table.UserId).FirstOrDefault();
            tu.UserId = table.UserId;
            db.ApplyCurrentValues(tu.EntityKey.EntitySetName, table);
            db.SaveChanges();
            /////
        }

        public IEnumerable<GetUserByApproveStatusByAgent_Result> GetUnppprovedUser(int AgentId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            return ent.GetUserByApproveStatusByAgent(false, AgentId);
        }

        public List<UserManagementModel.LockApprovedUserModel> GetUnapprovedAgentUserList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.GetUserByApproveStatus(false)
                      select new UserManagementModel.LockApprovedUserModel
                      {
                          UserName = aa.UserName,
                          AgentName = aa.AgentName,
                          Email = aa.Email,
                          IsApproved = aa.IsApproved,
                          UserId = aa.UserId,

                      }).ToList();
            return cc.ToList();
        }

        public List<UserManagementModel.LockApprovedUserModel> GetUnppprovedUserAdminUserList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ListAllAdminUser().Where(aa => aa.IsApproved == false)
                      select new UserManagementModel.LockApprovedUserModel
                      {
                          UserName = aa.UserName,
                          Email = aa.Email,
                          IsApproved = aa.IsApproved,
                          UserId = aa.UserId,
                          IsLockedOut = aa.IsLockedOut
                      }).ToList();
            return cc.ToList();
        }
        public List<UserManagementModel.LockApprovedUserModel> GetAllLockedUserList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ListAllRegisteredUser()
                      select new UserManagementModel.LockApprovedUserModel
                      {
                          AgentName = aa.AgentName,
                          UserName = aa.UserName,
                          Email = aa.Email,
                          IsApproved = aa.IsApproved,
                          UserId = aa.UserId,
                          IsLockedOut = aa.IsLockedOut
                      }).ToList();
            return cc.ToList();
        }



        public void ApproveUsers(Guid userIds)
        {
            MembershipUser usr = Membership.GetUser(userIds);
            if (usr != null && !usr.IsApproved)
            {
                // Approve the user
                usr.IsApproved = true;
                Membership.UpdateUser(usr);
            }
        }

        public void UnLockUser(Guid uerId)
        {
            MembershipUser usr = Membership.GetUser(uerId);
            if (usr != null)
            {
                // unlock the user
                usr.UnlockUser();
                Membership.UpdateUser(usr);
            }
        }
        public void CreateUser(UserManagementModel.CreateAspUser obj, int usertypeid)
        {
            db.CreateASPUser(obj.UserName,
                obj.Password,
                obj.Email,
                usertypeid == 5 ? "BRANCH" : (usertypeid == 6 ? "DIS" : "AGENT"),
                obj.AgentId,//(usertypeid == 5 || usertypeid == 6) ? null : (int?)obj.AgentId,
                obj.FullName, obj.Address,
                obj.MobileNo,
                obj.PhoneNo,
                usertypeid,
                obj.CreatedBy,
                ConfigurationManager.AppSettings["ApplicationName"]);
        }
        public bool ValidateUser(string userName, string password)
        {

            if (Membership.ValidateUser(userName, password) == true)
                return true;
            else return false;
        }
        public List<RoleBasedRoleModel> GetAllRolesListonProductWise(int ProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where bb.ProductId == ProductId && bb.Core_SubProduct.SubProductName == "Agent"
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                          ProductId = bb.ProductId,
                      }).ToList();
            return cc;

        }


        public UsersDetails GetUserDetails(Guid ID)
        {
            return db.UsersDetails.SingleOrDefault(u => u.UserId == ID);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        ///  

        public IQueryable<RoleBasedRoleModel> FindAllRolesForAdmin()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      // where bb.CreatedBy == 0
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                          ProductId = bb.ProductId,
                          ProductName = bb.Core_Products.ProductName,
                          SubProductName = bb.Core_SubProduct.SubProductName
                      }).AsQueryable();

            return cc;

            //return Roles.GetAllRoles().AsQueryable();
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public List<RoleBasedRoleModel> GetAllRolesListForAgent(int agentid)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      //where (bb.CreatedBy == agentid || (bb.UserTypeId == 2 && bb.CreatedBy == 0))
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                          ProductId = bb.ProductId,
                          ProductName = bb.Core_Products.ProductName
                      }).ToList();
            return cc;

        }
        /// <summary>
        /// /Admin Role Paging 
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="currentPageNo"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public IQueryable<RoleBasedRoleModel> GetAllRoleForAdminByByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = FindAllRolesForAdmin().Count();
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
            IQueryable<RoleBasedRoleModel> pagingdata = FindAllRolesForAdmin().OrderBy(t => t.RoleId).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }

        /// <summary>
        /// /agent role paging
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="currentPageNo"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public IQueryable<RoleBasedRoleModel> GetAllRoleForAgentByByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag, int agentid)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = GetAllRolesListForAgent(agentid).Count();
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
            IQueryable<RoleBasedRoleModel> pagingdata = GetAllRolesListForAgent(agentid).OrderBy(t => t.RoleId).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }

        public List<aspnet_Roles> GetAllRolesList()
        {
            return db.aspnet_Roles.ToList();

        }
        public void CreateRole(string roleName)
        {
            Roles.CreateRole(roleName);
        }
        public void DeleteRole(string rolename)
        {
            RoleUserTypeMappings model = new RoleUserTypeMappings();
            aspnet_Roles role = GetRoleInfoByName(rolename);
            db.Core_DeleteRole(role.RoleId);
        }
        public Guid GetIdbyRolename(string rolename)
        {
            aspnet_Roles roles = GetRoleInfoByName(rolename);
            return roles.RoleId;
        }
        public aspnet_Roles GetRoleInfoByName(string roelname)
        {
            return db.aspnet_Roles.SingleOrDefault(u => u.RoleName == roelname);

        }

        public void Save_RoleUserTypeMapping(Core_ProductRoles mappinfo)
        {
            db.AddToCore_ProductRoles(mappinfo);
            db.SaveChanges();
        }


        /// <summary>
        /// /
        /// </summary>
        /// <param name="lgh"></param>
        public void Save_LoginHistory(LoginHistories lgh)
        {
            db.AddToLoginHistories(lgh);
            db.SaveChanges();
        }
        /// <summary>
        /// Get Login History Admin
        /// </summary>
        /// <returns></returns>
        /// 



        /// <summary>
        /// Get Login History Agent
        /// </summary>
        /// <param name="AgentId"></param>
        /// <returns></returns>
        public IEnumerable<GetLoginHistoryByAgent_Result> GetLoginHistoryList(int AgentId)
        {
            return db.GetLoginHistoryByAgent(AgentId).OrderByDescending(xx => xx.HistoryId).AsQueryable();
        }



        public bool CheckDuplicateUsername(string userName)
        {
            aspnet_Users tu = db.aspnet_Users.Where(ii => ii.UserName == userName).FirstOrDefault();
            if (tu != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void EditUserInfo(AdminUserManagementModel.CreateAdminAspUser model)
        {
            UsersDetails result = db.UsersDetails.Where(x => x.UserId == model.UserId).FirstOrDefault();


            result.UserTypeId = (model.IsSalesMarketingUser != true ? ((int)ATLTravelPortal.Helpers.UserTypes.BackofficeUser) : ((int)ATLTravelPortal.Helpers.UserTypes.MEs));

            result.UserAddress = model.UserInfo.UserAddress;
            result.PhoneNumber = model.UserInfo.PhoneNumber;
            result.MobileNumber = model.UserInfo.MobileNumber;
            result.FullName = model.UserInfo.FullName;

            db.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            db.SaveChanges();
        }


        public void EditRoleInfo(AdminUserManagementModel.CreateAdminAspUser model)
        {


            Core_ProductRoles result = db.Core_ProductRoles.Where(x => x.RoleId == model.RoleId).FirstOrDefault();
            result.RoleId = model.RoleId;
            result.ProductId = model.ProductId;
            result.SubProductId = 1;

            db.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            db.SaveChanges();
        }






    }
}