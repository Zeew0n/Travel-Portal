using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using System.Text.RegularExpressions;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class MasterDistributorDealSetupController : Controller
    {
        BranchDealProvider mDealProvider = new BranchDealProvider();

        [HttpGet]
        public ActionResult Create()
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            string DistributorCode = mDealProvider.GetDistributorCodeByDistributorId(obj.LoginTypeId);
            MasterBranchDealviewModel viewmodel = new MasterBranchDealviewModel()
            {
                DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId),
                DistributorCode = DistributorCode
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_CreateNewDeal", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(MasterBranchDealviewModel model)
        {
            ValidateMasterDistributorDealviewModel(model);
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            string DistributorCode = mDealProvider.GetDistributorCodeByDistributorId(obj.LoginTypeId);
            try
            {
                if (!ModelState.IsValid)
                {
                    model.CreatedBy = obj.AppUserId;
                    model.BranchOfficeId = obj.LoginTypeId;
                    model.DistributorCode = DistributorCode;

                    if (model.CopyDeal == true)
                    {
                        mDealProvider.CopyDealFromOneToAnotherForMobileDistributor(model.DealName, model.DealMasterId, 3, model.BranchOfficeId, model.CreatedBy);
                    }
                    else
                    {
                        mDealProvider.AddDistributorDealMaster(model, 3);
                    }

                    return RedirectToAction("Index", "DistributorsDealSetup");
                }
                else
                {
                    return RedirectToAction("Index", "DistributorsDealSetup");
                }
            }
            catch
            {
                return RedirectToAction("Index", "DistributorsDealSetup");

            }
        }

        public ActionResult Delete(int id, string name)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            JsonResult returnJsonData = new JsonResult();
            BranchDealViewModel viewmodel = new BranchDealViewModel();
            try
            {
                bool result = false;
              
                result = mDealProvider.Delete_Core_DistributorDealMasters(id, obj.AppUserId);
                viewmodel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId);
                result = true;
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

        private void ValidateMasterDistributorDealviewModel(MasterBranchDealviewModel dealmaster)
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
