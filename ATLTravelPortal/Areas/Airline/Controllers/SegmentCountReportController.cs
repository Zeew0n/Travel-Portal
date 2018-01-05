using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index",Order = 2)]
    public class SegmentCountReportController : Controller
    {
        //
        // GET: /Airline/SegmentCountReport/
        SegmentCountReportProvider ser = new SegmentCountReportProvider();

        public ActionResult Index(int? page)
        {
            SegmentCountReportModel model = new SegmentCountReportModel();

            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;


            model.SegmentCountReportList = ser.ListSegmentCountReport(model.YearId, model.ServiceProviderId, model.AgentId).ToPagedList(currentPageIndex, defaultPageSize); ;
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, SegmentCountReportModel model, FormCollection frm, int? page)
        {
         
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            model.SegmentCountReportList = ser.ListSegmentCountReport(model.YearId, model.ServiceProviderId, model.hdfAgentId).ToPagedList(currentPageIndex, defaultPageSize);


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

                    var exportData = new List<SegmentCountReportExportModel>();
                 
                    foreach (var item in model.SegmentCountReportList)
                    {   
                        var rpt = new SegmentCountReportExportModel();

                        rpt.Info = item.Info;
                        rpt.Jan = item.Jan;
                        rpt.Feb = item.Feb;
                        rpt.March = item.Mar;
                        rpt.April = item.April;
                        rpt.May = item.May;
                        rpt.Jun = item.Jun;
                        rpt.July = item.July;
                        rpt.Aug = item.Aug;
                        rpt.Sep = item.Sep;
                        rpt.Oct = item.Oct;
                        rpt.Nov = item.Nov;
                        rpt.Dec = item.Dec;
                       
                        exportData.Add(rpt); 

                    }
                   

                    App_Class.AppCollection.Export(Expmodel, exportData, "SegmentCount");
                }
                catch
                {
                }
            }



            return View(model);
        }

    }
}
