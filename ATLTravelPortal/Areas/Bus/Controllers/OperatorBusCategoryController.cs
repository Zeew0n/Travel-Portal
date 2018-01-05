using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Areas.Bus.Repository;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Details = "Details", Delete = "Delete", Edit = "Edit", Order = 2)]
    [ValidateInput(false)]
    public class OperatorBusCategoryController : Controller
    {
        BusMessageModel _res = new BusMessageModel();
        public ActionResult Index(int? page)
        {
            OperatorBusCategoryModel _model = new OperatorBusCategoryModel();
            OperatorBusCategoryRepository _rep = new OperatorBusCategoryRepository();
            BusGeneralRepository.SetRequestPageRow();
            try
            {
                _model.TabularList = _rep.GetPagedList(page);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            _model.Message = _res;
            return View(_model);
        }

        public ActionResult Details(int? id)
        {
            OperatorBusCategoryModel _model = new OperatorBusCategoryModel();
            OperatorBusCategoryRepository _rep = new OperatorBusCategoryRepository();
            try
            {
                _model = _rep.Detail(id);

            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            BusGeneralRepository.ActionMessage = _res;
            if (_model.Message.MsgNumber == 0)
                return View(_model);
            else
                return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            OperatorBusCategoryModel _model = new OperatorBusCategoryModel();
            OperatorBusCategoryRepository _rep = new OperatorBusCategoryRepository();
            _model.Message = _res;
            _model = _rep.Fill(_model);
            return View(_model);
        }
        [HttpPost]
        public ActionResult Create(OperatorBusCategoryModel model)
        {
            OperatorBusCategoryRepository _rep = new OperatorBusCategoryRepository();
            model = _rep.Fill(model);
            try
            {
                model.Message = _rep.Create(model);
            }
            catch (Exception ex)
            {
                model.Message = BusGeneralRepository.CatchException(ex);
            }
            BusGeneralRepository.ActionMessage = _res;
            if (model.Message.MsgNumber == 0)
                return RedirectToAction("Index");
            else
                return View(model);
        }

        public ActionResult Edit(int? id)
        {
            OperatorBusCategoryModel _model = new OperatorBusCategoryModel();
            OperatorBusCategoryRepository _rep = new OperatorBusCategoryRepository();
            try
            {
                _model = _rep.Detail(id);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            BusGeneralRepository.ActionMessage = _model.Message;
            _model = _rep.Fill(_model);
            return View(_model);
        }
        [HttpPost]
        public ActionResult Edit(OperatorBusCategoryModel model)
        {
            OperatorBusCategoryRepository _rep = new OperatorBusCategoryRepository();
            model = _rep.Fill(model);
            try
            {
                model.Message = _rep.Edit(model);
            }
            catch (Exception ex)
            {
                model.Message = BusGeneralRepository.CatchException(ex);
            }
            if (model.Message.MsgNumber == 0)
            {
                BusGeneralRepository.ActionMessage = model.Message;
                return RedirectToAction("Index");
            }
            else
                return View(model);

        }

        public ActionResult Delete(int? id)
        {
            OperatorBusCategoryModel _model = new OperatorBusCategoryModel();
            OperatorBusCategoryRepository _rep = new OperatorBusCategoryRepository();
            try
            {
                _model.Message = _rep.Delete(id);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }

            BusGeneralRepository.ActionMessage = _model.Message;
            return RedirectToAction("Index");
        }
    
    }
}
