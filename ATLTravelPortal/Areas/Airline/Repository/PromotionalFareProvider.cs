using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using System.Web.Mvc;
using System.Data.Objects.DataClasses;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PromotionalFareProvider
    {
        EntityModel entity = new EntityModel();
        public bool Update(IssueDomesticTicketsModel model)
        {
            if (model != null)
                UpdatePnrs(model);
            entity.SaveChanges();

            //Call Air_Issue SP
            var obj = SessionStore.GetTravelSession();
            new PNRInfoProvider().TBO_Air_IssueTickets(model.MPNRId ?? 0, obj.AppUserId);

            return true;
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

                //if (p.ItinaryList != null)
                //    UpdateItinary(p.ItinaryList);

                if (p.PassengersList != null)
                    UpdatePassengers(p.PassengersList);
            }
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

                //objToUpdate.BaseFare = fare.SellingBaseFare;
                // objToUpdate.Tax = fare.SellingTax;
                objToUpdate.TicketNumber = fare.TicketNumber;
                //objToUpdate.OtherCharges = fare.OtherCharges;
                //objToUpdate.ServiceTax = fare.ServiceTax;
                // objToUpdate.MarkupAmount = fare.MarkupAmount;
                // objToUpdate.CommissionAmount = fare.CommissionAmount;
                // objToUpdate.DiscountAmount = fare.DiscountAmount;
                //objToUpdate.ServiceCharge = fare.ServiceCharge;

                // objToUpdate.FSC = fare.SellingFSC;

                // objToUpdate.SellingAdditionalTxnFee = fare.SellingAdditionalTxnFee;
                // objToUpdate.SellingAirlineTransFee = fare.SellingAirlineTransFee;
                // objToUpdate.SellingBaseFare = fare.SellingBaseFare + fare.MarkupAmount;
                //  objToUpdate.SellingTax = fare.SellingTax;
                // objToUpdate.SellingOtherCharges = fare.SellingOtherCharges;
                // objToUpdate.SellingServiceTax = fare.SellingServiceTax;
                //  objToUpdate.SellingFSC = fare.SellingFSC;

                objToUpdate.UpdatedBy = obj.AppUserId;
                objToUpdate.UpdatedDate = DateTime.UtcNow;
                entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            }
        }

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

        public Agents GetAgentsByAgentId(Int64 agentId)
        {
            return entity.Agents.Where(m => m.AgentId == agentId).FirstOrDefault();
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
                        FSC = ticket.FSC + ticket.SellingAdditionalTxnFee,//TODO::
                        SellingAdditionalTxnFee = ticket.SellingAdditionalTxnFee,
                        SellingAirlineTransFee = ticket.SellingAirlineTransFee,
                        SellingBaseFare = ticket.SellingBaseFare - ticket.MarkupAmount,
                        SellingTax = ticket.SellingTax,
                        SellingOtherCharges = ticket.SellingOtherCharges,
                        SellingServiceTax = ticket.SellingServiceTax,
                        SellingFSC = ticket.SellingFSC + ticket.SellingAdditionalTxnFee,//TODO::
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

        public IList<Airlines> AirlineNameList()
        {
            return entity.Airlines.Where(x => x.AirlineTypeId == 2 && x.isActive == true).OrderBy(xx => xx.AirlineId).ToList();
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


        public List<UnIssuedDomesticTicketModel> ListUnIssuedPromotionalFareTicket()
        {
            var data = entity.Air_GetUnIssuedPromotionalFareTickets(null);

            List<UnIssuedDomesticTicketModel> model = new List<UnIssuedDomesticTicketModel>();

            foreach (var item in data.Select(x => x))
            {
                var UnIssuedDomesticTicketModel = new UnIssuedDomesticTicketModel
                {
                    PNRID = item.PNRId,
                    Passenger = item.Passenger,
                    AirlineCode = item.AirlineCode,
                    Sector = item.Sector,
                    TicketStatusName = item.ticketStatusName,
                    BookedBy = item.BookedBy,
                    BookedDate = item.BookedDate,
                    AgentName = item.AgentName
                };
                model.Add(UnIssuedDomesticTicketModel);

            }
            return model.OrderByDescending(x => x.BookedDate).ToList();
        }



        //for pagination//
        public IQueryable<UnIssuedDomesticTicketModel> GetUnIssuedPromotionalFareTicketByPagination(UnIssuedDomesticTicketModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.UsIssuedDomesticTicketList.Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<UnIssuedDomesticTicketModel> pagingdata = m.UsIssuedDomesticTicketList.OrderByDescending(x => x.BookedDate).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();

        }

        //****************************************************************************************************************************************************************************************//


        public List<PromotionalFareSector> GetPromotionalFareSegment()
        {
            var Data = entity.Air_PromotionalFares.OrderByDescending(x => x.PromotionalFareId);
            List<PromotionalFareSector> collection = new List<PromotionalFareSector>();


            foreach (var item in Data)
            {

                PromotionalFareSector single = new PromotionalFareSector()
                {
                    PromotionalFareId = item.PromotionalFareId,
                    BaseFare = item.BaseFare,
                    FareRule = item.FareRules,
                    EffectiveFrom = item.EffectiveFrom,
                    ExpireOn = item.ExpireOn,
                    Status = item.isActive,
                    TotalSeatQuota = item.Qutota,
                    Note = item.Notes,
                    PromotionalFareSegment = GetPromotionalFareSegmentList(item.PromotionalFareId),
                    Taxes = GetPromotionalFareTaxesList(item.PromotionalFareId),

                };
                collection.Add(single);


            }
            return collection;
        }


        public List<PromotionalFareSegment> GetPromotionalFareSegmentList(long PromotionalFareId)
        {
            var Data = entity.Air_PromotionalFareSegments.Where(x => x.PromotionalFareId == PromotionalFareId);
            List<PromotionalFareSegment> Collection = new List<PromotionalFareSegment>();

            foreach (var item in Data)
            {
                PromotionalFareSegment single = new PromotionalFareSegment()
                {
                    PromotionalFareSegmentId = item.PromotionalFareSegmentId,
                    FromCityId = item.FromCityId,
                    FromCity = item.AirlineCities1.CityCode,
                    ToCityId = item.ToCityId,
                    ToCity = item.AirlineCities.CityCode,
                    AirlineId = item.AirlineId,
                    AirlineCode = item.Airlines.AirlineCode,
                    Class = item.Class,
                    DepartureTime = item.DepartureTime,
                    ArrivalTime = item.ArrivalTime,
                    FlightNo = item.FlightNo,
                    FromCityList = new SelectList(GetAllCityList(), "CityID", "CityCode", item.FromCityId),
                    ToCityList = new SelectList(GetAllCityList(), "CityID", "CityCode", item.ToCityId),
                    AirlineList = new SelectList(GetAllAirlineList(), "AirlineId", "AirlineCode", item.AirlineId)

                };

                Collection.Add(single);

            }

            return Collection;
        }

        public List<PromotionalFareTaxes> GetPromotionalFareTaxesList(long PromotionalFareId)
        {
            var Data = entity.Air_PromotionalFareTaxes.Where(x => x.PromotionalFareId == PromotionalFareId);
            List<PromotionalFareTaxes> Collection = new List<PromotionalFareTaxes>();

            foreach (var item in Data)
            {
                PromotionalFareTaxes single = new PromotionalFareTaxes()
                {
                    PromotionalFareTaxId = item.PromotionalFareTaxId,
                    TaxName = item.TaxName,
                    TaxAmount = item.TaxAmount


                };
                Collection.Add(single);
            }
            return Collection;
        }




        public PromotionalFareModel GetPromotionalFareCreateModel()
        {
            GeneralProvider generalProvider = new GeneralProvider();

            PromotionalFareModel model = new PromotionalFareModel();

            PromotionalFareSector promotionalFareSector = new PromotionalFareSector();
            List<PromotionalFareSegment> segments = new List<PromotionalFareSegment>();
            PromotionalFareSegment segment = new PromotionalFareSegment();
            var cities = generalProvider.GetAirlineCityList();

            segment.FromCityList = cities;
            segment.ToCityList = cities;
            segments.Add(segment);
            promotionalFareSector.PromotionalFareSegment = segments;

            //promotionalFareSector.CityList = generalProvider.GetAirlineCityList();
            promotionalFareSector.AirlinesList = generalProvider.GetInternationAirlinesList(1);
            var Airlines = generalProvider.GetInternationAirlinesList(1);
            segment.AirlineList = Airlines;
            promotionalFareSector.CurrencyList = generalProvider.GetCurrencyList();
            model.PromotionalFareSector = promotionalFareSector;

            return model;
        }

        //***************************************************************************************************Save Part*************************************************************//
        public void Save(PromotionalFareModel model)
        {

            Air_PromotionalFares ObjToSave = new Air_PromotionalFares()
            {

                CurrencyId = model.PromotionalFareSector.CurrencyId,
                BaseFare = Convert.ToDouble(model.PromotionalFareSector.BaseFare),
                FareRules = model.PromotionalFareSector.FareRule != null ? model.PromotionalFareSector.FareRule : string.Empty,
                isActive = model.PromotionalFareSector.Status,
                EffectiveFrom = model.PromotionalFareSector.EffectiveFrom.Value,
                ExpireOn = model.PromotionalFareSector.ExpireOn.Value,
                CreatedBy = model.PromotionalFareSector.CreatedBy,
                Notes = model.PromotionalFareSector.Note,
                Qutota = model.PromotionalFareSector.TotalSeatQuota,
                CreatedDate = DateTime.UtcNow,
                Air_PromotionalFareSegments = SaveSegments(model),
                Air_PromotionalFareTaxes = SaveTax(model)


            };
            entity.AddToAir_PromotionalFares(ObjToSave);
            entity.SaveChanges();

        }


        public EntityCollection<Air_PromotionalFareSegments> SaveSegments(PromotionalFareModel model)
        {
            EntityCollection<Air_PromotionalFareSegments> segment = new EntityCollection<Air_PromotionalFareSegments>();
            List<Air_PromotionalFareSegments> collection = new List<Air_PromotionalFareSegments>();

            foreach (var item in model.PromotionalFareSector.PromotionalFareSegment)
            {
                Air_PromotionalFareSegments single = new Air_PromotionalFareSegments()
                {
                    PromotionalFareId = item.PromotionalFareId,
                    ToCityId = item.ToCityId,
                    FromCityId = item.FromCityId,
                    AirlineId = item.AirlineId,
                    Class = item.Class,
                    DepartureTime = item.DepartureTime,
                    ArrivalTime = item.ArrivalTime,
                    FlightNo = item.FlightNo
                };
                collection.Add(single);
                segment.Add(single);
            }

            return segment;
        }
        public EntityCollection<Air_PromotionalFareTaxes> SaveTax(PromotionalFareModel model)
        {
            EntityCollection<Air_PromotionalFareTaxes> segment = new EntityCollection<Air_PromotionalFareTaxes>();
            //List<Air_PromotionalFareSegments> collection = new List<Air_PromotionalFareSegments>();

            foreach (var item in model.PromotionalFareSector.Taxes)
            {
                Air_PromotionalFareTaxes single = new Air_PromotionalFareTaxes()
                {
                    PromotionalFareId = item.PromotionalFareId,
                    TaxName = item.TaxName,
                    TaxAmount = item.TaxAmount

                };

                segment.Add(single);
            }

            return segment;
        }



        //*-******************************************************************************Edit Part***************************************************************************//


        public PromotionalFareModel GetPromotionalFareSegmentEdit(long id)
        {
            var Data = entity.Air_PromotionalFares.Where(x => x.PromotionalFareId == id).FirstOrDefault();
            PromotionalFareModel model = new PromotionalFareModel();

            PromotionalFareSector single = new PromotionalFareSector()
                  {
                      PromotionalFareId = Data.PromotionalFareId,
                      BaseFare = Data.BaseFare,
                      FareRule = Data.FareRules != null ? Data.FareRules : string.Empty,
                      EffectiveFrom = Data.EffectiveFrom.Date,
                      ExpireOn = Data.ExpireOn.Date,
                      Status = Data.isActive,
                      TotalSeatQuota = Data.Qutota,
                      Note = Data.Notes,
                      PromotionalFareSegment = GetPromotionalFareSegmentList(id),
                      Taxes = GetPromotionalFareTaxesList(id),
                      Currency = Data.Currencies.CurrencyCode,
                      CurrencyId = Data.CurrencyId,
                      CurrencyList = new SelectList(GetAllCurrencyList(), "CurrencyId", "CurrencyCode", Data.CurrencyId)


                  };



            model.PromotionalFareSector = single;
            return model;
        }


        public IList<AirlineCities> GetAllCityList()
        {
            var Data = entity.AirlineCities.OrderBy(x => x.CityID).ToList();

            return Data;
        }

        public IList<Currencies> GetAllCurrencyList()
        {
            var Data = entity.Currencies.Where(x => x.CurrencyId == 1 || x.CurrencyId == 2).ToList();


            return Data;

        }
        public IList<Airlines> GetAllAirlineList()
        {
            var Data = entity.Airlines.OrderBy(x => x.AirlineId).ToList();
            return Data;

        }



        public IEnumerable<SelectListItem> GetAirlineList()
        {
            var Data = entity.Airlines.OrderBy(x => x.AirlineId);

            List<SelectListItem> CollectionofAirline = new List<SelectListItem>();

            foreach (var item in Data)
            {
                SelectListItem single = new SelectListItem()
                {
                    Value = item.AirlineId.ToString(),
                    Text = item.AirlineCode
                };
                CollectionofAirline.Add(single);
            }

            return CollectionofAirline;

        }


        public bool UpdatePromotionalFareSegment(PromotionalFareModel model)
        {
            var Data = entity.Air_PromotionalFares.Where(x => x.PromotionalFareId == model.PromotionalFareSector.PromotionalFareId).FirstOrDefault();
            Data.CurrencyId = model.PromotionalFareSector.CurrencyId;
            Data.BaseFare = model.PromotionalFareSector.BaseFare ?? 0;
            Data.FareRules = model.PromotionalFareSector.FareRule != null ? model.PromotionalFareSector.FareRule : string.Empty;
            Data.isActive = model.PromotionalFareSector.Status;
            Data.EffectiveFrom = model.PromotionalFareSector.EffectiveFrom.Value;
            Data.ExpireOn = model.PromotionalFareSector.ExpireOn.Value;
            Data.UpdatedBy = model.PromotionalFareSector.CreatedBy;
            Data.Notes = model.PromotionalFareSector.Note;
            Data.Qutota = model.PromotionalFareSector.TotalSeatQuota;
            Data.UpdatedDate = DateTime.Now;
            int i = 0;
            foreach (var item in Data.Air_PromotionalFareSegments)
            {
                item.FromCityId = model.PromotionalFareSector.PromotionalFareSegment[i].FromCityId;
                item.ToCityId = model.PromotionalFareSector.PromotionalFareSegment[i].ToCityId;
                item.AirlineId = model.PromotionalFareSector.PromotionalFareSegment[i].AirlineId;
                item.DepartureTime = model.PromotionalFareSector.PromotionalFareSegment[i].DepartureTime;
                item.ArrivalTime = model.PromotionalFareSector.PromotionalFareSegment[i].ArrivalTime;
                item.Class = model.PromotionalFareSector.PromotionalFareSegment[i].Class;
                item.FlightNo = model.PromotionalFareSector.PromotionalFareSegment[i].FlightNo;
                i++;

            }
            i = 0;
            foreach (var item in Data.Air_PromotionalFareTaxes)
            {
                item.TaxAmount = model.PromotionalFareSector.Taxes[i].TaxAmount;
                item.TaxName = model.PromotionalFareSector.Taxes[i].TaxName;
                i++;
            }


            entity.ApplyCurrentValues(Data.EntityKey.EntitySetName, Data);
            entity.SaveChanges();

            return true;

        }

        public bool Delete(long id)
        {
            var Data = entity.Air_PromotionalFares.Where(x => x.PromotionalFareId == id).FirstOrDefault();
            entity.DeleteObject(Data);

            var Data1 = entity.Air_PromotionalFareSegments.Where(x => x.PromotionalFareId == id);
            foreach (var item in Data1)
            {
                entity.DeleteObject(item);
            }

            var Data2 = entity.Air_PromotionalFareTaxes.Where(x => x.PromotionalFareId == id);
            foreach (var item in Data2)
            {
                entity.DeleteObject(item);
            }
            entity.SaveChanges();

            return true;

        }


    }
}