using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Bus.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Bus.Models;
using System.Text;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Issue", Details = "Details", Delete = "Delete", Edit = "Edit", Order = 2)]
    public class UnIssuedTicketController : Controller
    {
        BusMessageModel _res = new BusMessageModel();
        ATLTravelPortal.Areas.Airline.Repository.GeneralProvider defaultProvider = new Airline.Repository.GeneralProvider();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            BusPNRModel _model = new BusPNRModel();
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            BusGeneralRepository.SetRequestPageRow();
            try
            {
                _model.FromDate = DateTime.Now.AddDays(-15);
                _model.ToDate = DateTime.Now;

                ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");

                _model.TabularList = _rep.GetPagedList(page, _model.AgentId);
            }
            catch (Exception ex)
            {
                _model.Message = BusGeneralRepository.CatchException(ex);
            }
            _model.Message = _res;
            return View(_model);
        }

        [HttpPost]
        public ActionResult Index(BusPNRModel model, int? page)
        {
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            BusGeneralRepository.SetRequestPageRow();
            try
            {
                model.FromDate = DateTime.Now.AddDays(-15);
                model.ToDate = DateTime.Now;

                ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");

                model.TabularList = _rep.GetPagedList(page, model.AgentId);
            }
            catch (Exception ex)
            {
                model.Message = BusGeneralRepository.CatchException(ex);
            }
            model.Message = _res;
            return View(model);
        }

        public ActionResult Details(Int64 id)
        {
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            try
            {
                return View(_rep.GetBusPNRModelByBusPNRId(id));
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            try
            {
                var viewModel = _rep.GetBusPNRModelByBusPNRId(id);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(BusPNRModel model, FormCollection coll)
        {
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            try
            {
                BusPNRModel viewModel = new BusPNRModel();
                 TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                if (coll.AllKeys.Contains("Update"))
                {
                    bool isUpdated = _rep.UpdateBusPNRModel(model);
                    viewModel = _rep.GetBusPNRModelByBusPNRId(model.BusPNRId);
                    TempData["ActionResponse"] = "Updated Successfully";
                }
                else if (coll.AllKeys.Contains("Issue"))
                {
                    bool isUpdated = _rep.UpdateBusPNRModel(model);
                    viewModel = _rep.GetBusPNRModelByBusPNRId(model.BusPNRId);
                    _rep.IssueBusTickets(model.BusPNRId, obj.AppUserId);

                    try
                    {
                        //string messageOperator = _rep.CreateMessage(viewModel, viewModel.OperatorMobileNo);
                        //Helpers.SMS.SendSms.Send(viewModel.MobileNumber, messageOperator, model.BusPNRId.ToString());
                        //string messagePassenger = _rep.CreateMessage(viewModel, viewModel.MobileNumber);
                        //Helpers.SMS.SendSms.Send(viewModel.OperatorMobileNo, messagePassenger.ToString(), model.BusPNRId.ToString());
                        TempData["ActionResponse"] = "Ticket Issued Successfully";
                       
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return RedirectToAction("Index");
                    }
                }
                else if (coll.AllKeys.Contains("Cancel"))
                {
                    _rep.CanCelBusTickets(model.BusPNRId, obj.AppUserId);
                    return RedirectToAction("Index");
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(Int64 id)
        {
            return RedirectToAction("Index");

        }

        public ActionResult Issue(Int64 id)
        {
            UnIssuedTicketRepository _rep = new UnIssuedTicketRepository();
            try
            {
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                _rep.IssueBusTickets(id, obj.AppUserId);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }


    }
}
