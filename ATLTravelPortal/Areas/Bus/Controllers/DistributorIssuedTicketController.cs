﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Bus.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class DistributorIssuedTicketController : Controller
    {
        BusMessageModel _res = new BusMessageModel();
        GeneralProvider defaultProvider = new GeneralProvider();


        public ActionResult Index(int? page, BusPNRModel _model)
        {
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            BusGeneralRepository.SetRequestPageRow();
            try
            {
                var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                _model.FromDate = Session["FromDate"] == null ? DateTime.Now.AddDays(-15) : Convert.ToDateTime(Session["FromDate"]);
                _model.ToDate = Session["ToDate"] == null ? DateTime.Now : Convert.ToDateTime(Session["ToDate"]);

                ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorAgentList(ts.LoginTypeId), "AgentId", "AgentName");
                _model.TabularList = _rep.GetDistributorPagedIssueList(page, _model.FromDate, _model.ToDate, _model.AgentId, ts.LoginTypeId);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            _model.Message = _res;
            return View(_model);
        }

        [HttpPost]
        public ActionResult Index(BusPNRModel model, int? page, ExportModel Expmodel, FormCollection frm)
        {
            Session["FromDate"] = model.FromDate;
            Session["ToDate"] = model.ToDate;
            BusPNRModel _model = new BusPNRModel();
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            BusGeneralRepository.SetRequestPageRow();
            try
            {
                var ts = (TravelSession)Session["TravelPortalSessionInfo"];
                ViewData["AgentList"] = new SelectList(defaultProvider.GetDistributorAgentList(ts.LoginTypeId), "AgentId", "AgentName");
                _model.TabularList = _rep.GetDistributorPagedIssueList(page, model.FromDate, model.ToDate, model.AgentId, ts.LoginTypeId);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }

            //export
            BookedTicketReportController crtBKT = new BookedTicketReportController();
            crtBKT.GetExportTypeClicked(Expmodel, frm);

            if (Expmodel != null && (Expmodel.ExportTypeExcel != null || Expmodel.ExportTypeWord != null || Expmodel.ExportTypeCSV != null || Expmodel.ExportTypePdf != null))
            {
                try
                {
                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = _model.TabularList.Select(m => new
                    {
                        Passenger_Name = m.FullName,
                        Operator_Name = m.BusMasterName,
                        DepartureDate = TimeFormat.DateFormat(m.DepartureDate.ToString()),
                        DepartureTime = TimeFormat.GetAMPMTimeFormat(m.DepartureTime.ToString()),
                        Category = m.BusCategoryName,
                        Type = m.Type
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Issued Ticket");
                }
                catch
                {
                }
            }

            _model.Message = _res;
            return View(_model);
        }
    }
}
