using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class IssueCardController : Controller
    {
        IssueCardRepository _issuecardrepo = new IssueCardRepository();
        CardRepository _cardrepo = new CardRepository();
        //
        // GET: /IssueCard/

        public ActionResult Index()
        {
            AgentCardViewModel model = new AgentCardViewModel()
            {
                AgentList = _issuecardrepo.GetAllAgentList().ToList(),
            };

            //ViewData["Agents"] = new SelectList(_issuecardrepo.ListAllAgent(), "AgentId", "AgentName",0);     //Get Agent List
            model.agentcardmodel = _issuecardrepo.GetAllIssueCardsListToAgent();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int agentid)
        {
            AgentCardViewModel model = new AgentCardViewModel()
            {
                AgentList = _issuecardrepo.GetAllAgentList().ToList(),
            };
            model.agentcardmodel = _issuecardrepo.GetAllIssueCardByAgentName(agentid);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(model);
        }





        //GET: /IssueCard/Details/5

        public ActionResult Details(int id)
        {
            var model = _cardrepo.GetCardDetailsInfo(id);
            TempData["Card Rule"] = _cardrepo.GetCardRule(model.CardTypeId);
            if (model.CardStatusId == 2)
            {
                model.CardRule = _cardrepo.GetCardRule(model.CardTypeId);
                Htl_AgentCards Agent = _issuecardrepo.GetAgentInfoByCardId(id);
                TempData["AgentName"] = _issuecardrepo.GetAgentInfo(Agent.AgentId);
                TempData["Issue Date"] = Agent.IssueDate;
                TempData["Card Rule"] = _cardrepo.GetCardRule(model.CardTypeId);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("Details", model);
            }
            return View(model);
        }



        //GET: /IssueCard/Create

        public ActionResult Create()
        {

            AgentCardViewModel model = new AgentCardViewModel()
            {
                AgentList = _issuecardrepo.GetAllAgentList().ToList(),
            };
            //ViewData["Agents"] = new SelectList(_issuecardrepo.ListAllAgent(), "AgentId", "AgentName",0);
            return View(model);
        }

        //
        // POST: /IssueCard/Create

        [HttpPost]
        public ActionResult Create(AgentCardViewModel model)
        {
            var ts = (TravelSession)Session["TravelSessionInfo"];
            if (Request.IsAjaxRequest())
            {
                ///Get details Card Information /////////////
                var viewmodel = _issuecardrepo.GetCardDetailsInfo(model.HFCardId);
                ///// Save Card issue to database in table ///////
                //model.CreatedBy = ts.AppUserId;  //// Login user info
                _issuecardrepo.CreateIssueCard(model);
                ////// Hit the Card database with card status Sold 
                CardViewModel cardmodel = new CardViewModel();
                cardmodel.CardId = model.HFCardId;
                cardmodel.CardStatusId = 2;     ////// This is for sold status
                _issuecardrepo.UpdateCardToSoldStatus(cardmodel);
                cardmodel.isActive = true;
                //model to return to partial view
                return PartialView("CreatePartial", viewmodel);
            }
            else
                return RedirectToAction("Index");

        }

        //
        // GET: /IssueCard/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /IssueCard/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /IssueCard/Delete/5

        public JsonResult Delete(int id)
        {
            /////// Delete AgentCard 
            _issuecardrepo.DeleteAgentCard(id);
            ////// Hit the Card database with card status Sold 
            CardViewModel cardmodel = new CardViewModel();
            cardmodel.CardId = id;
            cardmodel.CardStatusId = 1;     ////// This is for Unsold status
            _issuecardrepo.UpdateCardToSoldStatus(cardmodel);

            JsonResult result = new JsonResult();
            result.Data = id;
            return result;

        }


        //[HttpPost]
        //public JsonResult FindCard(string searchText, int maxResult)
        //{
        //    var result = GetCard(searchText, maxResult);
        //    return Json(result);
        //}

        //public List<Htl_Cards> GetCard(string CardNumber, int maxResult)
        //{
        //    return _issuecardrepo.GetAvailableCard(CardNumber, maxResult).ToList();
        //}



    }
}
