using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class BranchsDealSetupController : Controller
    {
        BranchDealProvider mDealProvider = new BranchDealProvider();
        AirLineInformationProvider airlineInfoProvider = new AirLineInformationProvider();
        MasterDealProvider masterDealProvider = new MasterDealProvider();

        public ActionResult Index(int? id, int? FilterDealIdentifierId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            var dealtype = mDealProvider.GetBranchDealMasterById(id ?? 0);
            BranchDealViewModel viewmodel = new BranchDealViewModel();

            viewmodel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId);
            viewmodel.DealIdentifierList = masterDealProvider.GetMobileServiceProviders();

            viewmodel.DealList = mDealProvider.GetAllMobileBranchDeals(id, FilterDealIdentifierId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetailList", viewmodel);
            else
                return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Index(BranchDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.MakerId = obj.AppUserId;
            model.MakerDate = DateTime.Now;
            model.isVerified = false;
            model.isDelete = false;

            mDealProvider.Update_Mobile_DistributorDeals(model);

            BranchDealViewModel viewmodel = new BranchDealViewModel()
            {                
                DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId),
                DealList = mDealProvider.GetAllMobileBranchDeals(model.DealMasterId, null)
            };

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("DisplayDealTemplate", viewmodel);
            else
                return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Create(int id, int? FilterDealIdentifierId, string FilterDealIdentifierText)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];


            BranchDealViewModel viewmodel = new BranchDealViewModel();


            viewmodel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId);
            viewmodel.DealMasterId = id;
            viewmodel.DealMaserText = mDealProvider.GetBranchDealMasterById(id).BranchDealName;
            viewmodel.DealIdentifierId = FilterDealIdentifierId != null ? FilterDealIdentifierId.Value : 0;
            viewmodel.DealIdentifierText = FilterDealIdentifierText;
            viewmodel.DealIdentifierList = masterDealProvider.GetMobileServiceProviders();
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("CreateDeal", viewmodel);
            else
                return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Create(BranchDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealViewModel viewmodel = new BranchDealViewModel()
            {
                DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId),
                DealMaserText = mDealProvider.GetBranchDealMasterById(model.DealMasterId).BranchDealName,
            };


            if (ModelState.IsValid)
            {
                model.MakerId = obj.AppUserId;
                model.MakerDate = DateTime.UtcNow;
                model.isVerified = true;
                model.VerifiedBy = obj.AppUserId;
                model.VerifiedDate = DateTime.UtcNow;
                model.isDelete = false;
                model.CreatedBy = obj.AppUserId;

                int dealId = mDealProvider.Save_Mobile_BranchDeals(model);

                viewModel = mDealProvider.GetMobileBranchDealDetail(dealId);
                
                viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId);                

                if (Request != null && Request.IsAjaxRequest())
                    return PartialView("VUC_DealDetail", viewModel);
                else
                    return View(viewModel);
            }
            else
            {                
                viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId);             
                return View(viewModel);
            }
        }

        public ActionResult Edit(BranchDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            mDealProvider.Update_Mobile_BranchDeals(model);

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetMobileBranchDealDetail(model.DealId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            JsonResult returnJsonData = new JsonResult();

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetMobileBranchDealDetail(id);

            try
            {
                mDealProvider.Mobile_BranchDealChangesLogs(viewModel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                result = mDealProvider.Delete_Mobile_BranchDeals(id, obj.AppUserId);
                returnJsonData.Data = result;
            }
            catch (Exception ex)
            {
                returnJsonData.Data = "Sorry, unable to delete deal!";
            }
            return returnJsonData;
        }
    }
}
