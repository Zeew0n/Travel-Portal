using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AdminUserManagementRepository
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

    

        public List<aspnet_Roles> GetRoleList()
        {

            return ent.aspnet_Roles.ToList();
        }

        public List<SelectListItem> GetAllRoleList()
        {
            List<aspnet_Roles> all = GetRoleList().ToList();
            var RoleList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.RoleName,
                    Value = item.RoleId.ToString()
                };
                RoleList.Add(teml);
            }
            return RoleList.ToList();
        }

        public List<RoleBasedRoleModel> GetProductList()
        {
            var cc = (from aa in ent.Core_Products.Where(tt => tt.isActive == true)

                      select new RoleBasedRoleModel
                      {
                          ProductId = aa.ProductId,
                          ProductName = aa.ProductName,
                          // RoleList = GetAllRoleList().ToList()
                      }).ToList();
            return cc;
        }

        public void CheckExistanceofUserProduct(int UserId,int productid)
        {
           TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
           var product = ent.Core_UserProducts.Where(xx => xx.UserId == UserId && xx.ProductId == productid).ToList();
           if (product.Count() == 0)
           {
               Core_UserProducts obj = new Core_UserProducts
             {
                 ProductId = productid,
                 UserId = UserId,
             };
            ent.AddToCore_UserProducts(obj);
            ent.SaveChanges();
           }
          
        }

        public List<string> RetrieveAllUserRoles(Guid UserId)
        { 
           
           var rolelist = ent.vw_aspnet_UsersInRoles.Where(xx => xx.UserId == UserId).ToList();
           List<string> AllroleList = new List<string>();
           foreach (var role in rolelist)
           {
               aspnet_Roles individualrole = GetRoleInfoByName(GETRolename(role.RoleId));
               AllroleList.Add(individualrole.RoleName);
           }
           return AllroleList;
        }

        public aspnet_Roles GetRoleInfo(Guid roleid)
        {
            return ent.aspnet_Roles.SingleOrDefault(u => u.RoleId == roleid);

        }

        public string GETRolename(Guid roleid)
        {
            aspnet_Roles roles = GetRoleInfo(roleid);
            return roles.RoleName;
        }

        public aspnet_Roles GetRoleInfoByName(string roelname)
        {
            return ent.aspnet_Roles.SingleOrDefault(u => u.RoleName == roelname);

        }
        public List<RoleBasedRoleModel> GetProductListId(int id)
        {
            List<RoleBasedRoleModel> cc = null;
            if (id == 1)
            {
                cc = (from aa in ent.Core_Products.Where(tt => tt.isActive == true)

                      select new RoleBasedRoleModel
                      {
                          ProductId = aa.ProductId,
                          ProductName = aa.ProductName,
                          // RoleList = GetAllRoleList().ToList()
                      }).ToList();
            }
            return cc;
        }

        public void LockUserNow(String UserName)
        {
            var obj = ent.aspnet_Membership.Where(x => x.aspnet_Users.UserName == UserName).ToList().LastOrDefault();
            obj.IsLockedOut = true;
            ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
            ent.SaveChanges();
        }
        public void CreateUser(AdminUserManagementModel.CreateAdminAspUser obj)
        {
            ent.CreateASPUser(obj.UserName, obj.Password, obj.Email, "ADMIN", null, obj.FullName, obj.Address, obj.MobileNo, obj.PhoneNo, (obj.IsSalesMarketingUser != true ? ((int)ATLTravelPortal.Helpers.UserTypes.BackofficeUser) : ((int)ATLTravelPortal.Helpers.UserTypes.MEs)), obj.CreatedBy, "Holidays");

        }
        public IQueryable<UsersDetails> GetLastAppUserId()
        {
            return ent.UsersDetails.AsQueryable();
        }


        public void UpdateAspnet_Membership(Guid UserId)
        {
            var obj = ent.aspnet_Membership.Where(x => x.UserId == UserId).FirstOrDefault();
            obj.IsApproved = true;
            ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
            ent.SaveChanges();
        }


        public IQueryable<vw_aspnet_MembershipUsers> ListAllAdminUser()
        {
            return ent.vw_aspnet_MembershipUsers.Where(vv => vv.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.User).AsQueryable();
        }

        //public IQueryable<vw_aspnet_MembershipUsers> ListAllAdminUserForPagination()
        //{
        //    Guid[] id = ent.aspnet_UsersAgentRelation.Select(z => z.UserId).ToArray();
        //    IQueryable<vw_aspnet_MembershipUsers> pagingdata = ent.vw_aspnet_MembershipUsers.OrderBy(t => t.UserName).Where(x => (x.UserTypeId == 2 || x.UserTypeId == 4) && x.AgentName == "BOU").AsQueryable();
        //    return pagingdata;
        //}
        ////SURAJ HERE
        public IQueryable<vw_BackofficeUsers> ListAllAdminUserForPagination()
        {
            Guid[] id = ent.aspnet_UsersAgentRelation.Select(z => z.UserId).ToArray();
            IQueryable<vw_BackofficeUsers> pagingdata = ent.vw_BackofficeUsers.OrderBy(t => t.UserName).AsQueryable();
            return pagingdata;
        }

        public List<AdminUserManagementModel.CreateAdminAspUser> ListGetUserRoles(Guid? id)
        {
           
            var result = ent.Core_GetUserRoles(id);
            List<AdminUserManagementModel.CreateAdminAspUser> model = new List<AdminUserManagementModel.CreateAdminAspUser>();
            foreach (var item in result)
            {

                AdminUserManagementModel.CreateAdminAspUser obj = new AdminUserManagementModel.CreateAdminAspUser();
              
                obj.RolesName = item.RoleName;
                obj.RolesOn = item.RoleOn;

                model.Add(obj);
            }
            return model;
        }





        public List<RoleBasedRoleModel> GetAllRolesBasedonProduct(int ProductId)
        {
         
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where bb.ProductId == ProductId
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

        }


        public List<RoleBasedRoleModel> GetAllRolesBasedonSubProduct(int SubProductId)
        {

            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where bb.SubProductId == SubProductId
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

        }



        //For filling the  Dropdownlist
        public List<RoleBasedRoleModel> GetRolesList(int SubProductId)
        {
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where bb.SubProductId == SubProductId
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;
        }



        public IEnumerable<SelectListItem> GetAllRolesList()
        {
            List<RoleBasedRoleModel> all = GetRolesList(1).ToList();
            var GetAllRolesList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.RoleName,
                    Value = item.RoleId.ToString()
                };
                GetAllRolesList.Add(teml);
            }
            return GetAllRolesList.AsEnumerable();
        }

        

        public void CreateUserInProduct(AdminUserManagementModel.CreateAdminAspUser model)
        {
           
            Core_UserProducts obj = new Core_UserProducts
            {
                ProductId = model.ProductId,
                UserId = model.UserAppId,
            };

            ent.AddToCore_UserProducts(obj);
            ent.SaveChanges();
        }

        ////////////////////////////  Associated User Product List  ////////////////////////////////////////////////////
        public List<RoleBasedRoleModel> GetAllAssociatedProductofAdminUser(Guid userid)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.Core_Products
                      join bb in ent.Core_UserProducts
                      on aa.ProductId equals bb.ProductId
                      where bb.UsersDetails.UserId == userid
                      select new RoleBasedRoleModel
                      {
                          ProductName = aa.ProductName,
                          ProductId = aa.ProductId,
                      }).ToList();
            return cc;
        }

        public List<RoleBasedRoleModel> GetAllRolesListonProductWiseForAdminUser(int ProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where bb.ProductId == ProductId && bb.Core_SubProduct.SubProductName == "Administrator"
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                          ProductId = bb.ProductId,
                          ProductName=bb.Core_Products.ProductName
                      }).ToList();
            return cc;

        }

        public Guid GetRoleIdBasedOnUserId(Guid id)
        {
            vw_aspnet_UsersInRoles result = ent.vw_aspnet_UsersInRoles.Where(x => x.UserId == id).FirstOrDefault();
            return  result.RoleId;

        }

        public string GetCreatedBy(Guid id)
        {
            UsersDetails result = ent.UsersDetails.Where(x => x.UserId == id).FirstOrDefault();
             UsersDetails Createdbyresult=ent.UsersDetails.Where(x => x.AppUserId == result.CreatedBy).FirstOrDefault();
            return Createdbyresult.FullName;

        }

        public List<RoleBasedRoleModel> GetUserAssociatedRolewithProduct(Guid UserId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();


            var result = (from a in ent.vw_aspnet_UsersInRoles
                          join b in ent.aspnet_Roles on a.RoleId equals b.RoleId
                          join c in ent.Core_ProductRoles on a.RoleId equals c.RoleId
                          where a.UserId == UserId
                          select new RoleBasedRoleModel
                          {
                              RoleId = b.RoleId,
                              RoleName = b.RoleName,
                              ProductId = c.ProductId,
                              ProductName=c.Core_Products.ProductName
                          }).ToList();
            return result;
        }



    }
}