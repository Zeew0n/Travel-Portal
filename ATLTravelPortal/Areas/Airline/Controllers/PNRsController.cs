using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order=1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class PNRsController : Controller
    {
       // PNRInfoProvider _pnrinfoProvier = new PNRInfoProvider();
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult PNRList()
        //{
        //    try
        //    {
        //        TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

        //        return View(_pnrinfoProvier.GetPNRsListByAgentId(1, obj.AgentId));
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewData["message"] = "<font color='red'>" + ex.Message + "</font>";
        //        return View();
        //    }
        //}

        PNRInfoProvider _pnrinfoProvier = new PNRInfoProvider();

        GeneralProvider defaultProvider = new GeneralProvider();


        public ActionResult Index(int? pageNo, int? flag)
        {
            TravelSession obj = (TravelSession)Session["TravelSessionInfo"];
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");

            Galileo.PnrService.DisplayRetrievePNR result = (Galileo.PnrService.DisplayRetrievePNR)TempData["Result"];

            PNRRetrieveResult resultViewmodel = new PNRRetrieveResult();
            if (result != null)
            {
                resultViewmodel.passengerList = result.PaxDetailList;
                resultViewmodel.phoneInfo = result.PhoneDetailList;
                resultViewmodel.segList = result.AirSegmentList;
                resultViewmodel.vndRemark = result.VendorRemarkList;
                resultViewmodel.seatSellList = result.SeatSellList;
                resultViewmodel.vendorRecordLocatorList = result.VendorRecordLocatorList;

                resultViewmodel.RecLoc = result.RecLoc;
                resultViewmodel.CodeCheck = result.CodeCheck;
                resultViewmodel.CreatingAgncyIATANum = result.CreatingAgncyIATANum;
                resultViewmodel.CreatingAgntSignOn = result.CreatingAgntSignOn;
                resultViewmodel.CreationDt = result.CreationDt;
                resultViewmodel.CurAgncyPCC = result.CurAgncyPCC;
                resultViewmodel.CurAgntSONID = result.CurAgntSONID;
                resultViewmodel.CurDtStamp = result.CurDtStamp;
                resultViewmodel.CurTmStamp = result.CurTmStamp;
                resultViewmodel.ETkDataExistInd = result.ETkDataExistInd;
                resultViewmodel.FareDataExistsInd = result.FareDataExistsInd;
                resultViewmodel.FileAddr = result.FileAddr;
                resultViewmodel.HeaderLine = result.HeaderLine;
                resultViewmodel.IMUdataexists = result.IMUdataexists;
                resultViewmodel.MCODataExists = result.MCODataExists;
                resultViewmodel.OrigBkLocn = result.OrigBkLocn;
                resultViewmodel.OrigRcvd = result.OrigRcvd;
                resultViewmodel.PNRAutoNotifyInd = result.PNRAutoNotifyInd;
                resultViewmodel.PNRAutoServiceInd = result.PNRAutoServiceInd;
                resultViewmodel.PNRBFChangeInd = result.PNRBFChangeInd;
                resultViewmodel.PNRBFPurgeDt = result.PNRBFPurgeDt;

                resultViewmodel.PNRBFTicketedInd = result.PNRBFTicketedInd;
                resultViewmodel.QInd = result.QInd;
                resultViewmodel.TkArrangement = result.TkArrangement;
                resultViewmodel.TkNumExistInd = result.TkNumExistInd;
            }

            // resultViewmodel.VendorLocatorToRetrive = _pnrinfoProvier.Air_GetToRetrivePNRs(obj.AgentId);

            resultViewmodel.VendorLocatorList = _pnrinfoProvier.ListVendorLocator(resultViewmodel.AgentId);



            int currentPageNo = 0; int numberOfPage = 0;
            if (pageNo == null)
                pageNo = 1;

            if (Request.IsAjaxRequest())
            {
                ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");

                resultViewmodel.VendorLocatorList = _pnrinfoProvier.GetVendorLocatorByPagination(resultViewmodel, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
                ViewData["TotalPages"] = numberOfPage;
                ViewData["CurrentPage"] = currentPageNo;
                return PartialView("VUC_VndLocatorToRetrieve", resultViewmodel);
            }
            resultViewmodel.VendorLocatorList = _pnrinfoProvier.GetVendorLocatorByPagination(resultViewmodel, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
            ViewData["TotalPages"] = numberOfPage;
            ViewData["CurrentPage"] = currentPageNo;


            return View(resultViewmodel);
        }


        [HttpPost]
        public ActionResult Index(string RecordLocator, FormCollection coll)
        {
           
            PNRRetrieveResult resultViewmodel = new PNRRetrieveResult();
            try
            {
                if (coll.AllKeys.Contains("Search"))
                {
                    var PnrRetrieveResult = _pnrinfoProvier.GetPNRResult(resultViewmodel.AgentId, RecordLocator.Trim());
                    if (PnrRetrieveResult != null)
                        _pnrinfoProvier.UpdateAir_AirlineVendorLocators(PnrRetrieveResult, resultViewmodel.AgentId, RecordLocator.Trim());

                    return PartialView("VUC_PNRsResult", GetPNRRetrieveResultModel(PnrRetrieveResult));
                }
                else if (coll.AllKeys.Contains("CancelPNR"))
                {
                    bool isPnrDeleted = false;
                    //Galileo.PnrService.DisplayRetrievePNR cancelPNRResponse = _pnrinfoProvier.CancelPnr(resultViewmodel.AgentId, obj.AgentCode, RecordLocator);

                    //if (cancelPNRResponse != null)
                    //{
                    //    resultViewmodel = GetPNRRetrieveResultModel(cancelPNRResponse);
                    //    isPnrDeleted = true;
                    //}
                    if (isPnrDeleted)
                        TempData["ActionResponse"] = string.Format("Passenger Name Record (PNR) {0} is deleted successfully.", RecordLocator);
                    else
                        TempData["ActionResponse"] = string.Format("Passenger Name Record (PNR) {0} is not deleted.", RecordLocator);

                    return PartialView("VUC_PNRsResult", resultViewmodel);
                }
                return PartialView("VUC_PNRSResult");
            }
            catch (GDS.GDSException ex)
            {
                
                System.Text.StringBuilder errorBuilder = new System.Text.StringBuilder();
                foreach (GDS.GdsErrorData errors in ex.GDSErrors)
                {
                    //errorBuilder.Append(errors.TransactionErrorCode + "  " + errors.TransactionErrorMessage + "  ");
                    //errorBuilder.Append(errors.ErrorCode + "  " + errors.ErrorMessage);
                    errorBuilder.Append(errors.ErrorMessage);
                    errorBuilder.Append(errors.ErrText);
                }
                TempData["ActionResponse"] = errorBuilder;
                return PartialView("VUC_PNRsResult");
            }
            catch (Exception ex)
            {
                return PartialView("VUC_PNRsResult");
            }
        }


        public ActionResult PNRList()
        {
            try
            {
                TravelSession obj = (TravelSession)Session["TravelSessionInfo"];

                PNRRetrieveResult resultViewmodel = new PNRRetrieveResult();

                return View(_pnrinfoProvier.GetPNRsListByAgentId(1, resultViewmodel.AgentId));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public PNRRetrieveResult GetPNRRetrieveResultModel(Galileo.PnrService.DisplayRetrievePNR result)
        {
            PNRRetrieveResult resultViewmodel = new PNRRetrieveResult();

            resultViewmodel.passengerList = result.PaxDetailList;
            resultViewmodel.phoneInfo = result.PhoneDetailList;
            resultViewmodel.segList = result.AirSegmentList;
            resultViewmodel.vndRemark = result.VendorRemarkList;
            resultViewmodel.seatSellList = result.SeatSellList;
            resultViewmodel.vendorRecordLocatorList = result.VendorRecordLocatorList;

            resultViewmodel.RecLoc = result.RecLoc;
            resultViewmodel.CodeCheck = result.CodeCheck;
            resultViewmodel.CreatingAgncyIATANum = result.CreatingAgncyIATANum;
            resultViewmodel.CreatingAgntSignOn = result.CreatingAgntSignOn;
            resultViewmodel.CreationDt = result.CreationDt;
            resultViewmodel.CurAgncyPCC = result.CurAgncyPCC;
            resultViewmodel.CurAgntSONID = result.CurAgntSONID;
            resultViewmodel.CurDtStamp = result.CurDtStamp;
            resultViewmodel.CurTmStamp = result.CurTmStamp;
            resultViewmodel.ETkDataExistInd = result.ETkDataExistInd;
            resultViewmodel.FareDataExistsInd = result.FareDataExistsInd;
            resultViewmodel.FileAddr = result.FileAddr;
            resultViewmodel.HeaderLine = result.HeaderLine;
            resultViewmodel.IMUdataexists = result.IMUdataexists;
            resultViewmodel.MCODataExists = result.MCODataExists;
            resultViewmodel.OrigBkLocn = result.OrigBkLocn;
            resultViewmodel.OrigRcvd = result.OrigRcvd;
            resultViewmodel.PNRAutoNotifyInd = result.PNRAutoNotifyInd;
            resultViewmodel.PNRAutoServiceInd = result.PNRAutoServiceInd;
            resultViewmodel.PNRBFChangeInd = result.PNRBFChangeInd;
            resultViewmodel.PNRBFPurgeDt = result.PNRBFPurgeDt;

            resultViewmodel.PNRBFTicketedInd = result.PNRBFTicketedInd;
            resultViewmodel.QInd = result.QInd;
            resultViewmodel.TkArrangement = result.TkArrangement;
            resultViewmodel.TkNumExistInd = result.TkNumExistInd;

            return resultViewmodel;
        }

        public ActionResult Update(string id)
        {
            TravelSession obj = (TravelSession)Session["TravelSessionInfo"];
            PNRRetrieveResult resultViewmodel = new PNRRetrieveResult();
            try
            {

                var PnrRetrieveResult = _pnrinfoProvier.GetPNRResult(resultViewmodel.AgentId, id.Trim());
                if (PnrRetrieveResult != null)
                    _pnrinfoProvier.UpdateAir_AirlineVendorLocators(PnrRetrieveResult, resultViewmodel.AgentId, id.Trim());
                TempData["Result"] = PnrRetrieveResult;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               
                System.Text.StringBuilder errorBuilder = new System.Text.StringBuilder();
                errorBuilder.Append(ex.Message);
                errorBuilder.Append(ex.InnerException);
                TempData["ActionResponse"] = errorBuilder;
                return RedirectToAction("Index");
            }
           
        }

















    }
}
