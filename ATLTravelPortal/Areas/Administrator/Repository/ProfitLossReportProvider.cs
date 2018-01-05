using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Data;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class ProfitLossReportProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public decimal totalExpenses = 0;
        public decimal totalIncome = 0;

        public IEnumerable<ProfitLossReportModel> GetProfitLossReportList(int? productId, DateTime? FromDate, DateTime? ToDate)
        {
            IQueryable<GL_GetProfitLossReport_Result> result = ent.GL_GetProfitLossReport(productId, FromDate, ToDate).AsQueryable();

            List<ProfitLossReportModel> model = new List<ProfitLossReportModel>();
            foreach (var item in result)
            {
                //ProfitLossReportModel obj = new ProfitLossReportModel
                //{
                //   txtLedgerName =item.LedgerName,
                //   txtExpenses = Convert.ToDecimal( item.Expenses),
                //   txtIncome = Convert.ToDecimal( item.Income),
                //};

                var obj = new ProfitLossReportModel();
                obj.txtLedgerName = item.LedgerName;
                obj.txtExpenses = Convert.ToDecimal( item.Expenses);
                obj.txtIncome = Convert.ToDecimal(item.Income);

                totalExpenses = totalExpenses + Convert.ToDecimal(item.Expenses);
                totalIncome = totalIncome + Convert.ToDecimal(item.Income);

                obj.txtSumExpenses = totalExpenses;
                obj.txtSumIncome = totalIncome;

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