using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class B2CVisitorInfoController : Controller
    {
        //
        // GET: /Administrator/B2CVisitorInfo/
        B2CVisitorInfoProvider ser = new B2CVisitorInfoProvider();
        BookedTicketReportController bktctrl = new BookedTicketReportController();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            B2CVisitorInfoModel model = new B2CVisitorInfoModel();
            model.ListB2CVisitorInfo = ser.ListB2CVisitorInfoReport().ToPagedList(currentPageIndex, defaultPageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, B2CVisitorInfoModel model, FormCollection frm)
        {


            model.ListB2CVisitorInfo = ser.ListB2CVisitorInfoReport().ToPagedList(1,int.MaxValue);

            //export
            bktctrl.GetExportTypeClicked(Expmodel, frm);
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

                    var exportData = model.ListB2CVisitorInfo.Select(m => new
                    {
                        Name = m.Name,
                        Address = m.Address,
                        Email = m.Email,
                        Contact_No = m.ContactNo,
                        Source = m.SRC,
                        Type = m.Type,
                        Profession = m.Profession,
                        Created_Date = m.CreatedDate
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Visitor_Info");
                }
                catch
                {
                }
            }
          
            return View(model);
        }


    }
}
