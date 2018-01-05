using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.MobileRechargeCard.Repository;
using ATLTravelPortal.Areas.MobileRechargeCard.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class MobileTopupController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? pageNo, int? flag)
        {
            MobileTopupProvider mobileTopupProvider = new MobileTopupProvider();
            MobileTopupModel model = new MobileTopupModel();
                      
            model.FromDate = DateTime.Today;
            model.ToDate = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

            return View( mobileTopupProvider.GetMobileTopupModel(model));
        }


        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, MobileTopupModel model, FormCollection frm, int? pageNo, int? flag)
        {
            MobileTopupProvider mobileTopupProvider = new MobileTopupProvider();
            MobileTopupModel viewModel = mobileTopupProvider.GetMobileTopupModel(model);
            try
            {                
                var ts = (TravelSession)Session["TravelPortalSessionInfo"];             

                //export
                GetExportTypeClicked(Expmodel, frm);
                if (Expmodel != null && (Expmodel.ExportTypeExcel != null || Expmodel.ExportTypeWord != null || Expmodel.ExportTypeCSV != null || Expmodel.ExportTypePdf != null))
                {
                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = model.MobileTopupModelList.Select(m => new
                    {
                        AgentName = m.AgentName,
                        ServiceProvierName = m.ServiceProvierName,
                        SalesPrice = m.SalesPrice,
                        SalesDate = m.SalesDate,
                        IsSucces = m.IsSucces,
                        StatusMessage = m.StatusMessage
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Mobile Topup Report");
                }
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["success"] = ex.Message;
            }
            return View(viewModel);
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

    }
}
