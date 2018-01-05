using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Repository;
using AirLines.Provider.Admin;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
   
    

    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Details = "Detail", Order = 2)]

    public class SectorSalesReportController : Controller
    {
        //
        // GET: /SectorSalesReport/

        GeneralProvider defaultProvider = new GeneralProvider();

        EntityModel ent = new EntityModel();
        SectorSalesReportProvider ser = new SectorSalesReportProvider();
        BookedTicketReportController ctrBKT = new BookedTicketReportController();

       

        public ActionResult Index(int? pageNo, int? flag)
        { 
            SectorSalesReportModel model = new SectorSalesReportModel();
            //if (Request.IsAjaxRequest())
            //{
               
            //    model.SegmentSalesReportList = ser.ListSegmentSalesReport(model.FromDate, model.ToDate, model.DepartCityId, model.ArriveCityId, model.AgentId, model.AirlineTypesId);
            //    return PartialView("ListPartial", model);
            //}


            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            ViewData["CityList"] = new SelectList(ser.GetCityList(model.AirlineTypesId), "CityID", "CityName");
            ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

              int? DCity;
                if (model.DepartCityId == 0)
                    DCity = null;
                else
                    DCity = model.DepartCityId;

                int? ACity;
                if (model.ArriveCityId == 0)
                    ACity = null;
                else
                    ACity = model.ArriveCityId;

              
                model.SegmentSalesReportList = ser.ListSegmentSalesReport(model.FromDate, model.ToDate, DCity, ACity, model.AgentId, model.AirlineTypesId);

            //int currentPageNo = 0; int numberOfPage = 0;
            //if (pageNo == null)
            //    pageNo = 1;

            //model.SegmentSalesReportList = ser.GetSectorSalesReportByPagination(model, pageNo.Value, out  currentPageNo, out numberOfPage, flag);




            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, SectorSalesReportModel model, FormCollection frm, int? pageNo, int? flag)
        {
            //if (Request.IsAjaxRequest())
            //{
                int? DCity;
                if (model.hdfDepartCityId == 0)
                    DCity = null;
                else
                    DCity = model.hdfDepartCityId;

                int? ACity;
                if (model.hdfArriveCityId == 0)
                    ACity = null;
                else
                    ACity = model.hdfArriveCityId;

                var AgentList = ent.Agents.ToList();
                ViewData["AgentList"] = new SelectList(AgentList, "AgentId", "AgentName", 0);
                //int? agentId;
                //    if (model.AgentId == 0)
                //        agentId = null;
                //else
                //        agentId = model.AgentId;

                var viewModel = new SectorSalesReportModel
                {
                    SegmentSalesReportList = ser.ListSegmentSalesReport(model.FromDate, model.ToDate, DCity, ACity, model.AgentId, model.AirlineTypesId)



                };


                //int currentPageNo = 0; int numberOfPage = 0;
                //if (pageNo == null)
                //    pageNo = 1;

                //model.SegmentSalesReportList = ser.GetSectorSalesReportByPagination(viewModel, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
                //ViewData["TotalPages"] = numberOfPage;
                //ViewData["CurrentPage"] = currentPageNo;


                //export

                ctrBKT.GetExportTypeClicked(Expmodel, frm);

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

                        var exportData = viewModel.SegmentSalesReportList.Select(m => new
                        {
                            Departure_City = m.DepartCity,
                            Arrival_City = m.ArriveCity,
                            Segment = m.SegmentId
                        });

                        App_Class.AppCollection.Export(Expmodel, exportData, "SectorSales ");
                    }
                    catch (Exception ex)
                    {
                        TempData["ActionResponse"] = ex.Message;
                    }
                }

                viewModel.FromDate = model.FromDate;
                viewModel.ToDate = model.ToDate;


               // return PartialView("ListPartial", viewModel);
           // }
           //return View();

                ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
                ViewData["CityList"] = new SelectList(ser.GetCityList(model.AirlineTypesId), "CityID", "CityName");
                ViewData["AirlineTypes"] = new SelectList(ser.GetAirlineTypesList(), "AirineTypeId", "TypeName");

            
                return View(viewModel);
        }

      

        

        [HttpGet]
        public ActionResult Detail(int DepartCityId, int ArriveCityId, DateTime FromDate, DateTime Todate)
        {
            if (Request.IsAjaxRequest())
            {
          
                var viewModel = new SectorSalesReportModel
                {
                    SegmentSalesDetailsReportList = ser.GetSegmentSalesDetailsReport(FromDate, Todate, DepartCityId, ArriveCityId)
                };
                return PartialView("Detail", viewModel);
            }
            else
            {
                return View();
            }

        
        }


        [HttpPost]
        public JsonResult FindAirlineCity(string searchText, int maxResult, int airlinetypes)
        {
            var result = ser.GetAirlineCity(searchText, maxResult, airlinetypes);
            return Json(result);
        }

       
       

    

    }
}
