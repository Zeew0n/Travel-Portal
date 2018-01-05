using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class DistributorDealSetupController : Controller
    {
        //
        // GET: /Airline/DistributorDealSetup/
        BranchDealProvider mDealProvider = new BranchDealProvider();
        AirLineInformationProvider airlineInfoProvider = new AirLineInformationProvider();

        public ActionResult Index(int? id, string FilterDealIdentifierId, int? FilterAirlineId, int? FilterCurrencyId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            var dealtype = mDealProvider.GetDistributorDealMasterById(id ?? 0);
            BranchDealViewModel viewmodel = new BranchDealViewModel();

            viewmodel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
            viewmodel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(1, obj.LoginTypeId);

            viewmodel.CurrencyList = mDealProvider.GetCurrencyList();
            viewmodel.DealList = mDealProvider.GetAllDistributorDeals(id, FilterDealIdentifierId, FilterAirlineId, FilterCurrencyId);

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
                AirlineNameList = mDealProvider.GetAllAirlineNameList(),
                CurrencyList = mDealProvider.GetCurrencyList(),
                DealMasterList = mDealProvider.GetAllDistributorDealMasterList(1, obj.LoginTypeId),

                DealList = mDealProvider.GetAllDistributorDeals(model.DealMasterId, null, null, null)
            };

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("DisplayDealTemplate", viewmodel);
            else
                return View(viewmodel);
        }
        public ActionResult Create(int id, int? FilterDealIdentifierId, string FilterDealIdentifierText, int? FilterAirlineId, int? FilterCurrencyId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            var airlineInfo = airlineInfoProvider.GetAirLineInfoById(FilterAirlineId ?? 0);

            BranchDealViewModel viewmodel = new BranchDealViewModel();

            viewmodel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
            viewmodel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(1, obj.LoginTypeId);
            viewmodel.DealMasterId = id;
            viewmodel.DealMaserText = mDealProvider.GetDistributorDealMasterById(id).DistributorDealName;
            viewmodel.DealIdentifierId = FilterDealIdentifierId != null ? FilterDealIdentifierId.Value : 0;
            viewmodel.DealIdentifierText = FilterDealIdentifierText;
            viewmodel.CurrencyId = FilterCurrencyId != null ? FilterCurrencyId.Value : 0;
            viewmodel.AirlineId = FilterAirlineId;
            viewmodel.AirlineName = airlineInfo != null ? airlineInfo.AirlineName : "";
            viewmodel.CurrencyList = mDealProvider.GetCurrencyList();

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
                AirlineNameList = mDealProvider.GetAllAirlineNameList(),
                CurrencyList = mDealProvider.GetCurrencyList(),
                DealMasterList = mDealProvider.GetAllDistributorDealMasterList(1, obj.LoginTypeId),
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

                int dealId = mDealProvider.Save_Air_DistributorDeals(model);



                viewModel = mDealProvider.GetDistributorDealDetail(dealId);

                viewModel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(1, obj.LoginTypeId);
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();

                if (Request != null && Request.IsAjaxRequest())
                    return PartialView("VUC_DealDetail", viewModel);
                else
                    return View(viewModel);
            }
            else
            {
                viewModel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(1, obj.LoginTypeId);
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                return View(viewModel);
            }
        }

        public ActionResult Edit(BranchDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            mDealProvider.Update_Air_DistributorDeals(model);

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetDistributorDealDetail(model.DealId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }
        public ActionResult Delete(int id)
        {
            JsonResult returnJsonData = new JsonResult();

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetDistributorDealDetail(id);

            try
            {
                mDealProvider.Air_DistributorDealChangesLogs(viewModel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                result = mDealProvider.Delete_Air_DistributorDeals(id, obj.AppUserId);
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
