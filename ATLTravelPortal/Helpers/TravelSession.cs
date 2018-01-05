using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Helpers
{
    public class TravelSession
    {

        public Guid Id { get; set; }          //This id can be user id
        public int AppUserId { get; set; }
        public int LoginTypeId { get; set; }
        public string LoginTypeName { get; set; }
        public string LoginName { get; set; }
        public int UserTypeId { get; set; }
        public string AgentCode { get; set; }
        public string TimeZoneId { get; set; }
        public List<int> ProductId { get; set; }
    }

    public static class AdminSessionStore
    {
        public static TravelSession GetTravelSession()
        {
            return HttpContext.Current.Session["TravelPortalSessionInfo"] as TravelSession;
        }
    }
}