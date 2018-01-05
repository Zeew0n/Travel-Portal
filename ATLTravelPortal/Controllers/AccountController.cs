using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ATLTravelPortal.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Helpers;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }
        GeneralRepository generalProvider = new GeneralRepository();
        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            GDS.Communication.GDSLogin.LogOut();
            UserEnvironmentVariables uenv = new UserEnvironmentVariables();
            uenv.SetLogOut();
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                Guid userId = new Guid();

                if ((generalProvider.ValidateUser(model.UserName, model.Password) == true) 
                    && (generalProvider.ValidateUnameAndPassword(model.UserName, model.Password, out userId)) == true)
                {

                    
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    UserEnvironmentVariables uenv = new UserEnvironmentVariables();
                    uenv.SetLogOn(userId, model.RememberMe);
                    TravelSession obj = SessionStore.GetTravelSession();
                    
                    GDS.Communication.GDSLogin.Login(new GDS.Communication.AgentInfo() { AgentId = 1 });

                    MembershipUser user = Membership.GetUser(model.UserName);
                    if (returnUrl == "/")
                    {
                        returnUrl = "";
                    }
                    if (IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {                   
                        switch (obj.UserTypeId)
                        { 
                            case (int)ATLTravelPortal.Helpers.UserTypes.SuperUser:
                            case (int)ATLTravelPortal.Helpers.UserTypes.User:
                            case (int)ATLTravelPortal.Helpers.UserTypes.MEs:
                            case (int)ATLTravelPortal.Helpers.UserTypes.BackofficeUser:
                                return RedirectToAction("Index", "Home");                                
                            case (int)ATLTravelPortal.Helpers.UserTypes.BranchUser:
                                return RedirectToAction("Index", "BranchOfficeDashboard", new { area = "" });                             
                            case (int)ATLTravelPortal.Helpers.UserTypes.DistributorUser:
                                return RedirectToAction("Index", "DistributorDashboard", new { area = "" });  
                            case (int)ATLTravelPortal.Helpers.UserTypes.CRMUser:
                                return RedirectToAction("Index", "CRMDashboard", new { area = "" }); 
                            default:
                                return RedirectToAction("logon", "account");
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    ViewData["message"] = "Invalid username or password!";
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOut()
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            if (obj != null)
            {
                MembershipUser usr = Membership.GetUser(obj.Id);
                LoginHistories lgh = new LoginHistories();
                lgh.LogedinDateTime = usr.LastLoginDate;
                lgh.LogedoutDateTime = DateTime.Now;
                lgh.UserId = obj.Id;
                 generalProvider.Save_LoginHistory(lgh);
            }
            FormsService.SignOut();
            GDS.Communication.GDSLogin.LogOut();            
            UserEnvironmentVariables uenv = new UserEnvironmentVariables();
            uenv.SetLogOut();
            return RedirectToAction("logon","account");
        }


        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
        private bool IsLocalUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            Uri absoluteUri;
            if (Uri.TryCreate(url, UriKind.Absolute, out absoluteUri))
            {
                return String.Equals(this.Request.Url.Host, absoluteUri.Host, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                bool isLocal = !url.StartsWith("http:", StringComparison.OrdinalIgnoreCase)
                    && !url.StartsWith("https:", StringComparison.OrdinalIgnoreCase)
                    && Uri.IsWellFormedUriString(url, UriKind.Relative);
                return isLocal;
            }
        }

    }
}
