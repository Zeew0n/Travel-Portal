using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Helpers;
using TravelPortalEntity;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class CardRegistrationController : Controller
    {
        CardRepository _Cardrepo = new CardRepository();
        IssueCardRepository _IssueRepo = new IssueCardRepository();
        //
        // GET: /CardRegistration/

        public ActionResult Index()
        {
            var model = _Cardrepo.GetAllCardsList();
            return View(model);
        }

        public ActionResult Create()
        {
            CardViewModel model = new CardViewModel()
            {
                CardTypeList = _Cardrepo.GetAllCardTypeList(),
            };
           
      
            ////////////////////////
           // var model = _Cardrepo.GetAllCardsList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("Create",model);
            }
            return View();
        }
         [HttpPost]
        public ActionResult Create(CardViewModel model)
        {
              var ts=(TravelSession)Session["TravelSessionInfo"];
              //model.CreatedBy = ts.AppUserId;
              model.isActive = true;
              model.CardStatusId = 1;
              model.CardRule = _Cardrepo.GetCardRule(model.CardTypeId);
              bool flag;
                 flag = _Cardrepo.CheckDuplicateCardNumber(model.CardNumber);
                 if (flag == true)
                 {
                     //TempData["Card Rule"] = _Cardrepo.GetCardRule(model.CardTypeId);
                     _Cardrepo.CreateCard(model);
                 }
                 else
                 {
                     return RedirectToAction("Index");
                 }
                 return RedirectToAction("Index");
        }
      
        public ActionResult Details(int id)
        {
            var model = _Cardrepo.GetCardDetailsInfo(id);
            TempData["Card Rule"] = _Cardrepo.GetCardRule(model.CardTypeId);
            if (model.CardStatusId == 2)
            {
                model.CardRule = _Cardrepo.GetCardRule(model.CardTypeId);
                Htl_AgentCards Agent = _IssueRepo.GetAgentInfoByCardId(id);
                TempData["AgentName"] = _IssueRepo.GetAgentInfo(Agent.AgentId);
                TempData["Issue Date"] = Agent.IssueDate;
                TempData["Card Rule"] = _Cardrepo.GetCardRule(model.CardTypeId);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("Details",model);
            }
            return View(model);
        }
        

        public ActionResult Edit(int id)
        {
            var datamodel = _Cardrepo.GetCardDetailsInfo(id);
            CardViewModel model = new CardViewModel()
            {  
                CardNumber =datamodel .CardNumber ,
               CardStatusId =datamodel .CardStatusId ,
               CardTypeId =datamodel .CardTypeId ,
               CardValue =datamodel .CardValue ,
               isActive =datamodel .isActive ,
               ValidTill =datamodel .ValidTill ,
               CardStatusList =_Cardrepo .GetAllCardStatusList (),
               CardTypeList = _Cardrepo.GetAllCardTypeList(),
            };

            model.CardRule = _Cardrepo.GetCardRule(model.CardTypeId);
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("Edit", model);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, CardViewModel model)
        {
            
            //ViewData["CardType"] = new SelectList(_Cardrepo.GetCardType(), "CardTypeId", "CardTypeName");
            //ViewData["CardStatus"] = new SelectList(_Cardrepo.GetCardStatus(), "CardStatusId", "CardStatusName", model.CardStatusId);
            //TempData["Card Rule"] = _Cardrepo.GetCardRule(model.CardTypeId);
             
           if (!ModelState.IsValid)
           {
               CardViewModel models = new CardViewModel()
               {
                   CardId =model.HFCardId ,
                   CardNumber = model.CardNumber,
                   CardStatusId = model.CardStatusId,
                   CardTypeId = model.CardTypeId,
                   CardValue = model.CardValue,
                   isActive = model.isActive,
                   ValidTill = model.ValidTill,
                   CardStatusList = _Cardrepo.GetAllCardStatusList(),
                   CardTypeList = _Cardrepo.GetAllCardTypeList(),
                  CardRule = _Cardrepo.GetCardRule(model.CardTypeId),
                   
               };
               //ViewData["CardType"] = new SelectList(_Cardrepo.GetCardType(), "CardTypeId", "CardTypeName");
               //ViewData["CardStatus"] = new SelectList(_Cardrepo.GetCardStatus(), "CardStatusId", "CardStatusName", model.CardStatusId);
               //TempData["Card Rule"] = _Cardrepo.GetCardRule(model.CardTypeId);
               models.CardId =id;
                 //_Cardrepo.GetCardDetailsInfo(id);
               //viewmodel.CardRule = _Cardrepo.GetCardRule(model.CardTypeId); 
               //model.CardRule = _Cardrepo.GetCardRule(model.CardTypeId); 
               //model.CardStatusId = 1;

               _Cardrepo.UpdateCard(models);
             
              return RedirectToAction("Index");
           }

           else
           {
               var ts = (TravelSession)Session["TravelSessionInfo"];
               model.CardId=id;
               model.UpdatedBy=ts.AppUserId;
               model.UpdatedDate =DateTime.Now ;
               model.CardStatusId = 1;
        
               _Cardrepo.UpdateCard(model);
               ViewData["success"] = "Record edited successfully .";
               if (Request.IsAjaxRequest())
               {
                   var model1 = _Cardrepo.GetAllCardsList();
                   return PartialView("Edit", model1);
               }
               return RedirectToAction("Index");
          
            }
          
       }
    
        //public JsonResult CardType(int id)
        //{
           
        //    var result = new JsonResult();
        //    var lists = _Cardrepo.GetCardRule(id);
        //    result.Data = lists;
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;

        //}

        public JsonResult Delete(int id)
        {
    
         
            ////// Hit the Card database with card status Sold 
            CardViewModel cardmodel = new CardViewModel();
            cardmodel.CardId = id;
              ////// This is for Unsold status _IssueRepo.UpdateCardToSoldStatus(cardmodel);

            _Cardrepo.DeleteCard(id);
            JsonResult result = new JsonResult();
            result.Data = id;
            return result;

        }

    }
}
