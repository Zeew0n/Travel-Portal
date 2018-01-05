using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using System.Text.RegularExpressions;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class HotelDistributorDealSetupController : Controller
    {
        HotelBranchDealProvider mDealProvider = new HotelBranchDealProvider();
        AirLineInformationProvider airlineInfoProvider = new AirLineInformationProvider();
        HotelDealRepository hotelDealRepository = new HotelDealRepository();

        public ActionResult Index(int? id, string FilterDealIdentifierId, int? FilterHotelId, int? FilterCurrencyId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            var dealtype = mDealProvider.GetDistributorDealMasterById(id ?? 0);
            BranchDealViewModel viewmodel = new BranchDealViewModel();

            viewmodel.HotelNameList = hotelDealRepository.GetAllHotelList();
            viewmodel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(2, obj.LoginTypeId);

            viewmodel.CurrencyList = mDealProvider.GetCurrencyList();
            viewmodel.DealList = mDealProvider.GetAllDistributorDeals(id, FilterDealIdentifierId, FilterHotelId, FilterCurrencyId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetailList", viewmodel);
            else
                return View(viewmodel);
        }


        //[HttpPost]
        //public ActionResult Index(BranchDealViewModel model)
        //{
        //    TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

        //    model.MakerId = obj.AppUserId;
        //    model.MakerDate = DateTime.Now;
        //    model.isVerified = false;
        //    model.isDelete = false;

        //    mDealProvider.Update_Htl_BranchDeals(model);

        //    BranchDealViewModel viewmodel = new BranchDealViewModel()
        //    {
        //        HotelNameList = hotelDealRepository.GetAllHotelList(),
        //        CurrencyList = mDealProvider.GetCurrencyList(),
        //        DealMasterList = mDealProvider.GetAllBranchDealMasterList(2, obj.LoginTypeId),

        //        DealList = mDealProvider.GetAllDeals(model.DealMasterId, null, null, null)
        //    };

        //    if (Request != null && Request.IsAjaxRequest())
        //        return PartialView("DisplayDealTemplate", viewmodel);
        //    else
        //        return View(viewmodel);
        //}

        public ActionResult Create(int id, int? FilterDealIdentifierId, string FilterDealIdentifierText, int? FilterHotelId, int? FilterCurrencyId)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            HotelInfoRepository hotelInfoRepository = new HotelInfoRepository();

            var hotelInfo = hotelInfoRepository.GetHotelInfoByHotelID(FilterHotelId ?? 0);
            BranchDealViewModel viewmodel = new BranchDealViewModel();

            viewmodel.HotelNameList = hotelDealRepository.GetAllHotelList();
            viewmodel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(2, obj.LoginTypeId);
            viewmodel.DealMasterId = id;
            viewmodel.DealMaserText = mDealProvider.GetDistributorDealMasterById(id).DistributorDealName;
            viewmodel.DealIdentifierId = FilterDealIdentifierId != null ? FilterDealIdentifierId.Value : 0;
            viewmodel.DealIdentifierText = FilterDealIdentifierText;
            viewmodel.CurrencyId = FilterCurrencyId != null ? FilterCurrencyId.Value : 0;
            viewmodel.HotelId = FilterHotelId;
            viewmodel.HotelName = hotelInfo != null ? hotelInfo.HotelName : string.Empty;
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
                HotelNameList = hotelDealRepository.GetAllHotelList(),
                CurrencyList = mDealProvider.GetCurrencyList(),
                DealMasterList = mDealProvider.GetAllDistributorDealMasterList(2, obj.LoginTypeId),
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

                int dealId = hotelDealRepository.Save_Htl_DistributorDeals(model);

                viewModel = hotelDealRepository.GetDistributorDealDetail(dealId);

                viewModel.HotelNameList = hotelDealRepository.GetAllHotelList();
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(2, obj.LoginTypeId);
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();

                if (Request != null && Request.IsAjaxRequest())
                    return PartialView("VUC_DealDetail", viewModel);

                else
                    return View(viewModel);
            }
            else
            {
                viewModel.HotelNameList = hotelDealRepository.GetAllHotelList();
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(2, obj.LoginTypeId);
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();

                return View(viewModel);
            }
        }

        public ActionResult Edit(BranchDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            mDealProvider.Update_Htl_DistributorDeals(model);

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
            viewModel = hotelDealRepository.GetBranchDealDetail(id);

            try
            {
                mDealProvider.Air_DistributorDealChangesLogs(viewModel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                result = mDealProvider.Delete_Htl_DistributorDeals(id, obj.AppUserId);
                returnJsonData.Data = result;
            }
            catch (Exception ex)
            {
                returnJsonData.Data = "Sorry, unable to delete deal!";
            }
            return returnJsonData;
        }

        private void ValidateBranchMasterDealviewModel(BranchDealViewModel dealmaster)
        {
            bool dealmasterIsNull = dealmaster == null ? true : false;
            const string decimalRegex = @"^\d+(\.\d\d)?$";
            Regex rgx = new Regex(decimalRegex);
            // Validation logic
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.FromCityId.ToString())))
                ModelState.AddModelError("FromCity", "From City is required.");
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.ToCityId.ToString())))
                ModelState.AddModelError("ToCity", "To City is required.");
        }
    }
}
