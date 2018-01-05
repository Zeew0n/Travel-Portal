using ATLTravelPortal.Areas.Bus.Repository;
using ATLTravelPortal.SecurityAttributes;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class BusGeneralController : Controller
    {
        public JsonResult JsonUpdateRate(long? id, double? Amount)
        {
            BusScheduleRepository _rep = new BusScheduleRepository();
            return Json(_rep.UpdateRate(id, Amount), JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonUpdateActualRate(long id, double Amount)
        {
            BusScheduleRepository _rep = new BusScheduleRepository();
            return Json(_rep.UpdateActualRate(id, Amount), JsonRequestBehavior.AllowGet);
        }
    }
}
