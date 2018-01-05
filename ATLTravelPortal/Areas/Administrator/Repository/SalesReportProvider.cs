using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;


namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class SalesReportProvider
    {
        EntityModel entity = new EntityModel();

        public List<SalesReportModel> GetInformation(string reportOf, int? currencyId, DateTime? fromDate, DateTime? toDate)
        {
            var Data = entity.Core_GetSalesReport(reportOf, currencyId, fromDate, toDate);
            List<SalesReportModel> informationcollection = new List<SalesReportModel>();

            foreach (var item in Data)
            {
                SalesReportModel singleinformation = new SalesReportModel()
                {
                    LedgerId = item.LedgerId,
 
                    FromDate = fromDate,
                    CurrencyId = currencyId,
                    ToDate = toDate,
                    ReportOf = reportOf,
                    Name = item.Name,
                    Airline = item.Airline,
                    Hotel = item.Hotel,
                    Mobile = item.Mobile,
                    Bus = item.Bus,
                    Train = item.Train,
                    Total = item.Total
                };
                informationcollection.Add(singleinformation);
            }
            return informationcollection;
        }

        public IEnumerable<SelectListItem> Getcurrencylist()
        {
            var Data = entity.Currencies.Where(x => x.CurrencyId == 1 || x.CurrencyId == 2);

            List<SelectListItem> CurrencyList = new List<SelectListItem>();
            foreach (Currencies item in Data)
            {
                SelectListItem option = new SelectListItem()
                {
                    Value = item.CurrencyId.ToString(),
                    Text = item.CurrencyCode
                };
                CurrencyList.Add(option);
            }
            return CurrencyList;
        }


        public IEnumerable<SelectListItem> GetReportof()
        {
            List<SelectListItem> Reportoflist = new List<SelectListItem>();
            Reportoflist.Add(new SelectListItem { Value = "Branch", Text = "Branch" });
            Reportoflist.Add(new SelectListItem { Value = "Dis", Text = "Distributor" });
            Reportoflist.Add(new SelectListItem { Value = "Agent", Text = "Agent" });

            return Reportoflist;
        }

        public List<SalesReportModel> GetLedgerInformation(int? ledgerid, string reportof, int? currenctid, DateTime? fromdate, DateTime? todate, int reportType)
        {
            List<SalesReportModel> collection = new List<SalesReportModel>();
            SalesReportModel model = new SalesReportModel();

         
            
            
            if (reportType == 1)
            {
                var Data = entity.Air_GetSalesReport(ledgerid, reportof, currenctid, fromdate, todate);
                
                foreach (var item in Data)
                {
                    SalesReportModel singleone = new SalesReportModel()
                    {

                        AirlineName = item.Airline,
                        Amount = item.Amount,
                        IssuedDate = item.IssuedDate,
                        IssuedFrom = item.IssueFrom,
                        MpnrId = item.MPNRId,
                        Sector = item.Sector,
                        ServiceProviderName = item.ServiceProviderName,
                        TicketNumber = item.TicketNumber,
                       };

                    collection.Add(singleone);
                   
                   
                }
                
            }

            if (reportType == 2)
            {
                var Data = entity.HTL_GetSalesReport(ledgerid, reportof, currenctid, fromdate, todate);
               
                foreach (var item in Data)
                {
                    SalesReportModel singleone = new SalesReportModel()
                    {
                        HotelName = item.HotelName,
                        CityName = item.CityName,
                        CountryName = item.CountryName,
                        IssuedDate = item.IssuedDate,
                        NOofNight = item.NoOfNights,
                        NoofRoom = item.NoOfRoom,
                        ServiceProviderName = item.ServiceProviderName,
                        Amount = item.Amount
                    };

                    singleone.TotalAmount = model.TotalAmount;
                    collection.Add(singleone);
                }

            }

            if (reportType == 3)
            {
                var Data = entity.MRC_GetSalesReport(ledgerid, reportof, currenctid, fromdate, todate);
               
                foreach (var item in Data)
                {
                    SalesReportModel singleone = new SalesReportModel()
                    {
                        SalesTranId = item.SalesTranId,
                        ServiceType = item.ServiceType,
                        ServiceProviderName = item.ServiceProviderName,
                        CreatedDate = item.CreatedDate,
                        CustomerMobileNo = item.CustomerMobileNo,
                        Amount = item.Amount
                    };
                    
                    collection.Add(singleone);
                }

            }
            if (reportType == 4)
            {
                var Data = entity.Bus_GetSalesReport(ledgerid, reportof, currenctid, fromdate, todate);

                foreach (var item in Data)
                {
                    SalesReportModel singleone = new SalesReportModel()
                    {
                        Amount = item.Amount,
                        BusMasterName = item.BusMasterName,
                        BusPNRId = item.BusPNRId,
                        IssuedDate = item.IssuedDate,
                        PassengerName = item.PassengerName,
                        Sector = item.Sector,
                        ServiceProviderName = item.ServiceProviderName

                    };
                    collection.Add(singleone);
                }

                
            }
            if (reportType == 5)
            {
                var Data = entity.Train_GetSalesReport(ledgerid, reportof, currenctid, fromdate, todate);
               
                foreach (var item in Data)
                {
                    SalesReportModel singleone = new SalesReportModel()
                    {
                        TrainName = item.TrainName,
                        PassengerName = item.PassengerName,
                        TrainNo = item.TrainNo,
                        TrainPNRId = item.TrainPNRId,
                        IssuedDate = item.IssuedDate,
                        NoOfSeat = item.NoOfSeat,
                        Sector = item.Sector,
                        Amount = item.Amount
                     };
                  
                    collection.Add(singleone);
                }
            }
            
                return collection;
            }
        
    }
}