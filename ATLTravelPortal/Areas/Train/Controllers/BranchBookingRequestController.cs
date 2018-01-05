﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Train.Models;
using ATLTravelPortal.Areas.Train.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;
using System.IO;

namespace ATLTravelPortal.Areas.Train.Controllers
{
    public class BranchBookingRequestController : PartialViewRendererController
    {
        TrainMessageModel _msg = new TrainMessageModel();
        ATLTravelPortal.Areas.Airline.Repository.GeneralProvider defaultProvider = new Airline.Repository.GeneralProvider();

        public ActionResult Index(int? page, TrainBookingRequestModel _model)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            _model.StatusId = 1;
            _model.PagedList = _rep.GetBrachPendingBookingPagedList(_model, page, ts.LoginTypeId);
            if (TrainGeneralRepository.Message != null)
            {
                _model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                _model.Message = _msg;
            }

            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(_model);
        }
        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, TrainBookingRequestModel model, FormCollection frm, int? page)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.StatusId = 1;
            model.PagedList = _rep.GetBrachPendingBookingPagedList(model, page, ts.LoginTypeId);
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            if (TrainGeneralRepository.Message != null)
            {
                model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                model.Message = _msg;
            }
            GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null &&
                (Expmodel.ExportTypeExcel != null ||
                Expmodel.ExportTypeWord != null ||
                Expmodel.ExportTypeCSV != null ||
                Expmodel.ExportTypePdf != null))
            {
                try
                {
                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = _rep.BranchList(model, ts.LoginTypeId).Select(m => new
                    {
                        SNo = m.SNo,
                        Passenger_Name = m.FullName,
                        Sector = m.Sector,
                        DepartureDate = m.DepartureDate,
                        RequestDate = m.CreateDate,
                        TicketStatusName = m.StatusName,
                        RequestBy = m.CreatedByName,
                        Request_ID = "AH-TR-" + m.TrainPNRId.ToString().PadLeft(5, '0')
                    });

                    App_Class.AppCollection.Export(Expmodel, exportData, "TrainBookingRequestList");

                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return View(model);
        }

        public ActionResult Issued(int? page, TrainBookingRequestModel _model)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            _model.StatusId = 4;
            _model.PagedList = _rep.GetBranchIssuedPagedList(_model, page, ts.LoginTypeId);
            if (TrainGeneralRepository.Message != null)
            {
                _model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                _model.Message = _msg;
            }
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(_model);
        }
        [HttpPost]
        public ActionResult Issued(ExportModel Expmodel, TrainBookingRequestModel model, FormCollection frm, int? page)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.StatusId = 4;
            model.PagedList = _rep.GetBranchIssuedPagedList(model, page, ts.LoginTypeId);
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            if (TrainGeneralRepository.Message != null)
            {
                model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                model.Message = _msg;
            }
            GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null &&
                (Expmodel.ExportTypeExcel != null ||
                Expmodel.ExportTypeWord != null ||
                Expmodel.ExportTypeCSV != null ||
                Expmodel.ExportTypePdf != null))
            {
                try
                {
                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = _rep.BranchIssuedList(model, ts.LoginTypeId).Select(m => new
                    {
                        SNo = m.SNo,
                        Passenger_Name = m.FullName,
                        Sector = m.Sector,
                        DepartureDate = m.DepartureDate,
                        RequestDate = m.CreateDate,
                        TicketStatusName = m.StatusName,
                        RequestBy = m.CreatedByName,
                        Request_ID = "AH-TR-" + m.TrainPNRId.ToString().PadLeft(5, '0')
                    });

                    App_Class.AppCollection.Export(Expmodel, exportData, "TrainBookingRequestList");
                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return View(model);
        }

        public ActionResult Canceled(int? page, TrainBookingRequestModel _model)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            _model.StatusId = 2;
            _model.PagedList = _rep.GetBranchCancelledBookingPagedList(_model, page, ts.LoginTypeId);
            if (TrainGeneralRepository.Message != null)
            {
                _model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                _model.Message = _msg;
            }
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(_model);
        }

        [HttpPost]
        public ActionResult Canceled(ExportModel Expmodel, TrainBookingRequestModel model, FormCollection frm, int? page)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.StatusId = 2;
            model.PagedList = _rep.GetBranchCancelledBookingPagedList(model, page, ts.LoginTypeId);
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            if (TrainGeneralRepository.Message != null)
            {
                model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                model.Message = _msg;
            }
            GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null &&
                (Expmodel.ExportTypeExcel != null ||
                Expmodel.ExportTypeWord != null ||
                Expmodel.ExportTypeCSV != null ||
                Expmodel.ExportTypePdf != null))
            {
                try
                {
                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = _rep.BranchCancelledBookingList(model, ts.LoginTypeId).Select(m => new
                    {
                        Sno = m.SNo,
                        Passenger_Name = m.FullName,
                        Sector = m.Sector,
                        DepartureDate = m.DepartureDate,

                        RequestDate = m.CreateDate,
                        TicketStatusName = m.StatusName,
                        RequestBy = m.CreatedByName,
                        Request_ID = "AH-TR-" + m.TrainPNRId.ToString().PadLeft(5, '0')
                    });

                    App_Class.AppCollection.Export(Expmodel, exportData, "TrainBookingRequestList");

                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return View(model);
        }

        public ActionResult Process(int? page, TrainBookingRequestModel _model)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            _model.StatusId = 7;
            _model.PagedList = _rep.GetBranchProcessBookingPagedList(_model, page, ts.LoginTypeId);
            if (TrainGeneralRepository.Message != null)
            {
                _model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                _model.Message = _msg;
            }
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(_model);
        }

        [HttpPost]
        public ActionResult Process(ExportModel Expmodel, TrainBookingRequestModel model, FormCollection frm, int? page)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.StatusId = 7;
            model.PagedList = _rep.GetBranchProcessBookingPagedList(model, page, ts.LoginTypeId);
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            if (TrainGeneralRepository.Message != null)
            {
                model.Message = TrainGeneralRepository.Message;
            }
            else
            {
                model.Message = _msg;
            }
            GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null &&
                (Expmodel.ExportTypeExcel != null ||
                Expmodel.ExportTypeWord != null ||
                Expmodel.ExportTypeCSV != null ||
                Expmodel.ExportTypePdf != null))
            {
                try
                {
                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = _rep.BranchProcessList(model, ts.LoginTypeId).Select(m => new
                    {
                        SNo = m.SNo,
                        Passenger_Name = m.FullName,
                        Sector = m.Sector,
                        DepartureDate = m.DepartureDate,
                        RequestDate = m.CreateDate,
                        TicketStatusName = m.StatusName,
                        RequestBy = m.CreatedByName,
                        Request_ID = "AH-TR-" + m.TrainPNRId.ToString().PadLeft(5, '0')
                    });

                    App_Class.AppCollection.Export(Expmodel, exportData, "TrainBookingRequestList");

                }
                catch (Exception ex)
                {
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                }
            }
            return View(model);
        }
        public ActionResult Detail(long? id)
        {
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model = _rep.Detail(id);
            if (_model.Message.MsgNumber > 0)
            {
                TrainGeneralRepository.Message = _model.Message;
                return View("Index");
            }
            else
            {
                return View(_model);
            }
        }
        public ActionResult Book(long? id)
        {
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model = _rep.Detail(id);
            if (_model.Message.MsgNumber > 0)
            {
                TrainGeneralRepository.Message = _model.Message;
                return View("Index");

            }
            else
            {
                return View(_model);
            }
        }
        [HttpPost]
        public ActionResult Book(TrainPNRModel model)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            TrainBookingRequestRepository _rep1 = new TrainBookingRequestRepository();
            _msg = _rep.Book(model);
            model = _rep1.Detail(model.TrainPNRId);
            model.Message = _msg;
            if (_msg.MsgNumber > 0)
            {
                return View(model);
            }
            else
            {
                return View("Detail", model);
            }
        }
        public ActionResult Edit(long? id)
        {
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model = _rep.Detail(id);
            _model.Message = _msg;
            if (_model.Message.MsgNumber > 0)
            {
                TrainGeneralRepository.Message = _model.Message;
                return View("Index");
            }
            else
            {
                return View(_model);
            }
        }
        [HttpPost]
        public ActionResult Edit(TrainPNRModel model)
        {
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model.Message = _rep.Edit(model);
            if (_model.Message.MsgNumber > 0)
            {
                TrainGeneralRepository.Message = _model.Message;
                return RedirectToAction("Index");
            }
            else
            {
                _model = _rep.Detail(model.TrainPNRId);
                return View("Detail", _model);
            }
        }
        public ActionResult Cancel(long? id)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model.Message = _rep.Cancel(id);
            TrainGeneralRepository.Message = _model.Message;
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return RedirectToAction("Index");
        }
        public ActionResult CancelInProcess(long? id)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model.Message = _rep.Cancel(id);
            TrainGeneralRepository.Message = _model.Message;
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return RedirectToAction("Process");
        }

        public ActionResult InProcess(long? id)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model.Message = _rep.Process(id);
            TrainGeneralRepository.Message = _model.Message;
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return RedirectToAction("RequestForm", new { @id = id });
        }
        public ExportModel GetExportTypeClicked(ExportModel Expmodel, FormCollection frm)
        {
            if (frm["ExportTypeExcel.x"] != null && frm["ExportTypeExcel.y"] != null)
                Expmodel.ExportTypeExcel = "true";

            if (frm["ExportTypeWord.x"] != null && frm["ExportTypeWord.y"] != null)
                Expmodel.ExportTypeWord = "true";

            if (frm["ExportTypePdf.x"] != null && frm["ExportTypePdf.y"] != null)
                Expmodel.ExportTypePdf = "true";

            return Expmodel;
        }

        [HttpGet]
        public ActionResult RequestForm(long? id)
        {

            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model = _rep.Detail(id);
            return View(_model);

        }

        [HttpPost]
        public ActionResult RequestForm(long? id, TrainPNRModel _model)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            TrainPNRModel _model1 = new TrainPNRModel();
            _model1 = _rep.Detail(id);


            string body = RenderPartialViewToString("VUC_RequestForm", _model1);
            try
            {

                _rep.SendEmail(body, _model.txtEmailTo, id);
                ViewData["isEmailSent"] = "Your email is right on the way, you'll get email in a minute.";
            }
            catch (Exception ex)
            {
                ViewData["isEmailSent"] = "Unable to Send Email";

            }

            return View("RequestForm", _model1);


        }

        [HttpGet]
        public ActionResult InProcessRequestForm(long? id)
        {

            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model = _rep.Detail(id);
            return View(_model);

        }

        [HttpPost]
        public ActionResult InProcessRequestForm(long? id, TrainPNRModel _model)
        {
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            TrainPNRModel _model1 = new TrainPNRModel();
            _model1 = _rep.Detail(id);


            string body = RenderPartialViewToString("VUC_RequestForm", _model1);
            try
            {

                _rep.SendEmail(body, _model.txtEmailTo, id);
                ViewData["isEmailSent"] = "Your email is right on the way, you'll get email in a minute.";
            }
            catch (Exception ex)
            {
                ViewData["isEmailSent"] = "Unable to Send Email";

            }

            return View("RequestForm", _model1);


        }



        public FileResult DownloadPNR(long? id)
        {
            TrainPNRModel _model = new TrainPNRModel();
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            var _fileName = _rep.IsValidFile(id);
            if (!string.IsNullOrEmpty(_fileName))
            {
                string filPath = Path.Combine(TrainGeneralRepository.TrainPNRLocation, _fileName);
                string format = _fileName.Substring(_fileName.Length - 3);
                string fileName = "Train-PNR-" + id.ToString() + "." + format;
                string contentType = "application/" + format;
                return File(filPath, contentType, fileName);
            }
            else
                return null;
        }

        public ActionResult TrainSearchReport(DateTime? FromDate, DateTime? ToDate, int? id, int? page)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");

            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            TrainSearchLogModel _model = new TrainSearchLogModel();
            if (FromDate == null && ToDate == null)
            {
                _model.FromDate = DateTime.Now.AddDays(-15);
                _model.ToDate = DateTime.Now;
                _model.PagedList = _rep.GetList(_model, page);
            }
            else
            {
                _model.FromDate = FromDate;
                _model.ToDate = ToDate;
                _model.PagedList = _rep.GetList(_model, page);
            }
            return View(_model);
        }

        [HttpPost]
        public ActionResult TrainSearchReport(TrainSearchLogModel _model, int? page)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            TrainBookingRequestRepository _rep = new TrainBookingRequestRepository();
            _model.PagedList = _rep.GetList(_model, page);
            ViewData["DisList"] = new SelectList(defaultProvider.GetDistributorList(ts.LoginTypeId), "DistributorId", "DistributorName");
            return View(_model);
        }
    }
}
