using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Controllers
{
    public class AjaxRequestController : Controller
    {
        HotelDealRepository hotelDealRepository = new HotelDealRepository();
        MasterDealProvider _DealProvider = new MasterDealProvider();
        BranchDealProvider bDealProvider = new BranchDealProvider();

        public JsonResult GetMobileDealIdentifiers(int? id)
        {
            var dealtype = hotelDealRepository.GetDealMasterById(id ?? 0, 3);
            var result = new JsonResult();
            var lists = _DealProvider.GetMobileDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult GetMobileServiceProviders(int? id)
        {
            //var dealtype = hotelDealRepository.GetDealMasterById(id ?? 0, 3);
            var result = new JsonResult();
            var lists = _DealProvider.GetMobileServiceProviders();
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        
        public ActionResult DeleteMobileMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            DealViewModel viewmodel = new DealViewModel();
            try
            {
                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

                result = _DealProvider.Delete_MRC_MobileForceDeleteMasterDeal(id, obj.AppUserId);
                viewmodel.DealMasterList = _DealProvider.GetAllDealMasterList(3);
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

        public ActionResult DeleteMobileDistributorMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            BranchDealViewModel viewmodel = new BranchDealViewModel();
            viewmodel = bDealProvider.GetMobileDistributorDealDetail(id);

            BranchDealViewModel masterviewmodel = new BranchDealViewModel();
            masterviewmodel = bDealProvider.GetDistributorMasterDealDetail(id);

            try
            {
                bDealProvider.Mobile_DistributorDealChangesLogs(viewmodel);                

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
               
                bDealProvider.Delete_AgentClassDeals(id, obj.LoginTypeId);
                bDealProvider.Delete_Core_AgentsDeals(id, obj.LoginTypeId);
                bDealProvider.Delete_Mobile_DistributorDeals(id, obj.AppUserId);
                bDealProvider.Delete_Core_DistributorDealMasters(id, obj.AppUserId);

                viewmodel.DealMasterList = bDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId);

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


        public ActionResult DeleteMobileBranchMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            BranchDealViewModel viewmodel = new BranchDealViewModel();
            viewmodel = bDealProvider.GetMobileBranchDealDetail(id);

            BranchDealViewModel masterviewmodel = new BranchDealViewModel();
            masterviewmodel = bDealProvider.GetBranchMasterDealDetail(id);

            try
            {
                bDealProvider.Mobile_BranchDealChangesLogs(viewmodel);
                //bDealProvider.Air_DistributorDealMasterChangesLogs(masterviewmodel);::TODO

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

                bDealProvider.Delete_Mobile_BranchDeals(id, obj.AppUserId);
                bDealProvider.Delete_Core_BranchDealMasters(id, obj.AppUserId);

                viewmodel.DealMasterList = bDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId);

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

        public ActionResult AjaxDealDetail(int id, string source)
        {
            DealViewModel viewModel = new DealViewModel();

            viewModel = _DealProvider.GetMobileDealDetail(id);

            viewModel.DealMasterList = _DealProvider.GetAllDealMasterList(3);
            viewModel.DealAppliedOnList = _DealProvider.GetAllDealAppliedOnList();
            viewModel.DealCalculateOnList = _DealProvider.GetAllDealCalculateOnList();

            viewModel.DealIdentifierList = _DealProvider.GetMobileDealIdentifiers(_DealProvider.GetDealMasterById(viewModel.DealMasterId).DealTypeId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDealCancel(int id)
        {
            DealViewModel viewModel = new DealViewModel();
            viewModel = _DealProvider.GetMobileDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDistributorDealDetail(int id)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetMobileDistributorDealDetail(id);
            
            viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(3, obj.LoginTypeId);
            viewModel.DealIdentifierList = _DealProvider.GetMobileServiceProviders();            

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DistributorDealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxBranchDealDetail(int id)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetMobileBranchDealDetail(id);

            viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(3, obj.LoginTypeId);
            viewModel.DealIdentifierList = _DealProvider.GetMobileServiceProviders();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealEdit", viewModel);
            else
                return View(viewModel);
        }
        public ActionResult AjaxDistributorDealCancel(int id)
        {
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetMobileDistributorDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealDetail", viewModel);
            else
                return View(viewModel);
        }
        public ActionResult AjaxBranchDealCancel(int id)
        {
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetMobileBranchDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealDetail", viewModel);
            else
                return View(viewModel);
        }
    }
}
