using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Delete = "Delete", Order = 2)]

    public class AgentNewsScrollController : Controller
    {
        //
        // GET: /Administrator/AgentNewsScroll/
        AgentNewsScrollProvider ser = new AgentNewsScrollProvider();

        public ActionResult Index()
        {
            AgentNewsScrollModel model = new AgentNewsScrollModel();
            model.NewsScrollList = ser.GetNewsScrollList();
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AgentNewsScrollModel model)
        {
            try
            {
                ser.ScrollNewsAdd(model);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            AgentNewsScrollModel model = new AgentNewsScrollModel();
            model = ser.GetScrollNewsDetail(Id);

            return View(model);
        }

        
        [HttpPost]
        public ActionResult Edit(int Id, AgentNewsScrollModel model)
        {
            model.ScrollNewsId = Id;
            try
            {
                ser.ScrollNewsEdit(model);
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            ser.ScrollNewsDelete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {

            AgentNewsScrollModel model = new AgentNewsScrollModel();
            model = ser.GetScrollNewsDetail(id);

            return View(model);


        }
    }
}
