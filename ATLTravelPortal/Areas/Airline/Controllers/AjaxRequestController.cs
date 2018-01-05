#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
#endregion



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Repository;
using AirLines.Provider.Admin;
using ATLTravelPortal.Areas.Hotel.Repository;
using System.Text.RegularExpressions;


namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [ATLTravelPortal.SecurityAttributes.CheckSessionFilter(Order = 1)]
    public class AjaxRequestController : Controller
    {
        //
        // GET: /AjaxRequest/
        AirLineInformationProvider ser = new AirLineInformationProvider();
        TicketAirlineSearchProvider _ser = new TicketAirlineSearchProvider();
        AirLineCityInformationProvider sers = new AirLineCityInformationProvider();
        TravelFareProvider _tfareprovider = new TravelFareProvider();
        GeneralProvider _provider = new GeneralProvider();
        MasterDealProvider _DealProvider = new MasterDealProvider();
        SectorSalesReportProvider serRP = new SectorSalesReportProvider();
        PNRManagementRepository serPM = new PNRManagementRepository();
        MasterDealProvider mDealProvider = new MasterDealProvider();
        BranchDealProvider bDealProvider = new BranchDealProvider();
        PNRsModel _modPNR = new PNRsModel();
        PNRDetailProvider _PNRDetailprovider = new PNRDetailProvider();
        PNRSegmentsModel _modPNRSeg = new PNRSegmentsModel();
        PassengersModel _modPassenger = new PassengersModel();
        FareModel _modFare = new FareModel();
        EntityModel ent = new EntityModel();

        HotelDealRepository hotelDealRepository = new HotelDealRepository();
        OnLineAirlineSettingsProvider OnlineAirlineSettings = new OnLineAirlineSettingsProvider();

        ////////////////////find airline//////////////////

        ///////From AirlineSchedule////////////

        [HttpPost]
        public JsonResult FindAirlinesCode(string searchText, int maxResult)
        {
            var result = OnlineAirlineSettings.GetAirlineCode(searchText, maxResult);
            return Json(result);
        }

        [HttpPost]
        public JsonResult FindAirline(string searchText, int maxResult)
        {
            var result = ser.GetAllAirlineNameList(searchText, maxResult);
            return Json(result);
        }

        [HttpPost]
        public JsonResult FindAirlineByAirLineType(string searchText, int AirlineTypeId, int maxResult)
        {

            if (AirlineTypeId == 1)
            {
                var result = _ser.GetAllInternationalAirlineNameList(searchText, maxResult);
                return Json(result);
            }
            else if (AirlineTypeId == 2)
            {
                var result = _ser.GetAllDomesticAirlineNameList(searchText, maxResult);
                return Json(result);
            }
            else
            {
                var result = _ser.GetAllLccAirlineNameList(searchText, maxResult);
                return Json(result);
            }


        }
        [HttpPost]
        public JsonResult FindAirlineCity(string searchText, int maxResult)
        {
            var result = GetAirlineCity(searchText, maxResult);
            return Json(result);
        }

        public List<AirlineCities> GetAirlineCity(string AirlineCityName, int maxResult)
        {
            return sers.GetAllAirlineCityList(AirlineCityName, maxResult).ToList();
        }
        public JsonResult FindBusCity(string searchText, int maxResult)
        {
            var result = GetBusCity(searchText, maxResult);
            return Json(result);

        }
        public List<Bus_Cities> GetBusCity(string BusCityName, int maxResult)
        {

            return sers.GetAllBusCityNameList(BusCityName, maxResult).ToList();

        }
        [HttpPost]
        public JsonResult FindAirline(string searchText, int maxResult, int Type)
        {

            var result = GetAirline(searchText, maxResult, Type);
            return Json(result);
        }

        public List<Airlines> GetAirline(string AirlineName, int maxResult, int Type)
        {
            if (Type == 1)
            {
                return ser.GetAllAirlineNameList(AirlineName, maxResult).ToList();
            }
            return ser.GetAllDomesticAirlineNameList(AirlineName, maxResult).ToList();
        }

        //FromTravelFareController///////////////
        public JsonResult GetFlightClassCodeByAirline(int id)
        {

            var result = new JsonResult();
            var lists = new SelectList(_tfareprovider.GetFlightClassCodeByAirlineID(id), "DomesticFlightClassId", "FlightClassCode");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public JsonResult GetAirlines(int AirlineTypeId)
        {
            var model = _provider.GetAirlinesList(AirlineTypeId).ToList();
            JsonResult result = new JsonResult();
            result.Data = new SelectList(model, "AirlineId", "AirlineName");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public JsonResult GetCities(int AirlineTypeId)
        {
            var model = _provider.CityListAsperFlightType(AirlineTypeId).ToList();
            JsonResult result = new JsonResult();
            result.Data = new SelectList(model, "CityID", "CityName");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        //////////////////////////////


        ////MasterDealSetUp Controller//////
        [HttpPost]
        public ActionResult GetAllDealAssociatedlToAgent(int id)
        {

            MasterDealviewModel viewmodel = new MasterDealviewModel()
            {
                AssociatedAgentList = _DealProvider.GetDealDetailsByAgent(id),
            };

            return PartialView("PVC_AssociatedAgentinDeal", viewmodel);
        }
        [HttpPost]
        public ActionResult GetDealByAirline(int id)
        {

            MasterDealviewModel viewmodel = new MasterDealviewModel()
            {
                AirlineWiseDealDetailsList = _DealProvider.GetAllDealDetailsByAirline(id),
            };

            return PartialView("PVC_AirlineWiseDealDetails", viewmodel);
        }
        [HttpPost]
        public JsonResult FindAirlines(string searchText, int maxResult)
        {

            var result = _DealProvider.GetAirlineName(searchText, maxResult);
            return Json(result);
        }
        /////////////////


        ///////////////////////////Brnach Deal Setup Action Starts Here/////////////////////////////
        public ActionResult AjaxBranchDealDetail(int id, string source)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();

            viewModel = bDealProvider.GetDealDetail(id);
            viewModel.AirlineNameList = bDealProvider.GetAllAirlineNameList();
            viewModel.DealMasterList = bDealProvider.GetAllBranchDealMasterList(1, obj.LoginTypeId);
            viewModel.CurrencyList = bDealProvider.GetCurrencyList();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxBranchDealCancel(int id)
        {
            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = bDealProvider.GetDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult DeleteBranchMasterDealForceFully(int id, string name)
        {
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
                viewmodel.DealMasterList = bDealProvider.GetAllBranchDealMasterList(1, obj.LoginTypeId);
                //result = bDealProvider.Delete_Core_BranchDealMasters(id, obj.AppUserId);

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

        private void ValidateBranchMasterDealviewModel(MasterDealviewModel dealmaster)
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

        ////////////////////////////////////////////////////////////////////////////////////




        ///////////////////////////Distributor Deal Setup Action Starts Here/////////////////////////////
        public ActionResult AjaxDistributorDealDetail(int id, string source)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();

            viewModel = bDealProvider.GetDistributorDealDetail(id);
            viewModel.AirlineNameList = bDealProvider.GetAllAirlineNameList();
            viewModel.DealMasterList = bDealProvider.GetAllDistributorDealMasterList(1, obj.LoginTypeId);
            viewModel.CurrencyList = bDealProvider.GetCurrencyList();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DistributorDealEdit", viewModel);
            else
                return View(viewModel);
        }



        public ActionResult AjaxDistributorDealCancel(int id)
        {
            BranchDealViewModel viewModel = new BranchDealViewModel();
            viewModel = bDealProvider.GetDistributorDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DistributorDealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult DeleteDistributorMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            BranchDealViewModel viewmodel = new BranchDealViewModel();
            viewmodel = bDealProvider.GetDistributorDealDetail(id);

            BranchDealViewModel masterviewmodel = new BranchDealViewModel();
            masterviewmodel = bDealProvider.GetDistributorMasterDealDetail(id);

            try
            {
                bDealProvider.Air_DistributorDealChangesLogs(viewmodel);
                bDealProvider.Air_DistributorDealMasterChangesLogs(masterviewmodel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                viewmodel.DealMasterList = bDealProvider.GetAllDistributorDealMasterList(1, obj.LoginTypeId);
                //result = bDealProvider.Delete_Core_DistributorDealMasters(id, obj.AppUserId);
                bDealProvider.Delete_Core_DistributorDeals(id, obj.AppUserId);
                bDealProvider.Delete_Core_DistributorDealMasters(id, obj.AppUserId);
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


        public ActionResult DeleteBusDistributorMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            BranchDealViewModel viewmodel = new BranchDealViewModel();
            viewmodel = bDealProvider.GetDistributorDealDetail(id);

            BranchDealViewModel masterviewmodel = new BranchDealViewModel();
            masterviewmodel = bDealProvider.GetDistributorMasterDealDetail(id);

            try
            {
                bDealProvider.Air_DistributorDealChangesLogs(viewmodel);
                bDealProvider.Air_DistributorDealMasterChangesLogs(masterviewmodel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                viewmodel.DealMasterList = bDealProvider.GetAllDistributorDealMasterList(4, obj.LoginTypeId);
                //result = bDealProvider.Delete_Core_DistributorDealMasters(id, obj.AppUserId);
                bDealProvider.Delete_Core_DistributorDeals(id, obj.AppUserId);
                bDealProvider.Delete_Core_DistributorDealMasters(id, obj.AppUserId);
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

        public ActionResult DeleteBusBranchMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            BranchDealViewModel viewmodel = new BranchDealViewModel();
            viewmodel = bDealProvider.GetBusBranchDealDetail(id);

            BranchDealViewModel masterviewmodel = new BranchDealViewModel();
            masterviewmodel = bDealProvider.GetBranchMasterDealDetail(id);

            try
            {
                bDealProvider.Air_DistributorDealChangesLogs(viewmodel);
                bDealProvider.Air_DistributorDealMasterChangesLogs(masterviewmodel);

                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                viewmodel.DealMasterList = bDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId);
                bDealProvider.Delete_Bus_Core_BranchDeals(id, obj.AppUserId);
                bDealProvider.Delete_Core_DistributorDealMasters(id, obj.AppUserId);
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
        ////////////////////////////////////////////////////////////////////////////////////






























        public JsonResult GetLedgerNameofBSPorConsolidatorBasedonAccTypes(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(ser.GetAllLedgerNameofBSPorConsolidatorBasedonAccTypes(id), "LedgerId", "LedgerName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }


        public JsonResult GetDepartCityNameBasedonAirlineTypeId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(serRP.GetCityList(id), "CityID", "CityName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }


        [HttpPost]
        public JsonResult GetCityList(string searchText, int maxResults)
        {
            var result = serPM.GetAllAirlineCity(searchText, maxResults).Where(cc => cc.AirlineCityTypeId == 1);

            List<AirlineCities> _list = new List<AirlineCities>();
            foreach (var x in result)
            {
                _list.Add(new AirlineCities { CityID = x.CityID, CityName = x.CityName, CityCode = x.CityCode });
            }
            return Json(_list);
        }


        public JsonResult GetDealIdentifiers(int? id, string source)
        {
            var dealtype = _DealProvider.GetDealMasterById(id ?? 0);

            var result = new JsonResult();
            if (source == "5")
            {
                IEnumerable<SelectListItem> lists = _DealProvider.GetDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
                result.Data = lists.Where(x => x.Value == "5");
            }
            else
            {
                IEnumerable<SelectListItem> lists = _DealProvider.GetDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
                result.Data = lists;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return result;

        }

        public JsonResult GetBusDealIdentifiers(int? id)
        {
            var dealtype = hotelDealRepository.GetDealMasterById(id ?? 0, 4);
            var result = new JsonResult();
            var lists = _DealProvider.GetBusDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult GetHotelDealIdentifiers(int? id)
        {
            var dealtype = hotelDealRepository.GetDealMasterById(id ?? 0, 2);

            var result = new JsonResult();
            var lists = hotelDealRepository.GetDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        [HttpPost]
        public JsonResult GetAgentNameListAC(string searchText, int maxResult)
        {
            var result = _provider.GetAllAgentNameListForAutoComplete(searchText, maxResult);
            return Json(result);
        }


        ///////////////////////////Deal Setup Action Starts Here/////////////////////////////
        public ActionResult AjaxDealDetail(int id, string source)
        {
            DealViewModel viewModel = new DealViewModel();

            viewModel = mDealProvider.GetDealDetail(id);
            viewModel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
            viewModel.DealMasterList = mDealProvider.GetAllDealMasterList(1);
            viewModel.DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList();
            viewModel.DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList();

            if (source == "5")
            {
                viewModel.CurrencyList = mDealProvider.GetCurrencyList().Where(x => x.Text == "INR");
                IEnumerable<SelectListItem> dealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(viewModel.DealMasterId).DealTypeId);
                if (dealIdentifierList.Count() > 0)
                {
                    var x = Request.QueryString["Source"].ToString();
                    dealIdentifierList = dealIdentifierList.Where(z => z.Value == "5");
                }
                viewModel.DealIdentifierList = dealIdentifierList;
            }
            else
            {
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(viewModel.DealMasterId).DealTypeId);
            }

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDealCancel(int id)
        {
            DealViewModel viewModel = new DealViewModel();
            viewModel = mDealProvider.GetDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult DeleteMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            DealViewModel viewmodel = new DealViewModel();
            try
            {
                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

                result = mDealProvider.Delete_TKT_ForceDeleteMasterDeal(id, obj.AppUserId);
                viewmodel.DealMasterList = mDealProvider.GetAllDealMasterList(1);
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

        public ActionResult DeleteBusMasterDealForceFully(int id, string name)
        {
            JsonResult returnJsonData = new JsonResult();
            DealViewModel viewmodel = new DealViewModel();
            try
            {
                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

                result = mDealProvider.Delete_TKT_BusForceDeleteMasterDeal(id, obj.AppUserId);
                viewmodel.DealMasterList = mDealProvider.GetAllDealMasterList(4);
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

        ////////////////////////////////////////////////////////////////////////////////////

        public ActionResult PNR(int id)
        {
            _modPNR = _PNRDetailprovider.GetPNRDetail(id);
            return PartialView("VUC_PNR", _modPNR);
        }

        public ActionResult PNRSegment(int id)
        {
            _modPNRSeg.PNRSegmentsList = _PNRDetailprovider.GetPNRSegmentList(id);
            return PartialView("VUC_PNRSegment", _modPNRSeg);
        }

        public ActionResult PNRPassenger(int id)
        {
            _modPassenger.PassengersList = _PNRDetailprovider.GetPassengersList(id);
            return PartialView("VUC_PNRPassenger", _modPassenger);
        }

        public ActionResult Fare(int id)
        {
            _modFare = _PNRDetailprovider.GetFare(id);
            return PartialView("VUC_Fare", _modFare);
        }

        [HttpPost]
        public ActionResult GetCoreCityOptions(int id)
        {

            var ddlSelectOptionList = CoreCityProvider.GetSelectListOptions(id);
            JsonResult jResult = new JsonResult();
            jResult.Data = ddlSelectOptionList;
            return jResult;
        }


        [HttpPost]
        public JsonResult GetAccountInfoByAgentId(int agentId)
        {
            var AvailableBalanceResult = _provider.GetAvailableBalanceForAgent(agentId).ToList();
            var Balanceviewmodel = new AvailableBalanceViewModel();
            /// For NPR balance
            ///  //Currency
            Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
            Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
            Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;
            Balanceviewmodel.LeadgerBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).LedgerAmount;

            /// For USD balance
            Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
            Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");
            Balanceviewmodel.LeadgerBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).LedgerAmount : double.Parse("");


            /// For INR balance
            Balanceviewmodel.CurrencyINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode : "";
            Balanceviewmodel.CreditLimitINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).Amount : double.Parse("");


            if (Balanceviewmodel.CurrentBalanceNPR == null)
                Balanceviewmodel.CurrentBalanceNPR = 0;


            double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceNPR = true;
            else
                Balanceviewmodel.isLowBalanceNPR = false;

            double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceUSD = true;
            else
                Balanceviewmodel.isLowBalanceUSD = false;

            double minBalanceINR = Balanceviewmodel.CreditLimitINR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceINR <= minBalanceINR)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceINR = true;
            else
                Balanceviewmodel.isLowBalanceINR = false;

            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = Balanceviewmodel;

            return Json(jsonResult);

        }
    }
}
