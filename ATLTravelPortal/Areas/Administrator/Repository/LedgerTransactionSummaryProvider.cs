using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class LedgerTransactionSummaryProvider
    {
        EntityModel entity = new EntityModel();
        public List<LedgerTransactionSummaryModel> GetSummeryOfLedgerTransactionList(int? ProductId,int CurrencyId,int Type,DateTime DateFrom,DateTime DateTo,int? FilterType,float FilterValue)
        {
            var Data = entity.GL_GetSummeryOfLedgerTransaction(ProductId, CurrencyId, Type, DateFrom, DateTo, FilterType, FilterValue);
            List<LedgerTransactionSummaryModel> Listcollection = new List<LedgerTransactionSummaryModel>();
            foreach (var item in Data)
            {
                LedgerTransactionSummaryModel singleone = new LedgerTransactionSummaryModel()
                {
                    ClosingBalance = item.ClosingBalance,
                    Cr = item.Cr,
                    Dr = item.Dr,
                    LedgerId = item.LedgerId,
                    LedgerName = item.LedgerName,
                    OpeningBalance = item.OpeningBalance

                };
                Listcollection.Add(singleone);
            }
            return Listcollection;
        }

        public IEnumerable<SelectListItem> GetProductOption() 
        {
            var Data = entity.Core_Products.Where(x=>x.ProductId !=5);
            List<SelectListItem> listoption = new List<SelectListItem>();

            foreach (var item in Data)
            {
                SelectListItem option = new SelectListItem()
                {
                    Value = item.ProductId.ToString(),
                    Text = item.ProductName
                };
                listoption.Add(option);
            }
            return listoption;
            }
        public IEnumerable<SelectListItem> GetCurrencyOption()
        {
            var Data = entity.Currencies.Where(x => x.CurrencyId == 1 || x.CurrencyId == 2);
            List<SelectListItem> listcollection = new List<SelectListItem>();
            foreach(var item in Data)
            {
                SelectListItem option = new SelectListItem()
                {
                    Value = item.CurrencyId.ToString(),
                    Text = item.CurrencyCode
                };
                listcollection.Add(option);
             }
            return listcollection;
        }

        public IEnumerable<SelectListItem> GetLedgerOfOption()
        {
            List<SelectListItem> listcollection = new List<SelectListItem>();
            listcollection.Add(new SelectListItem {Value="1",Text="Agent"});
            listcollection.Add(new SelectListItem { Value = "2", Text = "Branch" });
            listcollection.Add(new SelectListItem { Value = "3", Text = "Distributor" });

            return listcollection;
        }
        public IEnumerable<SelectListItem> GerFilterTypeoption()
        {
            List<SelectListItem> listcollection = new List<SelectListItem>();
            listcollection.Add(new SelectListItem { Value = "1", Text = "Greater Than" });
            listcollection.Add(new SelectListItem { Value = "2", Text = "Less Than" });

            return listcollection;
        }
        }
    }
