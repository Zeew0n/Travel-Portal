using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using AirLines.Provider.Admin;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]

    public class ReportAirRetrievePNRInfoController : Controller
    {
        //
        // GET: /ReportAirRetrievePNRInfo/
        ReportPNRProvider _provider = new ReportPNRProvider();
        PNRReportModel _modObj = new PNRReportModel();
       GeneralProvider defaultProvider = new GeneralProvider();
       BookedTicketReportController crtBKT = new BookedTicketReportController();
       
        [NonAction]
        private PNRReportModel GetViewModelList(PNRReportModel model)
        {
            _modObj.ddlAgentIdList = defaultProvider.GetAgentSelectOptionList();
            _modObj.PNRReportList = _provider.GetAirRetrievePNRInfoList(model);
            return _modObj;

        }

        [HttpGet]
        public ActionResult Index()
        {
            PNRReportModel model = new PNRReportModel();
           var viewModel =  GetViewModelList(model);
           return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult Index(PNRReportModel model)
        //{
        //    var viewModel = GetViewModelList(model);
        //    return View(viewModel);
        //}


        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, PNRReportModel model, FormCollection frm)
        {

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];


            _modObj.PNRReportList = _provider.GetAirRetrievePNRInfoList(model);


            //export
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

                    var exportData = _modObj.PNRReportList.Select(m => new
                    {
                        Booked_Date = TimeFormat.DateFormat(m.CreatedDate.ToString()),
                        GDS_PNR = m.GDSRefrenceNumber,
                        Airlines_PNR = m.ServiceProviderName,
                        Airline = m.AirlineCode,
                        Sector = m.Sector,
                        Class = m.Class,
                        Fare = m.BaseFare,
                        Tax = m.TotalTax,
                        Comm = m.CommissionOnBF,
                        Service_Charge = m.ServiceCharge,
                        Total_Fare = m.TotalFare,
                        Status = m.ticketStatusName
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "RetrievePNR");

                }
                catch
                {
                }
            }

            GetViewModelList(_modObj);
            return View(_modObj);
        }

    }
}
