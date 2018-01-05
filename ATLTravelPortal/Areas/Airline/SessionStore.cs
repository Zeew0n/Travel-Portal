using System.Web;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline
{
    public static class SessionStore
    {
        public static TravelSession GetTravelSession()
        {
            return HttpContext.Current.Session["TravelPortalSessionInfo"] as TravelSession;
        }
    }
}