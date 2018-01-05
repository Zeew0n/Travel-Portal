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
    public class CardRepository
    {
        EntityModel entities = new EntityModel();
        public void CreateCard(CardViewModel model)
        {
            Htl_Cards obj = new Htl_Cards
            {

                CardNumber = model.CardNumber,
                CardStatusId = model.CardStatusId,
                ValidTill = model.ValidTill ,
                CardTypeId = model.CardTypeId,
                CardValue = model.CardValue,
                isActive = model.isActive,
                CreatedBy = model.CreatedBy,
                CreatedDate  = DateTime.Now,
                CardRule =model.CardRule ,
            };

            entities.AddToHtl_Cards(obj);
            entities.SaveChanges();
        }
         public void UpdateCard(CardViewModel  modeltosave)
        {
            Htl_Cards  comm = entities.Htl_Cards.Where(u => u.CardId == modeltosave.CardId ).FirstOrDefault();
            comm.CardId =modeltosave.CardId ;
            comm.CardNumber = modeltosave.CardNumber;
            comm.CardTypeId = modeltosave.CardTypeId;
            comm.CardValue = modeltosave.CardValue;
            comm.CardRule = modeltosave.CardRule;
            comm.isActive = modeltosave.isActive;
            comm.ValidTill = modeltosave.ValidTill;
            comm.CardStatusId = 1;
            
            entities.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            entities.SaveChanges();
            /////
        }
        
        public List<CardViewModel> GetAllCardsList()
        {
            var model = (from aa in entities.Htl_Cards.Where (aa => aa.CardStatusId ==1)
                      select new CardViewModel
                      {
                          CardId = aa.CardId,
                          CardNumber = aa.CardNumber,
                          CardStatusId = aa.CardStatusId,
                          CardStatus =aa.Htl_CardStatus.CardStatusName,
                          CardValue=aa.CardValue,
                          CardType=aa.Htl_CardTypes.CardTypeName ,
                          ValidTill  = aa.ValidTill,
                      }).ToList();

            return model;

        }
        public CardViewModel GetCardDetailsInfo(int id)
        {
            var model = (from aa in entities.Htl_Cards.Where(ii => ii.CardId == id)

                         select new CardViewModel
                         {
                             CardId = aa.CardId,
                             HFCardId=aa.CardId ,
                             CardNumber = aa.CardNumber,
                             CardStatusId=aa.CardStatusId,
                             CardStatus = aa.Htl_CardStatus.CardStatusName,
                             CardValue = aa.CardValue,
                             CardTypeId=aa.CardTypeId,
                             CardType = aa.Htl_CardTypes.CardTypeName,
                             ValidTill = aa.ValidTill,
                             isActive =aa.isActive ,
                             CardRule =aa.CardRule ,
                         }).SingleOrDefault ();

            return model;

        }
        
        public List<Htl_CardStatus> GetCardStatus()
        {

            return entities.Htl_CardStatus.ToList();
        }
        public IEnumerable<SelectListItem> GetAllCardStatusList()
        {
            List<Htl_CardStatus> all = GetCardStatus().ToList();
            var GetAllCardStatusList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var temp = new SelectListItem
                {
                    Text = item.CardStatusName,
                    Value = item.CardStatusId .ToString()
                };
                GetAllCardStatusList.Add(temp);
            }
            return GetAllCardStatusList.AsEnumerable();
        }
        public List<Htl_CardTypes> GetCardType()
        {

            return entities.Htl_CardTypes.ToList();
        }
        public IEnumerable<SelectListItem> GetAllCardTypeList()
        {
            List<Htl_CardTypes> all = GetCardType().ToList();
            var GetAllCardTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var temp = new SelectListItem
                {
                    Text = item.CardTypeName,
                    Value = item.CardTypeId.ToString()
                };
                GetAllCardTypeList.Add(temp);
            }
            return GetAllCardTypeList.AsEnumerable();
        }
        public string GetCardRule(int CardTypeId)
        {
            Htl_CardTermsAndConditions ctermandcondition = entities.Htl_CardTermsAndConditions.Where(cc => cc.CardTypeId == CardTypeId).SingleOrDefault();

            return ctermandcondition.TermAndCondition;
        }
        public void DeleteCard(int CardId)
        {
            Htl_Cards comm = entities.Htl_Cards.Where(u => u.CardId == CardId).FirstOrDefault();
            Htl_Cards datatodelete = entities.Htl_Cards.FirstOrDefault(m => m.CardId == comm.CardId);
            entities.DeleteObject(datatodelete);
            entities.SaveChanges();
        }
        public bool CheckDuplicateCardNumber(string CardNumber)
        {
            Htl_Cards Cards = entities.Htl_Cards.Where(ii => ii.CardNumber == CardNumber).FirstOrDefault();
            if (Cards != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}