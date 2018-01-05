using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Repository;
using System.Web.Security;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "ResetPassword", Edit = "LockUnlockAgentUser", Order = 2)]
    public class AgentUserManagementController : Controller
    {

        UserManagementProvider _UserManagementRepo = new UserManagementProvider();
        AdminUserManagementRepository _AdminUserRepo = new AdminUserManagementRepository();
        //
        // GET: /Administrator/AgentUserManagement/

        public ActionResult Index(int id)
        {
            IEnumerable<View_AgentDetails> model = _UserManagementRepo.GetAllAgentUsers(id);
            string AgentName = _UserManagementRepo.GetAgentNameByAgentID(id);
            ViewData["AgentName"] = AgentName;
            TempData["AgentId"] = id;
            return View(model);
        }

        public ActionResult ResetPassword(string id)
        {
            int Agentid = (int)TempData["AgentId"];
            try
            {
  
                MembershipUser mbruser = Membership.GetUser(id);
                Guid userId = new Guid(mbruser.ProviderUserKey.ToString());
                string UserFullName = _UserManagementRepo.GetAgentUserFullNameByUserID(userId);
                string password = mbruser.ResetPassword();
                TempData["TemoResetPassword"] = password;
                mbruser.Comment = "MustChangePassword";
                Membership.UpdateUser(mbruser);
                return RedirectToAction("Index", "AgentUserManagement", new { @id = Agentid });
            }

            catch (Exception ex)
            {
                TempData["ResponseMsg"] = "Email Cannot sent due to error - " + ex.Message;
                return RedirectToAction("Index", "AgentUserManagement", new { @id = Agentid });
            }

        }
        [HttpGet]
        public ActionResult LockUnlockAgentUser(string id)
        {
            var session = (TravelSession)Session["TravelSessionInfo"];
            int Agentid = (int)TempData["AgentId"];
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
            return RedirectToAction("Index", "AgentUserManagement", new { @id = Agentid });
        }
    }
}
