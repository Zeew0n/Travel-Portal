using System.Web.Mvc;

namespace ATLTravelPortal.Controllers
{
    // Jeewanle Comment Gareko login garna
    //[HandleError]
    //[CheckSessionFilter(Order = 1)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to Arihant Holidays Travel Portal!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
