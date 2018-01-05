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
    public class MessagePanelsController : Controller
    {
        //
        // GET: /Administrator/MessagePanels/
        MessagePanelsProvider ser = new MessagePanelsProvider();
        public ActionResult Index()
        {
            MessagePanelsModel model = new MessagePanelsModel();
            model.MessagePanelList = ser.GetMessagePanelList();
            return View(model);
        }

         [ValidateInput(false)]
        public ActionResult Create()
        {
            MessagePanelsModel model = new MessagePanelsModel();
            return View(model);
        }

          [HttpPost, ValidateInput(false)]
         public ActionResult Create(MessagePanelsModel model)
         {
             try
             {
                 ser.MessagePanelAdd(model);
             }
             catch
             {
             }
             return RedirectToAction("Index");
         }

          [ValidateInput(false)]
          public ActionResult Edit(int Id)
          {
              MessagePanelsModel model = new MessagePanelsModel();
              model = ser.GetMessagePanelsDetail(Id);

              return View(model);
          }

          [HttpPost, ValidateInput(false)]
          public ActionResult Edit(int Id, MessagePanelsModel model)
          {
              model.MessagePanelId = Id;
              try
              {
                  ser.MessagePanelEdit(model);
              }
              catch
              {
              }

              return RedirectToAction("Index");
          }

          public ActionResult Delete(int Id)
          {
              ser.MessagePanelsDelete(Id);
              return RedirectToAction("Index");
          }
          public ActionResult Detail(int id)
          {

              MessagePanelsModel model = new MessagePanelsModel();
              model = ser.GetMessagePanelsDetail(id);

              return View(model);


          }




    }
}
