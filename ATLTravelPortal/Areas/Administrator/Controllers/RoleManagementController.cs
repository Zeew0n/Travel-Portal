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
    [PermissionDetails(View = "ManageRole", Add = "CreateRole", Delete = "DeleteRole", Order = 2)]
    public class RoleManagementController : Controller
    {
        UserManagementProvider ser = new UserManagementProvider();

        //
        // GET: /RoleManagement/

        [Authorize]
        public ActionResult ManageRole(int? pageNo, int? flag)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            ViewData["ProductList"] = new SelectList(ser.GetProductList(), "ProductId", "ProductName"); ////Product List in dropdown
            ViewData["SubProductList"] = new SelectList("", "SubProductId", "SubProductName");
            /////////////////End role here/////////////////////////////////////
            ////////////// Paging Data //////////////////////////////////////////
            int currentPageNo = 0; int numberOfPage = 0;
            if (pageNo == null)
                pageNo = 1;
            ////////////// End of Paging Data ////////////////////////////////
            //////////// Showing Role logig start here //////////////////////
            var model = new List<RoleBasedRoleModel>();
            model = ser.GetAllRoleForAdminByByPaging(pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();
            //////////// End of Showing Role logic  //////////////////
            if (Request.IsAjaxRequest())
            {
                ViewData["TotalPages"] = numberOfPage;
                ViewData["CurrentPage"] = currentPageNo;
                return PartialView("RolePartial", model);

            }
            ViewData["TotalPages"] = numberOfPage;
            ViewData["CurrentPage"] = currentPageNo;
            return View(model);
        }
        /// <summary>
        /// ///Deleting Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteRole(string id)
        {
            try
            {
                ser.DeleteRole(id);
                TempData["delmessage"] = "This role is deleted Successfully";

            }
            catch
            {
                TempData["delmessage"] = "This role cannot be deleted because there are users present in it.";
            }

            return RedirectToAction("ManageRole");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetallRoles()
        {
            ViewData["Roles"] = ser.FindAllRolesForAdmin();
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public RedirectToRouteResult CreateRole(string id, FormCollection fc)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            if (id != "")
            {
                if (Roles.RoleExists(id) != true)
                {
                    ///////// Save Role ////////////////
                    ser.CreateRole(id);
                    ///////// End Saving Role //////////
                    ////////// Get RoleId for saving in Core_ProductRoles table  /////////////
                    Guid roleid = ser.GetIdbyRolename(id);
                    Core_ProductRoles model = new Core_ProductRoles();
                    model.RoleId = roleid;
                    model.ProductId = Convert.ToInt32(fc["ProductId"]);
                    model.SubProductId = Convert.ToInt32(fc["SubProductId"]);
                    ser.Save_RoleUserTypeMapping(model);
                    /////////////// End Role Creation ////////////
                    TempData["message"] = "Role Created Successfully";
                    return RedirectToAction("ManageRole");
                }
                else
                {
                    TempData["message"] = " The role " + id + " already exists.";
                    return RedirectToAction("ManageRole");
                }
            }
            else
            {
                TempData["message"] = "Please Enter Role Name";
                return RedirectToAction("ManageRole");
            }
        }


    }
}
