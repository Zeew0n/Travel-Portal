using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using System.Web.Mvc;
using System.Web.Configuration;
using System.IO;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class IssueDomesticTicketsProvider
    {
        EntityModel entity = new EntityModel();
        public IssueDomesticTicketsModel GetIssueDomesticTickets(Int64? mPnrId, bool doOnlyUploadETicket)
        {
            IssueDomesticTicketsModel viewModel = new IssueDomesticTicketsModel();
            var masterPNRs = entity.TBO_MasterPNRs.Where(m => m.MPNRId == mPnrId).FirstOrDefault();
            var queryResult = entity.TBO_PNRs.Where(m => m.MPNRId == mPnrId);
            viewModel.MPNRId = mPnrId;
            Agents agent = GetAgentsByAgentId(masterPNRs.AgentId);
            viewModel.AgentId = agent.AgentId;
            viewModel.AgentName = agent.AgentName;
            viewModel.Phone = agent.Phone;

            viewModel.DoOnlyUploadETicket = doOnlyUploadETicket;

            List<DomesticPnrs> DomesticPnrsList = new List<DomesticPnrs>();
            if (queryResult != null)
            {
                foreach (var query in queryResult)
                {
                    DomesticPnrs pnr = new DomesticPnrs();
                    pnr.PnrId = query.PNRId;
                    pnr.PNR = query.RecLoc;
                    pnr.PassengersList = GetPassengersByPnrId(query.PNRId);
                    pnr.ItinaryList = GetItinaryByPnrId(query.PNRId);
                    DomesticPnrsList.Add(pnr);
                }
            }
            viewModel.DomesticPnrsList = DomesticPnrsList;
            return viewModel;
        }

        public IList<DomesticPassenger> GetPassengersByPnrId(Int64? pnrId)
        {
            List<DomesticPassenger> domesticPassengers = new List<DomesticPassenger>();
            var passengers = entity.TBO_Passengers.Where(m => m.PNRId == pnrId);

            foreach (var pax in passengers)
            {
                DomesticPassenger pass = new DomesticPassenger();

                pass.PassengerId = pax.PassengerId;
                pass.Name = pax.FirstName + " " + (!string.IsNullOrWhiteSpace(pax.MiddleName) ? pax.MiddleName + " " : "") + pax.LastName;
                if (pax.PassengerTypeId == 1)
                    pass.PassengerType = "Adult";
                else if (pax.PassengerTypeId == 2)
                    pass.PassengerType = "Child";
                else if (pax.PassengerTypeId == 3)
                    pass.PassengerType = "Infant";

                pass.EmailAddress = pax.Email;
                pass.isDeleted = pax.IsDeleted;

                var tickets = pax.TBO_PNRTickets.Where(m => m.PNRId == pnrId);

                List<DomesticFare> fareList = new List<DomesticFare>();
                foreach (var ticket in tickets)
                {
                    DomesticFare fare = new DomesticFare()
                    {
                        TicketId = ticket.TicketId,
                        TicketNumber = ticket.TicketNumber,
                        AdditionalTxnFee = ticket.AdditionalTxnFee,
                        AirlineTransFee = ticket.AirlineTransFee,
                        Tax = ticket.Tax,
                        OtherCharges = ticket.OtherCharges,
                        ServiceTax = ticket.ServiceTax,
                        MarkupAmount = ticket.MarkupAmount,
                        CommissionAmount = ticket.CommissionAmount,
                        DiscountAmount = ticket.DiscountAmount,
                        ServiceCharge = ticket.ServiceCharge,
                        FSC = ticket.FSC,
                        SellingAdditionalTxnFee = ticket.SellingAdditionalTxnFee,
                        SellingAirlineTransFee = ticket.SellingAirlineTransFee,
                        SellingBaseFare = ticket.SellingBaseFare-ticket.MarkupAmount,
                        SellingTax = ticket.SellingTax,
                        SellingOtherCharges = ticket.SellingOtherCharges,
                        SellingServiceTax = ticket.SellingServiceTax,
                        SellingFSC = ticket.SellingFSC,
                        Currency = ticket.Currency,
                        isDeleted = false
                    };

                    fareList.Add(fare);
                }
                pass.FareList = fareList;
                domesticPassengers.Add(pass);
            }
            return domesticPassengers;
        }

        public IList<DomesticItinary> GetItinaryByPnrId(Int64? pnrId)
        {
            MasterDealProvider mDealProvider = new MasterDealProvider();
            List<DomesticItinary> domesticItinary = new List<DomesticItinary>();
            var pnrSegments = entity.TBO_PNRsegments.Where(m => m.PNRId == pnrId);

            foreach (var segment in pnrSegments)
            {
                DomesticItinary itinary = new DomesticItinary();

                itinary.SegmentId = segment.SegmentId;

                itinary.AirlineId = segment.AirlineId;
                itinary.AirlineCode = segment.Airlines != null ? segment.Airlines.AirlineCode : null;
                itinary.AirlineName = segment.Airlines != null ? segment.Airlines.AirlineName : null;
                itinary.AirlineNameList = new SelectList(AirlineNameList(), "AirlineId", "AirlineName", segment.AirlineId);

                itinary.DepartureCityId = segment.DepartCityId;
                itinary.From = segment.AirlineCities.CityName + "(" + segment.AirlineCities.CityCode + ")";

                itinary.ArrivalCityId = segment.ArrivalCityId;
                itinary.To = segment.AirlineCities1.CityName + "(" + segment.AirlineCities1.CityCode + ")";

                itinary.DepartureDate = segment.DepartDate.Date.Add(segment.DepartTime);
                itinary.DepartureTime = segment.DepartTime;
                itinary.ArrivalDate = segment.ArrivalDate.Date.Add(segment.ArrivalTime);
                itinary.ArrivalTime = segment.ArrivalTime;
                itinary.BIC = segment.BIC;
                domesticItinary.Add(itinary);
            }
            return domesticItinary;
        }

        public Agents GetAgentsByAgentId(Int64 agentId)
        {
            return entity.Agents.Where(m => m.AgentId == agentId).FirstOrDefault();
        }

        public IList<Airlines> AirlineNameList()
        {           
            return entity.Airlines.Where(x=>x.AirlineTypeId==2 && x.isActive==true).OrderBy(xx => xx.AirlineId).ToList();
        }

        public string GetLocationToSaveFile()
        {
            return WebConfigurationManager.AppSettings["OfflineTicketsPath"];
        }

        public bool UploadFile(HttpPostedFileBase eTicket, Int64? mPnrId)
        {
            HttpPostedFileBase eTicketFile = eTicket;
            bool isSaved = false;

            if (eTicketFile != null)
            {
                switch (eTicketFile.ContentType)
                {
                    case "application/zip":
                    case "application/x-zip-compressed":
                        string photoLocation = GetLocationToSaveFile();

                        if (!Directory.Exists(photoLocation))
                            Directory.CreateDirectory(photoLocation);

                        string photoDirectory = photoLocation + "/" + mPnrId;
                        if (!Directory.Exists(photoDirectory))
                            Directory.CreateDirectory(photoDirectory);


                        string strTimeStamp = DateTime.Now.ToString();
                        strTimeStamp = strTimeStamp.Replace("/", "-");
                        strTimeStamp = strTimeStamp.Replace(" ", "-");
                        strTimeStamp = strTimeStamp.Replace(":", "-");



                        string filename = strTimeStamp + "_" + eTicketFile.FileName;
                        eTicketFile.SaveAs(photoDirectory + "/" + filename);
                        isSaved = true;
                        break;
                }
            }
            return isSaved;
        }

        public bool Update(IssueDomesticTicketsModel model)
        {
            if (!model.DoOnlyUploadETicket)
            {
                if (model != null)
                    UpdatePnrs(model);
                entity.SaveChanges();
                UploadFile(model.eTicket, model.MPNRId);
            //Call Air_Issue SP
            var obj = SessionStore.GetTravelSession();
            new PNRInfoProvider().TBO_Air_IssueTickets(model.MPNRId ?? 0, obj.AppUserId);
            }
            else if (model.DoOnlyUploadETicket)
            {
                UploadFile(model.eTicket, model.MPNRId);
            }
            return true;
        }

        public void UpdateItinary(IList<DomesticItinary> itinaryList)
        {

            var obj = SessionStore.GetTravelSession();

            foreach (var itinary in itinaryList)
            {
                TBO_PNRsegments objToUpdate = new TBO_PNRsegments();
                objToUpdate = entity.TBO_PNRsegments.Where(m => m.SegmentId == itinary.SegmentId).FirstOrDefault();

                objToUpdate.AirlineId = itinary.AirlineId;
                objToUpdate.BIC = itinary.BIC;

                objToUpdate.DepartDate = itinary.DepartureDate.Date;
                objToUpdate.DepartTime = itinary.DepartureDate.TimeOfDay;

                objToUpdate.ArrivalDate = itinary.ArrivalDate.Date;
                objToUpdate.ArrivalTime = itinary.ArrivalDate.TimeOfDay;

                objToUpdate.UpdatedBy = obj.AppUserId;
                objToUpdate.UpdatedDate = DateTime.UtcNow;

                entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            }
        }

        public void UpdatePassengers(IList<DomesticPassenger> passengersList)
        {
            var obj = SessionStore.GetTravelSession();
            foreach (var pax in passengersList)
            {
                UpdateTBO_PnrTickets(pax.FareList, pax.PassengerId);
            }
        }

        public void UpdateTBO_PnrTickets(IList<DomesticFare> fareList, Int64 passengerId)
        {
            var obj = SessionStore.GetTravelSession();

            foreach (var fare in fareList)
            {
                TBO_PNRTickets objToUpdate = new TBO_PNRTickets();
                objToUpdate = entity.TBO_PNRTickets.Where(m => m.PassengerId == passengerId).FirstOrDefault();

                objToUpdate.BaseFare = fare.SellingBaseFare;
                objToUpdate.Tax = fare.SellingTax;
                objToUpdate.TicketNumber = fare.TicketNumber;
                //objToUpdate.OtherCharges = fare.OtherCharges;
                //objToUpdate.ServiceTax = fare.ServiceTax;
                objToUpdate.MarkupAmount = fare.MarkupAmount;
                objToUpdate.CommissionAmount = fare.CommissionAmount;
                objToUpdate.DiscountAmount = fare.DiscountAmount;
                //objToUpdate.ServiceCharge = fare.ServiceCharge;

                objToUpdate.FSC = fare.SellingFSC;

                // objToUpdate.SellingAdditionalTxnFee = fare.SellingAdditionalTxnFee;
                // objToUpdate.SellingAirlineTransFee = fare.SellingAirlineTransFee;
                objToUpdate.SellingBaseFare = fare.SellingBaseFare+fare.MarkupAmount;
                objToUpdate.SellingTax = fare.SellingTax;
                // objToUpdate.SellingOtherCharges = fare.SellingOtherCharges;
                // objToUpdate.SellingServiceTax = fare.SellingServiceTax;
                objToUpdate.SellingFSC = fare.SellingFSC;

                objToUpdate.UpdatedBy = obj.AppUserId;
                objToUpdate.UpdatedDate = DateTime.UtcNow;
                entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            }
        }

        public void UpdatePnrs(IssueDomesticTicketsModel model)
        {

            var obj = SessionStore.GetTravelSession();

            foreach (var p in model.DomesticPnrsList)
            {
                TBO_PNRs objToUpdate = new TBO_PNRs();
                objToUpdate = entity.TBO_PNRs.Where(m => m.PNRId == p.PnrId).FirstOrDefault();

                objToUpdate.RecLoc = p.PNR;

                objToUpdate.UpdatedBy = obj.AppUserId;
                objToUpdate.UpdatedDate = DateTime.UtcNow;

                entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);

                if (p.ItinaryList != null)
                    UpdateItinary(p.ItinaryList);

                if (p.PassengersList != null)
                    UpdatePassengers(p.PassengersList);
            }
        }

        public void DeletePassenger(Int64? passengerId, string mode)
        {
            var obj = SessionStore.GetTravelSession();

            TBO_Passengers objToUpdate = new TBO_Passengers();
            objToUpdate = entity.TBO_Passengers.Where(m => m.PassengerId == passengerId).FirstOrDefault();

            if (mode == "remove")
                objToUpdate.IsDeleted = true;
            else if (mode == "include")
                objToUpdate.IsDeleted = false;

            objToUpdate.UpdatedBy = obj.AppUserId;
            objToUpdate.UpdatedDate = DateTime.UtcNow;

            entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            entity.SaveChanges();
        }

        public void CancelPNR(Int64? mPnrId)
        {
            var obj = SessionStore.GetTravelSession();
            TBO_MasterPNRs objToUpdate = new TBO_MasterPNRs();
            objToUpdate = entity.TBO_MasterPNRs.Where(m => m.MPNRId == mPnrId).FirstOrDefault();
            objToUpdate.TicketStatusId = 2;            
            objToUpdate.UpdatedBy = obj.AppUserId;
            objToUpdate.UpdatedDate = DateTime.UtcNow;
            entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            entity.SaveChanges();
        }
    }
}