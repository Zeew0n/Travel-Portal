using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class BalanceSheetProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public decimal totalLiabilities = 0;
        public decimal totalAsset = 0;


        public IEnumerable<ProfitLossReportModel> GetBalanceSheetReportList(int? productId, DateTime? FromDate, DateTime? ToDate)
        {
            IQueryable<GL_GetBalanceSheetReport_Result> result = ent.GL_GetBalanceSheetReport(productId, FromDate, ToDate).AsQueryable();

            List<ProfitLossReportModel> model = new List<ProfitLossReportModel>();
            foreach (var item in result)
            {

                var obj = new ProfitLossReportModel();
                obj.txtLedgerName = item.LedgerName;
                obj.txtLiabilities = Convert.ToDecimal(item.Liabilities);
                obj.txtAsset = Convert.ToDecimal(item.Accet);

                totalLiabilities = totalLiabilities + Convert.ToDecimal(item.Liabilities);
                totalAsset = totalAsset + Convert.ToDecimal(item.Accet);

                obj.txtSumLiabilities = totalLiabilities;
                obj.txtSumAsset = totalAsset;

                model.Add(obj);
            }
            return model.AsEnumerable();

        }

        //For filling the Product Dropdownlist
        public List<Core_Products> GetProductList()
        {
            return ent.Core_Products.Where(tt => tt.isActive == true).ToList();
        }

        public IEnumerable<SelectListItem> GetAllProductList()
        {
            List<Core_Products> all = GetProductList().ToList();
            var GetAllProductList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.ProductName,
                    Value = item.ProductId.ToString()
                };
                GetAllProductList.Add(teml);
            }
            return GetAllProductList.AsEnumerable();
        }




    }
}