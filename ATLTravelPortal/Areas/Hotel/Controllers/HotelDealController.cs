using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using System.Text.RegularExpressions;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    [ATLTravelPortal.SecurityAttributes.CheckSessionFilter(Order = 1)]
    public class HotelDealController : Controller
    {
        MasterDealProvider masterDealProvider = new MasterDealProvider();
        HotelDealRepository hotelDealRepository = new HotelDealRepository();
        MasterDealProvider mDealProvider = new MasterDealProvider();
        public ActionResult Index(int? id, string filterCountryCode, int? filterCategory, int? filterCityId, int? filterHotelId, string filterDealIdentifier, int? filterCurrency)
        {
            var dealtype = hotelDealRepository.GetDealMasterById(id ?? 0, 2);

            HotelDealViewModel viewmodel = new HotelDealViewModel()
            {
                CurrencyList = masterDealProvider.GetCurrencyList().Where(x=>x.Value=="1"),
                HotelList = hotelDealRepository.GetAllHotelList(),
                DealMasterList = mDealProvider.GetAllDealMasterList(2),
                DealIdentifierList = hotelDealRepository.GetDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0),
                DealList = hotelDealRepository.GetAllDeals(id, filterCountryCode, filterCategory, filterCityId, filterHotelId, filterDealIdentifier, filterCurrency)
            };

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetailList", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(HotelDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.MakerId = obj.AppUserId;
            model.MakerDate = DateTime.Now;
            model.isVerified = false;

            hotelDealRepository.Update_Htl_Deals(model);

            HotelDealViewModel viewmodel = new HotelDealViewModel()
            {

                CurrencyList = masterDealProvider.GetCurrencyList().Where(x => x.Value == "1"),
                HotelList = hotelDealRepository.GetAllHotelList(),
                DealMasterList = mDealProvider.GetAllDealMasterList(2),
                DealIdentifierList = hotelDealRepository.GetDealIdentifiers(hotelDealRepository.GetDealMasterById(model.DealMasterId,2).DealTypeId),
                DealList = hotelDealRepository.GetAllDeals(model.DealMasterId, null, null, null, null, null, null)
            };

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("DisplayDealTemplate", viewmodel);
            else
                return View(viewmodel);
        }


        public ActionResult Create(int id)
        {
            HotelDealViewModel viewmodel = new HotelDealViewModel()
            {
                CurrencyList = masterDealProvider.GetCurrencyList().Where(x => x.Value == "1"),
                HotelList = hotelDealRepository.GetAllHotelList(),
                DealMasterList = mDealProvider.GetAllDealMasterList(2),
                DealIdentifierList = hotelDealRepository.GetDealIdentifiers(hotelDealRepository.GetDealMasterById(id,2).DealTypeId),

                DealMasterId = id,
                DealMaserText = hotelDealRepository.GetDealMasterById(id,2).DealName
            };


            if (Request != null && Request.IsAjaxRequest())
                return PartialView("CreateDealTemplate", viewmodel);
            else
                return View(viewmodel);
        }

        public IEnumerable<SelectListItem> GetEmtpyCityList()
        {
            var CityList = new List<SelectListItem>();

            var teml = new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            };
            CityList.Add(teml);
            return CityList.AsEnumerable();
        }

        [HttpPost]
        public ActionResult Create(HotelDealViewModel model)
        {
            HotelDealViewModel viewmodel = new HotelDealViewModel()
            {
                CurrencyList = masterDealProvider.GetCurrencyList().Where(x => x.Value == "1"),
                HotelList = hotelDealRepository.GetAllHotelList(),
                DealMasterList = mDealProvider.GetAllDealMasterList(2),
                DealIdentifierList = hotelDealRepository.GetDealIdentifiers(hotelDealRepository.GetDealMasterById(model.DealMasterId,2).DealTypeId),
                DealMaserText = hotelDealRepository.GetDealMasterById(model.DealMasterId,2).DealName
            };

            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.MakerId = obj.AppUserId;
            model.MakerDate = DateTime.UtcNow;
            model.isVerified = true;
            model.VerifiedBy = obj.AppUserId;
            model.VerifiedDate = DateTime.UtcNow;

            int dealId = hotelDealRepository.Save_HTL_Deals(model);

            HotelDealViewModel viewModel = new HotelDealViewModel();

            viewModel = hotelDealRepository.GetDealDetail(dealId);

            viewModel.CurrencyList = masterDealProvider.GetCurrencyList().Where(x => x.Value == "1");
            viewModel.HotelList = hotelDealRepository.GetAllHotelList();
            viewModel.DealMasterList = mDealProvider.GetAllDealMasterList(2);
            viewModel.DealIdentifierList = hotelDealRepository.GetDealIdentifiers(hotelDealRepository.GetDealMasterById(model.DealMasterId,2).DealTypeId);
            viewModel.DealMaserText = hotelDealRepository.GetDealMasterById(model.DealMasterId,2).DealName;

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDealDetail(int id)
        {
            HotelDealViewModel viewModel = new HotelDealViewModel();
            viewModel = hotelDealRepository.GetDealDetail(id);
            viewModel.CurrencyList = masterDealProvider.GetCurrencyList().Where(x => x.Value == "1");
            viewModel.HotelList = hotelDealRepository.GetAllHotelList();
            viewModel.DealMasterList = mDealProvider.GetAllDealMasterList(2);
            viewModel.DealIdentifierList = hotelDealRepository.GetDealIdentifiers(hotelDealRepository.GetDealMasterById(viewModel.DealMasterId,2).DealTypeId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDealEdit(HotelDealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            hotelDealRepository.Update_Htl_Deals(model);

            HotelDealViewModel viewModel = new HotelDealViewModel();
            viewModel = hotelDealRepository.GetDealDetail(model.HotelDealId);
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDealCancel(int id)
        {
            HotelDealViewModel viewModel = new HotelDealViewModel();
            viewModel = hotelDealRepository.GetDealDetail(id);

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
                result = hotelDealRepository.Delete_HTL_Deals(id, obj.AppUserId);
                returnJsonData.Data = result;
            }
            catch (Exception ex)
            {
                returnJsonData.Data = "Sorry, unable to delete deal!";
            }
            return returnJsonData;
        }

        [HttpGet]
        public ActionResult CreateDeal()
        {
            MasterDealviewModel viewmodel = new MasterDealviewModel()
            {
                DealMasterList = mDealProvider.GetAllHotelDealMasterList(),
                DealTypeList = mDealProvider.GetAllDealTypeList(2),
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_CreateNewDeal", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult CreateDeal(MasterDealviewModel model)
        {
            ValidateMasterDealviewModel(model);
            try
            {
                if (!ModelState.IsValid)
                {
                    if (model.CopyDeal == true)
                    {
                        mDealProvider.CopyDealfromOneToAnother(model.DealName, model.DealMasterId, model.DealTypeId, model.EffectiveFrom, model.ExpireOn);
                    }
                    else
                    {
                        mDealProvider.AddDealMaster(model, 2);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
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
