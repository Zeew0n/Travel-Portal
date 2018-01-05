using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class BranchDealSetupController : Controller
    {
        BranchDealProvider mDealProvider = new BranchDealProvider();
        AirLineInformationProvider airlineInfoProvider = new AirLineInformationProvider();

        public ActionResult Index(int? id, int? FilterBusOperatorId, int? FilterBusCategoryId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            var dealtype = mDealProvider.GetBranchDealMasterById(id ?? 0);
            BranchDealViewModel viewmodel = new BranchDealViewModel();

            viewmodel.BusOperatorList = mDealProvider.GetAllBusOperatorList();
            viewmodel.BusCategoryList = mDealProvider.GetAllBusCategoryList(FilterBusOperatorId ?? 0);
            viewmodel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId);

            viewmodel.CurrencyList = mDealProvider.GetCurrencyList();
            viewmodel.DealList = mDealProvider.GetAllBusBranchDeals(id, FilterBusOperatorId, FilterBusCategoryId);

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

            mDealProvider.Update_Bus_BranchDeals(model);

            BranchDealViewModel viewmodel = new BranchDealViewModel()
            {
                //AirlineNameList = mDealProvider.GetAllAirlineNameList(),
                CurrencyList = mDealProvider.GetCurrencyList(),
                DealMasterList = mDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId),
                DealList = mDealProvider.GetAllBusDistributorDeals(model.DealMasterId, null, null)               
            };

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("DisplayDealTemplate", viewmodel);
            else
                return View(viewmodel);
        }
        public ActionResult Create(int id, int? FilterBusOperatorId, int? FilterBusCategoryId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];           
            BranchDealViewModel viewmodel = new BranchDealViewModel();
          
            viewmodel.BusOperatorList = mDealProvider.GetAllBusOperatorList();
            viewmodel.BusCategoryList = mDealProvider.GetAllBusCategoryList(FilterBusOperatorId ?? 0);

            viewmodel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId);
            viewmodel.DealMasterId = id;
            viewmodel.DealMaserText = mDealProvider.GetBranchDealMasterById(id).BranchDealName;

            viewmodel.BusOperatorId = FilterBusOperatorId;
            viewmodel.BusCategoryId = FilterBusCategoryId;
            viewmodel.BusOperatorName = mDealProvider.GetBusOperatorById(FilterBusCategoryId ?? 0);
            viewmodel.BusCategoryName = mDealProvider.GetBusCategoryById(FilterBusCategoryId ?? 0);

          
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
                CurrencyList = mDealProvider.GetCurrencyList(),
                DealMasterList = mDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId),
                DealMaserText = mDealProvider.GetBranchDealMasterById(model.DealMasterId).BranchDealName,
                BusOperatorList = mDealProvider.GetAllBusOperatorList(),
                BusCategoryList = mDealProvider.GetAllBusCategoryList(model.BusOperatorId ?? 0)
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

                int dealId = mDealProvider.Save_Bus_BranchDeals(model);

                viewModel = mDealProvider.GetBusBranchDealDetail(dealId);
             
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId);

                if (Request != null && Request.IsAjaxRequest())
                    return PartialView("VUC_DealDetail", viewModel);
                else
                    return View(viewModel);
            }
            else
            {
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId);

                return View(viewModel);
            }
        }

        public ActionResult Edit(BranchDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            mDealProvider.Update_Bus_BranchDeals(model);

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetBusBranchDealDetail(model.DealId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            JsonResult returnJsonData = new JsonResult();

            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = mDealProvider.GetBusBranchDealDetail(id);

            try
            {
                mDealProvider.Air_BranchDealChangesLogs(viewModel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                result = mDealProvider.Delete_Bus_BranchDeals(id, obj.AppUserId);
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
