using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers.Pagination;

using ATLTravelPortal.Areas.Airline.Controllers;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Details = "Details", Order = 2)]
    public class SalesReportsController : Controller
    {
        SalesReportProvider salesReportProvider = new SalesReportProvider();

        public ActionResult Index(DateTime? FromDate, DateTime? ToDate)
        {
            SalesReportModel model = new SalesReportModel();
            model.FromDate = DateTime.Now.AddDays(-15);
            model.ToDate = DateTime.Now;

            model.ReportsOfOption = salesReportProvider.GetReportof();
            model.CurrencyOption = salesReportProvider.Getcurrencylist();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ATLTravelPortal.Areas.Airline.Models.ExportModel Expmodel, SalesReportModel model, FormCollection frm)
        {
            model.InformationList = salesReportProvider.GetInformation(model.ReportOf, model.CurrencyId, model.FromDate, model.ToDate);

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

                    var exportData = model.InformationList.Select(m => new
                    {
                        Name = m.Name,
                        Airline = m.Airline,
                        Hotel = m.Hotel,
                        Mobile = m.Mobile,
                        Bus = m.Bus,
                        Train = m.Train,
                        Total = m.Total
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "Sales Report");
                }
                catch
                {
                }
            }
            model.ReportsOfOption = salesReportProvider.GetReportof();
            model.CurrencyOption = salesReportProvider.Getcurrencylist();
            return View(model);
        }

        public ActionResult Details(SalesReportModel model,string reportOf, int? currencyid, DateTime? fromdate, DateTime? todate, int? ledgerid, string name, int reportType)
        {
           
            

            model.ReportHeading = name;
            model.FromDate = fromdate;
            if (model.CurrencyId == 1)
             model.Currency = "NPR";
            if (model.CurrencyId == 2)
                model.Currency = "USD";
            model.ToDate = todate;
           
            model.ReportType = reportType;
            model.InformationList = salesReportProvider.GetLedgerInformation(ledgerid, reportOf, currencyid, fromdate, todate, reportType);
            return View(model);
        }
        [HttpPost]
        public ActionResult Details(ATLTravelPortal.Areas.Airline.Models.ExportModel Expmodel, SalesReportModel model, FormCollection frm)
        {
            model.ReportHeading = model.Name;
            model.InformationList = salesReportProvider.GetLedgerInformation(model.LedgerId, model.ReportOf, model.CurrencyId, model.FromDate, model.ToDate, model.ReportType);
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

                    int counter = 0;
                    if (model.ReportType == 1)
                    {
                        var exportData = model.InformationList.Select(m => new
                        {
                            SN = ++counter,
                            Airline = m.AirlineName,
                            MPNRID = m.MpnrId,
                            ServiceProvider_Name = m.ServiceProviderName,
                            Sector = m.Sector,
                            Issued_Date = TimeFormat.DateFormat(m.IssuedDate.ToString()),
                            Issued_From = m.IssuedFrom,
                            Ticket_Number = m.TicketNumber,
                            Amount = m.Amount
                        });
                        App_Class.AppCollection.Export(Expmodel, exportData, "Sales Report");
                    }
                    if (model.ReportType == 2)
                    {
                        var exportData = model.InformationList.Select(m => new
                            {
                                SN = ++counter,
                                Hotel_Name = m.HotelName,
                                Country_Name = m.CountryName,
                                City_Name = m.CityName,
                                ServiceProvider_Name = m.ServiceProviderName,
                                Issued_Date = TimeFormat.DateFormat(m.IssuedDate.ToString()),
                                No_Of_Night = m.NOofNight,
                                No_Of_Room = m.NoofRoom,
                                Amount = m.Amount


                            });
                        App_Class.AppCollection.Export(Expmodel, exportData, "Sales Report");
                    }
                    if (model.ReportType == 3)
                    {
                        var exportData = model.InformationList.Select(m => new
                        {
                            SN = ++counter,
                            SalesTranId = m.SalesTranId,
                            ServiceType = m.ServiceType,
                            Customer_MobileNo = m.CustomerMobileNo,
                            ServiceProvider_Name = m.ServiceProviderName,
                            Issued_Date = TimeFormat.DateFormat(m.IssuedDate.ToString()),
                            Created_Date = m.CreatedDate,
                            Amount = m.Amount


                        });
                        App_Class.AppCollection.Export(Expmodel, exportData, "Sales Report");
                    }
                    if (model.ReportType == 4)
                    {
                        var exportData = model.InformationList.Select(m => new
                        {
                            SN = ++counter,
                            BusMasterName = m.BusMasterName,
                            BusPNRId = m.BusPNRId,
                            ServiceProvider_Name = m.ServiceProviderName,
                            Passenger_Name= m.PassengerName,
                            Sector = m.Sector,
                            Issued_Date = TimeFormat.DateFormat(m.IssuedDate.ToString()),
                            Amount = m.Amount
                        });
                        App_Class.AppCollection.Export(Expmodel, exportData, "Sales Report");
                    }
                    
                    if (model.ReportType == 5)
                    {
                        var exportData = model.InformationList.Select(m => new
                        {
                            SN = ++counter,
                            Passenger_Name = m.PassengerName,
                            TrainNo = m.TrainNo,
                            Sector = m.Sector,
                            Issued_Date = TimeFormat.DateFormat(m.IssuedDate.ToString()),
                            TrainPNRId = m.TrainPNRId,
                            Amount = m.Amount


                        });
                        App_Class.AppCollection.Export(Expmodel, exportData, "Sales Report");
                    }


                    
                }
                catch
                {
                }
            }
            return View(model);
        }
    }
}
