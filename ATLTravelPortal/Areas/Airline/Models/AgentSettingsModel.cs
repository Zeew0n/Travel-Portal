using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentSettingsModel
    {
        public int SettingId { get; set; }

        public String SettingName { get; set; }

        public bool IsActive { get; set;}

        public int AgentSettingId { get; set; }

        public int? AgentId { get; set; }
    }
    public class ModelSettingExtension
    {
        //////
        public static bool IsActiveSetting(int SettingId, List<AgentSettingsModel> SettingIdHelper)
        {
            bool flag = false;
            List<int> SettingIds = SettingIdHelper.Select(ii => ii.SettingId).ToList();
            foreach (int sSid in SettingIds)
            {
                if (SettingId == sSid)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}