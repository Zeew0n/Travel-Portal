using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Routing;
using System.Web.Security;
using System.Collections;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Hotel.Repository;

using TravelPortalEntity;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
     [CheckSessionFilter(Order = 1)]
    public class UserManagementController : Controller
    {

         EntityModel ent = new EntityModel();
        UserManagementRepository ser = new UserManagementRepository();
        //AgentManagement _agentPorvider = new AgentManagement();

        CustomValidationClass valsvc;
        public UserManagementController()
        {
            valsvc = new CustomValidationClass(this.ModelState);

        }
        //
        // GET: /UserManagement/
        [Authorize]
        public ActionResult Index()
        {
            TravelSession obj = (TravelSession)Session["TravelSessionInfo"];
            ViewData["Userid"] = obj.Id;
            ViewData["list"] = ser.ListAllUser();
            return View();
        }

       

        //
        // GET: /UserManagement/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ser = new UserManagementRepository();

            var model = new Hotels.ClientDataModel.MetaData.Hotel.UserManagementModel.CreateAspUser
            {
               // AgentList = _agentPorvider.getAllAgentList()

            };
            ViewData["RolesList"] = ser.GetAllRolesList();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Hotels.ClientDataModel.MetaData.Hotel.UserManagementModel.CreateAspUser obj, FormCollection fc)
        {
           // UserManagementProvider sr = new UserManagementProvider();
            if (obj.Password != obj.ConfirmPassword)
            {
                TempData["ErrorMessage"] = "Registration failed! Your passwords must match, please re-enter and try again";
                return RedirectToAction("Create");
            }
           // sr.CreateUser(obj);
            Guid userid = ser.ListAllUser().Last().UserId;
            ///////Get Roles information/////////////
            //List<Guid> RoleIds = new List<Guid>();
            List<aspnet_Roles> vu = ser.GetAllRolesList();
            // RoleIds = new List<Guid>();
            foreach (aspnet_Roles u in vu)
            {
                if (fc["Chk_" + u.RoleId].ToString() != "false")
                {
                    //string cCid = fc["Chk_" + u.RoleId].ToString();
                    //int i = cCid.IndexOf(",");
                    //Guid j = Guid.Parse(cCid.Substring(0, i));
                    //RoleIds.Add(j);
                    Roles.AddUserToRole(obj.UserName, u.RoleName);
                }
            }


            //ser.AddRoleforParticularUser(RoleIds, userid);
            //////////////End of Role/////////////
            //var model = new AirLines.DataModel.ModelMetaData.AirLine.UserManagementModel.CreateAspUser
            //{
            //    AgentList = _agentPorvider.getAllAgentList()
            //};

            //return View(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult ManageRole()
        {

            ViewData["Roles"] = ser.FindAllRoles();
            return View();
        }

        public ActionResult SearchUser(string searchType, string searchInput)
        {
            List<SelectListItem> searchOptionList = new List<SelectListItem>() 
            {
                new SelectListItem() { Value = "UserName", Text = "UserName" },
                new SelectListItem() { Value = "Email", Text = "Email" }
            };

            ViewData["searchOptionList"] = new SelectList(searchOptionList, "Value", "Text", searchType ?? "UserName");
            ViewData["searchInput"] = searchInput ?? string.Empty;
            ViewData["UsersOnlineNow"] = Membership.GetNumberOfUsersOnline().ToString();
            ViewData["RegisteredUsers"] = Membership.GetAllUsers().Count.ToString();

            MembershipUserCollection viewData;

            if (String.IsNullOrEmpty(searchInput))
                viewData = Membership.GetAllUsers();
            else if (searchType == "Email")
                viewData = Membership.FindUsersByEmail(searchInput);
            else
                viewData = Membership.FindUsersByName(searchInput);

            return View(viewData);
        }


        //
        // GET: /UserManagement/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UserManagement/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


       
        //public ActionResult unapprovedUserList()
        //{


        //    IEnumerable<GetUserByApproveStatus_Result> res = ser.GetUnppprovedUser();

        //    return View(res);
        //}

        //[Authorize]
        //public ActionResult ManageUser()
        //{
        //    var res = ser.GetLockedUserList();
        //    return View(res);
        //}

        [Authorize]
        [HttpPost]
        public ActionResult ApproveUsernow(Guid id)
        {
            ser.ApproveUser(id);
            return RedirectToAction("unapprovedUserList");
        }

        [Authorize]
        [HttpPost]
        public ActionResult LockUsernow(Guid id)
        {
            ser.UnLockUser(id);
            return RedirectToAction("ManageUser");
        }
        public ActionResult GetallRoles()
        {
            ViewData["Roles"] = ser.FindAllRoles();
            return View();
        }
        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult CreateRole(string id)
        {
            ser.CreateRole(id);
            return RedirectToAction("ManageRole");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult DeleteRole(string role)
        {
            ser.DeleteRole(role);
            return RedirectToAction("ManageRole");
        }
        ///////////////individual user Memebership details goes here ////////////////////
        #region
        [Authorize]
        public virtual ViewResult UserDetails(Guid id)
        {
            // int recordsReturned;
            SqlProfileProvider myProfileProvider = new SqlProfileProvider();

            var user = Membership.GetUser(id);
            ViewData["Title"] = "User Details (" + user.UserName + ")";
            var data = new Hotels.ClientDataModel.MetaData.Hotel.UserManagementModel.MembershipUserAndRolesViewData 
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
            user.IsApproved = ((Request.Form["IsApproved"] ?? "").Trim().Equals("on", StringComparison.CurrentCultureIgnoreCase));
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

        public virtual RedirectToRouteResult RemoveUserFromRole(string ProviderUserKey, string role)
        {
            Guid userId = new Guid(ProviderUserKey);
            var user = Membership.GetUser(userId);
            OnBeforeRemoveUserFromRole(user.UserName, role);
            Roles.RemoveUserFromRole(user.UserName, role);
            OnAfterRemoveUserFromRole(user.UserName, role);
            return RedirectToUserPage(user);
        }
        public virtual ViewResult ResetPassword()
        {
            ViewData["Title"] = "Reset Password";

            var userName = Request.Form["UserName"];
            var pwdAnswer = Request.Form["PasswordAnswer"];

            OnBeforeResetPassword(userName, pwdAnswer);

            var user = Membership.GetUser(userName);
            var pwd = user.ResetPassword(pwdAnswer);

            OnAfterResetPassword(user.Email, userName, pwdAnswer);

            ViewData["Password"] = pwd;
            return View("ResetPassword");
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
                throw new MembershipPasswordException("\"New Password\" does not match \"Confirm New Password\".");

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
        #endregion


        public ActionResult LoginHistory(int? flag, int? firstOrLastPage)
        {
            //var model = ser.GetLoginHistoryList();
            //return View(model);
            int currentPage = 1;
            int pageSize = (int)PageSize.LaPageSize;
            int pageNo = 0;
            if (flag != null)
                currentPage = firstOrLastPage.Value;
            List<GetLoginHistory_Result> model = ser.GetLoginHistoryList().ToList();
            pageNo = (int)Math.Ceiling((double)model.Count / (double)pageSize);

            ViewData["CurrentPage"] = currentPage;
            ViewData["PageNo"] = pageNo;
            //ViewData["list"] = model.Skip(pageSize * currentPage - pageSize).Take(pageSize).ToList();
            return View(model.Skip(pageSize * currentPage - pageSize).Take(pageSize).ToList());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LoginHistory(FormCollection fc)
        {
            int currentPage = Convert.ToInt32(fc["CurrentPage"]);
            int pageSize = (int)PageSize.LaPageSize;

            List<GetLoginHistory_Result> model = ser.GetLoginHistoryList().ToList();
            int pageNo = (int)Math.Ceiling((double)model.Count / (double)pageSize);

            if (!string.IsNullOrEmpty(fc["Next"]))
                currentPage += 1;
            else if (!string.IsNullOrEmpty(fc["Previous"]))
                currentPage -= 1;

            ViewData["CurrentPage"] = currentPage;
            ViewData["PageNo"] = pageNo;

            return View(model.Skip(pageSize * currentPage - pageSize).Take(pageSize).ToList());
        }
        public enum PageSize
        {
            JePageSize = 5,
            LaPageSize = 5
        }

        //public ActionResult unapprovedUserListAgent()
        //{
        //    var ts = (TravelSession)Session["TravelSessionInfo"];
        //    IEnumerable<GetUserByApproveStatusByAgent_Result> res = ser.GetUnppprovedUser(ts.AgentId);
        //    return View(res);
        //}

    }
}
