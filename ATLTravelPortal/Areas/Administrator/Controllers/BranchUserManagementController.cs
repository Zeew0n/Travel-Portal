using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Repository;
using System.Web.Security;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class BranchUserManagementController : Controller
    {
        //
        // GET: /Administrator/BranchUserManagement/
        UserManagementProvider _UserManagementRepo = new UserManagementProvider();
        AdminUserManagementRepository _AdminUserRepo = new AdminUserManagementRepository();

        public ActionResult Index(int id)
        {
            IEnumerable<View_BranchDetails> model = _UserManagementRepo.GetAllBranchOfficeUsers(id);
            string BranchOfficeName = _UserManagementRepo.GetBranchNameByBranchID(id);
            ViewData["BranchOfficeName"] = BranchOfficeName;
            TempData["BranchOfficeId"] = id;
            return View(model);
        }



        public ActionResult ResetPassword(string id)
        {
            int BranchOfficeId = (int)TempData["BranchOfficeId"];
            try
            {

                MembershipUser mbruser = Membership.GetUser(id);
                Guid userId = new Guid(mbruser.ProviderUserKey.ToString());
                string UserFullName = _UserManagementRepo.GetAgentUserFullNameByUserID(userId);
                string password = mbruser.ResetPassword();
                TempData["TemoResetPassword"] = password;
                mbruser.Comment = "MustChangePassword";
                Membership.UpdateUser(mbruser);
                return RedirectToAction("Index", "BranchUserManagement", new { @id = BranchOfficeId });
            }

            catch (Exception ex)
            {
                TempData["ResponseMsg"] = "Email Cannot sent due to error - " + ex.Message;
                return RedirectToAction("Index", "BranchUserManagement", new { @id = BranchOfficeId });
            }

        }

        [HttpGet]
        public ActionResult LockUnlockBranchOfficeUser(string id)
        {
            var session = (TravelSession)Session["TravelSessionInfo"];
            int BranchOfficeId = (int)TempData["BranchOfficeId"];
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
            return RedirectToAction("Index", "BranchUserManagement", new { @id = BranchOfficeId });
        }


    }
}
