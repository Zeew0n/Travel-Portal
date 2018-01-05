using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class AgentMessagesController : Controller
    {
        //
        // GET: /Airline/AgentMessages/
        GeneralProvider defaultProvider = new GeneralProvider();
        AgentMessagesProvider ser = new AgentMessagesProvider();

        public ActionResult Index()
        {
            AgentMessagesModel model = new AgentMessagesModel();
            model.AgentMessageList = ser.GetAgentMessageList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            AgentMessagesModel model = new AgentMessagesModel();
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            model.ProductList = ser.GetAllProductList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AgentMessagesModel model)
        {
            try
            {
               

                
                ser.AgentMessageAdd(model);
            }
            catch
            {
            }
            model.ProductList = ser.GetAllProductList();
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
          
            AgentMessagesModel model = new AgentMessagesModel();

            model = ser.GetAgentMessageDetail(Id);

           
            model.ProductList = ser.GetAllProductList();
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, AgentMessagesModel model)
        {
          
            model.AgentMessageId = Id;
          
            try
            {

                ser.AgentMessageEdit(model);
            }
            catch
            {
            }
            model.ProductList = ser.GetAllProductList();
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ser.AgentMessageDelete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {

            AgentMessagesModel model = new AgentMessagesModel();
            model = ser.GetAgentMessageDetail(id);

            return View(model);


        }

    }
}
