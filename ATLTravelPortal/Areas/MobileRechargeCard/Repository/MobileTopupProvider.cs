using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.MobileRechargeCard.Models;
using ATLTravelPortal.Repository;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Repository
{
    public class MobileTopupProvider
    {
        EntityModel entity = new EntityModel();

        GeneralProvider generalProvider = new GeneralProvider();
        public MobileTopupModel GetMobileTopupModel(MobileTopupModel model)
        {
            model.Agents = new SelectList(generalProvider.GetAgentList(), "AgentId", "AgentName");
            model.ServiceProviders = new SelectList(GetServiceProviders(), "ServiceProviderId", "ServiceProviderName");
            model.MobileTopupModelList = ListMobileTopupReport(model.AgentId, model.FromDate, model.ToDate, model.ServiceProviderId, model.IsSucces);
            model.SuccessFlags = new SelectList(GetSuccessFlags(), "Value", "Text","true");
            model.IsSucces = true;
            return model;
        }


        public List<ServiceProviders> GetServiceProviders()
        {
            return entity.ServiceProviders
                .Where(x => x.isActive == true && (x.ServiceProviderName.Equals("NTC Mobile") || x.ServiceProviderName.Equals("NCELL Mobile")))
                .OrderBy(x => x.ServiceProviderName).ToList();
        }

        public List<MobileTopupModel> ListMobileTopupReport(int? agentId, DateTime? fromdate, DateTime? todate, int? serviceProviderId, bool? isSuccess)
        {
            var data = entity.MRC_GetRechargeDetails(agentId, isSuccess, serviceProviderId == 0 ? null : serviceProviderId, fromdate, todate);

            List<MobileTopupModel> model = new List<MobileTopupModel>();

            foreach (var item in data)
            {
                var MobileTopupModel = new MobileTopupModel
                {
                    AgentName = item.AgentName,
                    ServiceProvierName = item.ServiceProviderName,
                    SalesPrice = item.Amount,
                    SalesDate = item.SalesDate,
                    IsSucces = item.IsSuccess,
                    StatusMessage = item.StatusMessage
                };
                model.Add(MobileTopupModel);
            }
            return model.OrderByDescending(x => x.SalesDate).ToList();
        }

        public IEnumerable<SelectListItem> GetSuccessFlags()
        {
            List<SelectListItem> flags = new List<SelectListItem>();
            flags.Add(new SelectListItem
            {
                Text = "True",
                Value = "true",
                Selected = false
            });
            flags.Add(new SelectListItem
            {
                Text = "False",
                Value = "false",
                Selected = false
            });            
            return flags;
        }
    }
}