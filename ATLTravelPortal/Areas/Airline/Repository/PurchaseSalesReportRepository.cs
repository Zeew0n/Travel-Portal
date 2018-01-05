using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;
namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PurchaseSalesReportRepository
    {
        EntityModel entity = new EntityModel();

        public List<PurchaseSalesReportModel> GetPurchaseList(int? CurrencyID, DateTime? FromDate, DateTime? ToDate)
        {
            var Data = entity.Air_GetPurchaseSalesReport(CurrencyID, FromDate, ToDate);
            List<PurchaseSalesReportModel> SalesPurchaselist = new List<PurchaseSalesReportModel>();

            double AdminPurchaseTotal, AdminSalesTotal, BranchpurchaseTotal, BranchSalesTotal, DisPurchaseTotal, DisSalesTotal, AgentPurchaseTotal, AgentSalesTotal;
            AdminPurchaseTotal = AdminSalesTotal = BranchpurchaseTotal = BranchSalesTotal = DisPurchaseTotal = DisSalesTotal = AgentPurchaseTotal = AgentSalesTotal = 0;

            foreach (var item in Data)
            {
                PurchaseSalesReportModel singleone = new PurchaseSalesReportModel()
                {
                    BranchName = item.BranchName,
                    DistributorName = item.DistributorName,
                    AgentName = item.AgentName,
                    Ariline = item.Airline,
                    ServiceProvider = item.ServiceProviderName,
                    Sector = item.Sector,
                    AdminPurchase = item.AdminPurchaseAmount,
                    AdminSales = item.AdminSalesAmount,
                    BranchPurchase = item.BranchPurchaseAmount,
                    BranchSales = item.BranchSalesAmount,
                    DistributorPurchase = item.DisPurchaseAmount,
                    DistributorSales = item.DisSalesAmount,
                    AgentPurchase = item.AgentPurchaseAmount,
                    AgentSales = item.AgentSalesAmount

                };
                SalesPurchaselist.Add(singleone);

                AdminPurchaseTotal += item.AdminPurchaseAmount;
                AdminSalesTotal += item.AdminSalesAmount ?? 0;
                BranchpurchaseTotal += item.BranchPurchaseAmount ?? 0;
                BranchSalesTotal += item.BranchSalesAmount ?? 0;
                DisPurchaseTotal += item.DisPurchaseAmount ?? 0;
                DisSalesTotal += item.DisSalesAmount ?? 0;
                AgentPurchaseTotal += item.AgentPurchaseAmount ?? 0;
                AgentSalesTotal += item.AgentSalesAmount ?? 0;
            }
            PurchaseSalesReportModel last = new PurchaseSalesReportModel();
            last.AdminPurchase = AdminPurchaseTotal;
            last.AdminSales = AdminSalesTotal;
            last.BranchPurchase = BranchpurchaseTotal;
            last.BranchSales = BranchSalesTotal;
            last.DistributorPurchase = DisPurchaseTotal;
            last.DistributorSales = DisSalesTotal;
            last.AgentPurchase = AgentPurchaseTotal;
            last.AgentSales = AgentSalesTotal;
            SalesPurchaselist.Add(last);
            return SalesPurchaselist;
        }


        public IEnumerable<SelectListItem> GetCurrency()
        {
            var Data = entity.Currencies.OrderBy(x => x.CurrencyId);
            List<SelectListItem> currencyList = new List<SelectListItem>();
            foreach (var item in Data)
            {
                SelectListItem singleone = new SelectListItem()
                {
                    Value = item.CurrencyId.ToString(),
                    Text = item.CurrencyCode
                };
                currencyList.Add(singleone);
            }
            return currencyList;
        }
    }
}