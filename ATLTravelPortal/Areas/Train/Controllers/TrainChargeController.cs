using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Train.Models;
using ATLTravelPortal.Areas.Train.Repository;

namespace ATLTravelPortal.Areas.Train.Controllers
{
    public class TrainChargeController : Controller
    {
        //
        // GET: /Train/TrainAgentCharge/
        TrainChargeRepository _rep = new TrainChargeRepository();
        public ActionResult Index()
        {
            TrainChargeModel _model = new TrainChargeModel();
            _model.ClassList = _rep.Codelist();
            _model.List = _rep.Create(_model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Index(TrainChargeModel _model)
        {
            _model.ClassList = _rep.Codelist();
            _model.List = _rep.Create(_model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            TrainChargeModel _model = new TrainChargeModel();
            _model.ClassList = _rep.Codelist();
            _model.List = _rep.Create(_model);
            return View(_model);
        }
        [HttpPost]
        public ActionResult Edit(TrainChargeModel _model)
        {
            _model.ClassList = _rep.Codelist();
            _rep.Edit(_model);
            return RedirectToAction("Index");

        }
        

    }
}
