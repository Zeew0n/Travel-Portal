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
    [PermissionDetails(View = "Index", Add = "Create", Delete = "Delete", Order = 2)]
    public class PriviledgeSetupController : Controller
    {
        //
        // GET: /PriviledgeSetup/

        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        UserRolePrevilageProvider ser = new UserRolePrevilageProvider();


        public ActionResult Index()
        {
            RolePrivilageModel model = new RolePrivilageModel();
            model.ProductList = ser.GetAllProductList();
            model.SubProductList = ser.GetSubProductList(0);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(RolePrivilageModel model)
        {

            model.ProductList = ser.GetAllProductList();
            model.PriviledgeSetupList = ser.GetControllerGroupingListByProductId(model.ProductId,model.SubProductId);
            model.SubProductList = ser.GetSubProductList(model.ProductId);
            if (Request.IsAjaxRequest())
            {
                if (model.SubProductId == 0)
                {
                    model.PriviledgeSetupList = ser.GetControllerGroupingListByProductId(model.ProductId);
                }
                return PartialView("VUC_PriviledgeList", model);
            }
            return View(model);
            

        }

        [HttpGet]
        public ActionResult Create()
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            RolePrivilageModel viewmodel = new RolePrivilageModel()
            {
                ProductList = ser.GetAllProductList(),
                ActionTypeList = ser.GetAllActionTypeList(),
                GroupNameList = ser.GetAllControllerGroupList(),
                ControllerNameList = ser.GetAllControllerList(),
                SubProductList = ser.GetSubProductList(0),
            };
            return View(viewmodel);
        }

     

        [HttpPost]
        public ActionResult Create(RolePrivilageModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            if (!ModelState.IsValid)
            {
                RolePrivilageModel viewmodel = new RolePrivilageModel()
                {
                    ProductList = ser.GetAllProductList(),
                    ActionTypeList = ser.GetAllActionTypeList(),
                    GroupNameList = ser.GetAllControllerGroupList(),
                    ControllerNameList = ser.GetAllControllerList(),
                    SubProductList = ser.GetSubProductList(0),
                };
                return View(viewmodel);
            }
            else
            {

                model.SeqNumber = ser.GetAllSequenceNoFromControllerList(model.ControllerName) + 1;    // use sequence no last sequence No. + 1

                bool checkactionname = ser.GetControllerNameList(model.ControllerId, model.ActionTypeName);

                if (checkactionname == false)
                {
                    model.ControllerId = ser.ControllerActionMappingsAdd(model);
                }

                else
                {
                    TempData["ActionResponse"] = "Action Name already Exists";
                }
                //model.ControllerGroupId = ser.ControllerGroup(model);

                ////////////////not needed now as controllername textbox is replaced by controllername dropdownlist/////////////////////// 
                // model.ControllerId=ser.ControllerListAdd(model);
                ///////////////////////////////////////////////////////////////////////////


            }
           
            RolePrivilageModel viewmodel1 = new RolePrivilageModel()
            {
                ProductList = ser.GetAllProductList(),
                ActionTypeList = ser.GetAllActionTypeList(),
                GroupNameList = ser.GetAllControllerGroupList(),
                ControllerNameList = ser.GetAllControllerList(),
                 SubProductList = ser.GetSubProductList(0)
            };
           // return View(viewmodel1);

            return RedirectToAction("Create");
            

        }




        public ActionResult Delete(int ControllerId, int? ActionTypeId)
        {
            try
            {

                if (ControllerId != 0 && ActionTypeId == null)
                {
                    ser.DeleteControllerAction(ControllerId, null);

                }
                else
                {
                    ser.DeleteControllerAction(ControllerId, ActionTypeId);
                }
            }
            catch
            {
                TempData["ActionResponse"] = "Unable to delete.";
            }


            return RedirectToAction("Index");

        }







    }
}
