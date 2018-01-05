using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel;
using ATLTravelPortal.Helpers;
using TBO.Passenger;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class IndianLccAirOfflineBookProvider
    {
        private EntityModel _entity;
        private ServiceResponse _response;

        public IndianLccAirOfflineBookProvider()
        {
            _entity = new EntityModel();

        }

        public ServiceResponse ActionSaveUpdate(OfflineBookViewModel model, string tranMode)
        {
            try
            {
                if (tranMode == "N")
                {
                    return Save(model);
                }
                else if (tranMode == "U")
                {
                    return Edit(model);
                }
            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false);
            }
            return _response;
        }

        public ServiceResponse Save(OfflineBookViewModel models)
        {
            try
            {
                int confirmTicketstatus = 24;
                var model = models;
                long masterpnr = 0;
                string bookingref;
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    ATLTravelPortal.Areas.Airline.Repository.GeneralProvider generalProvider = new GeneralProvider();
                    var agent = generalProvider.GetAgents(model.UserDetail.AgentId);
                    bool isByPassDealByBranch = generalProvider.GetBranchSettings(agent.BranchOfficeId, 12);
                    bool isByPassDealByDistrubutor = generalProvider.GetDistributorSettings(agent.DistributorId, 13);

                    System.Data.Objects.ObjectParameter BranchaDeal = new System.Data.Objects.ObjectParameter("Amount", 0);
                    System.Data.Objects.ObjectParameter DistributorDeal = new System.Data.Objects.ObjectParameter("Amount", 0);

                    var currency = generalProvider.GetCurrencyByCode("NPR");
                    double totalFareAmount = models.PNRDetails[0].PassengerDetail[0].FareDetail.SellingBaseFare + models.PNRDetails[0].PassengerDetail[0].FareDetail.SellingFSC - models.PNRDetails[0].PassengerDetail[0].FareDetail.DiscountAmount;

                    var branchDealAmount = _entity.Air_GetBranchDeal
                                         (agent.DistributorId,
                                             model.PNRDetails[0].SegmentDetail.FirstOrDefault().AirlineId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().DepartCityId,
                                              model.PNRDetails[0].SegmentDetail.FirstOrDefault().ArrivalCityId, false, totalFareAmount, currency.CurrencyId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().BIC, BranchaDeal);


                    var distributorDealAmount = _entity.Air_GetBranchDeal
                                        (agent.AgentId,
                                             model.PNRDetails[0].SegmentDetail.FirstOrDefault().AirlineId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().DepartCityId,
                                             model.PNRDetails[0].SegmentDetail.FirstOrDefault().ArrivalCityId, false, totalFareAmount + (double)BranchaDeal.Value + branchDealAmount, currency.CurrencyId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().BIC, DistributorDeal);



                    var mpnrDetail = new TBO_MasterPNRs
                    {
                        SessionId = model.UserDetail.SessionId.ToString(),
                        AgentId = model.UserDetail.AgentId,
                        ServiceProviderId = 5,
                        Prefix = model.PNRDetails[0].PassengerDetail[0].Prefix.ToString(),
                        FirstName = model.PNRDetails[0].PassengerDetail[0].FirstName.ToUpper(),
                        MiddleName = model.PNRDetails[0].PassengerDetail[0].MiddleName,
                        LastName = model.PNRDetails[0].PassengerDetail[0].LastName.ToUpper(),
                        TicketStatusId = confirmTicketstatus,
                        Email = "lcc@arihantholidays.com",
                        Phone = model.PNRDetails[0].PassengerDetail[0].Phone,
                        Address = "104 Level 1 The Chamber, Mumbai",
                        CreatedBy = model.UserDetail.AppUserId,
                        CreatedDate = DateTime.UtcNow,
                        IssuedDate = DateTime.UtcNow,
                        DispatchedDate = null,
                        //  BookingReference = "AH" + RandomGenerator.GenerateRandomAlphanumeric()
                        isBranchByPassDeal = isByPassDealByBranch,
                        isDistributorByPassDeal = isByPassDealByDistrubutor
                    };

                    _entity.AddToTBO_MasterPNRs(mpnrDetail);
                    _entity.SaveChanges();

                    mpnrDetail.BookingReference = "AH" + RandomGenerator.GenerateRandomAlphanumeric() + mpnrDetail.MPNRId;
                    _entity.ApplyCurrentValues(mpnrDetail.EntityKey.EntitySetName, mpnrDetail);
                    _entity.SaveChanges();


                    masterpnr = mpnrDetail.MPNRId;
                    bookingref = mpnrDetail.BookingReference;

                    foreach (var pnrData in model.PNRDetails)
                    {
                        var pnrDetail = new TBO_PNRs
                        {
                            MPNRId = mpnrDetail.MPNRId,
                            BookingId = 0,
                            TicketStatusId = confirmTicketstatus,
                            RecLoc = pnrData.PNR.ToUpper(),
                            // BookingSource = pnrData.BookingSource,
                        };

                        _entity.AddToTBO_PNRs(pnrDetail);
                        _entity.SaveChanges();

                        var sectorDetail = new TBO_PNRsectors
                        {
                            MPNRId = mpnrDetail.MPNRId,
                            PNRId = pnrDetail.PNRId,
                            PlatingCarrierId = pnrData.SegmentDetail.FirstOrDefault().AirlineId,
                            DepartCityId = pnrData.SegmentDetail.FirstOrDefault().DepartCityId,
                            DepartDate = pnrData.SegmentDetail.FirstOrDefault().DepartDate.Value,
                            DepartTime = pnrData.SegmentDetail.FirstOrDefault().DepartTime.Value,
                            DestinationCityId = pnrData.SegmentDetail.Last().ArrivalCityId,
                            ArriveDate = pnrData.SegmentDetail.LastOrDefault().ArrivalDate.Value,
                            ArriveTime = pnrData.SegmentDetail.FirstOrDefault().ArrivalTime.Value,
                            StartTerminal = pnrData.SegmentDetail.FirstOrDefault().StartTerminal,
                            EndTerminal = pnrData.SegmentDetail.LastOrDefault().EndTerminal,

                        };
                        _entity.AddToTBO_PNRsectors(sectorDetail);
                        _entity.SaveChanges();

                        foreach (var seg in pnrData.SegmentDetail)
                        {
                            var segmentDetail = new TBO_PNRsegments
                            {
                                MPNRId = mpnrDetail.MPNRId,
                                PNRId = pnrDetail.PNRId,
                                SectorId = sectorDetail.SectorId,
                                AirlineId = seg.AirlineId,
                                FlightNumber = seg.FlightNumber,
                                DepartCityId = seg.DepartCityId,
                                DepartDate = seg.DepartDate.Value,
                                DepartTime = seg.DepartTime.Value,
                                ArrivalCityId = seg.ArrivalCityId,
                                ArrivalDate = seg.ArrivalDate.Value,
                                ArrivalTime = seg.ArrivalTime.Value,
                                BIC = seg.BIC,
                                StartTerminal = seg.StartTerminal,
                                EndTerminal = seg.EndTerminal,
                                AirlineRefNumber = seg.AirlineRefNumber.ToUpper(),
                                VndRemarks = seg.VndRemarks,
                                FlightDuration =
                                    String.IsNullOrEmpty(seg.Duration)
                                        ? (seg.FlightDuration.Hours.ToString() + ":" +
                                           seg.FlightDuration.Minutes.ToString())
                                        : seg.Duration,
                                Baggage = Baggage.No.ToString(),
                                FareBasis = null,
                                FlightKey = null,
                                NVB = null,
                                NVA = null
                            };

                            _entity.AddToTBO_PNRsegments(segmentDetail);
                            _entity.SaveChanges();
                        }

                        foreach (var paxData in pnrData.PassengerDetail)
                        {
                            var paxDetail = new TBO_Passengers();
                            paxDetail.PNRId = pnrDetail.PNRId;
                            paxDetail.MPNRId = mpnrDetail.MPNRId;
                            paxDetail.Prefix = paxData.Prefix.ToString();
                            paxDetail.FirstName = paxData.FirstName.ToUpper();
                            paxDetail.MiddleName = paxData.MiddleName;
                            paxDetail.LastName = paxData.LastName.ToUpper();
                            paxDetail.Gender = "N/A";
                            if (!string.IsNullOrEmpty(paxData.DOB.Trim()))
                                paxDetail.DOB = Convert.ToDateTime(paxData.DOB);
                            paxDetail.Nationality = paxData.NationalityId;
                            paxDetail.Country = paxData.PassportIssuedCountryId;
                            paxDetail.PassportNumber = paxData.PassportNumber;
                            paxDetail.PassportExpDate = paxData.PassportExpDate;

                            paxDetail.Phone = paxData.Phone;
                            paxDetail.Email = "reservation@arihantholidays.com";
                            paxDetail.PassengerTypeId = (int)paxData.PaxType;
                            paxDetail.FFAirline = paxData.FrequentFlyerAirlineCode != null ? (int?)_entity.Airlines.Where(
                                        x => x.AirlineCode == paxData.FrequentFlyerAirlineCode).
                                            Select(y => y.AirlineId).FirstOrDefault()
                                    : null;
                            paxDetail.FFNumber = paxData.FrequentFlyerNo != "" ? paxData.FrequentFlyerNo : null;
                            paxDetail.DOCA = "2nd Floor, Buddha Complex, Swayambhu, Kathmandu, Nepal";
                            paxDetail.SSR = paxData.Meal != null ? paxData.Meal.Code : null;
                            paxDetail.SSRDescription =
                                paxData.Meal != null
                                    ? paxData.Meal.Description = paxData.Meal.Code
                                    : null;
                            paxDetail.SeatName = paxData.Seat != null ? paxData.Seat.Code : null;
                            paxDetail.SeatDescription =
                                paxData.Seat != null ? paxData.Seat.Description : null;
                            paxDetail.UpdatedBy = 1;
                            paxDetail.UpdatedDate = DateTime.UtcNow;

                            _entity.AddToTBO_Passengers(paxDetail);
                            _entity.SaveChanges();

                            var fareDetail = new TBO_PNRTickets
                            {
                                PNRId = pnrDetail.PNRId,
                                MPNRId = mpnrDetail.MPNRId,
                                PassengerId = paxDetail.PassengerId,
                                TicketNumber = paxData.FareDetail.TicketNumber.ToUpper(),
                                AdditionalTxnFee = paxData.FareDetail.SellingAdditionalTxnFee,
                                AirlineTransFee = paxData.FareDetail.AirlineTransFee,
                                BaseFare = paxData.FareDetail.SellingBaseFare,
                                Tax = paxData.FareDetail.SellingTax,
                                OtherCharges = paxData.FareDetail.SellingOtherCharges,
                                ServiceTax = paxData.FareDetail.SellingServiceTax,
                                MarkupAmount = paxData.FareDetail.MarkupAmount,
                                CommissionAmount = 0,
                                DiscountAmount = paxData.FareDetail.CommissionAmount,
                                Currency = "NPR",
                                FSC = paxData.FareDetail.SellingFSC,
                                TicketStatusId = confirmTicketstatus,
                                TktId = paxData.FareDetail.TicketId,
                                TourCode = paxData.FareDetail.TourCode,
                                ValidatingAirline = paxData.FareDetail.ValidatingAirline,
                                Remarks = paxData.FareDetail.Remarks,
                                CorporateCode = paxData.FareDetail.CorporateCode,
                                EndorseMent = paxData.FareDetail.Endorsement,
                                //value with Rounding
                                SellingAdditionalTxnFee =
                                    Math.Ceiling(paxData.FareDetail.SellingAdditionalTxnFee),
                                SellingAirlineTransFee =
                                    Math.Ceiling(paxData.FareDetail.SellingAirlineTransFee),
                                SellingBaseFare = Math.Ceiling(paxData.FareDetail.SellingBaseFare),
                                SellingTax = Math.Ceiling(paxData.FareDetail.SellingTax),
                                SellingOtherCharges =
                                    Math.Ceiling(paxData.FareDetail.SellingOtherCharges),
                                SellingServiceTax =
                                    Math.Ceiling(paxData.FareDetail.SellingServiceTax),
                                SellingFSC = Math.Ceiling(paxData.FareDetail.SellingFSC),
                                BranchDealAmount = (double)BranchaDeal.Value,
                                DistrubutorDealAmount = (double)DistributorDeal.Value
                            };

                            _entity.AddToTBO_PNRTickets(fareDetail);
                            _entity.SaveChanges();
                        }

                    }

                    ts.Complete();

                }
                IssueTicket(masterpnr, model.UserDetail.AppUserId);

                _entity.SaveChanges();
                _entity.Air_UpdateTicketStatusId(masterpnr, "ISSUEPNR", false, model.UserDetail.AppUserId);

                _response = new ServiceResponse("Record successfully created!! \n Your Booking Reference No is :" + bookingref, MessageType.Success, true, "Save");


                return _response;

            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Save");
                return _response;
            }
        }

        public List<OfflineBookViewModel> ListOfflineBook(DateTime? fromdate, DateTime? todate)
        {
            var data = _entity.Air_GetOfflineBookingRequest(fromdate, todate).Where(x => (x.ServiceProviderId == 5 && x.TicketStatusId != 33 && x.TicketStatusId != 34));

            List<OfflineBookViewModel> model = new List<OfflineBookViewModel>();

            foreach (var item in data.Select(x => x))
            {
                OfflineBookViewModel OfflineBookViewModel = new OfflineBookViewModel();

                OfflineBookViewModel.UserDetail.AgentName = item.AgentName;
                OfflineBookViewModel.ServiceProviderId = item.ServiceProviderId;
                OfflineBookViewModel.ServiceProviderName = item.ServiceProviderName;
                OfflineBookViewModel.PassengerName = item.PassengerName;
                OfflineBookViewModel.Sector = item.Sector;
                OfflineBookViewModel.BookedDate = item.BookedOn.Value;
                OfflineBookViewModel.BookedBy = item.BookedBy;
                OfflineBookViewModel.MPNRId = item.MPNRId;
                OfflineBookViewModel.BookingRefNo = item.BookingReference;
                OfflineBookViewModel.TicketStatusId = item.TicketStatusId;


                model.Add(OfflineBookViewModel);

            }
            return model.ToList();
        }


        public IEnumerable<OfflineBookingServiceProvider> GetOfflineBookingServiceSource()
        {
            return _entity.OfflineBookingServiceProvider.Where(x => x.IsActive == true).AsEnumerable();
        }



        public ServiceResponse Edit(OfflineBookViewModel models)
        {
            try
            {

                //int confirmTicketstatus = 24;

                int confirmTicketstatus = models.TicketStatusId;
                //if (confirmTicketstatus != 28)
                //{
                //    confirmTicketstatus = 24;
                //}

                var model = models.PNRBookedList.FirstOrDefault();
                long mpnrId = model.MPNRId;
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {

                    var mpnrResult = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrId).FirstOrDefault();
                    mpnrResult.TicketStatusId = confirmTicketstatus;
                    mpnrResult.IssuedDate = DateTime.UtcNow;

                    _entity.ApplyCurrentValues(mpnrResult.EntityKey.EntitySetName, mpnrResult);
                    _entity.SaveChanges();

                    var pnrResult = _entity.TBO_PNRs.Where(x => x.MPNRId == mpnrId).ToList();
                    int pnrcount = pnrResult.Count;
                    for (int i = 0; i < pnrcount; i++)
                    {
                        pnrResult[i].RecLoc = model.PNRDetails[i].PNR;

                        //  pnrResult[i].BookingSource = model.PNRDetails[i].BookingSource;

                        pnrResult[i].TicketStatusId = confirmTicketstatus;
                        _entity.ApplyCurrentValues(pnrResult[i].EntityKey.EntitySetName, pnrResult[i]);
                        _entity.SaveChanges();

                        long currentPNRId = pnrResult[i].PNRId;

                        var ticketResult = _entity.TBO_PNRTickets.Where(x => x.PNRId == currentPNRId).ToList();
                        int ticketCount = ticketResult.Count;

                        for (int j = 0; j < ticketCount; j++)
                        {
                            ticketResult[j].TicketNumber =
                                model.PNRDetails[i].PassengerDetail[j].FareDetail.TicketNumber;


                            ticketResult[j].TicketStatusId = confirmTicketstatus;


                            _entity.ApplyCurrentValues(ticketResult[j].EntityKey.EntitySetName, ticketResult[j]);
                            _entity.SaveChanges();
                        }

                        var airlinePnrResult = _entity.TBO_PNRsegments.Where(x => x.PNRId == currentPNRId).ToList();
                        int airlinePNRCount = airlinePnrResult.Count;

                        for (int k = 0; k < airlinePNRCount; k++)
                        {
                            airlinePnrResult[k].AirlineRefNumber = model.PNRDetails[i].SegmentDetail[k].AirlineRefNumber.ToUpper();
                            _entity.ApplyCurrentValues(airlinePnrResult[k].EntityKey.EntitySetName, airlinePnrResult[k]);
                            _entity.SaveChanges();
                        }
                    }
                    ts.Complete();
                }

                _response = new ServiceResponse("Record successfully created!!", MessageType.Success, true, "Save");
                return _response;
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Save");
                return _response;
            }


        }


        internal void IssueTicket(long mpnrId, int AppUserId)
        {
            EntityModel _entity = new EntityModel();
            _entity.TBO_Air_IssueTickets(mpnrId, AppUserId);
            _entity.SaveChanges();

        }

        public int GetPlatingCarrierId(Int64 MPNRID)
        {
            return _entity.TBO_PNRsectors.Where(x => x.MPNRId == MPNRID).Select(x => x.PlatingCarrierId).FirstOrDefault();

        }

        public bool isoffline(int airlineid)
        {
            bool check = _entity.Air_OffLineAirlineSettings.Where(x => x.AirlineId == airlineid).Select(x => x.IsOffline).FirstOrDefault();
            return check;

        }




        public OfflineBookViewModel GetBookedPNRList(long? mpnrid, DateTime? fromdate, DateTime? todate)
        {
            List<TBO_MasterPNRs> masterpnrList = null;
            if (mpnrid != null)
            {
                masterpnrList = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrid).ToList();
            }
            else
            {

                masterpnrList = _entity.TBO_MasterPNRs.Where(x => ((x.TicketStatusId == 2) && (x.IssuedDate >= fromdate && x.IssuedDate <= todate))).ToList();
            }
            var sortedMpnrList = masterpnrList.OrderByDescending(x => x.CreatedDate);
            var pnrList = new OfflineBookViewModel();
            pnrList.PNRBookedList = new List<OfflineBookViewModel>();


            foreach (var masterpnr in sortedMpnrList)
            {
                var agentDetail = _entity.Agents.Where(x => x.AgentId == masterpnr.AgentId);

                var offlinebooked = new OfflineBookViewModel();
                offlinebooked.MPNRId = masterpnr.MPNRId;
                offlinebooked.BookingRefNo = masterpnr.BookingReference;
                offlinebooked.UserDetail.AgentId = masterpnr.AgentId;
                offlinebooked.UserDetail.AgentName = agentDetail.FirstOrDefault().AgentName + "(" + agentDetail.FirstOrDefault().AgentCode + ")";
                offlinebooked.UserDetail.AgentPhone = agentDetail.FirstOrDefault().Phone;
                string districtName = agentDetail.FirstOrDefault().Districts != null ? agentDetail.FirstOrDefault().Districts.DistrictName : string.Empty;
                string zoneName = agentDetail.FirstOrDefault().Zones != null ? agentDetail.FirstOrDefault().Zones.ZoneName : string.Empty;

                offlinebooked.UserDetail.AgencyDescription =
                                                            @"<br/>Email: " +
                                                            agentDetail.FirstOrDefault().Email +
                                                            @"<br/>Contact No: " +
                                                            agentDetail.FirstOrDefault().Phone +
                                                            @"<br/>Contact Person: " +
                                                            @"<br>Address: " + districtName + ", " +
                                                           zoneName;
                offlinebooked.TicketStatusId = masterpnr.TicketStatusId;
                offlinebooked.TicketStatus = GetTicketStatusName(offlinebooked.TicketStatusId);

                offlinebooked.PNRDetails = new List<OfflineBookPNRDetailsModel>();
                var pnr = _entity.TBO_PNRs.Where(x => x.MPNRId == masterpnr.MPNRId);

                foreach (var item in pnr)
                {
                    var pnrdetail = new OfflineBookPNRDetailsModel();
                    //  pnrdetail.BookedDate = new ATLTravelPortal.Repository.GeneralRepository().LocalDateTime(masterpnr.CreatedDate);
                    //  pnrdetail.IssueDate = new ATLTravelPortal.Repository.GeneralRepository().LocalDateTime((DateTime)masterpnr.IssuedDate);
                    pnrdetail.PNRId = item.PNRId;
                    pnrdetail.PNR = item.RecLoc;
                    //pnrdetail.BookingSource = item.BookingSource;

                    pnrdetail.TicketStatus = _entity.TicketStatus.Where(x => x.ticketStatusId == item.TicketStatusId).FirstOrDefault().ticketStatusName;

                    pnrdetail.SegmentDetail = new List<OfflineBookSegmentModel>();

                    var segmentDetail = _entity.TBO_PNRsegments.Where(x => x.PNRId == item.PNRId);
                    foreach (var seg in segmentDetail)
                    {

                        var segment = new OfflineBookSegmentModel();
                        var segAirline = GetAirlineById(seg.AirlineId);

                        segment.SegmentId = seg.SegmentId;
                        segment.DepartCityId = seg.DepartCityId;
                        segment.DepartDate = seg.DepartDate;
                        segment.DepartTime = seg.DepartTime;
                        segment.DepartCityCode = _entity.AirlineCities.Where(x => x.CityID == seg.DepartCityId).FirstOrDefault().CityCode;

                        segment.ArrivalCityId = seg.ArrivalCityId;
                        segment.ArrivalDate = seg.ArrivalDate;
                        segment.ArrivalTime = seg.ArrivalTime;
                        segment.ArrivalCityCode = _entity.AirlineCities.Where(x => x.CityID == seg.ArrivalCityId).FirstOrDefault().CityCode;
                        segment.BIC = seg.BIC;
                        segment.AirlineRefNumber = seg.AirlineRefNumber;
                        segment.AirlineCode = segAirline.AirlineCode;
                        segment.AirlineName = segAirline.AirlineName;
                        segment.FlightNumber = seg.FlightNumber;


                        pnrdetail.SegmentDetail.Add(segment);
                    }

                    pnrdetail.PassengerDetail = new List<OfflineBookPassengerModel>();

                    var paxDetail = _entity.TBO_Passengers.Where(x => x.PNRId == item.PNRId);
                    foreach (var paxItem in paxDetail)
                    {
                        var pax = new OfflineBookPassengerModel();

                        if (paxItem.Nationality != null)
                            pax.Nationality = GetCountriesById((int)paxItem.Nationality).CountryName;

                        if (paxItem.FFAirline != null)
                            pax.FrequentFlyerAirline = paxItem.FFAirline > 0 ? GetAirlineById((int)paxItem.FFAirline).AirlineName : string.Empty;

                        pax.FrequentFlyerNo = pax.FrequentFlyerNo;

                        if (pax.Meal != null)
                            pax.Meal.Code = paxItem.SSR;

                        if (pax.Seat != null)
                            pax.Seat.Code = paxItem.SeatName;

                        pax.FirstName = paxItem.FirstName;
                        pax.LastName = paxItem.LastName;
                        pax.DOB = paxItem.DOB.ToString();
                        pax.Phone = paxItem.Phone;
                        pax.PassengerPrefix = paxItem.Prefix;

                        pax.PaxType = (PassengerType)Enum.Parse(typeof(PassengerType), paxItem.PassengerTypeId.ToString());
                        pnrdetail.PassengerDetail.Add(pax);


                        pax.PassportNumber = paxItem.PassportNumber;
                        pax.PassportExpDate = paxItem.PassportExpDate;


                        var fareDetail = _entity.TBO_PNRTickets.Where(x => x.PassengerId == paxItem.PassengerId).FirstOrDefault();
                        if (fareDetail != null)
                        {
                            pax.FareDetail.BaseFare = fareDetail.SellingBaseFare;
                            pax.FareDetail.SellingBaseFare = fareDetail.SellingBaseFare;

                            pax.FareDetail.MarkupAmount = fareDetail.MarkupAmount;

                            pax.FareDetail.Tax = fareDetail.Tax;
                            pax.FareDetail.SellingTax = fareDetail.SellingTax;

                            pax.FareDetail.OtherCharges = fareDetail.OtherCharges;
                            pax.FareDetail.SellingOtherCharges = fareDetail.SellingOtherCharges;

                            pax.FareDetail.SellingServiceTax = fareDetail.SellingServiceTax;

                            pax.FareDetail.FSC = fareDetail.SellingFSC;
                            pax.FareDetail.SellingFSC = fareDetail.SellingFSC;

                            pax.FareDetail.TicketNumber = fareDetail.TicketNumber;

                            // pax.FareDetail.AgentAirlineMarkup = fareDetail.AgentAirlineMarkup;

                            pax.FareDetail.SellingAirlineTransFee = fareDetail.SellingAirlineTransFee;
                            pax.FareDetail.AdditionalTxnFee = fareDetail.AdditionalTxnFee;
                            pax.FareDetail.SellingAdditionalTxnFee = fareDetail.SellingAdditionalTxnFee;

                            pax.FareDetail.DiscountAmount = fareDetail.DiscountAmount;

                            pax.FareDetail.TktId = fareDetail.TicketId;

                            pax.FareDetail.ValidatingAirline = fareDetail.ValidatingAirline;

                            pax.FareDetail.TicketStatus = _entity.TicketStatus.Where(x => x.ticketStatusId == fareDetail.TicketStatusId).FirstOrDefault().ticketStatusName;
                        }

                    }
                    offlinebooked.PNRDetails.Add(pnrdetail);

                    pnrList.BookingBourceList = new SelectList(EnumHelper.GetEnumDescription(typeof(BookingSourceEnum)), "Name", "Description", pnrdetail.BookingSource);
                }
                pnrList.PNRBookedList.Add(offlinebooked);
            }

            return pnrList;
        }



        public int GetTicketStatusId(long mpnrid)
        {
            int ticketsstatusid = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrid).Select(x => x.TicketStatusId).FirstOrDefault();
            return ticketsstatusid;
        }


        public SelectList GetCitiesByCityTypeId(int cityTypeId)
        {
            if (cityTypeId == 3)
            {
                return new SelectList(_entity.AirlineCities.Where(x => (x.AirlineCityTypeId == 3) || x.AirlineCityTypeId == 4), "CityID", "CityName");
            }
            else
            {
                return new SelectList(_entity.AirlineCities.Where(x => (x.AirlineCityTypeId == 1) || x.AirlineCityTypeId == 4), "CityID", "CityName");
            }
        }

        private Countries GetCountriesById(int id)
        {
            return _entity.Countries.Where(x => x.CountryId == id).FirstOrDefault();
        }

        private Airlines GetAirlineById(int id)
        {
            return _entity.Airlines.Where(x => x.AirlineId == id).FirstOrDefault();
        }

        public bool CheckMPNRIdExist(long id)
        {
            var result = _entity.TBO_PNRs.Where(x => x.MPNRId == id);
            if (result.Count() > 0)
                return true;
            else
                return false;

        }

        //Reject Book Action
        public ServiceResponse Delete(long id, int MakerId)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _entity.Air_CancelTickets(id, null, null, false, 1, MakerId, 5);
                    _entity.SaveChanges();
                    //var mpnrResult = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == id).FirstOrDefault();
                    //mpnrResult.TicketStatusId = 2;
                    //_entity.ApplyCurrentValues(mpnrResult.EntityKey.EntitySetName, mpnrResult);
                    //_entity.SaveChanges();

                    ts.Complete();
                    _response = new ServiceResponse("Record successfully Cancelled!!", MessageType.Success, true, "Cancelled");
                    return _response;

                }
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Cancelled");
                return _response;
            }
        }



        public string GetTicketStatusName(int id)
        {
            string result = _entity.TicketStatus.Where(x => x.ticketStatusId == id).Select(x => x.ticketStatusName).FirstOrDefault();
            return result;
        }


        public int GetIndianLccRowCount()
        {
            int count = _entity.TBO_MasterPNRs.Count(x => (x.ServiceProviderId == 5 && (x.TicketStatusId == 14 || x.TicketStatusId == 17
|| x.TicketStatusId == 1 || x.TicketStatusId == 25 || x.TicketStatusId == 28 || x.TicketStatusId == 24)));
            return count;
        }

        public int GetRowCount()
        {
            //            int count = _entity.TBO_MasterPNRs.Count(x => (x.ServiceProviderId != 5  && (x.TicketStatusId == 14 || x.TicketStatusId == 17
            //|| x.TicketStatusId == 1 || x.TicketStatusId == 25)));
            int count = _entity.TBO_MasterPNRs.Count(x => (x.TicketStatusId == 14 || x.TicketStatusId == 17
|| x.TicketStatusId == 1 || x.TicketStatusId == 25 || x.TicketStatusId == 28 || x.TicketStatusId == 24));
            return count;
        }



    }
}