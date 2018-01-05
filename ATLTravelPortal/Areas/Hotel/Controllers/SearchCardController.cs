

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Helpers;
using TravelPortalEntity;


namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    public class SearchCardController : Controller
    {
        SearchCardRepository _SearchCardrepo = new SearchCardRepository();
        CardRepository _Cardrepo = new CardRepository();

        [HttpGet]
        public ActionResult Search()
        {
    
            CardViewModel cardViewModel = new CardViewModel();
            return View(cardViewModel);
        }
        [HttpPost]
        public ActionResult Search(CardViewModel model,FormCollection fc)
        {

            int SearchCardId = Convert.ToInt32(fc["6$SearchCardId"]);
            model = _SearchCardrepo.SearchCard(model.HFCardId);
            if (SearchCardId == 0 || SearchCardId ==3)
            {
                var Viewmodel = new CardViewModel()
                {   isActive =true,
                    CardNumber = model.CardNumber,
                    CardTypeId = model.CardTypeId,
                    CardValue = model.CardValue,
                    ValidTill = model.ValidTill,
                    CardId = model.HFCardId,
                    UpdatedDate = DateTime.Now,
                };
            }
            else
            {

                CardViewModel datamodel = new CardViewModel();
                datamodel.CardNumber = model.CardNumber;
                datamodel.CardStatusId = SearchCardId;
                datamodel.HFCardId  = model.CardId;
                datamodel.CardTypeId = model.CardTypeId;
                datamodel.CardValue = model.CardValue;
                datamodel.ValidTill = model.ValidTill;
                _SearchCardrepo.UpdateCardStatus(datamodel);
               
               
                return RedirectToAction("Search");
            }
            ViewData["success"] = "Record Saved successfully .";
            return View(model);
            }
 
        //[HttpPost]
        //public JsonResult FindCard(string searchText)
        //{
        //    var result = GetCard(searchText);
        //    return Json(result);
        //}

        //public List<Htl_Cards> GetCard(string CardNumber)
        //{
        //    return _SearchCardrepo.GetAvailableCard(CardNumber).ToList();
        //}

       
        
    }
}