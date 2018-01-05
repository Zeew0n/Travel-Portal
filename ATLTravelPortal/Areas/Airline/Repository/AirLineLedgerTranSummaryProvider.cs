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
    public class AirLineLedgerTranSummaryProvider
    {
        EntityModel ent = new EntityModel();

        public IEnumerable<GetLedgerTransactionByAgent_Result> GetLadgertransactionAgent(int AgentId)
        {
            EntityModel ent = new EntityModel();
            return ent.GetLedgerTransactionByAgent(AgentId, 1, null, null);
        }

        public IEnumerable<GetLedgerTransactionByAgentAndDate_Result> GetledgerTransactionByAgentDate(int AgentId, DateTime FromDate, DateTime ToDate)
        {
            return ent.GetLedgerTransactionByAgentAndDate(AgentId, FromDate, ToDate);
        }

       

    }
}