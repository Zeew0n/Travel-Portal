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
using ATLTravelPortal.Areas.Administrator.Repository;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class MasterBranchDealSetUpController : Controller
    {
        //
        // GET: /Airline/MasterBranchDealSetUp/
        BranchDealProvider mDealProvider = new BranchDealProvider();
       DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();


        [HttpGet]
        public ActionResult Create()
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            string BranchCode =mDealProvider.GetBranchCodeByBranchId(obj.LoginTypeId);
            MasterBranchDealviewModel viewmodel = new MasterBranchDealviewModel()
            {
                DealMasterList = mDealProvider.GetAllBranchDealMasterList(1, obj.LoginTypeId),
                BranchOffices = new SelectList(distributorManagementProvider.GetBranchOffices(), "BranchOfficeId", "BranchOfficeName"),
                BranchOfficeCode = BranchCode
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_CreateNewDeal", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(MasterBranchDealviewModel model)
        {
            ValidateMasterBranchDealviewModel(model);
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            string BranchCode = mDealProvider.GetBranchCodeByBranchId(obj.LoginTypeId);
            try
            {
                if (!ModelState.IsValid)
                {
                    model.CreatedBy = obj.AppUserId;
                    model.BranchOfficeId = obj.LoginTypeId;
                    model.BranchOfficeCode = BranchCode;
                    mDealProvider.AddDealMaster(model, 1);
                    if (model.CopyDeal == true){
                     mDealProvider.CopyDealfromOneToAnother(model.DealName, model.DealMasterId, 1,model.BranchOfficeId,model.CreatedBy);
                       
                    }

                    return RedirectToAction("Index", "BranchDealSetup");
                }
                else
                {
                    return RedirectToAction("Index", "BranchDealSetup");
                }
            }
            catch
            {
                return RedirectToAction("Index", "BranchDealSetup");

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
                viewmodel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(1, obj.LoginTypeId);
                //result = mDealProvider.Delete_Core_BranchDealMasters(id, obj.AppUserId);
                //mDealProvider.Delete_Core_BranchDeals(id, obj.AppUserId);
                //mDealProvider.Delete_Core_BranchDealMasters(id, obj.AppUserId);
                result = false;
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
           
            //mDealProvider.Delete_Core_BranchDeals(id, obj.AppUserId);
            //mDealProvider.Delete_Core_BranchDealMasters(id, obj.AppUserId);
            //return RedirectToAction("Index", "BranchDealSetup");

        }       
        private void ValidateMasterBranchDealviewModel(MasterBranchDealviewModel dealmaster)
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
