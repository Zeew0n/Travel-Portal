using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class AjaxRequestController : Controller
    {
        HotelPhotoCategoryRepository _PhotoCatRepo = new HotelPhotoCategoryRepository();
        CardRepository _Cardrepo = new CardRepository();
        IssueCardRepository _issuecardrepo = new IssueCardRepository();
        CustomerCardRepository _Custrepo = new CustomerCardRepository();
        SearchCardRepository _SearchCardrepo = new SearchCardRepository();
        HotelCityInfoAssociationRepository _CityInfoAssocaitionRepo = new HotelCityInfoAssociationRepository();

        /// <summary>
        /// /  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetHotelPhotoCategory(string id)
        {
            JsonResult result = new JsonResult();
            var filteredModels = _PhotoCatRepo.HotelPhtoCategoryByHotelId(int.Parse(id));

            result.Data = filteredModels.ToList();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult CardType(int id)
        {

            var result = new JsonResult();
            var lists = _Cardrepo.GetCardRule(id);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        [HttpPost]
        public JsonResult FindCard(string searchText, int maxResult)
        {
            var result = GetCard(searchText, maxResult);
            return Json(result);
        }

        public List<Htl_Cards> GetCard(string CardNumber, int maxResult)
        {
            return _issuecardrepo.GetAvailableCard(CardNumber, maxResult).ToList();
        }

        [HttpPost]
        public JsonResult FindCustomerInfo(string searchText, int maxResult)
        {
            var result = GetCustomerInfo(searchText, maxResult);
            return Json(result);
        }

        public List<Core_Customers> GetCustomerInfo(string CustomerCode, int maxResult)
        {
            return _Custrepo.GetAddedCustomer(CustomerCode, maxResult).ToList();
        }
        [HttpPost]
        public JsonResult FindCards(string searchText)
        {
            var result = GetCards(searchText);
            return Json(result);
        }

        public List<Htl_Cards> GetCards(string CardNumber)
        {
            return _SearchCardrepo.GetAvailableCard(CardNumber).ToList();
        }
        public JsonResult GetHotelCityInfo(string id)
        {
            JsonResult result = new JsonResult();

            var filteredModels = _CityInfoAssocaitionRepo.HotelCityInfoAssociationByHotelId(int.Parse(id));

            result.Data = filteredModels.ToList();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult HotelsForMap(int id)
        {
            JsonResult jsResult = new JsonResult();
            jsResult.Data = new HotelCityInfoAssociationRepository().GetHotels(id);

            return Json(jsResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHtl_BookingDestinationCity(string id)
        {
            HotelDealRepository hotelDealRepository = new HotelDealRepository();
            var result = new JsonResult();
            var lists = hotelDealRepository.GetAllCityListByCountryCode(id);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        [HttpPost]
        public JsonResult FindHotels(string searchText, int maxResult)
        {
            HotelDealRepository hotelDealRepository = new HotelDealRepository();

            var result = hotelDealRepository.GetHotelName(searchText, maxResult);
            return Json(result);
        }
        /////////////////

        public ActionResult DeleteBranchMasterDealForceFully(int id, string name)
        {
            BranchDealProvider bDealProvider = new BranchDealProvider();

            JsonResult returnJsonData = new JsonResult();
            BranchDealViewModel viewmodel = new BranchDealViewModel();
            viewmodel = bDealProvider.GetDealDetail(id);

            BranchDealViewModel masterviewmodel = new BranchDealViewModel();
            masterviewmodel = bDealProvider.GetMasterDealDetail(id);


            try
            {
                bDealProvider.Air_BranchDealChangesLogs(viewmodel);
                bDealProvider.Air_BranchDealMasterChangesLogs(masterviewmodel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                viewmodel.DealMasterList = bDealProvider.GetAllBranchDealMasterList(2, obj.LoginTypeId);

                bDealProvider.Delete_Core_BranchDeals(id, obj.AppUserId);
                bDealProvider.Delete_Core_BranchDealMasters(id, obj.AppUserId);
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

        ///////////////////////////Brnach Deal Setup Action Starts Here/////////////////////////////
        public ActionResult AjaxBranchDealDetail(int id, string source)
        {
            HotelDealRepository hotelDealRepository = new HotelDealRepository();
            HotelBranchDealProvider mDealProvider = new HotelBranchDealProvider();
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();

            viewModel = hotelDealRepository.GetBranchDealDetail(id);
            viewModel.HotelNameList = hotelDealRepository.GetAllHotelList();
            viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(2, obj.LoginTypeId);
            viewModel.CurrencyList = mDealProvider.GetCurrencyList();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxBranchDealCancel(int id)
        {
            HotelDealRepository hotelDealRepository = new HotelDealRepository();
            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = hotelDealRepository.GetBranchDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealDetail", viewModel);
            else
                return View(viewModel);
        }


        ///////////////////////////Brnach Deal Setup Action Starts Here/////////////////////////////
        public ActionResult AjaxDistributorDealDetail(int id, string source)
        {
            HotelDealRepository hotelDealRepository = new HotelDealRepository();
            HotelBranchDealProvider mDealProvider = new HotelBranchDealProvider();
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();

            viewModel = hotelDealRepository.GetDistributorDealDetail(id);
            viewModel.HotelNameList = hotelDealRepository.GetAllHotelList();
            viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(2, obj.LoginTypeId);
            viewModel.CurrencyList = mDealProvider.GetCurrencyList();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DistributorDealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDistributorDealCancel(int id)
        {
            HotelDealRepository hotelDealRepository = new HotelDealRepository();
            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = hotelDealRepository.GetDistributorDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DistributorDealDetail", viewModel);
            else
                return View(viewModel);
        }
    }
}