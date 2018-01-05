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
    public class SearchCardRepository
    {
        EntityModel entities = new EntityModel();
        public CardViewModel SearchCard(int id)
        {
            var model = (from aa in entities.Htl_Cards.Where(ii => ii.CardId == id)

                         select new CardViewModel
                         {
                             HFCardId = aa.CardId,
                             CardId = aa.CardId ,
                             CardNumber = aa.CardNumber,
                             CardStatusId = aa.CardStatusId,
                             CardStatus = aa.Htl_CardStatus.CardStatusName,
                             CardValue = aa.CardValue,
                             CardTypeId = aa.CardTypeId,
                             CardType = aa.Htl_CardTypes.CardTypeName,
                             ValidTill = aa.ValidTill,
                            
                         }).SingleOrDefault();

            return model;

        }


        public void CreateIssueCard(CardViewModel model)
        {
            Htl_Cards obj = new Htl_Cards
            {

                CardId = model.HFCardId,

                CardStatusId = model.CardStatusId,
                UpdatedBy = model.UpdatedBy,
                UpdatedDate = model.UpdatedDate,
            };
            entities.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
            entities.SaveChanges();
        }

        public void UpdateCardStatus(CardViewModel modeltosave)
        {
             Htl_Cards  comm = entities.Htl_Cards.Where(u => u.CardId == modeltosave.HFCardId ).FirstOrDefault();
            comm.CardId  =modeltosave.HFCardId ;
            comm.CardNumber = modeltosave.CardNumber;
            comm.CardTypeId = modeltosave.CardTypeId;
            comm.CardValue = modeltosave.CardValue;
         
            comm.isActive = modeltosave.isActive;
            comm.ValidTill = modeltosave.ValidTill;
            comm.CardStatusId = modeltosave.CardStatusId;
            
            entities.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            entities.SaveChanges();
            /////
        }
            

        public CardViewModel GetAgentInfoByCardId(int CardId)
        {
            Htl_AgentCards AgentCard = entities.Htl_AgentCards.Where(cc => cc.CardId == CardId).SingleOrDefault();
            CardViewModel model = new CardViewModel();
            model.Agentviewmodel.First().AgentId = AgentCard.AgentId;
           
            return model;
        }

        public IEnumerable<Core_Customers> GetAddedCustomer(string CustomerName)
        {
            return entities.Core_Customers.Where(x => ((x.FirstName.ToLower().Contains(CustomerName) || x.FirstName.ToUpper().Contains(CustomerName)) && (x.ProductId == 2)/* && (x.isActive == true)*/)).ToList().Select(x =>
             new Core_Customers
             {
                 CustomerID = x.CustomerID,
                 CustomerCode = x.CustomerCode,
                 FirstName = x.FirstName,
                 MiddleName = x.MiddleName,
                 LastName = x.LastName,
                 Gender = x.Gender,
                 DateOfBirth = x.DateOfBirth,
                 Address1 = x.Address1,
                 Address2 = x.Address2,
                 HouseNo = x.HouseNo,
                 City = x.City,
                 ZipCode = x.ZipCode,
                 CountryID = x.CountryID,
                 HomePhone = x.HomePhone,
                 WorkPhone = x.WorkPhone,
                 MobileNo = x.MobileNo,
                 FaxNo = x.FaxNo,
                 Email = x.Email,
                 Profession = x.Profession
             }
                );
        }
        public IEnumerable<Htl_Cards> GetAvailableCard(string CardNumber)
        {
            return entities.Htl_Cards.Where(x => ((x.CardNumber.ToLower().Contains(CardNumber) || x.CardNumber.ToUpper().Contains(CardNumber)) && (x.CardStatusId != 1) )).ToList().Select(x =>
                                new Htl_Cards { CardNumber = x.CardNumber, CardId = x.CardId }
                );
        }
    }
}
