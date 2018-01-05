using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Areas.Bus.Repository;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Details = "Details", Delete = "Delete", Edit = "Edit", Order = 2)]
    public class BusCityController : Controller
    {
        BusMessageModel _res = new BusMessageModel();
        public ActionResult Index(int? page)
        {
            BusCityModel _model = new BusCityModel();
            BusCityRepository _rep = new BusCityRepository();
            BusGeneralRepository.SetRequestPageRow();
            try
            {
                _model.TabularList = _rep.GetPagedList(page);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            _model.Message=_res;
            return View(_model);
        }

        public ActionResult Details(int? id)
        {
            BusCityModel _model = new BusCityModel();
            BusCityRepository _rep = new BusCityRepository();
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
            BusCityModel _model = new BusCityModel();
            BusCityRepository _rep = new BusCityRepository();
            _model.Message = _res;
            return View(_model);
        }
        [HttpPost]
        public ActionResult Create(BusCityModel model)
        {
            BusCityModel _model = new BusCityModel();
            BusCityRepository _rep = new BusCityRepository();
            try
            {
                _model.Message = _rep.Create(model);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            BusGeneralRepository.ActionMessage = _res;
            if (_model.Message.MsgNumber == 0)
                return RedirectToAction("Index");
            else
                return View(model);
        }

        public ActionResult Edit(int? id)
        {
            BusCityModel _model = new BusCityModel();
            BusCityRepository _rep = new BusCityRepository();
            try
            {
                _model = _rep.Detail(id);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            BusGeneralRepository.ActionMessage = _model.Message;
            return View(_model);
        }
        [HttpPost]
        public ActionResult Edit(BusCityModel model)
        {
            BusCityRepository _rep = new BusCityRepository();
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
            BusCityModel _model = new BusCityModel();
            BusCityRepository _rep = new BusCityRepository();
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
