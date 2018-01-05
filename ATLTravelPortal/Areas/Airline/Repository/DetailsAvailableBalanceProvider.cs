using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using System.Data.Objects;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class DetailsAvailableBalanceProvider
    {
        EntityModel ent = new EntityModel();

        public IEnumerable<LedgerSummaryModel> GetAvailableBalance(int? AgentId, int? ProductId)
        {
            var result = ent.GetAvailableBalance(AgentId, ProductId);
            List<LedgerSummaryModel> model = new List<LedgerSummaryModel>();
            foreach (var item in result)
            {
                LedgerSummaryModel obj = new LedgerSummaryModel
                {
                    Mode = item.TranMode,
                    Amount = item.Amount,
                    AgentName = item.AgentName
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
    }
}