using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using ATLTravelPortal.Areas.Bus.Repository;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    public class UpdateDatabaseController : Controller
    {
       
        UpdateDatabaseRepository _rep = new UpdateDatabaseRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string CityUpdate()
        {
            string result = "Failed";

            try
            {
                result = _rep.UpdateCity();
            }
            catch
            {
                result = "Failed";
            }
            return result;
        }  

        [HttpPost]
        public string StationUpdate()
        {
            string result = "Failed";

            try
            {
                result = _rep.UpdateStation();
            }
            catch
            {
                result = "Failed";
            }
            return result;
        }

        [HttpPost]
        public string CategoryUpdate()
        {
            string result = "Failed";

            try
            {
                result = _rep.UpdateCategory();
            }
            catch
            {
                result = "Failed";
            }
            return result;           
        }           

        [HttpPost]
        public string OperatorUpdate()
        {
            string result = "Failed";

            try
            {
                result = _rep.UpdateOperator();
            }
            catch
            {
                result = "Failed";
            }
            return result;    
        } 

        [HttpPost]
        public string RouteScheduleUpdate()
        {
            string result = "Failed";

            try
            {
                result = _rep.UpdateRouteSchedule();
            }
            catch
            {
                result = "Failed";
            }
            return result;    
        }
       
       
    } 
}
