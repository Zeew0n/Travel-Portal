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
    [PermissionDetails(View = "Index", Add = "Create", Order = 2)]
    public class UserRolePrevilageController : Controller
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        UserRolePrevilageProvider ser = new UserRolePrevilageProvider();


        public ActionResult Index()
        {

            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            RolePrivilageModel model = new RolePrivilageModel();
            model.ProductList = ser.GetAllProductList();
            model.RoleList = new SelectList(ser.GetAllRolesBasedonProduct(model.ProductId), "RoleId", "RoleName").ToList();
            model.SubProductList = ser.GetSubProductList(model.ProductId);
            return View(model);
          
        }

        [HttpPost]
        public ActionResult Index(RolePrivilageModel model, FormCollection fc)
        {

            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.ProductList = ser.GetAllProductList();
            model.RoleList = new SelectList("", "RoleId", "RoleName").ToList();
            model.SubProductList = ser.GetSubProductList(model.ProductId);
            model.RoleTypeId= ser.GetIdbyRolename(model.RoleName);
            model.PriviledgeSetupList = ser.GetRolePrivilageBaseonRole(model.RoleTypeId,model.SubProductId);
            if (model.RoleTypeId==Guid.Parse( "00000000-0000-0000-0000-000000000000"))
            {
                model.ProductList = ser.GetAllProductList();
                model.RoleList = new SelectList(ser.GetAllRolesBasedonProduct(model.ProductId), "RoleId", "RoleName").ToList();
                model.SubProductList = ser.GetSubProductList(model.ProductId);
                model.PriviledgeSetupList = ser.GetControllerGroupingListByProductId(model.ProductId, model.SubProductId);
                return View(model);
            }
            return PartialView("ListPartial",model);

            
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(RolePrivilageModel model, FormCollection frmColl)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            Guid roleid = Guid.Parse(frmColl["Roleid"]);
            //////////////collect roleprivilage if any for deleting /////////////
            ser.DeleteAlreadyAddedPrivilageBaseonRole(roleid);
            char separatorChar = Convert.ToChar("_");

            List<int> PrivilegeIds = new List<int>();
            PrivilegeIds = new List<int>();
            foreach (string item in frmColl)
            {
                string str = "";
                if (item.Contains("checkbox"))
                {
                    string[] arrayCheckBox = item.Split(separatorChar);
                    PrivilegeIds.Add(Convert.ToInt32(arrayCheckBox[3]));
                }
            }
            AddRolePrivilageMapping(PrivilegeIds, roleid);

            string Role = ser.Rolename(roleid);
            return RedirectToAction("Index");
           
        }



        #region custom

        [NonAction]
        public void AddUserTypeControllerMapping(List<int> idlist, int usertype)
        {
            try
            {
                int count = idlist.Count;
                List<UserTypeControllerMappings> Lists = new List<UserTypeControllerMappings>();
                for (int i = 0; i < count; i++)
                {

                    UserTypeControllerMappings Controllerlist = new UserTypeControllerMappings();
                    Controllerlist.UserTypeId = usertype;
                    Controllerlist.ControllerId = idlist[i];
                    Lists.Add(Controllerlist);

                }
                ser.SaveUserTypeMapping(Lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [NonAction]
        public void AddRolePrivilageMapping(List<int> idlist, Guid roleid)
        {
            try
            {
                int count = idlist.Count;
                List<RolePrivilegeMappings> Lists = new List<RolePrivilegeMappings>();
                for (int i = 0; i < count; i++)
                {

                    RolePrivilegeMappings rolelist = new RolePrivilegeMappings();
                    rolelist.RoleId = (Guid)roleid;
                    rolelist.PrivilegeId = idlist[i];
                    Lists.Add(rolelist);

                }
                ser.SaveRolePrivilageMapping(Lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
