using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel;
using ATLTravelPortal.Helpers;
using System.IO;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Details", Add = "Create", Order = 2)]

    public class AirOfflineBookController : Controller
    {

        AirOfflineBookProvider bookProvider = new AirOfflineBookProvider();

        public ActionResult Index()
        {
            OfflineBookViewModel model = new OfflineBookViewModel();
            model.OfflineBookTicketList = bookProvider.ListOfflineBook();
            return View(model);
        }

        public ActionResult Details(long id)
        {
            var model = bookProvider.GetBookedPNRList(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Details(OfflineBookViewModel model, FormCollection fs)
        {
            if (model.PNRBookedList[0].ServiceProviderId != Convert.ToInt32(fs["PreviousServiceProviderId"]))
            {
                //var mpnrResult = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrId).FirstOrDefault();
                //if (model.PNRBookedList[0].TicketStatusId == 33 && model.PNRBookedList[0].ServiceProviderId == 5)
                //{
                //    mpnrResult.TicketStatusId = 24;
                //}

                //if (model.PNRBookedList[0].TicketStatusId == 34 && model.PNRBookedList[0].ServiceProviderId == 5)
                //{
                //    mpnrResult.TicketStatusId = 28;
                //}

                //_entity.ApplyCurrentValues(mpnrResult.EntityKey.EntitySetName, mpnrResult);
                //_entity.SaveChanges();

                bookProvider.UpdateMasterPnrTicketStatusID(model);

                bookProvider.UpdateMasterPnrServiceProviderId(model.PNRBookedList[0].ServiceProviderId, model.PNRBookedList[0].MPNRId);
            }

            GeneralProvider generalProvider = new GeneralProvider();
            decimal totalFare = 0;

            //foreach (var fare in model.PNRBookedList[0].PNRDetails[0].PassengerDetail[0].FareDetails)
            //{
            //    totalFare = Convert.ToDecimal(fare.BaseFare + fare.SellingTax - fare.DiscountAmount);
            //}

            totalFare = bookProvider.GetTotalFareByMPNRID(model.PNRBookedList[0].MPNRId);

            string currency = bookProvider.GetCurrencyByMPNRID(model.PNRBookedList[0].MPNRId);
            model.AvailableBalance = generalProvider.GetAccountInfoByAgentId(model.PNRBookedList[0].UserDetail.AgentId);


            bool IsSufficientBalance = (bool)generalProvider.Air_isSufficientBalance
                (
                    totalFare,
                   model.PNRBookedList[0].UserDetail.AgentId,
                   (int)Enum.Parse(typeof(Galileo.FareService.CurrencyType), currency),
                    model.PNRBookedList[0].ServiceProviderId
                 );


            try
            {

                if (fs.AllKeys.Contains("Issue"))
                {
                    var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                    if (model.PNRBookedList[0].ServiceProviderId == 3)
                    {
                        if (!IsSufficientBalance)
                        {
                            TempData["ActionResponse"] = "Insufficient Balance";
                            return RedirectToAction("Details", new { id = model.PNRBookedList[0].MPNRId });
                        }

                        string recloc = bookProvider.GetRecLoc(model.PNRBookedList[0].MPNRId);
                        if (string.IsNullOrEmpty(recloc))
                        {
                            var result = bookProvider.Edit(model);
                            bookProvider.IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                            bookProvider.Air_UpdateTicketStatusId(model.PNRBookedList[0].MPNRId, "ISSUEPNR", false, ts.AppUserId);
                        }
                        else
                        {
                            bookProvider.Abacus_IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                        }
                        TempData["SuccessMessage"] = "PNR is successfully issued.";
                    }
                    else if (model.PNRBookedList[0].ServiceProviderId == 4)
                    {
                        if (!IsSufficientBalance)
                        {
                            TempData["ActionResponse"] = "Insufficient Balance";
                            return RedirectToAction("Details", new { id = model.PNRBookedList[0].MPNRId });
                        }

                        string recloc = bookProvider.GetRecLoc(model.PNRBookedList[0].MPNRId);
                        if (string.IsNullOrEmpty(recloc))
                        {
                            var result = bookProvider.Edit(model);
                            bookProvider.IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                            bookProvider.Air_UpdateTicketStatusId(model.PNRBookedList[0].MPNRId, "ISSUEPNR", false, ts.AppUserId);
                        }
                        else
                        {
                            bookProvider.Buddha_IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                        }
                        TempData["SuccessMessage"] = "PNR is successfully issued.";
                    }
                    else if (model.PNRBookedList[0].TicketStatusId == 28)
                    {
                        try
                        {
                            var result = bookProvider.Edit(model);

                            bookProvider.IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                            bookProvider.Air_UpdateTicketStatusId(model.PNRBookedList[0].MPNRId, "ISSUEPNR", false, ts.AppUserId);
                            TempData["SuccessMessage"] = "PNR is successfully issued.";
                        }
                        catch
                        {
                            TempData["ActionResponse"] = "Ticket already issued.";
                        }
                    }
                    else if (model.PNRBookedList[0].ServiceProviderId == 1)
                    {
                        if (!IsSufficientBalance)
                        {
                            TempData["ActionResponse"] = "Insufficient Balance";
                            return RedirectToAction("Details", new { id = model.PNRBookedList[0].MPNRId });
                        }

                        string recloc = bookProvider.GetRecLoc(model.PNRBookedList[0].MPNRId);
                        if (string.IsNullOrEmpty(recloc))
                        {
                            var result = bookProvider.Edit(model);
                            bookProvider.IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                            bookProvider.Air_UpdateTicketStatusId(model.PNRBookedList[0].MPNRId, "ISSUEPNR", false, ts.AppUserId);
                        }
                        else
                        {
                            bookProvider.Galileo_IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                        }
                        TempData["SuccessMessage"] = "PNR is successfully issued.";
                    }
                    else
                    {
                        try
                        {
                            if (!IsSufficientBalance)
                            {
                                TempData["ActionResponse"] = "Insufficient Balance";
                                return RedirectToAction("Details", new { id = model.PNRBookedList[0].MPNRId });
                            }
                            var result = bookProvider.Edit(model);
                            bookProvider.IssueTicket(model.PNRBookedList[0].MPNRId, ts.AppUserId);
                            bookProvider.Air_UpdateTicketStatusId(model.PNRBookedList[0].MPNRId, "ISSUEPNR", false, ts.AppUserId);
                            TempData["SuccessMessage"] = "PNR is successfully issued.";
                        }
                        catch
                        {
                            TempData["ActionResponse"] = "Ticket already issued.";
                        }
                    }
                }
                else if (fs.AllKeys.Contains("Save"))
                {
                    var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                    model.UpdatedBy = ts.AppUserId;
                    model.MPNRId = model.PNRBookedList[0].MPNRId;

                    HttpPostedFileBase eTicketFile = model.ticket;
                    if (model.ticket != null)
                    {
                        if (eTicketFile.ContentType == "application/zip" || eTicketFile.ContentType == "application/x-zip-compressed")
                        {
                            var result = bookProvider.Edit(model);
                            TempData["SuccessMessage"] = "PNR is successfully saved.";
                        }
                    }
                    else if (model.ticket == null)
                    {
                        var result = bookProvider.Edit(model);
                        TempData["SuccessMessage"] = "PNR is successfully saved.";
                    }
                }
                else if (model.isDeleted)
                {
                    var sessionDetail = (TravelSession)Session["TravelPortalSessionInfo"];
                    var models = bookProvider.GetBookedPNRList(model.PNRBookedList[0].MPNRId);
                    model.ServiceProviderId = models.PNRBookedList[0].ServiceProviderId;
                    bool checkId = bookProvider.CheckMPNRIdExist(model.PNRBookedList[0].MPNRId);

                    if (checkId == true)
                        bookProvider.Delete(model.PNRBookedList[0].MPNRId, sessionDetail.AppUserId, model.ServiceProviderId);

                    TempData["SuccessMessage"] = "PNR is successfully cancelled.";
                }
            }
            catch (GDS.GDSException ex)
            {
                System.Text.StringBuilder errorBuilder = new System.Text.StringBuilder();
                foreach (GDS.GdsErrorData errors in ex.GDSErrors)
                {
                    errorBuilder.Append(errors.ErrorMessage);
                    errorBuilder.Append(errors.ErrText);
                }
                TempData["ActionResponse"] = errorBuilder;
                ATLTravelPortal.Utility.ErrorLogging.BookingLogException(ex, model.PNRBookedList[0].MPNRId);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    TempData["ActionResponse"] = ex.InnerException.Message;
                ATLTravelPortal.Utility.ErrorLogging.BookingLogException(ex, model.PNRBookedList[0].MPNRId);
            }
            return RedirectToAction("Details", new { id = model.PNRBookedList[0].MPNRId });
        }


        public ActionResult Create()
        {


            OfflineBookViewModel model = new OfflineBookViewModel();



            // model.SelectListCollection.CityList = bookProvider.GetCitiesByCityTypeId(1);
            model.SelectListCollection.CityList = bookProvider.GetCitiesByCityTypeId();
            model.PNRDetails.Add(new OfflineBookPNRDetailsModel());
            model.PNRDetails[0] = new OfflineBookPNRDetailsModel();
            model.PNRDetails[0].SegmentDetail.Add(new OfflineBookSegmentModel());
            model.PNRDetails[0].PassengerDetail.Add(new OfflineBookPassengerModel());

            //  model.PNRDetails[0].FareDetail.Add(new OfflineBookFareDetailModel());

            ViewData["PassengerTypes"] = new SelectList(bookProvider.GetPassengerList(), "PassengerTypeId", "PassengerTypeName");
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(OfflineBookViewModel model, FormCollection coll)
        {
            var sessionDetail = (TravelSession)Session["TravelPortalSessionInfo"];
            decimal totalFare = 0;
            List<OfflineBookFareDetailModel> fareDetailsList = new List<OfflineBookFareDetailModel>();
            foreach (var fare in model.PNRDetails[0].PassengerDetail)
            {
                totalFare += Convert.ToDecimal(fare.FareDetail.SellingBaseFare );//+ fare.FareDetail.SellingTax - fare.FareDetail.DiscountAmount
            }


            GeneralProvider generalProvider = new GeneralProvider();

            bool IsSufficientBalance = (bool)generalProvider.Air_isSufficientBalance
                (
                    totalFare,
                    int.Parse(coll["UserDetail.AgentId"]),
                   (int)Enum.Parse(typeof(Galileo.FareService.CurrencyType), model.PNRDetails[0].PassengerDetail[0].FareDetail.Currency),
                    int.Parse(model.PNRDetails[0].BookingSource)
                 );

            bool chkGDSPNR = bookProvider.CheckDuplicateGDSPNR(model.PNRDetails[0].PNR.ToUpper());
            try
            {
                model.UserDetail.AppUserId = sessionDetail.AppUserId;
                model.UserDetail.SessionId = sessionDetail.Id;

                HttpPostedFileBase eTicketFile = model.ticket;
                if (model.ticket != null && chkGDSPNR == true)
                {
                    if (eTicketFile.ContentType == "application/zip" || eTicketFile.ContentType == "application/x-zip-compressed")
                    {
                        if (!IsSufficientBalance)
                        {
                            TempData["ActionResponse"] = "Insufficient Balance";
                            return View(model);
                        }

                        var response = bookProvider.Save(model,(double)totalFare);
                        return RedirectToAction("Index");
                    }
                }
                else if (model.ticket == null && chkGDSPNR == true)
                {
                    if (!IsSufficientBalance)
                    {
                        TempData["ActionResponse"] = "Insufficient Balance";
                        return View(model);
                    }
                    var response = bookProvider.Save(model,(double)totalFare);
                    if (response == true)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Create", model);
                    }
                }
                else
                {
                    TempData["ActionResponse"] = "Uploaded file should have .zip extension";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, Error Occurred While Booking!", e);
            }
        }

        public void DownloadETicket(long id)
        {
            try
            {
                string filePath = System.Web.Configuration.WebConfigurationManager.AppSettings["OfflineTicketsPath"] + "/" + id;
                DirectoryInfo directory = new DirectoryInfo(filePath);

                FileInfo[] filesInfo = null;
                if (Directory.Exists(filePath))
                    filesInfo = directory.GetFiles("*.zip");

                FileInfo fileInfo = null;
                if (filesInfo != null)
                {
                    fileInfo = filesInfo.OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
                }
                if (fileInfo != null)
                {
                    string fname = fileInfo.Name;
                    bool forceDownload = true;
                    string path = filePath + "/" + fname;
                    string name = Path.GetFileName(path);
                    string ext = Path.GetExtension(path);
                    name = name.Contains(" ") == true ? name.Replace(" ", "_") : name;
                    string type = "";

                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {
                            case ".zip":
                                type = "application/x-zip-compressed";
                                break;
                            case ".pdf":
                                type = "Application/pdf";
                                break;

                            case ".xls":
                            case ".xlsx":
                                type = "Application/vnd.ms-excel";
                                break;

                            case ".doc":
                            case ".docx":
                            case ".rtf":
                                type = "Application/msword";
                                break;
                        }
                    }
                    if (forceDownload)
                    {
                        Response.AppendHeader("content-disposition",
                            "attachment; filename=" + name);
                    }
                    if (type != "")
                        Response.ContentType = type;
                    Response.WriteFile(path);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}

