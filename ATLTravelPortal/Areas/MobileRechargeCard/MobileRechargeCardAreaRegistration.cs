using System.Web.Mvc;

namespace ATLTravelPortal.Areas.MobileRechargeCard
{
    public class MobileRechargeCardAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MobileRechargeCard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MobileRechargeCard_default",
                "MobileRechargeCard/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
