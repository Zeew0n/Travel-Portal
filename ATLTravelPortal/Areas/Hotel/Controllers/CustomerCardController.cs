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
using ATLTravelPortal.Repository;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
      [CheckSessionFilter(Order = 1)]
    public class CustomerCardController : Controller
    {
        EntityModel entities = new EntityModel();
        HotelCountryRepository _CountryRepo = new HotelCountryRepository();
        CustomerCardRepository _Custrepo = new CustomerCardRepository();
        IssueCardRepository _issuecardrepo = new IssueCardRepository();
        CardRepository _Cardrepo = new CardRepository();
        GeneralProvider _GenPro = new GeneralProvider();

        //
        // GET: /IssueCard/

        public ActionResult Index()
        {
            AgentCardViewModel model = new AgentCardViewModel()
            {
                AgentList = _issuecardrepo.GetAllAgentList().ToList(),
            };
           
            //ViewData["Agents"] = new SelectList(_issuecardrepo.ListAllAgent(), "AgentId", "AgentName", 0);
           
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(int agentid)
        {
            AgentCardViewModel model = new AgentCardViewModel()
            {
                AgentList = _issuecardrepo.GetAllAgentList().ToList(),

            };
                //ViewData["Agents"] = new SelectList(_issuecardrepo.ListAllAgent(), "AgentId", "AgentName", 0);


            model.agentcardmodel = _issuecardrepo.GetAllIssueCardByAgentName(agentid);
          
              
           
            return View(model);
        }
        
        //
        // GET: /CustomerCard/Details/5
            [HttpPost]
        public ActionResult Details(int[] Selectedcardnumber)
        {

            return View();
        }

        //
        // GET: /CustomerCard/Create

            public ActionResult Create(AgentCardViewModel model, string[] Selectedcardnumber, int AgentId)
        {
            List<SelectListItem> customerstatus = new List<SelectListItem>();
           
            customerstatus.Add(new SelectListItem
            {
                Text = "Active",
                Value = "T"
            });
            customerstatus.Add(new SelectListItem
            {
                Text = "InActive",
                Value = "F"
            });
            TempData["AgentName"] = _issuecardrepo.GetAgentInfo(AgentId);
           // ViewData["CustomerStatus"] = new SelectList(customerstatus, "Value", "Text",0);
            //ViewData["Agents"] = new SelectList(_issuecardrepo.ListAllAgent(), "AgentId", "AgentName", 0);
            
           // ViewData["Country"] = new SelectList(_CountryRepo.HotelCountryList(), "CountryId", "CountryName");
            //ViewData["CustomerType"] = new SelectList(_Custrepo.GetCustomerType(), "CustomerTypeId", "CustomerTypeName");
                 List<string> Selectedcardnumbers = new List<string>();
                 List<int> SelectedcardIDs = new List<int>();
                     foreach (string sid in Selectedcardnumber)
                     {
                         Selectedcardnumbers.Add(sid);
                         int cardid = _Custrepo.GetCardIdByCardNumber(sid);
                         SelectedcardIDs.Add(cardid);
                        
                     }
                    
                    
            var viewmodel = new CustomerIsssueCard
            {
                CustomerStatusList = customerstatus,
                CustomerCard = Selectedcardnumbers,
                CustomerCardId = SelectedcardIDs,
                CountryList = _CountryRepo.GetAllCountryList().ToList(),
                AgentList = _issuecardrepo.GetAllAgentList().ToList(),
                CustomerTypeList = _Custrepo.GetAllCustomerType()
               // AgentId =id
            };
           // TempData["AgentName"] = _issuecardrepo.GetAgentInfo(Agent.AgentId);
            return View(viewmodel);
          
        } 

        //
        // POST: /CustomerCard/Create

        [HttpPost]
            public ActionResult Create(CustomerIsssueCard model, List<int> CardsId)
        {
            var ts = (TravelSession)Session["TravelSessionInfo"];
            for (int i = 0; i < CardsId.Count; i++)
            { 
                model.CardId = CardsId[i];
                //model.CreatedBy = ts.AppUserId;
                model.CustomerID = model.HFCustomerID;
               
            }
            
          
                   
                 //model.CreatedBy = ts.AppUserId;
                 model.Created =DateTime .Now;
                 model.ProductId = 2;
                 //model.CustomerTypeId =1;
                 model.CustomerTpeName = _GenPro.GetCustomerType(model.CustomerTypeId);
                 model.AgentId = 2;
                 model.Gender = "male";
            
                 //long CustomerID = _Custrepo.GetCustomerID();
             

                 bool flag;
                 flag = _Custrepo.CheckDuplicateUsername(model.CustomerCode);
                 if (flag==true)
                 { //_Custrepo.UpdateCard(model);
                   long CID =  _Custrepo.CreateCard(model);
                 model.CustomerID = CID;
                   _Custrepo.CreateCards(model);
                 }
                 else
                 {
                     model.AgentId = 2;
                     model.Gender = "male";
                     model.CustomerID = _Custrepo.GetCustomerID();
                     model.ProductId = 2;
                     model.UpdatedBy = ts.AppUserId;
                     //_Custrepo.CreateCard(model);
                     _Custrepo.UpdateCard(model);
                     _Custrepo.CreateCards(model);

                 }
                 CardViewModel cardmodel = new CardViewModel();
                 cardmodel.CardId = model.CardId;
                 cardmodel.CardStatusId = 3;
                 _Custrepo.UpdateCardToActiveStatus(cardmodel);
            
            
                 //// This IS for Active Status

                

         
                
                 //if (Selectedcardnumber != null)    //////////  Checking if product is other than Ticketing
                 //{
                 //    List<int> Selectedcardnumbers = new List<int>();
                 //    foreach (int sid in Selectedcardnumber)
                 //    {
                 //        Selectedcardnumbers.Add(sid);
                 //    }

                   //  Add(Selectedcardnumbers,model.AgentId ,CustomerID);
                // }
                
                 //////////// Return view //////////////
                 //ViewData["Country"] = new SelectList(_CountryRepo.HotelCountryList(), "CountryId", "CountryName");
                 CustomerIsssueCard models = new CustomerIsssueCard()
                 {
                     
                     CountryList = _CountryRepo.GetAllCountryList().ToList(),
                 };     
            //ViewData["Agents"] = new SelectList(_issuecardrepo.ListAllAgent(), "AgentId", "AgentName", 0);
                 ViewData["success"] = "Record successfully added.";
                 return RedirectToAction ("Index",models);
            
           
        }
         //
        // GET: /CustomerCard/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CustomerCard/Edit/5

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
        // GET: /CustomerCard/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CustomerCard/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public JsonResult FindCustomerInfo(string searchText, int maxResult)
        //{
        //    var result = GetCustomerInfo(searchText, maxResult);
        //    return Json(result);
        //}

        //public List<Core_Customers> GetCustomerInfo(string CustomerCode, int maxResult)
        //{
        //    return _Custrepo.GetAddedCustomer(CustomerCode, maxResult).ToList();
        //}

        //  List  For Selelcted array of Cards
        public void Add(List<int> idlist, int agentid, long CustomerId)
        {
            try
            {
                int count = idlist.Count;
                List<CustomerIsssueCard> Lists = new List<CustomerIsssueCard>();
                for (int i = 0; i < count; i++)
                {

                    CustomerIsssueCard CustomerCardList = new CustomerIsssueCard();
                    CustomerCardList.AgentId = agentid;
                    CustomerCardList.CustomerID = CustomerId;
                    CustomerCardList.CardId = idlist[i];
                    Lists.Add(CustomerCardList);
                    
                }
                _Custrepo.SaveCustomerCard(Lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
