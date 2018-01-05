using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;


namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class CustomerCardRepository
    {
        EntityModel entities = new EntityModel();
        public List<AgentCardViewModel> GetAllIssueCardByAgentName(int Agentid)
        {
            var model = (from aa in entities.Htl_Cards
                         join bb in entities.Htl_AgentCards
                         on aa.CardId equals bb.CardId
                         where bb.AgentId == Agentid && aa.CardStatusId == 2
                         select new AgentCardViewModel
                         {
                            
                             CardNumber = aa.CardNumber,
                             CardValue = aa.CardValue,
                             CardType = aa.Htl_CardTypes.CardTypeName,
                             IssueDate = aa.ValidTill,
                         }).ToList();

            return model;

        }
        public List<CustomerIsssueCard> GetAllCardByAgent(int Agentid)
        {
            var model = (from aa in entities.Htl_Cards
                         join bb in entities.Htl_AgentCards
                         on aa.CardId equals bb.CardId
                         where bb.AgentId == Agentid && aa.CardStatusId == 2
                         select new CustomerIsssueCard
                         {
                             AgentId = Agentid,
                             CardId = aa.CardId,
                             CardNumber = aa.CardNumber,
                             AgentName = bb.Agents.AgentName
                         }).ToList();

            return model;

        }
        public long CreateCard(CustomerIsssueCard model)
        {
            Core_Customers obj = new Core_Customers
            {
                
                ProductId = model.ProductId,
                AgentId = model.AgentId,
                CustomerCode = model.CustomerCode,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Address1 = model.Address1,
                Address2 = model.Address2,
                HouseNo = model.HouseNo,
                City = model.City,
                ZipCode = model.ZipCode,
                CountryID = model.CountryID,
                HomePhone = model.HomePhone,
                WorkPhone = model.WorkPhone,
                MobileNo = model.MobileNo,
                FaxNo = model.FaxNo,
                Email = model.Email,
                Profession = model.Profession,
                CustomerTypeId = model.CustomerTypeId,

                CustomerStatus = model.CustomerStatus,
                //Created = model.Created,
                //CreatedBy = model.CreatedBy,


            };

            entities.AddToCore_Customers(obj);
            entities.SaveChanges();
            return entities.Core_Customers.Max(x => x.CustomerID);
        }

        public void UpdateCard(CustomerIsssueCard model)
        {
            Core_Customers comm = entities.Core_Customers.Where(u => u.CustomerID == model.CustomerID).FirstOrDefault();

            comm.ProductId = model.ProductId;
            comm.AgentId = model.AgentId;
            comm.CustomerCode = model.CustomerCode;
            comm.FirstName = model.FirstName;
            comm.MiddleName = model.MiddleName;
            comm.LastName = model.LastName;
            comm.Gender = model.Gender;
            comm.DateOfBirth = model.DateOfBirth;
            comm.Address1 = model.Address1;
            comm.Address2 = model.Address2;
            comm.HouseNo = model.HouseNo;
            comm.City = model.City;
            comm.ZipCode = model.ZipCode;
            comm.CountryID = model.CountryID;
            comm.HomePhone = model.HomePhone;
            comm.WorkPhone = model.WorkPhone;
            comm.MobileNo = model.MobileNo;
            comm.FaxNo = model.FaxNo;
            comm.Email = model.Email;
            comm.Profession = model.Profession;
            comm.CustomerTypeId = model.CustomerTypeId;
            comm.CustomerStatus = model.CustomerStatus;
            comm.Created = DateTime.Now;
            comm.CreatedBy = model.CreatedBy;
            comm.Updated = DateTime.Now;
            comm.UpdatedBy = model.UpdatedBy;

            entities.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            entities.SaveChanges();
            /////
        }


        public void SaveCustomerCard(List<CustomerIsssueCard> obj)
        {
            foreach (var item in obj)
            {
                entities.Htl_CustomerCards.AddObject(new Htl_CustomerCards()
                {
                    AgentId = item.AgentId,
                    CardId = item.CardId,
                    CustomerId = Convert.ToInt32(item.CustomerID),
                    IssueDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    
                });
            }
            entities.SaveChanges();
        }

        public IEnumerable<Htl_Cards> GetAvailableCard(string CardNumber, int Agentid, int maxResult)
        {
            return GetAllCardByAgent(Agentid).Where(x => ((x.CardNumber.ToLower().Contains(CardNumber) || x.CardNumber.ToUpper().Contains(CardNumber)) && (x.AgentId == Agentid))).Take(maxResult).ToList().Select(x =>
                                new Htl_Cards { CardNumber = x.CardNumber, CardId = x.CardId }
                );
        }
        public IEnumerable<Core_Customers> GetAddedCustomer(string CustomerName, int maxResult)
        {
            return entities.Core_Customers.Where(x => ((x.FirstName.ToLower().Contains(CustomerName) || x.FirstName.ToUpper().Contains(CustomerName)) && (x.ProductId == 2)/* && (x.isActive == true)*/)).Take(maxResult).ToList().Select(x =>
             new Core_Customers
             {
                
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

        public long GetCustomerID()
        {
            long id = entities.Core_Customers.Max(x => x.CustomerID);
            return id;
        }
        public void UpdateCardToActiveStatus(CardViewModel modeltosave)
        {
            Htl_Cards comm = entities.Htl_Cards.Where(u => u.CardId == modeltosave.CardId).FirstOrDefault();
            comm.CardId = modeltosave.CardId;
            comm.CardStatusId = modeltosave.CardStatusId;
            entities.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            entities.SaveChanges();
            
        }
        public bool CheckDuplicateUsername(string CustomerCode)
        {
            Core_Customers Customers = entities.Core_Customers.Where(ii => ii.CustomerCode == CustomerCode).FirstOrDefault();
            if (Customers != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public IEnumerable<Core_CustomerTypes> GetCustomerType()
        {
            return entities.Core_CustomerTypes.AsEnumerable(); 
        }

        public IEnumerable<SelectListItem> GetAllCustomerType()
        {
            IEnumerable<Core_CustomerTypes> all = GetCustomerType().ToList();
            var GetAllCustomerType = new List<SelectListItem>();
            foreach (var item in all)
            {
                var temp = new SelectListItem
                {
                    Text = item.CustomerTypeName ,
                    Value = item.CustomerTypeId.ToString()
                };
                GetAllCustomerType.Add(temp);
            }
            return GetAllCustomerType.AsEnumerable();
        }
        public void CreateCards(CustomerIsssueCard model)
        {
            Htl_CustomerCards obj = new Htl_CustomerCards
            {

                //CardId = model.CustomerCardId.ElementAt(0),
                CardId = model.CardId,
                AgentId = model.AgentId,
                CustomerId = Convert.ToInt16(model.CustomerID),
                CreateDate = DateTime.Now,
                CreatedBy = model.CreatedBy,


            };

            entities.AddToHtl_CustomerCards(obj);
            entities.SaveChanges();
           
        }
        public void UpdateCards(CustomerIsssueCard model)
        {
            Htl_CustomerCards comm = entities.Htl_CustomerCards.Where(u => u.CustomerCardsId  == model.CustomerCardsId).FirstOrDefault();
        

                comm.CardId = model.CardId;
                comm.AgentId = model.AgentId;
                comm.CustomerId = Convert.ToInt16(model.CustomerID);
                comm.CreateDate = model.Created;
                comm.CreatedBy = model.CreatedBy;
                comm.UpdatedBy =model.UpdatedBy ;
                comm.UpdatedDate =model.Updated ;
            entities.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            entities.SaveChanges();

        }
        public int GetCardIdByCardNumber(string CardNumber)
        {
             Htl_Cards comm = entities.Htl_Cards.Where(u => u.CardNumber  == CardNumber).FirstOrDefault();
             return comm.CardId;

        }

    }
}