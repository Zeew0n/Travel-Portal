using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using System.Text.RegularExpressions;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Delete = "Delete", Edit = "Edit", Order = 2)]
    public class DealSetupController : Controller
    {
        MasterDealProvider mDealProvider = new MasterDealProvider();
        AirLineInformationProvider airlineInfoProvider = new AirLineInformationProvider();
        BranchDealProvider mbDealProvider = new BranchDealProvider();

        public ActionResult Index(int? id, string FilterDealIdentifierId, int? FilterBusOperatorId, int? FilterBusCategoryId, int? FilterCurrencyId)
        {
            var dealtype = mDealProvider.GetDealMasterById(id ?? 0);
            DealViewModel viewmodel = new DealViewModel();

            viewmodel.DealMasterList = mDealProvider.GetAllDealMasterList(4);
            viewmodel.DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList();
            viewmodel.DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList();

            viewmodel.BusOperatorList = mbDealProvider.GetAllBusOperatorList();
            viewmodel.BusCategoryList = mbDealProvider.GetAllBusCategoryList(FilterBusOperatorId ?? 0);

            viewmodel.CurrencyList = mDealProvider.GetCurrencyList().Where(x=>x.Value=="1");
            viewmodel.DealIdentifierList = mDealProvider.GetBusDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
            viewmodel.DealList = mDealProvider.GetAllBusDeals(id, FilterDealIdentifierId, FilterBusOperatorId, FilterBusCategoryId, FilterCurrencyId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetailList", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(DealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.MakerId = obj.AppUserId;
            model.MakerDate = DateTime.Now;
            model.isVerified = false;
            model.isDelete = false;

            mDealProvider.Update_Tkt_Deals(model);
            DealViewModel viewmodel = new DealViewModel()
                        {

                            CurrencyList = mDealProvider.GetCurrencyList().Where(x=>x.Value=="1"),
                            DealMasterList = mDealProvider.GetAllDealMasterList(4),
                            DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList(),
                            DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList(),
                            BusOperatorList = mbDealProvider.GetAllBusOperatorList(),
                            BusCategoryList = mbDealProvider.GetAllBusCategoryList(model.BusOperatorId ?? 0),
                            DealIdentifierList = mDealProvider.GetBusDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId),
                            DealList = mDealProvider.GetAllBusDeals(model.DealMasterId, null, null, null, null)
                        };

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("DisplayDealTemplate", viewmodel);
            else
                return View(viewmodel);
        }

        public ActionResult Create(int id, int? FilterDealIdentifierId, string FilterDealIdentifierText, int? FilterBusOperatorId, int? FilterBusCategoryId, int? FilterCurrencyId)
        {
            DealViewModel viewmodel = new DealViewModel();
            
            viewmodel.DealMasterList = mDealProvider.GetAllDealMasterList(1);
            viewmodel.DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList();
            viewmodel.DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList();
            viewmodel.DealMasterId = id;
            viewmodel.DealMaserText = mDealProvider.GetDealMasterById(id).DealName;
            viewmodel.DealIdentifierId = FilterDealIdentifierId != null ? FilterDealIdentifierId.Value : 0;
            viewmodel.DealIdentifierText = FilterDealIdentifierText;
            viewmodel.BusOperatorId = FilterBusOperatorId != null ? FilterBusOperatorId.Value : 0; 
            viewmodel.BusCategoryId = FilterBusCategoryId!=null?FilterBusCategoryId.Value :0;
            viewmodel.CurrencyId = FilterCurrencyId != null ? FilterCurrencyId.Value : 0;

            viewmodel.BusOperatorList = mbDealProvider.GetAllBusOperatorList();
            viewmodel.BusCategoryList = mbDealProvider.GetAllBusCategoryList(FilterBusOperatorId ?? 0);


            viewmodel.CurrencyList = mDealProvider.GetCurrencyList().Where(x=>x.Value=="1");
            viewmodel.DealIdentifierList = mDealProvider.GetBusDealIdentifiers(mDealProvider.GetDealMasterById(id).DealTypeId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("CreateDeal", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(DealViewModel model)
        {

            DealViewModel viewmodel = new DealViewModel()
            {
                CurrencyList = mDealProvider.GetCurrencyList().Where(x => x.Value == "1"),
                DealMasterList = mDealProvider.GetAllDealMasterList(4),
                DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList(),
                DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList(),
                DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId),
                DealMaserText = mDealProvider.GetDealMasterById(model.DealMasterId).DealName
            };

            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.MakerId = obj.AppUserId;
            model.MakerDate = DateTime.UtcNow;
            model.isVerified = true;
            model.VerifiedBy = obj.AppUserId;
            model.VerifiedDate = DateTime.UtcNow;
            model.isDelete = false;

            int dealId = mDealProvider.Save_Bus_Deals(model);

            DealViewModel viewModel = new DealViewModel();

            viewModel = mDealProvider.GetBusDealDetail(dealId);

            viewModel.CurrencyList = mDealProvider.GetCurrencyList().Where(x => x.Value == "1");
            viewModel.DealMasterList = mDealProvider.GetAllDealMasterList(4);
            viewModel.BusOperatorList = mbDealProvider.GetAllBusOperatorList();
            viewmodel.BusCategoryList = mbDealProvider.GetAllBusCategoryList(model.BusOperatorId ?? 0);
            viewModel.DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList();
            viewModel.DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList();
            viewModel.DealIdentifierList = mDealProvider.GetBusDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult Edit(DealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            mDealProvider.Update_Bus_Deals(model);

            DealViewModel viewModel = new DealViewModel();
            viewModel = mDealProvider.GetBusDealDetail(model.DealId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            JsonResult returnJsonData = new JsonResult();
            try
            {
                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                result = mDealProvider.Delete_Bus_Deals(id, obj.AppUserId);
                returnJsonData.Data = result;
            }
            catch (Exception ex)
            {
                returnJsonData.Data = "Sorry, unable to delete deal!";
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
