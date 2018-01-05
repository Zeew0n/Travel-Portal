using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Areas.Bus.Repository;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class BranchItineraryController : Controller
    {
        BusMessageModel _res = new BusMessageModel();
        public ActionResult Detail(long? id)
        {
            BusPNRModel _model = new BusPNRModel();
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            try
            {
                _model = _rep.GetBusPNRModelByBusPNRId(id);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            BusGeneralRepository.ActionMessage = _model.Message;

            if (_model.Message.MsgNumber == 0)
                return View(_model);
            else
                return RedirectToAction("Index");
        }

        public ActionResult Print(long? id)
        {
            BusPNRModel _model = new BusPNRModel();
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            try
            {
                _model = _rep.GetBusPNRModelByBusPNRId(id);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            BusGeneralRepository.ActionMessage = _model.Message;
            if (_model.Message.MsgNumber == 0)
                return View(_model);
            else
                return RedirectToAction("Index");
        }
    }
}
