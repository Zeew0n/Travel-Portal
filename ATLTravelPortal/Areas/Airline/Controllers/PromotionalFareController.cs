using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class PromotionalFareController : Controller
    {
        
        PromotionalFareProvider promotionalFareProvider = new PromotionalFareProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            //UnIssuedDomesticTicketModel model = new UnIssuedDomesticTicketModel();
            PromotionalFareSector model = new PromotionalFareSector();
            //model.UsIssuedDomesticTicketList = promotionalFareProvider.ListUnIssuedPromotionalFareTicket();

            model.PromotionalFareSectorList = promotionalFareProvider.GetPromotionalFareSegment();

            //int currentPageNo = 0; int numberOfPage = 0;
            //if (pageNo == null)
            //    pageNo = 1;

            //model.UsIssuedDomesticTicketList = promotionalFareProvider.GetUnIssuedPromotionalFareTicketByPagination(model, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
            //ViewData["TotalPages"] = numberOfPage;
            //ViewData["CurrentPage"] = currentPageNo;

            return View(model);
        }

        //[HttpGet]
        //public ActionResult Edit(Int64? id)
        //{
        //    IssueDomesticTicketsModel viewModel = new IssueDomesticTicketsModel();
        //    try
        //    {
        //        if (id != null)
        //            viewModel = promotionalFareProvider.GetIssueDomesticTickets(id, false);
        //        return View(viewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ActionResponse"] = ex.Message;
        //    }
        //    return View(viewModel);
        //}
        [HttpGet]
        public ActionResult Create()
        {

            PromotionalFareProvider promotionalFareProvider = new PromotionalFareProvider();
            PromotionalFareModel model = new PromotionalFareModel();
            try
            {
                model = promotionalFareProvider.GetPromotionalFareCreateModel();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(PromotionalFareModel model)
        {

            PromotionalFareProvider promotionalFareProvider = new PromotionalFareProvider();
            PromotionalFareModel viewModel = new PromotionalFareModel();
            GeneralProvider generalProvider = new GeneralProvider();
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
           
            try
            {
       
                model.PromotionalFareSector.CreatedBy = obj.AppUserId;                            
                promotionalFareProvider.Save(model);
                model = promotionalFareProvider.GetPromotionalFareCreateModel();    
                TempData["SuccessMessage"] = "Record Saved Successfully!";
                return RedirectToAction("Index");             
             }
        
            catch
            {
                TempData["ActionResponse"] = "Unsuccessful to Save";
                model = promotionalFareProvider.GetPromotionalFareCreateModel();
                return View(model);
            }
      }
        [HttpGet]
        public ActionResult Edit(long PromotionalfareId)
        {
            PromotionalFareModel model = new PromotionalFareModel();
          

            model = promotionalFareProvider.GetPromotionalFareSegmentEdit(PromotionalfareId);
            
            
           return View(model);

 
        }


        [HttpPost]
        public ActionResult Edit(PromotionalFareModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.PromotionalFareSector.CreatedBy = obj.AppUserId;
            IssueDomesticTicketsModel viewModel = new IssueDomesticTicketsModel();
            try
            {
               
                    bool isUpdated = false;
                    isUpdated = promotionalFareProvider.UpdatePromotionalFareSegment(model);
                   

                    if (isUpdated)
                        TempData["SuccessMessage"] = "Record Updated Successfully!";
                        return RedirectToAction("Index");
                    
                    
               
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(viewModel);
            }
           
        }

        [HttpGet]




        public ActionResult Delete(long PromotionalfareId)
        {
            try
            {
                //promotionalFareProvider.CancelPNR(PromotionalfareId);

                if (promotionalFareProvider.Delete(PromotionalfareId))
                {
                    TempData["ActionResponse"] = "Sucessfully Deleted";
                    return RedirectToAction("Index");
                }
                else {
                    TempData["ActionResponse"] = "Sorry Can't Delete";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }
            return RedirectToAction("Index", new { id = PromotionalfareId });          
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index");   
        }

        public ActionResult Details(long PromotionalfareId)
        {
            PromotionalFareModel model = new PromotionalFareModel();

           
            model = promotionalFareProvider.GetPromotionalFareSegmentEdit(PromotionalfareId);


            return View(model);


        }
    }
}
