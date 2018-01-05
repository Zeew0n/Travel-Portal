using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    //Jeewan le comment gareko [ATLTravelPortal.SecurityAttributes.CheckSessionFilter(Order = 1)]
    public class DashboardController : Controller
    {
        //
        // GET: /Bus/DashBoard/

        public ActionResult Index()
        {
            return View();
        }

    }
}
