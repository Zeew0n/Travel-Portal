using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Order = 2)]
    public class MasterDealSetUpController : Controller
    {
        MasterDealProvider mDealProvider = new MasterDealProvider();

        [HttpGet]
        public ActionResult Create()
        {
            MasterDealviewModel viewmodel = new MasterDealviewModel()
            {
                DealMasterList = mDealProvider.GetAllDealMasterList(4),
                DealTypeList = mDealProvider.GetAllDealTypeList(4),
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_CreateNewDeal", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(MasterDealviewModel model)
        {
            ValidateMasterDealviewModel(model);
            try
            {
                if (!ModelState.IsValid)
                {
                    if (model.CopyDeal == true)
                    {
                        mDealProvider.CopyBusDealfromOneToAnother(model.DealName, model.DealMasterId, model.DealTypeId, model.EffectiveFrom, model.ExpireOn);
                    }
                    else
                    {
                        mDealProvider.AddDealMaster(model, 4);
                    }
                    return RedirectToAction("Index", "DealSetup");
                }
                else
                {
                    return RedirectToAction("Index", "DealSetup");
                }
            }
            catch
            {
                return RedirectToAction("Index", "DealSetup");
            }
        }

        public ActionResult Delete(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            DealViewModel viewmodel = new DealViewModel();
            try
            {
                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

                result = mDealProvider.Delete_Tkt_BusDealMasters(id, obj.AppUserId);
                viewmodel.DealMasterList = mDealProvider.GetAllDealMasterList(4);
                viewmodel.isVerified = result;
                returnJsonData.Data = viewmodel;
                return returnJsonData;
            }
            catch (Exception ex)
            {
                viewmodel.isVerified = false;
                returnJsonData.Data = viewmodel;
            }
            return returnJsonData;
        }

        private void ValidateMasterDealviewModel(MasterDealviewModel dealmaster)
        {
            bool dealmasterIsNull = dealmaster == null ? true : false;
            const string decimalRegex = @"^\d+(\.\d\d)?$";
            Regex rgx = new Regex(decimalRegex);
            // Validation logic
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.DealName)))
                ModelState.AddModelError("DealName", "DealName  is required.");
            if ((dealmasterIsNull) || (string.IsNullOrEmpty((dealmaster.DealTypeId).ToString())) || (dealmaster.DealTypeId == 0))
                ModelState.AddModelError("DealTypeId", "DealType Name is required.");
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.EffectiveFrom.ToString())))
                ModelState.AddModelError("EffectiveFrom", "EffectiveFrom Date is required.");
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.ExpireOn.ToString())))
                ModelState.AddModelError("ExpireOn", "ExpireOn Date is required.");
        }
    }
}
