using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Train
{
    public class TrainAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Train";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Train_default",
                "Train/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
