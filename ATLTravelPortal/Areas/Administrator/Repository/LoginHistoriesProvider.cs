using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class LoginHistoriesProvider
    {
        EntityModel ent = new EntityModel();

        public List<LoginHistoriesModel> ListLoginHistories( DateTime fromdate, DateTime todate)
        {
            var data = ent.GetLoginHistory(fromdate.Date, todate.Date);

            List<LoginHistoriesModel> model = new List<LoginHistoriesModel>();

            foreach (var item in data.Select(x => x))
            {
                var LoginHistoriesModel = new LoginHistoriesModel
                {
                    HistoryId = item.HistoryId,
                    AgentName = item.AgentName,
                    UserName = item.UserName,
                    FullName = item.FullName,
                    LogInDateTime = item.LogedinDateTime,
                    LogOutDateTime = item.LogedoutDateTime

                   
                };
                model.Add(LoginHistoriesModel);

            }
            return model.ToList();
        }
    }
}