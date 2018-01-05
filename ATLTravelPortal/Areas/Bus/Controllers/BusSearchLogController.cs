using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Areas.Bus.Repository;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;


namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class BusSearchLogController : Controller
    {
        BusMessageModel _res = new BusMessageModel();
        BusSearchLogModel _model = new BusSearchLogModel();
        BusSearchLogRepository _rep = new BusSearchLogRepository();  

        [HttpGet]
        public ActionResult Index(int? page)
        {
            _model.FromDate = DateTime.Now.AddDays(-29);
            _model.ToDate = DateTime.Now.AddDays(1);
            _model = _rep.FillModelddl(_model);
            _model = _rep.GetSearchLogList(_model);            
            return View(_model);       
            
        }

        [HttpPost]
        public ActionResult Index(BusSearchLogModel model)
        {
            model = _rep.FillModelddl(model);
            model = _rep.GetSearchLogList(model);   
            return View(model);
        }
    }
}
