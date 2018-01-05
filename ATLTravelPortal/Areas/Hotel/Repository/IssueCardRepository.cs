using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ATLTravelPortal.Helpers;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Models;


namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class IssueCardRepository
    {
        EntityModel entities = new EntityModel();
        public List<Agents> ListAllAgent()
        {
            return entities.Agents.ToList();
        }
        public IEnumerable <SelectListItem> GetAllAgentList()
        {
            List<Agents> all = ListAllAgent().ToList();
            var GetAllAgentList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var temp = new SelectListItem
                {
                    Text = item.AgentName ,
                    Value = item.AgentId .ToString()
                };
                GetAllAgentList.Add(temp);
            }
            return GetAllAgentList.AsEnumerable();
        }

        public List<AgentCardViewModel> GetAllIssueCardsListToAgent()
        {
            var model = (from aa in entities.Htl_Cards.Where(ii => ii.CardStatusId==2)
                         select new AgentCardViewModel
                         {
                             HFCardId = aa.CardId,
                             CardNumber = aa.CardNumber,
                             CardValue = aa.CardValue,
                             CardType = aa.Htl_CardTypes.CardTypeName,
                             IssueDate = aa.ValidTill,
                         }).ToList();

            return model;

        }
        public List<AgentCardViewModel> GetAllIssueCardByAgentName(int Agentid)
        {
            var model = (from aa in entities.Htl_Cards
                      join bb in entities.Htl_AgentCards
                      on aa.CardId equals bb.CardId
                      where bb.AgentId == Agentid && aa.CardStatusId==2
                         select new AgentCardViewModel
                         {
                             AgentId=Agentid,
                             HFCardId = aa.CardId,
                             CardNumber = aa.CardNumber,
                             CardValue = aa.CardValue,
                             CardType = aa.Htl_CardTypes.CardTypeName,
                             IssueDate = aa.ValidTill,
                         }).ToList();

            return model;

        }
        public Htl_AgentCards GetAgentInfoByCardId(int CardId)
        {
            Htl_AgentCards AgentCard = entities.Htl_AgentCards.Where(cc => cc.CardId == CardId).SingleOrDefault();

            return AgentCard;
        }
        public string GetAgentInfo(int AgentId)
        {
            Agents Agent = entities.Agents.Where(cc => cc.AgentId == AgentId).SingleOrDefault();

            return Agent.AgentName;
        }
        public IEnumerable<Htl_Cards> GetAvailableCard(string CardNumber, int maxResult)
        {
            return entities.Htl_Cards.Where(x => ((x.CardNumber.ToLower().Contains(CardNumber) || x.CardNumber.ToUpper().Contains(CardNumber)) && (x.CardStatusId == 1) && (x.isActive == true))).Take(maxResult).ToList().Select(x =>
                                new Htl_Cards { CardNumber = x.CardNumber, CardId = x.CardId }
                );
        }
        public AgentCardViewModel GetCardDetailsInfo(int id)
        {
            var model = (from aa in entities.Htl_Cards.Where(ii => ii.CardId == id)

                         select new AgentCardViewModel
                         {
                             HFCardId=aa.CardId,
                             CardNumber = aa.CardNumber,
                             CardValue = aa.CardValue,
                             CardType = aa.Htl_CardTypes.CardTypeName,
                             ValidTill = aa.ValidTill,
                         }).SingleOrDefault();

            return model;

        }
        public void CreateIssueCard(AgentCardViewModel model)
        {
            Htl_AgentCards  obj = new Htl_AgentCards
            {
                AgentId = model.AgentId,
                CardId =model.HFCardId,
                IssueDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CreatedBy = model.CreatedBy,

            };
            entities.AddToHtl_AgentCards(obj);
            entities.SaveChanges();
        }
        public void UpdateCardToSoldStatus(CardViewModel modeltosave)
        {
            Htl_Cards comm = entities.Htl_Cards.Where(u => u.CardId == modeltosave.CardId).FirstOrDefault();
            comm.CardId = modeltosave.CardId;
            comm.CardStatusId = modeltosave.CardStatusId;
            entities.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            entities.SaveChanges();
            
        }

        public void DeleteAgentCard(int CardId)
        {
            Htl_AgentCards comm = entities.Htl_AgentCards.Where(u => u.CardId == CardId).FirstOrDefault();
            Htl_AgentCards datatodelete = entities.Htl_AgentCards.FirstOrDefault(m => m.AgentCardsId == comm.AgentCardsId);
            entities.DeleteObject(datatodelete);
            entities.SaveChanges();
        }
    }
}