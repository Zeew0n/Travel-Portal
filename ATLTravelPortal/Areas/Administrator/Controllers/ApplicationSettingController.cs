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
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Models;


namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details", Delete = "Delete", Order = 2)]
    public class ApplicationSettingController : Controller
    {
        ApplicationSettingRepository _rep = new ApplicationSettingRepository();
        ApplicationSettingViewModel _model = new ApplicationSettingViewModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        //
        // GET: /ApplicationSetting/

        public ActionResult Index()
        {
            _model.ddlProductList= new SelectList(_rep.GetProductList(), "ProductId", "ProductName", 0);
            _model.Flag = false;
            return View(_model);
        }
        [HttpPost]
        public ActionResult Index(ApplicationSettingViewModel model,int? ProductId)
        {
            if (Request.IsAjaxRequest())
            {
                if (ProductId == null)
                    ProductId = 0;
                _model = _rep.Get(ProductId, out _res);
                _model.HFProductId = ProductId.Value;
                Session["ActionResponse"] = _res;
                return PartialView("SettingPartial", _model);
            }
            model = _rep.Edit(model, out _res);
            model.ddlProductList = new SelectList(_rep.GetProductList(), "ProductId", "ProductName", 0);
         
            Session["ActionResponse"] = _res;
            return View(model);
        }

        //
        // GET: /ApplicationSetting/Edit/5

        public ActionResult Edit(int? id)
        {
            _model = _rep.Get(id, out _res);
            Session["ActionResponse"] = _res;
            return View(_model);
        }

        //
        // POST: /ApplicationSetting/Edit/5

        [HttpPost]
        public ActionResult Edit(ApplicationSettingViewModel model)
        {
            model = _rep.Edit(model, out _res);
            model.ddlProductList = new SelectList(_rep.GetProductList(), "ProductId", "ProductName", 0);
            Session["ActionResponse"] = _res;
            //return PartialView("SettingPartial", model);
            return View("Index", model);
        }

        //
        // GET: /ApplicationSetting/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ApplicationSetting/Delete/5

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
    }
}
