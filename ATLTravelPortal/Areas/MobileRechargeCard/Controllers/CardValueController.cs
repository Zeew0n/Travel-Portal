using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.MobileRechargeCard.Repository;
using ATLTravelPortal.Areas.MobileRechargeCard.Models;
using ATLTravelPortal.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Details = "Details", Delete = "Delete", Edit = "Edit", Order = 2)]
    public class CardValueController : Controller
    {
        //
        // GET: /MobileRechargeCard/CardValue/

        CardValueRepository _pro = new CardValueRepository();
        CardValueModel _model = new CardValueModel();
        DateTime CurrentDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
        int LogedUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
        ActionResponse _res = new ActionResponse();
        public ActionResult Index()
        {
            _model.CardValueList = _pro.List();
            return View(_model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            _model = _pro.Detail(id,out _res);
            _model.CardStatusList = ATLTravelPortal.Repository.GeneralRepository.GeneralStatus();
            Session["ActionResponse"] = _res;
            if (_res.ErrNumber == 0)
                return View(_model);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(CardValueModel model)
        {
            model.ModifiedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
            model.ModifiedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
            Session["ActionResponse"] = _res;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            else
            {
                _res=_pro.Edit(model);
                if (_res.ErrNumber == 0)
                    return RedirectToAction("Index");
                else
                    return View(model);
            }
        }

        public ActionResult Create()
        {
            _model.CardStatusList = ATLTravelPortal.Repository.GeneralRepository.GeneralStatus();
            Session["ActionResponse"] = _res;
            return View(_model);

        }
        [HttpPost]
        public ActionResult Create(CardValueModel model)
        {
            
            model.CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
            model.CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
            _res=_pro.Create(model);
            Session["ActionResponse"] = _res;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            else
            {
                if (_res.ErrNumber == 0)
                    return RedirectToAction("Index");
                else
                    return View(model);
            }
        }

        public ActionResult Details(int? id)
        {
            _model = _pro.Detail(id, out _res);
            Session["ActionResponse"] = _res;
            if (_res.ErrNumber == 0)
                return View(_model);
            else
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            _res=_pro.Delete(Id,LogedUserId,CurrentDate);
            Session["ActionResponse"] = _res;
            return RedirectToAction("Index");
        }
    }
}
