using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 1)]
    public class LoginHistoriesController : Controller
    {
        LoginHistoriesProvider ser = new LoginHistoriesProvider();
        BookedTicketReportController bktController = new BookedTicketReportController();
        public ActionResult Index(int? page, DateTime? FromDate, DateTime? ToDate)
        {

            LoginHistoriesModel model = new LoginHistoriesModel();

            if (FromDate == null && ToDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime();
                model.ToDate = GeneralRepository.CurrentDateTime();
            }
            else
            {
                model.FromDate = (DateTime)FromDate;
                model.ToDate = (DateTime)ToDate;
            }

            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 3;

            model.LoginHistoriesList = ser.ListLoginHistories(model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);


            return View(model);
        }
      
        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, LoginHistoriesModel model, FormCollection frm, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 3;

            model.LoginHistoriesList = ser.ListLoginHistories(model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize).ToPagedList(currentPageIndex, defaultPageSize); ;

            //export
            bktController.GetExportTypeClicked(Expmodel, frm);
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

                    var exportData = model.LoginHistoriesList.Select(m => new
                    {
                        Agent_Name = m.AgentName,
                        User_Name = m.UserName,
                        Full_Name = m.FullName,
                        Login_Date = m.LogInDateTime,
                        LogOut_Date = m.LogOutDateTime

                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Login Histories");
                }
                catch
                {
                }
            }



            return View(model);
        }

    }
}
