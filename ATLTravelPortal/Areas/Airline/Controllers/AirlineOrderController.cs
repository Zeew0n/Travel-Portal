using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Delete = "Delete", Order = 2)]
    public class AirlineOrderController : Controller
    {
        TicketAirlineSearchProvider _ser = new TicketAirlineSearchProvider();
        GeneralProvider _provider = new GeneralProvider();
        public ActionResult Index(int? TypeId)
        {
            TicketAirlineSearchOrderModel model = new TicketAirlineSearchOrderModel();
            ViewData["AirlineTypes"] = new SelectList(_provider.GetAirlineType(), "AirineTypeId", "TypeName", 0);
            if (Request.IsAjaxRequest())
            {
                model.GetTicketAirlineSearchList = _ser.GetTicketAirlineSearchOrder(Convert.ToInt32(TypeId));

                return PartialView("OrderList", model);
            }
            //As In View Page by default International i.e.TypeId =1 will be selected.
            model.GetTicketAirlineSearchList = _ser.GetTicketAirlineSearchOrder(1);
            model.SerialOrder = new List<int>();
            foreach (var item in model.GetTicketAirlineSearchList)
            {
                model.SerialOrder.Add(Convert.ToInt32(item.SerialNo));
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult Index(TicketAirlineSearchOrderModel model, FormCollection fc, List<string> SerialOrders)
        {
            bool flag = false;
            
            if (model.AirlineName != null && model.AirlineName != "")
            {
                int airlineId = _ser.GetAirlineId(model.AirlineName);
                if (airlineId != 0)
                {
                    bool check = _ser.CheckIfAirlineExist(airlineId);
                    if (check == true)
                    {
                        model.SerialNo = _ser.GetMaxAirlineSearchId(model.AirlineTypeId);
                        model.AirlineId = airlineId;
                        _ser.AddAirlineSearchOrder(model);
                    }
                    else
                    {
                        TempData["Error"] = "Airline already Exists";
                        flag = true;

                    }
                }
                else
                {
                    TempData["Airline"] = "Please Select proper Airline Name";
                    flag = true;
                }
            }

            ViewData["AirlineTypes"] = new SelectList(_provider.GetAirlineType(), "AirineTypeId", "TypeName", 0);
            string str1 = fc["SerialOrder"];

            
            bool checkOrder1 = _ser.CheckOrder(str1);
            if (checkOrder1 == true)
            {
                if (str1 != null && str1 != "")
                {
                    string[] order = str1.Split(new char[] { ' ', '.', '?', 'r' });

                    for (int i = 1; i < order.Length; i++)
                    {

                        _ser.UpdateOrder(int.Parse(order[i].Replace(",", "")), i);
                    }
                }
                if (flag == true)
                {
                    model.GetTicketAirlineSearchList = _ser.GetTicketAirlineSearchOrder(model.AirlineTypeId);
                    return View("Index", model);
                    //return PartialView("OrderList", model);
                }
            }

            model.GetTicketAirlineSearchList = _ser.GetTicketAirlineSearchOrder(model.AirlineTypeId);
            return PartialView("Index", model);
        }

        public ActionResult Delete(int Id)
        {
            _ser.DeleteTicketAirlineSearch(Id);
            return RedirectToAction("Index");
        }
       
    }

}
