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
    [PermissionDetails(View = "Index", Add = "Create", Details = "Details", Delete = "Delete", Edit = "Edit", Custom1 = "UpdateRate", Order = 2)]
    public class BusScheduleController : Controller
    {
        BusMessageModel _res = new BusMessageModel();
        public ActionResult Index(int? page)
        {
            BusScheduleModel _model = new BusScheduleModel();
            BusScheduleRepository _rep = new BusScheduleRepository();
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
            BusScheduleModel _model = new BusScheduleModel();
            BusScheduleRepository _rep = new BusScheduleRepository();
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
            BusScheduleModel _model = new BusScheduleModel();
            BusScheduleRepository _rep = new BusScheduleRepository();
            _model.Message = _res;
            _model = _rep.Fill(_model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Create(BusScheduleModel model)
        {
            BusScheduleRepository _rep = new BusScheduleRepository();
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
            BusScheduleModel _model = new BusScheduleModel();
            BusScheduleRepository _rep = new BusScheduleRepository();
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
        public ActionResult Edit(BusScheduleModel model)
        {
            BusScheduleRepository _rep = new BusScheduleRepository();
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
            BusScheduleModel _model = new BusScheduleModel();
            BusScheduleRepository _rep = new BusScheduleRepository();
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

        public ActionResult UpdateRate(int? page)
        {
            BusScheduleModel _model = new BusScheduleModel();
            BusScheduleRepository _rep = new BusScheduleRepository();
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
        }
}
