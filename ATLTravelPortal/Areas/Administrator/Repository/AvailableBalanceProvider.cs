using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AvailableBalanceProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public List<AvailableBalanceModel> GetAvailableBalance()
        {

            var agents = ent.Agents.OrderBy(x => x.AgentName);


            List<AvailableBalanceModel> Listmodel = new List<AvailableBalanceModel>();

            foreach (var agentinfo in agents)
            {
                var data = ent.Air_GetAvailableBalance(agentinfo.AgentId).ToList();

                var otherData = data.FirstOrDefault();

                AvailableBalanceModel model = new AvailableBalanceModel();
                model.CreditLimit = otherData.CreditLimit.Value;
                model.RemainingBalance = otherData.Amount.Value;
                model.AgentName = otherData.AgentName;

                foreach (var currency in data)
                {
                    CurrencyDetail detail = new CurrencyDetail();
                    detail.Amount = currency.Amount.ToString();
                    detail.CreditLimit = currency.CreditLimit.ToString();
                    detail.CurrenyCode = currency.CurrencyCode.ToString();
                    detail.LedgerAmount = currency.LedgerAmount.ToString();

                    model.CurrencyList.Add(detail);
                    // model.Currency = item.CurrencyCode;
                }
                Listmodel.Add(model);
            }

            return Listmodel;
        }

        public string GetAgencyCode(int? AgentId)
        {
            if (AgentId != null)
            {
                return (from a in ent.Agents
                        where a.AgentId == AgentId
                        select a.AgentCode).SingleOrDefault() ?? "";
            }
            else
            {
                return "";
            }
        }

        //public IEnumerable<SelectListItem> GetAllAgentList()
        //{
        //    List<Agents> all = GetAgentList().ToList();
        //    var GetAllAgentList = new List<SelectListItem>();
        //    foreach (var item in all)
        //    {
        //        var teml = new SelectListItem
        //        {
        //            Text = item.AgentName,
        //            Value = item.AgentId.ToString()
        //        };
        //        GetAllAgentList.Add(teml);
        //    }
        //    return GetAllAgentList.AsEnumerable();
        //}

        //public List<Agents> GetAgentList()
        //{
        //    return ent.Agents.OrderBy(x => x.AgentName).ToList();
        //}

    }
}