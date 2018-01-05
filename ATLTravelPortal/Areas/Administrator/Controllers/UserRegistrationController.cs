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
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Routing;
using System.Web.Security;
using System.Collections;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;
using System.Web;
using System.Net.Mail;
using System.Net;


namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Details = "LockUnlockUser", Edit = "Edit", Delete = "Delete", Custom1 = "ResetPassword", Order = 2)]
    public class UserRegistrationController : Controller
    {
        private const int defaultPageSize = 30;
        UserManagementProvider ser = new UserManagementProvider();
        AdminUserManagementRepository pro = new AdminUserManagementRepository();

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            TempData["Flag"] = true;
            var model = pro.ListAllAdminUserForPagination().ToPagedList(currentPageIndex, defaultPageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("UserPartial", model);
            }
            return View(model);
        }

        //
        // GET: /AdminUserManagement/
        public ActionResult Create()
        {
            var viewmodel = new AdminUserManagementModel.CreateAdminAspUser
            {

                ProductBaseRoleList = pro.GetProductList(),
                RoleList = pro.GetAllRolesList(),

            };
            ViewData["RoleAssign"] = new SelectList("", "RoleName", "RoleName", "");
            return View(viewmodel);
        }

        [HttpPost]

        public ActionResult Create(AdminUserManagementModel.CreateAdminAspUser model, int[] ChkProductId, FormCollection fc)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = obj.AppUserId;
            if (ChkProductId == null)
            {
                //// Validate to Choose atleast one product //////////
                TempData["ErrorMessage"] = "Please Choose Atleast one Product.";
                ViewData["RoleAssign"] = new SelectList("", "RoleName", "RoleName", "");
                var viewmodel = new AdminUserManagementModel.CreateAdminAspUser
                {
                    ProductBaseRoleList = pro.GetProductList(),
                     RoleList = pro.GetAllRolesList(),
                };
                return RedirectToAction("Create", viewmodel);
            }
            if (model.Password != model.ConfirmPassword || model.UserName == "")
            {
                TempData["ErrorMessage"] = "Registration failed! Either Enter Username or Your passwords must match, please re-enter and try again";
                ViewData["RoleAssign"] = new SelectList("", "RoleName", "RoleName", "");
                var viewmodel = new AdminUserManagementModel.CreateAdminAspUser
                {
                    ProductBaseRoleList = pro.GetProductList(),
                    RoleList = pro.GetAllRolesList(),
                };
                return RedirectToAction("Create", viewmodel);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////
            // ************ Save User membership in database ************************************************
            //////////////////////////////////////////////////////////////////////////////////////////////////
            pro.CreateUser(model);
            int AppuserId = pro.GetLastAppUserId().ToList().Last().AppUserId;  ////Get UserId
            model.UserAppId = AppuserId;

            Guid UserId = pro.GetLastAppUserId().ToList().Last().UserId; ////Get UserId
            pro.UpdateAspnet_Membership(UserId);
            //////// Collecting Product and corresponding Role ///////////////
            List<int> ProductIds = new List<int>();
            ProductIds = new List<int>();
            foreach (int cid in ChkProductId)
            {
                ProductIds.Add(cid);
                model.ProductId = cid;   
                pro.CreateUserInProduct(model);
            }
            //////////////collect Agent Associate Product and save /////////////////////////////////////////////////////////////
            List<int> ChkProductIdS = new List<int>();
            foreach (int pid in ChkProductId)
            {
                ChkProductIdS.Add(pid);
                /////////  Save individual User Roles in database ////
                model.AgentRole = fc["RoleId"] ?? fc["RoleId" + pid];

                Roles.AddUserToRole(model.UserName, model.AgentRole);
            }


            //// If success Return Back to list
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid id)
        {
           
             RoleBasedRoleModel model = new RoleBasedRoleModel();

            
            var viewmodel = new AdminUserManagementModel.CreateAdminAspUser
            {
                UserInfo = ser.GetUserDetails(id),
                GetUserName = ser.GetUserinfo(id),
                GetEmail = ser.GetEmail(id),
                ProductBaseRoleList = pro.GetUserAssociatedRolewithProduct(id),
                AdminProductList = pro.GetProductListId(1),
                //RoleList = pro.GetAllRolesList(),

            };
            viewmodel.IsSalesMarketingUser = viewmodel.UserInfo.UserTypeId != (int)ATLTravelPortal.Helpers.UserTypes.User ? true : false;

           //List<RoleBasedRoleModel> UserAssignRoleList= pro.GetUserAssociatedRolewithProduct(id);
            foreach (var AsociatedProductOfUser in viewmodel.ProductBaseRoleList)
            {
                ViewData[AsociatedProductOfUser.ProductName] = new SelectList(pro.GetAllRolesListonProductWiseForAdminUser(AsociatedProductOfUser.ProductId), "RoleName", "RoleName", AsociatedProductOfUser.RoleName);
            }
            return View(viewmodel);

        }
        [HttpPost]
        public ActionResult Edit(AdminUserManagementModel.CreateAdminAspUser model, Guid id, int[] ChkProductId, FormCollection fc)
        {
            model.UserId = id;
            MembershipUser user;
            user = Membership.GetUser(model.UserId);
            //user.Email =model.GetUserName.aspnet_Membership.Email ;
            Membership.UpdateUser(user);
            ser.UpdateEmail(model);
            ser.EditUserInfo(model);
            var UserInfo = ser.GetUserDetails(id);
            List<string> roleList = pro.RetrieveAllUserRoles(model.UserId);
            // firstly delete all roles in user
            if (roleList.Count() != 0)
            {
                Roles.RemoveUserFromRoles(model.GetUserName.UserName, roleList.ToArray());
            }
            foreach (int pid in ChkProductId)
            {
                // check if current product exist for current user or not
                pro.CheckExistanceofUserProduct(UserInfo.AppUserId, pid);
                /////////  Save individual User Roles in database ////
                model.AgentRole = fc["RoleId"] ?? fc["RoleId" + pid];
               Roles.AddUserToRole(model.GetUserName.UserName, model.AgentRole);
            }

          
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult LockUnlockUser(string id)
        {
            var session = (TravelSession)Session["TravelSessionInfo"];

            MembershipUser muUser = Membership.GetUser(id);
            if (muUser.IsLockedOut)
            {
                Membership.GetUser(id).UnlockUser();
                muUser.IsApproved = true;
                Membership.UpdateUser(muUser);
            }
            else
            {
                muUser.IsApproved = false;
                pro.LockUserNow(id);
                Membership.UpdateUser(muUser);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                TravelPortalEntity.EntityModel ent = new EntityModel();
                UsersDetails userDetails = ent.UsersDetails.Where(x => x.UserId == id).FirstOrDefault();

                List<Core_UserProducts> userprod = ent.Core_UserProducts.Where(x => x.UserId == userDetails.AppUserId).ToList();
                if (userprod != null)
                {
                    foreach (var item in userprod)
                    {
                        Core_UserProducts data = item;
                        if (data != null)
                        {
                            ent.DeleteObject(data);
                            ent.SaveChanges();
                        }
                    }
                }

                if (userDetails != null)
                {
                    ent.DeleteObject(userDetails);
                    ent.SaveChanges();
                }

                List<LoginHistories> loginResult = ent.LoginHistories.Where(x => x.UserId == id).ToList();

                foreach (var item in loginResult)
                {
                    LoginHistories rec = item;
                    ent.DeleteObject(rec);
                    ent.SaveChanges();
                }
                
                aspnet_Users user = ent.aspnet_Users.Where(x => x.UserId == id).FirstOrDefault();
                Membership.DeleteUser(user.UserName, true);
               
            }
            catch
            { }
            return RedirectToAction("Index");

        }
        public ActionResult ResetPassword(string id)
        {
            UserManagementProvider _UserManagementRepo = new UserManagementProvider();
            try
            {

                MembershipUser mbruser = Membership.GetUser(id);
                Guid userId = new Guid(mbruser.ProviderUserKey.ToString());
                string UserFullName = _UserManagementRepo.GetAgentUserFullNameByUserID(userId);
                string password = mbruser.ResetPassword();
                TempData["TemoResetPassword"] = password;
                mbruser.Comment = "MustChangePassword";
                Membership.UpdateUser(mbruser);
            }

            catch (Exception ex)
            {
                TempData["ResponseMsg"] = "Password can not reset due to-  " + ex.Message;
            }
            return RedirectToAction("Index");

        }

        


    }
}
