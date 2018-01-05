using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentLedgerTransactionsProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public IEnumerable<SelectListItem> GetAllAgentList()
        {
            List<Agents> all = GetAgentList().ToList();
            var GetAllAgentList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentName,
                    Value = item.AgentId.ToString()
                };
                GetAllAgentList.Add(teml);
            }
            return GetAllAgentList.AsEnumerable();
        }
        public List<Agents> GetAgentList()
        {
            return ent.Agents.OrderBy(x => x.AgentName).ToList();
        }


        public List<Core_Products> GetProductsList()
        {
            return ent.Core_Products.Where(x => x.ProductId == 1).OrderBy(x => x.ProductName).ToList();
        }

        public IEnumerable<SelectListItem> GetAllProductList()
        {
            List<Core_Products> all = GetProductsList().ToList();
            var GetAllpRODUCTist = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.ProductName,
                    Value = item.ProductId.ToString()
                };
                GetAllpRODUCTist.Add(teml);
            }
            return GetAllpRODUCTist.AsEnumerable();
        }

        public List<AgentLedgerTransactionsModel> GetTransactionList(int? AgentLedgerId, int productId, DateTime FromDate, DateTime ToDate, int Currency, int Type)
        {
            EntityModel ent = new EntityModel();
            var data = ent.Air_GetLedgerTransaction(AgentLedgerId, productId, Currency, Type, FromDate, ToDate);

            List<AgentLedgerTransactionsModel> list = new List<AgentLedgerTransactionsModel>();
            foreach (var item in data)
            {
                var temp = new AgentLedgerTransactionsModel
                {
                    Balance = item.Balance,
                    CrAmount = item.CrAmount,
                    DrAmount = item.DrAmount,
                    DrCr = item.DrCr,
                    Narration1 = item.Narration1,
                    RefrenceNo = item.RefrenceNo,
                    TranID = item.TranID,
                    VoucherNumber = item.VoucherNumber.Value,
                    TranDate = item.TranDate
                };
                list.Add(temp);
            }
            return list.ToList();
        }

        public List<Currencies> GetCurrencies()
        {
            //  return ent.Currencies.Where(x => x.CurrencyId == 1).ToList();
            return ent.Currencies.ToList();
        }
    }
}