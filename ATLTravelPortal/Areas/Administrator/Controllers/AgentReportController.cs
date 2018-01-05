using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 1)]
    public class AgentReportController : Controller
    {
        //
        // GET: /Administrator/AgentReport/
        AgentReportProvider ser = new AgentReportProvider();
        BookedTicketReportController BookedTicket = new BookedTicketReportController();

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            AgentReportModel model = new AgentReportModel();
            model.AgentDetailList = ser.GetAgentInfo().ToPagedList(currentPageIndex, defaultPageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, AgentReportModel model, FormCollection frm,int? page)
        {
            int currentPageIndex = 1;//page.HasValue ? page.Value : 1;
            int defaultPageSize = 1000000;//30;
            model.AgentDetailList = ser.GetAgentInfo().ToPagedList(currentPageIndex, defaultPageSize);

            //export
            BookedTicket.GetExportTypeClicked(Expmodel, frm);
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

                    var exportData = model.AgentDetailList.Select(m => new
                    {
                        Branch_Name = m.BranchName,
                        Distributor_Name = m.DistributorName,
                       Agent_Name = m.AgentName,
                       Agent_Code = m.AgentCode,
                       MEs_Name = m.MEsName,
                       Address = m.Address,
                       Email = m.Email,
                       Phone = m.Phone,
                       Mobile = m.mobile,
                       Zone_Name = m.zonename,
                       District_Name = m.districtname,
                       Signup_By = m.signupby,
                       Signup_Date = TimeFormat.DateFormat( m.SignupDate.ToString()),
                       Reg_By = m.Type == -1 ? "Admin" : "Self"
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Agent Information");
                }
                catch
                {
                }
            }

            return View(model);
        }

    }
}
