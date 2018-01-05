using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.MobileRechargeCard.Repository;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.Areas.MobileRechargeCard.Models;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Controllers
{
    public class BranchTopUpController : Controller
    {
        TopUpProvider ser = new TopUpProvider();

        BookedTicketReportController crtBKT = new BookedTicketReportController();

        public ActionResult Index()
        {
            TopUpModel _model = new TopUpModel();
            _model.ddlServiceProviderList = ser.ddlServiceProviderList();
            _model.ddlTypeList = ser.ddlTypeList();
            _model.ddlStatusList = ser.ddlStatusList();
            return View(_model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, TopUpModel model, FormCollection frm)
        {
            model.ddlServiceProviderList = ser.ddlServiceProviderList();
            model.ddlTypeList = ser.ddlTypeList();
            model.ddlStatusList = ser.ddlStatusList();
            model.ListTopUp = ser.List(model);


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

                    var exportData = model.ListTopUp.Select(m => new
                    {

                        Tran_Id = m.SalesTranId,
                        Date = TimeFormat.DateFormat(m.SalesDate.ToString()),
                        Mobile_No = m.MobileNo,
                        Amount = m.RechargeAmount,


                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Mobile TopUp ");

                }
                catch
                {
                }
            }


            return View(model);
        }

        public ActionResult TranReport()
        {
            AgentTranModel _model = new AgentTranModel();
            _model.ddlReportType = ser.ddlReportTypeList();
            return View(_model);
        }
        [HttpPost]
        public ActionResult TranReport(AgentTranModel model)
        {
            AgentTranModel _model = new AgentTranModel();
            model.ddlReportType = ser.ddlReportTypeList();
            model.List = ser.TranList(model);
            return View(model);
        }

    }
}
