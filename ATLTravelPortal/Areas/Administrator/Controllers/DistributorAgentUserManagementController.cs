using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Administrator.Repository;
using TravelPortalEntity;
using System.Web.Security;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    //[PermissionDetails(View = "Index", Add = "ResetPassword", Edit = "LockUnlockAgentUser", Order = 2)]
    public class DistributorAgentUserManagementController : Controller
    {

        UserManagementProvider _UserManagementRepo = new UserManagementProvider();
        AdminUserManagementRepository _AdminUserRepo = new AdminUserManagementRepository();
       
          

        public ActionResult Index(int id)
        {
            IEnumerable<View_DistributorDetails> model = _UserManagementRepo.GetAllDistributorOfficeUsers(id);
            string DistributorOfficeName = _UserManagementRepo.GetDistributorNameByDistributorID(id);
            ViewData["DistributorOfficeName"] = DistributorOfficeName;
            TempData["DistributorOfficeId"] = id;
            return View(model);
        }

      

        public ActionResult ResetPassword(string id)
        {
            int DistributorOfficeId = (int)TempData["DistributorOfficeId"];
            try
            {

                MembershipUser mbruser = Membership.GetUser(id);
                Guid userId = new Guid(mbruser.ProviderUserKey.ToString());
                string UserFullName = _UserManagementRepo.GetAgentUserFullNameByUserID(userId);
                string password = mbruser.ResetPassword();
                TempData["TemoResetPassword"] = password;
                mbruser.Comment = "MustChangePassword";
                Membership.UpdateUser(mbruser);
                return RedirectToAction("Index", "DistributorAgentUserManagement", new { @id = DistributorOfficeId });
            }

            catch (Exception ex)
            {
                TempData["ResponseMsg"] = "Email Cannot sent due to error - " + ex.Message;
                return RedirectToAction("Index", "DistributorAgentUserManagement", new { @id = DistributorOfficeId });
            }

        }
      

        [HttpGet]
        public ActionResult LockUnlockDistributorUser(string id)
        {
            var session = (TravelSession)Session["TravelSessionInfo"];
            int DistributorOfficeId = (int)TempData["DistributorOfficeId"];
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
                _AdminUserRepo.LockUserNow(id);
                Membership.UpdateUser(muUser);
            }
            return RedirectToAction("Index", "DistributorAgentUserManagement", new { @id = DistributorOfficeId });
        }
    }
}
