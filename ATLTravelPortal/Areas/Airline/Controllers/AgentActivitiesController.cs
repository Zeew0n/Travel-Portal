using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class AgentActivitiesController : Controller
    {
        //
        // GET: /Airline/AgentActivities/

        AgentActivitiesProvider ser = new AgentActivitiesProvider();
        GeneralProvider defaultProvider = new GeneralProvider();
        BookedTicketReportController bktController = new BookedTicketReportController();

        public ActionResult Index(int? page)
        {
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            AgentActivitiesModel model = new AgentActivitiesModel();
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            model.AgentActivitesList = ser.GetAgentActivitiesList(model.AgentId, model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize); 
            return View(model);

           

        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, AgentActivitiesModel model, FormCollection frm, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;

            model.AgentActivitesList = ser.GetAgentActivitiesList(model.AgentId, model.FromDate, model.ToDate).ToPagedList(currentPageIndex, defaultPageSize);

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

                    var exportData = model.AgentActivitesList.Select(m => new
                    {
                        Agent_Name = m.AgentName,
                        Booked = m.Booked,
                        Cancelled = m.Cancelled,
                        Issued = m.Issued,
                        Void = m.Void,
                        Total_Login = m.TotalLogin,
                        Last_Login = m.LastLogin
                        
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Agent Activity");
                }
                catch
                {
                }
            }


            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            return View(model);
        }

    }
}
