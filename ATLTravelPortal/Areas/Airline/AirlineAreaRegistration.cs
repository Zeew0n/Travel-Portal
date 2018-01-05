using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline
{
    public class AirlineAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Airline";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Airline_default",
                "Airline/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
