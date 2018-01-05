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
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{

    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(Edit = "ApproveUsernow", View = "ManageUser", Details = "Details", Add = "UnLockUsernow", Order = 2)]
    public class UserManagementController : Controller
    {
      
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        UserManagementProvider ser = new UserManagementProvider();
        AgentManagementRepository _agentPorvider = new AgentManagementRepository();
        BookedTicketReportController bktController = new BookedTicketReportController();

        public ActionResult ManageUser()
        {
            //////// Adding Dropdownlist for Role creation///////////////////////
            ViewData["ddlmanageopt"] = new SelectList(GetOptionType(), "Id", "Name");
            /////////////////End role here/////////////////////////////////////
            TempData["Flag"] = false;
            return View();
        }
        [HttpPost]
        public ActionResult ManageUser(FormCollection fc,int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            int optionid = int.Parse(fc["ddlOpt"]);
            TempData["Flag"] = true;
            if (Request.IsAjaxRequest())
            {
                if (optionid == 1)
                {
                    var result = ser.GetUnppprovedUserAdminUserList().ToPagedList(currentPageIndex, defaultPageSize);
                    ViewData["ddlmanageopt"] = new SelectList(GetOptionType(), "Id", "Name", optionid);
                    TempData["messageflag"] = "Pending Approval Admin User";
                    TempData["messageHead"] = "Approved Admin User";
                    return PartialView("LockedUnapproveduser", result);
                }
                else if (optionid == 2)
                {
                    var res = ser.GetUnapprovedAgentUserList().ToPagedList(currentPageIndex, defaultPageSize);
                    ViewData["ddlmanageopt"] = new SelectList(GetOptionType(), "Id", "Name", optionid);
                    TempData["messageflag"] = "Pending Approval Agent User";
                    TempData["messageHead"] = "Approved Agent User";
                    return PartialView("LockedUnapproveduser", res);
                }
                else
                {
                    var result = ser.GetAllLockedUserList().ToPagedList(currentPageIndex, defaultPageSize);
                    ViewData["ddlmanageopt"] = new SelectList(GetOptionType(), "Id", "Name", optionid);
                    TempData["messageflag"] = "Locked Agent User";
                    TempData["messageHead"] = "Unlock Agent User";
                    return PartialView("LockedUnapproveduser", result);
                }

            }
            ViewData["ddlmanageopt"] = new SelectList(GetOptionType(), "Id", "Name");
            TempData["Flag"] = false;
            return View();

        }

      
        [HttpGet]
        public ActionResult ApproveUsernow(Guid id)
        {
            ser.ApproveUsers(id);
            return RedirectToAction("ManageUser");
        }

       [HttpGet]
        public ActionResult UnLockUsernow(Guid id)
        {
            ser.UnLockUser(id);
            ViewData["ddlmanageopt"] = new SelectList(GetOptionType(), "Id", "Name");
            return RedirectToAction("ManageUser");
        }

        #region
        public ActionResult Details(Guid id)
        {
            SqlProfileProvider myProfileProvider = new SqlProfileProvider();

            var user = Membership.GetUser(id);
            ViewData["Title"] = "User Details :" + user.UserName + "";
            var data = new UserManagementModel.MembershipUserAndRolesViewData
            {
                User = user,
                UsersRoles = Roles.GetRolesForUser(user.UserName).OrderBy(x => x).ToList(),
                UserDetails = ser.GetUserDetails(id),
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("Details", data);
            return View(data);
        }


        public class OptionType
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public List<OptionType> GetOptionType()
        {
            List<OptionType> nn = new List<OptionType>();

            OptionType n1 = new OptionType();
            OptionType n2 = new OptionType();
            OptionType n3 = new OptionType();
            n1.Id = 1;
            n1.Name = "Admin Users Pending Approval";

            n2.Id = 2;
            n2.Name = "Agent Users Pending Approval";

            n3.Id = 3;
            n3.Name = "Locked User";

            nn.Add(n1);
            nn.Add(n2);
            nn.Add(n3);

            return nn;
        }
        #endregion
    }

}
