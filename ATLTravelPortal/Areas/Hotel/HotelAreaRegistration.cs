using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Hotel
{
    public class HotelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Hotel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Hotel_default",
                "Hotel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}