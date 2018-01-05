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
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class ProfileManagementController : Controller
    {

        UserManagementProvider ser = new UserManagementProvider();
        //
        // GET: /ProfileManagement/

        [Authorize]
        public virtual ViewResult UserDetails(Guid id)
        {
            // int recordsReturned;
            SqlProfileProvider myProfileProvider = new SqlProfileProvider();

            var user = Membership.GetUser(id);
            ViewData["Title"] = "User Details (" + user.UserName + ")";
            var data = new UserManagementModel.MembershipUserAndRolesViewData
            {
                RolesEnabled = Roles.Enabled,
                RequiresQuestionAndAnswer = Membership.RequiresQuestionAndAnswer,
                User = user,
                AllRoles = Roles.GetAllRoles().OrderBy(x => x).ToList(),
                UsersRoles = Roles.GetRolesForUser(user.UserName).OrderBy(x => x).ToList(),
                UserDetails = ser.GetUserDetails(id),
                //UserProfiles =   myProfileProvider.FindProfilesByUserName(ProfileAuthenticationOption.Authenticated,user.UserName,0,1, out recordsReturned  )                     
            };

            ViewData["User"] = data;
            return View("DisplayUser");
        }

        //////////////// End of Membership details //////////////////////////////////////
        public virtual RedirectToRouteResult SaveExistingUser()
        {
            var userName = Request.Form["UserName"];
            OnBeforeUpdateUser(userName);
            var user = Membership.GetUser(userName);
            UpdateModel(user, new[] { "Email", "Comment" });
            user.IsApproved = true;//((Request.Form["IsApproved"] ?? "").Trim().Equals("on", StringComparison.CurrentCultureIgnoreCase));
            Membership.UpdateUser(user);
            OnAfterUpdateUser(userName);
            return RedirectToUserPage(user);
        }


        public virtual RedirectToRouteResult AddUserToRole(string ProviderUserKey, string role)
        {
            Guid userId = new Guid(ProviderUserKey);
            var user = Membership.GetUser(userId);
            OnBeforeAddUserToRole(user.UserName, role);
            Roles.AddUserToRole(user.UserName, role);
            OnAfterAddUserToRole(user.UserName, role);
            return RedirectToUserPage(user);
        }

        public virtual RedirectToRouteResult UpdateDetails(string ProviderUserKey)
        {
            Guid userId = new Guid(ProviderUserKey);
            var user = Membership.GetUser(userId);
            UsersDetails details = ser.GetUserDetails(userId);
            details.UserId = userId;
            details.FullName = Request.Form["FullName"];
            details.UserAddress = Request.Form["Address"];
            details.MobileNumber = Request.Form["MobileNo"];
            details.PhoneNumber = Request.Form["PhoneNo"];
            details.AppUserId = details.AppUserId;
            ser.UpdateUserDetailsInfo(details);
            return RedirectToUserPage(user);
        }

        public virtual RedirectToRouteResult RemoveUserFromRole(string ProviderUserKey, string role)
        {
            Guid userId = new Guid(ProviderUserKey);
            var user = Membership.GetUser(userId);
            OnBeforeRemoveUserFromRole(user.UserName, role);
            Roles.RemoveUserFromRole(user.UserName, role);
            OnAfterRemoveUserFromRole(user.UserName, role);
            return RedirectToUserPage(user);
        }
        public virtual RedirectToRouteResult ResetPassword()
        {
            ViewData["Title"] = "Reset Password";

            var userName = Request.Form["UserName"];
            var pwdAnswer = Request.Form["PasswordAnswer"];

            OnBeforeResetPassword(userName, pwdAnswer);

            var user = Membership.GetUser(userName);
            // var pwd = user.ResetPassword(pwdAnswer);  //Commented 

            OnAfterResetPassword(user.Email, userName, pwdAnswer);

            // TempData["Password"] = pwd;
            return RedirectToUserPage(user);
        }
        public virtual RedirectToRouteResult ChangePassword()
        {
            var userName = Request.Form["UserName"];
            var oldPwd = Request.Form["OldPassword"];
            var newPwd = Request.Form["NewPassword"];
            var newPwdConfirm = Request.Form["NewPasswordConfirm"];

            OnBeforePasswordChange(userName, oldPwd, newPwd, newPwdConfirm);

            var user = Membership.GetUser(userName);
            if (newPwd == newPwdConfirm)
                user.ChangePassword(oldPwd, newPwd);
            else
            {
                TempData["Password"] = "\"New Password\" does not match \"Confirm New Password\".";

            }

            OnAfterPasswordChange(userName, oldPwd, newPwd, newPwdConfirm);

            return RedirectToUserPage(user);
        }
        //////////////  user update Non action region////////////////////////////////
        #region Non action region

        [NonAction]
        protected virtual void OnBeforeUpdateUser(string userName) { }

        [NonAction]
        protected virtual void OnAfterUpdateUser(string userName) { }

        [NonAction]
        protected virtual void OnBeforeUnlockUser(string id) { }

        [NonAction]
        protected virtual void OnAfterUnlockUser(string id) { }

        [NonAction]
        protected virtual void OnBeforeDeleteUser(string id) { }

        [NonAction]
        protected virtual void OnAfterDeleteUser(string id) { }

        [NonAction]
        protected virtual void OnBeforeAddUserToRole(string userName, string roleName) { }

        [NonAction]
        protected virtual void OnAfterAddUserToRole(string userName, string roleName) { }

        [NonAction]
        protected virtual void OnBeforeRemoveUserFromRole(string userName, string roleName) { }

        [NonAction]
        protected virtual void OnAfterRemoveUserFromRole(string userName, string roleName) { }

        [NonAction]
        protected virtual void OnBeforeResetPassword(string userName, string passwordAnswer) { }

        [NonAction]
        protected virtual void OnAfterResetPassword(string email, string userName, string newPassword) { }

        [NonAction]
        protected virtual void OnBeforePasswordChange(string userName, string currentPassword, string newPassword, string newPasswordConfirm) { }

        [NonAction]
        protected virtual void OnAfterPasswordChange(string userName, string currentPassword, string newPassword, string newPasswordConfirm) { }


        [NonAction]
        protected RedirectToRouteResult RedirectToUserPage(MembershipUser user)
        {
            var rvd = new RouteValueDictionary(new
            {
                controller = ControllerContext.RouteData.Values["controller"],
                action = "UserDetails",
                id = (Guid)user.ProviderUserKey
            });
            return RedirectToRoute(rvd);
        }

        ///////////////////////////////////////////////////////////////////
        #endregion

    }
}
