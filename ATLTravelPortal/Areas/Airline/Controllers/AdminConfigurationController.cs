using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    //[CheckSessionFilter(Order = 1)]
    //[PermissionDetails(View = "Create", Order = 2)]

    public class AdminConfigurationController : Controller
    {
        //
        // GET: /AdminConfiguration/

        AdminConfigurationProvider ser = new AdminConfigurationProvider();

        [HttpGet]
        public ActionResult Create()
        {
            AdminConfigurationModel model = new AdminConfigurationModel();
            int AdminConfigurationId = ser.checkDuplicateRow();

            if (AdminConfigurationId != 0)
            {
                model.AdminConfugrationId = AdminConfigurationId;
                model = ser.GetAdminConfigurationDetail(model.AdminConfugrationId);
                return View(model);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Create(AdminConfigurationModel model)
        {
            // var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                int chkduplicate = ser.checkDuplicateRow();

                if (chkduplicate != 0)
                {
                    model.AdminConfugrationId = chkduplicate;
                    ser.AdminConfigurationEdit(model);
                }
                else
                {
                    ser.AdminConfigurationAdd(model);
                }
            }
            ///// else return if success
            return View();


            // return RedirectToAction("Index");

        }





    }
}
