using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Administrator.Repository;
using System.Text;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Details = "Details", Delete = "Delete", Order = 2)]

    public class AgentMessageBoardController : Controller
    {

        // GET: /AgentMessageBoards/
        GeneralProvider _generalprovider = new GeneralProvider();
        AgentMessageBoardModel _model = new AgentMessageBoardModel();
        AgentMessageBoardProvider _pro = new AgentMessageBoardProvider();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        int LoginUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
        DateTime CurresntDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
        public ActionResult Index()
        {
           // _model.AgentList = _generalprovider.GetAgentList();
            _model.AgentMessageBoardList = _pro.List();
            return View(_model);
        }
        [HttpGet, ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            _model = _pro.Detail(id,out _res);
            _model = _pro.FillDdl(_model);
            _model.MessageCatagories = new SelectList(_pro.GetMessageCategories(), "MessageCategoryId", "CategoryName");
            Session["ActionResponse"] = _res;
            if(_res.ErrNumber==0)
            return View(_model);
            else
                return RedirectToAction("Index");
        }
         [HttpPost, ValidateInput(false)]
        public ActionResult Edit(AgentMessageBoardModel model,  int[] ChkAgentId, int[] ChkProductId)
        {
           model.UpdatedBy = LoginUserId;
           model.UpdatedDate = CurresntDate;
           model= _pro.Edit(model,ChkAgentId,ChkProductId,out _res);
           Session["ActionResponse"] = _res;
           if (_res.ErrNumber == 0)
               return RedirectToAction("Index");
           else
               return View(model);
        }
         [ValidateInput(false)]
        public ActionResult Create()
        {
            _model = _pro.FillDdl(_model);
            _model.MessageCatagories = new SelectList(_pro.GetMessageCategories(), "MessageCategoryId", "CategoryName");
            return View(_model);
        }
       [HttpPost, ValidateInput(false)]
        public ActionResult Create(AgentMessageBoardModel model, int[] ChkAgentId, int[] ChkProductId)
        {
            model.UpdatedBy = LoginUserId;
            model.UpdatedDate = CurresntDate;
            model = _pro.Create(model, ChkAgentId, ChkProductId, out _res);
            Session["ActionResponse"] = _res;
            if (_res.ErrNumber == 0)
                return RedirectToAction("Index");
            else
                return View(model);
        }

        public ActionResult Details(int id)
        {
            _model = _pro.Detail(id,out _res);
            //Session["ActionResponse"] = _res;
            //if (_res.ErrNumber == 0)
            //    return RedirectToAction("Index");
            //else
                return View(_model);
        }

        public ActionResult Delete(int? Id)
        {
           _res= _pro.Delete(Id);
            Session["ActionResponse"] = _res;
            return RedirectToAction("Index");
        }

    }
}
