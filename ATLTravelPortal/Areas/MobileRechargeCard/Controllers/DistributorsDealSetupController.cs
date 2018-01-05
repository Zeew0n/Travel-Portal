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
    public class DistributorsDealSetupController : Controller
    {
        BranchDealProvider mDealProvider = new BranchDealProvider();
        AirLineInformationProvider airlineInfoProvider = new AirLineInformationProvider();
        MasterDealProvider masterDealProvider = new MasterDealProvider();

        public ActionResult Index(int? id, int? FilterDealIdentifierId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            var dealtype = mDealProvider.GetDistributorDealMasterById(id ?? 0);
            BranchDealViewModel viewmodel = new BranchDealViewModel();

            //viewmodel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
            viewmodel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId);
            viewmodel.DealIdentifierList = masterDealProvider.GetMobileServiceProviders();

            //viewmodel.CurrencyList = mDealProvider.GetCurrencyList();
            viewmodel.DealList = mDealProvider.GetAllMobileDistributorDeals(id, FilterDealIdentifierId);

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

            mDealProvider.Update_Air_DistributorDeals(model);

            BranchDealViewModel viewmodel = new BranchDealViewModel()
            {
                //AirlineNameList = mDealProvider.GetAllAirlineNameList(),
                // CurrencyList = mDealProvider.GetCurrencyList(),
                DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId),

                DealList = mDealProvider.GetAllMobileDistributorDeals(model.DealMasterId, null)
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


            viewmodel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId);
            viewmodel.DealMasterId = id;
            viewmodel.DealMaserText = mDealProvider.GetDistributorDealMasterById(id).DistributorDealName;
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
                DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId),
                DealMaserText = mDealProvider.GetDistributorDealMasterById(model.DealMasterId).DistributorDealName,
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

                int dealId = mDealProvider.Save_Mobile_DistributorDeals(model);



                viewModel = mDealProvider.GetMobileDistributorDealDetail(dealId);

                // viewModel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
                // viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId);
                // viewModel.CurrencyList = mDealProvider.GetCurrencyList();

                if (Request != null && Request.IsAjaxRequest())
                    return PartialView("VUC_DealDetail", viewModel);
                else
                    return View(viewModel);
            }
            else
            {
                // viewModel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
                //  viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId);
                // viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                return View(viewModel);
            }
        }

        public ActionResult Edit(BranchDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            mDealProvider.Update_Mobile_DistributorDeals(model);

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetMobileDistributorDealDetail(model.DealId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            JsonResult returnJsonData = new JsonResult();

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetMobileDistributorDealDetail(id);

            try
            {
                mDealProvider.Mobile_DistributorDealChangesLogs(viewModel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                result = mDealProvider.Delete_Mobile_DistributorDeals(id, obj.AppUserId);
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
