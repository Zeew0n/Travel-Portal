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
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details",Delete="Delete" , Order = 2)]
    public class AgentClassesController : Controller
    {
        //
        // GET: /AgentClasses/
        GeneralProvider _provider = new GeneralProvider();
        AgentClassesProvider _ser = new AgentClassesProvider();
        EntityModel ent = new EntityModel();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            AgentClassesModel model = new AgentClassesModel();
            model.AgentClassList = _ser.GetAgentClassList().ToPagedList(currentPageIndex, defaultPageSize);
            
            return View(model);
            
        }
        public ActionResult Create()
        {
            AgentClassesModel model = new AgentClassesModel();
            ViewData["Deals"] = new SelectList(ent.Tkt_DealMasters,"DealMasterId","DealName",0);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(AgentClassesModel model, int[] Deals)
        {

            ViewData["Deals"] = new SelectList(ent.Tkt_DealMasters, "DealMasterId", "DealName", 0);



            bool check = _ser.CheckAgentClassName(model.AgentTypeClasses);
            if (check == true)
            {
                int AgentTypeId = _ser.SaveAgentClass(model.AgentTypeClasses, model.Description);
                return RedirectToAction("Index");

            }
            else
            {
                TempData["AgentTypeName"] = "Agent Class Name already Exists";
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            AgentClassesModel model = new AgentClassesModel();

            model = _ser.GetAgentClass(id);
            ViewData["Deals"] = new SelectList(ent.Tkt_DealMasters, "DealMasterId", "DealName", 0);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(AgentClassesModel model, int[] Deals, int id)
        {

            bool check = true;
            string NewName = model.AgentTypeClasses;
            string Name = ent.AgentClasses.Where(x => x.AgentClassId == id).Select(x => x.AgentClassName).FirstOrDefault();
            if (Name.ToUpper() != model.AgentTypeClasses.ToUpper())
            {
                check = _ser.CheckAgentClassName(model.AgentTypeClasses);
            }
            if (check == true)
            {
                _ser.EditAgentClass(model.AgentTypeClasses, model.Description, id);
                return RedirectToAction("Index");
            }
            else
            {
                model = _ser.GetAgentClass(id);
                model.AgentTypeClasses = NewName;
                TempData["AgentTypeName"] = "Agent Class Name already Exists";
                return View(model);
             
            }

        }
        public ActionResult Delete(int id)
        {
            _ser.DeleteTicketDeals(id);

          int a=  _ser.DeleteAgentClasses(id);
          if (a == 0)
          {
              return RedirectToAction("Index");
          }
         // TempData["Error"] = "Class  Cannot be deleted as Some Agent belongs to this class";
          TempData["Error"] = "Class can't be  deleted ";
          return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            AgentClassesModel model = new AgentClassesModel();
            model = _ser.GetAgentClass(id);
            return View(model);
        }

    }
}
