using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using TBO.Passenger;
using System.Transactions;
using System.Web.Configuration;
using System.IO;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirOfflineBookProvider
    {
        private EntityModel _entity;
        private ServiceResponse _response;

        public AirOfflineBookProvider()
        {
            _entity = new EntityModel();

        }

        public List<OfflineBookViewModel> ListOfflineBook()
        {
            var data = _entity.Air_GetOfflineBookingRequest(null, null);

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
                OfflineBookViewModel.MPNRId = item.MPNRId;
                OfflineBookViewModel.TicketStatusId = item.TicketStatusId;

                model.Add(OfflineBookViewModel);
            }
            return model.ToList();
        }


        public OfflineBookViewModel GetBookedPNRList(long? mpnrid)
        {
            GeneralProvider generalProvider = new GeneralProvider();

            List<TBO_MasterPNRs> masterpnrList = null;
            if (mpnrid != null)
            {
                masterpnrList = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrid).ToList();
            }
            else
            {

                masterpnrList = _entity.TBO_MasterPNRs.Where(x => ((x.TicketStatusId == 14) || (x.TicketStatusId == 1 || (x.TicketStatusId == 17)))).ToList();
            }
            var sortedMpnrList = masterpnrList.OrderByDescending(x => x.CreatedDate);
            var pnrList = new OfflineBookViewModel();
            pnrList.PNRBookedList = new List<OfflineBookViewModel>();


            pnrList.SelectListCollection.BookingSourceList = new SelectList(ToSelectList.BookingSourceList(), "ServiceProviderId", "ServiceProviderName", masterpnrList[0].ServiceProviderId);

            foreach (var masterpnr in sortedMpnrList)
            {
                var agentDetail = _entity.Agents.Where(x => x.AgentId == masterpnr.AgentId);

                var userDetail = _entity.UsersDetails.Where(x => x.AppUserId == masterpnr.CreatedBy);

                var offlinebooked = new OfflineBookViewModel();
                offlinebooked.MPNRId = masterpnr.MPNRId;
                offlinebooked.ServiceProviderName = masterpnr.ServiceProviders.ServiceProviderName;
                offlinebooked.ServiceProviderId = masterpnr.ServiceProviderId;

                offlinebooked.UserDetail.AgentId = masterpnr.AgentId;
                offlinebooked.UserDetail.AgentName = agentDetail.FirstOrDefault().AgentName + "(" + agentDetail.FirstOrDefault().AgentCode + ")";


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


                offlinebooked.UserDetail.BranchId = agentDetail.FirstOrDefault().BranchOfficeId;
                offlinebooked.UserDetail.DistributorId = agentDetail.FirstOrDefault().DistributorId;
                offlinebooked.UserDetail.BranchOfficeName = agentDetail.FirstOrDefault().BranchOffices.BranchOfficeName;
                offlinebooked.UserDetail.DistributorOfficeName = agentDetail.FirstOrDefault().Distributors.DistributorName;

                offlinebooked.UserDetail.UserFullName = userDetail.FirstOrDefault().FullName == null ? "-" : userDetail.FirstOrDefault().FullName;
                offlinebooked.UserDetail.UserAddress = userDetail.FirstOrDefault().UserAddress == null ? "-" : userDetail.FirstOrDefault().UserAddress;
                offlinebooked.UserDetail.UserMobileNumber = userDetail.FirstOrDefault().MobileNumber == null ? "-" : userDetail.FirstOrDefault().MobileNumber;
                offlinebooked.UserDetail.UserPhoneNumber = userDetail.FirstOrDefault().PhoneNumber == null ? "-" : userDetail.FirstOrDefault().PhoneNumber;

                offlinebooked.BookedDate = masterpnr.CreatedDate;
                offlinebooked.TicketStatusId = masterpnr.TicketStatusId;
                offlinebooked.TicketStatus = GetTicketStatusName(offlinebooked.TicketStatusId);



                offlinebooked.PnrInfoFirstName = masterpnr.FirstName;
                offlinebooked.PnrInfoMiddleName = masterpnr.MiddleName;
                offlinebooked.PnrInfoLastName = masterpnr.LastName;
                offlinebooked.PnrInfoPrefix = null;

                offlinebooked.PnrInfoPrefixList = new SelectList(GetPassengerPrefixList(), "Value", "Text", masterpnr.Prefix.Trim());

                offlinebooked.PNRDetails = new List<OfflineBookPNRDetailsModel>();
                var pnr = _entity.TBO_PNRs.Where(x => x.MPNRId == masterpnr.MPNRId);

                Int64[] paxIds = new Int64[3];

                foreach (var item in pnr)
                {
                    List<OfflineBookFareDetailModel> farePassengerInfo = new List<OfflineBookFareDetailModel>();

                    var adultList = _entity.TBO_Passengers.Where(x => (x.PassengerTypeId == 1 && x.PNRId == item.PNRId)).FirstOrDefault();
                    if (adultList != null)
                    {
                        paxIds[0] = adultList.PassengerId;
                        OfflineBookFareDetailModel adultFare = new OfflineBookFareDetailModel();
                        var adultfareDetail = adultList.TBO_PNRTickets.First();

                        adultFare.Currency = adultfareDetail.Currency;

                        adultFare.BaseFare = adultfareDetail.BaseFare;
                        adultFare.SellingBaseFare = adultfareDetail.SellingBaseFare;
                        adultFare.MarkupAmount = adultfareDetail.MarkupAmount;
                        adultFare.Tax = adultfareDetail.Tax;
                        adultFare.SellingTax = adultfareDetail.SellingTax;
                        adultFare.OtherCharges = adultfareDetail.OtherCharges;
                        adultFare.SellingOtherCharges = adultfareDetail.SellingOtherCharges;
                        adultFare.SellingServiceTax = adultfareDetail.SellingServiceTax;
                        adultFare.FSC = adultfareDetail.SellingFSC;
                        adultFare.SellingFSC = adultfareDetail.SellingFSC;
                        adultFare.TicketNumber = adultfareDetail.TicketNumber;
                        adultFare.AgentAirlineMarkup = adultfareDetail.MarkupAmount;
                        adultFare.SellingAirlineTransFee = adultfareDetail.AirlineTransFee;
                        adultFare.AdditionalTxnFee = adultfareDetail.AdditionalTxnFee;
                        adultFare.SellingAdditionalTxnFee = adultfareDetail.SellingAdditionalTxnFee;
                        adultFare.DiscountAmount = adultfareDetail.DiscountAmount;
                        adultFare.TktId = adultfareDetail.TicketId;
                        adultFare.ValidatingAirline = adultfareDetail.ValidatingAirline;
                        adultFare.ServiceTax = adultfareDetail.ServiceTax;
                        adultFare.CommissionAmount = adultfareDetail.CommissionAmount;
                        adultFare.TicketStatus = _entity.TicketStatus.Where(x => x.ticketStatusId == adultfareDetail.TicketStatusId).FirstOrDefault().ticketStatusName;
                        adultFare.TicketStatusId = _entity.TicketStatus.Where(x => x.ticketStatusId == adultfareDetail.TicketStatusId).FirstOrDefault().ticketStatusId;
                        adultFare.PaxType = PassengerType.Adult;


                        adultFare.PaxTypeList = new SelectList(GetPassengerTypeList(), "Value", "Text", 1);

                        farePassengerInfo.Add(adultFare);
                    }

                    var childList = _entity.TBO_Passengers.Where(x => (x.PassengerTypeId == 2 && x.PNRId == item.PNRId)).FirstOrDefault();
                    if (childList != null)
                    {
                        paxIds[1] = childList.PassengerId;
                        OfflineBookFareDetailModel childFare = new OfflineBookFareDetailModel();
                        var childfareDetail = childList.TBO_PNRTickets.First();

                        childFare.Currency = childfareDetail.Currency;

                        childFare.BaseFare = childfareDetail.BaseFare;
                        childFare.SellingBaseFare = childfareDetail.SellingBaseFare;
                        childFare.MarkupAmount = childfareDetail.MarkupAmount;
                        childFare.Tax = childfareDetail.Tax;
                        childFare.SellingTax = childfareDetail.SellingTax;
                        childFare.OtherCharges = childfareDetail.OtherCharges;
                        childFare.SellingOtherCharges = childfareDetail.SellingOtherCharges;
                        childFare.SellingServiceTax = childfareDetail.SellingServiceTax;
                        childFare.FSC = childfareDetail.SellingFSC;
                        childFare.SellingFSC = childfareDetail.SellingFSC;
                        childFare.TicketNumber = childfareDetail.TicketNumber;
                        childFare.AgentAirlineMarkup = childfareDetail.MarkupAmount;
                        childFare.SellingAirlineTransFee = childfareDetail.AirlineTransFee;
                        childFare.AdditionalTxnFee = childfareDetail.AdditionalTxnFee;
                        childFare.SellingAdditionalTxnFee = childfareDetail.SellingAdditionalTxnFee;
                        childFare.DiscountAmount = childfareDetail.DiscountAmount;
                        childFare.TktId = childfareDetail.TicketId;
                        childFare.ValidatingAirline = childfareDetail.ValidatingAirline;
                        childFare.ServiceTax = childfareDetail.ServiceTax;
                        childFare.CommissionAmount = childfareDetail.CommissionAmount;
                        childFare.TicketStatus = _entity.TicketStatus.Where(x => x.ticketStatusId == childfareDetail.TicketStatusId).FirstOrDefault().ticketStatusName;
                        childFare.TicketStatusId = _entity.TicketStatus.Where(x => x.ticketStatusId == childfareDetail.TicketStatusId).FirstOrDefault().ticketStatusId;
                        childFare.PaxType = PassengerType.Child;
                        //childFare.FarePaxType = PassengerType.Child;
                        childFare.PaxTypeList = new SelectList(GetPassengerTypeList(), "Value", "Text", 2);

                        farePassengerInfo.Add(childFare);

                    }

                    var infantList = _entity.TBO_Passengers.Where(x => (x.PassengerTypeId == 3 && x.PNRId == item.PNRId)).FirstOrDefault();
                    if (infantList != null)
                    {
                        paxIds[2] = infantList.PassengerId;
                        OfflineBookFareDetailModel infantFare = new OfflineBookFareDetailModel();
                        var infantfareDetail = infantList.TBO_PNRTickets.First();
                        infantFare.Currency = infantfareDetail.Currency;
                        infantFare.BaseFare = infantfareDetail.BaseFare;
                        infantFare.SellingBaseFare = infantfareDetail.SellingBaseFare;
                        infantFare.MarkupAmount = infantfareDetail.MarkupAmount;
                        infantFare.Tax = infantfareDetail.Tax;
                        infantFare.SellingTax = infantfareDetail.SellingTax;
                        infantFare.OtherCharges = infantfareDetail.OtherCharges;
                        infantFare.SellingOtherCharges = infantfareDetail.SellingOtherCharges;
                        infantFare.SellingServiceTax = infantfareDetail.SellingServiceTax;
                        infantFare.FSC = infantfareDetail.SellingFSC;
                        infantFare.SellingFSC = infantfareDetail.SellingFSC;
                        infantFare.TicketNumber = infantfareDetail.TicketNumber;
                        infantFare.AgentAirlineMarkup = infantfareDetail.MarkupAmount;
                        infantFare.SellingAirlineTransFee = infantfareDetail.AirlineTransFee;
                        infantFare.AdditionalTxnFee = infantfareDetail.AdditionalTxnFee;
                        infantFare.SellingAdditionalTxnFee = infantfareDetail.SellingAdditionalTxnFee;
                        infantFare.DiscountAmount = infantfareDetail.DiscountAmount;
                        infantFare.TktId = infantfareDetail.TicketId;
                        infantFare.ValidatingAirline = infantfareDetail.ValidatingAirline;
                        infantFare.ServiceTax = infantfareDetail.ServiceTax;
                        infantFare.CommissionAmount = infantfareDetail.CommissionAmount;
                        infantFare.TicketStatus = _entity.TicketStatus.Where(x => x.ticketStatusId == infantfareDetail.TicketStatusId).FirstOrDefault().ticketStatusName;
                        infantFare.TicketStatusId = _entity.TicketStatus.Where(x => x.ticketStatusId == infantfareDetail.TicketStatusId).FirstOrDefault().ticketStatusId;
                        infantFare.PaxType = PassengerType.Infant;
                        // infantFare.FarePaxType = PassengerType.Infant;
                        infantFare.PaxTypeList = new SelectList(GetPassengerTypeList(), "Value", "Text", 3);

                        farePassengerInfo.Add(infantFare);
                    }

                    pnrList.FarePassengerInfo = farePassengerInfo;

                    var pnrdetail = new OfflineBookPNRDetailsModel();
                    pnrdetail.BookedDate = masterpnr.CreatedDate;

                    pnrdetail.PNRId = item.PNRId;
                    pnrdetail.PNR = item.RecLoc == null ? "" : item.RecLoc;
                    pnrdetail.PCC = item.PCC;

                    pnrdetail.TicketStatus = _entity.TicketStatus.Where(x => x.ticketStatusId == item.TicketStatusId).FirstOrDefault().ticketStatusName;

                    pnrdetail.SegmentDetail = new List<OfflineBookSegmentModel>();

                    var segmentDetail = _entity.TBO_PNRsegments.Where(x => x.PNRId == item.PNRId);
                    foreach (var seg in segmentDetail)
                    {

                        var segment = new OfflineBookSegmentModel();
                        var segAirline = GetAirlineById(seg.AirlineId);


                        segment.SegmentId = seg.SegmentId;
                        segment.DepartCityId = seg.DepartCityId;

                        segment.DepartDate = seg.DepartDate.Date + seg.DepartTime;

                        //segment.DepartDate = seg.DepartDate + seg.DepartTime;
                        segment.DepartTime = seg.DepartTime;
                        segment.DepartCityCode = _entity.AirlineCities.Where(x => x.CityID == seg.DepartCityId).FirstOrDefault().CityCode;
                        segment.ArrivalCityId = seg.ArrivalCityId;

                        segment.ArrivalDate = seg.ArrivalDate.Date + seg.ArrivalTime;


                        // segment.ArrivalDate = seg.ArrivalDate + seg.ArrivalTime;
                        segment.ArrivalTime = seg.ArrivalTime;
                        segment.ArrivalCityCode = _entity.AirlineCities.Where(x => x.CityID == seg.ArrivalCityId).FirstOrDefault().CityCode;
                        segment.BIC = seg.BIC;
                        segment.AirlineRefNumber = seg.AirlineRefNumber;
                        segment.AirlineCode = segAirline.AirlineCode;
                        segment.AirlineName = segAirline.AirlineName;
                        segment.FlightNumber = seg.FlightNumber;
                        segment.AirlineId = seg.AirlineId;
                        segment.Baggage = seg.Baggage;


                        segment.DepartCityList = new SelectList(GetCityList(), "Value", "Text", segment.DepartCityId);
                        segment.ArriveCityList = new SelectList(GetCityList(), "Value", "Text", segment.ArrivalCityId);
                        segment.AirlineList = new SelectList(GetAirlinesList(), "Value", "Text", segment.AirlineId);

                        pnrdetail.SegmentDetail.Add(segment);
                    }

                    pnrdetail.PassengerDetail = new List<OfflineBookPassengerModel>();

                    var paxDetail = _entity.TBO_Passengers.Where(x => x.PNRId == item.PNRId);

                    foreach (var paxItem in paxDetail)
                    {
                        var pax = new OfflineBookPassengerModel();

                        pax.FareDetail.PassengerId = paxItem.PassengerId;

                        pax.PassengerPrefix = paxItem.Prefix;
                        pax.FirstName = paxItem.FirstName;
                        pax.MiddleName = paxItem.MiddleName;
                        pax.LastName = paxItem.LastName;
                        pax.DOB = TimeFormat.DateFormat(paxItem.DOB.ToString());
                        pax.Phone = paxItem.Phone;

                        pax.PaxType = (PassengerType)Enum.Parse(typeof(PassengerType), paxItem.PassengerTypeId.ToString());

                        pax.PaxTypeList = new SelectList(GetPassengerTypeList(), "Value", "Text", paxItem.PassengerTypeId.ToString());

                        pax.PrefixList = new SelectList(GetPassengerPrefixList(), "Value", "Text", pax.PassengerPrefix);

                        pnrdetail.PassengerDetail.Add(pax);


                        pax.PassportNumber = paxItem.PassportNumber;
                        pax.PassportExpDate = paxItem.PassportExpDate;


                        var fareDetail = _entity.TBO_PNRTickets.Where(x => x.PassengerId == paxItem.PassengerId).FirstOrDefault();
                        if (fareDetail != null)
                        {
                            pax.FareDetail.Currency = fareDetail.Currency;
                            pax.FareDetail.BaseFare = fareDetail.BaseFare;
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
                            pax.FareDetail.AgentAirlineMarkup = fareDetail.MarkupAmount;
                            pax.FareDetail.SellingAirlineTransFee = fareDetail.AirlineTransFee;
                            pax.FareDetail.SellingAdditionalTxnFee = fareDetail.AdditionalTxnFee;
                            pax.FareDetail.DiscountAmount = fareDetail.DiscountAmount;
                            pax.FareDetail.TktId = fareDetail.TicketId;
                            pax.FareDetail.ValidatingAirline = fareDetail.ValidatingAirline;
                            pax.FareDetail.ServiceTax = fareDetail.ServiceTax;
                            pax.FareDetail.CommissionAmount = fareDetail.CommissionAmount;
                            pax.FareDetail.TicketStatus = _entity.TicketStatus.Where(x => x.ticketStatusId == fareDetail.TicketStatusId).FirstOrDefault().ticketStatusName;
                            pax.FareDetail.TicketStatusId = _entity.TicketStatus.Where(x => x.ticketStatusId == fareDetail.TicketStatusId).FirstOrDefault().ticketStatusId;
                        }

                    }
                    offlinebooked.PNRDetails.Add(pnrdetail);

                    pnrList.BookingBourceList = new SelectList(EnumHelper.GetEnumDescription(typeof(BookingSourceEnum)), "Name", "Description", pnrdetail.BookingSource);
                }
                pnrList.PNRBookedList.Add(offlinebooked);
            }
            pnrList.AvailableBalance = new GeneralProvider().GetAccountInfoByAgentId(sortedMpnrList.First().AgentId);

            return pnrList;
        }

        private Airlines GetAirlineById(int id)
        {
            return _entity.Airlines.Where(x => x.AirlineId == id).FirstOrDefault();
        }

        private Countries GetCountriesById(int id)
        {
            return _entity.Countries.Where(x => x.CountryId == id).FirstOrDefault();
        }



        public int? GetNumberofAdultPassenger(Int64 mpnrid, int paxtypeid)
        {
            var result = _entity.TBO_Passengers.Where(x => (x.MPNRId == mpnrid && x.PassengerTypeId == 1)).ToList();
            int totalnumberofadult = result.Count;
            return totalnumberofadult;
        }

        public int? GetNumberofChildPassenger(Int64 mpnrid, int paxtypeid)
        {
            var result = _entity.TBO_Passengers.Where(x => (x.MPNRId == mpnrid && x.PassengerTypeId == 2)).ToList();
            int totalnumberofchild = result.Count;
            return totalnumberofchild;
        }

        public int? GetNumberofInfantPassenger(Int64 mpnrid, int paxtypeid)
        {
            var result = _entity.TBO_Passengers.Where(x => (x.MPNRId == mpnrid && x.PassengerTypeId == 3)).ToList();
            int totalnumberofinfant = result.Count;
            return totalnumberofinfant;
        }

        public ServiceResponse Edit(OfflineBookViewModel models)
        {
            try
            {

                var model = models.PNRBookedList.FirstOrDefault();
                long mpnrId = model.MPNRId;


                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    List<OfflineBookFareDetailModel> fareDetailsList = new List<OfflineBookFareDetailModel>();
                    List<OfflineBookFareDetailModel> rtnFareDetailsList = new List<OfflineBookFareDetailModel>();

                    foreach (var fare in models.PNRBookedList[0].PNRDetails[0].PassengerDetail[0].FareDetails)
                    {
                        fareDetailsList.Add(fare);
                    }

                    if (models.PNRBookedList.Count > 1)
                    {
                        foreach (var fare in models.PNRBookedList[0].PNRDetails[1].PassengerDetail[0].FareDetails)
                        {
                            rtnFareDetailsList.Add(fare);
                        }
                    }
                    else if (models.PNRBookedList[0].ServiceProviderId == 4)
                    {
                        rtnFareDetailsList.Add(fareDetailsList[0]);
                    }


                    var mpnrResult = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrId).FirstOrDefault();

                    mpnrResult.Prefix = model.PnrInfoPrefix;
                    mpnrResult.FirstName = model.PnrInfoFirstName;
                    mpnrResult.MiddleName = model.PnrInfoMiddleName;
                    mpnrResult.LastName = model.PnrInfoLastName;

                    if (models.PNRBookedList[0].TicketStatusId == 25)
                        mpnrResult.TicketStatusId = 27;


                    if (models.PNRBookedList[0].TicketStatusId == 33 && models.PNRBookedList[0].ServiceProviderId == 5)
                    {
                        mpnrResult.TicketStatusId = 24;
                    }

                    if (models.PNRBookedList[0].TicketStatusId == 34 && models.PNRBookedList[0].ServiceProviderId == 5)
                    {
                        mpnrResult.TicketStatusId = 28;
                    }

                    _entity.ApplyCurrentValues(mpnrResult.EntityKey.EntitySetName, mpnrResult);
                    _entity.SaveChanges();

                    var pnrResult = _entity.TBO_PNRs.Where(x => x.MPNRId == mpnrId).ToList();
                    int pnrcount = pnrResult.Count;



                    for (int i = 0; i < pnrcount; i++)
                    {
                        pnrResult[i].RecLoc = model.PNRDetails[i].PNR == null ? "" : model.PNRDetails[i].PNR;
                        pnrResult[i].PCC = model.PNRDetails[i].PCC;
                        if (models.PNRBookedList[0].TicketStatusId == 25)
                            pnrResult[i].TicketStatusId = 27;


                        _entity.ApplyCurrentValues(pnrResult[i].EntityKey.EntitySetName, pnrResult[i]);
                        _entity.SaveChanges();

                        long currentPNRId = pnrResult[i].PNRId;



                        var ticketResult = _entity.TBO_PNRTickets.Where(x => x.PNRId == currentPNRId).ToList();
                        int counter = 0;
                        int ticketCounter = 0;
                        foreach (var ticket in ticketResult)
                        {
                            OfflineBookFareDetailModel fare = new OfflineBookFareDetailModel();
                            if (i == 0)
                                fare = fareDetailsList.Where(x => (int)x.PaxType == ticket.TBO_Passengers.PassengerTypeId).FirstOrDefault();
                            else if (i == 1)
                                fare = rtnFareDetailsList.Where(x => (int)x.PaxType == ticket.TBO_Passengers.PassengerTypeId).FirstOrDefault();

                            //  var fare = fareDetailsList.Where(x => (int)x.PaxType == ticket.TBO_Passengers.PassengerTypeId).FirstOrDefault();

                            var ticketNo = models.PNRBookedList[0].PNRDetails[i].PassengerDetail.Where(x => x.FareDetail.PassengerId == ticket.PassengerId).ToList();
                            string extractedTicketNo = string.Empty;
                            if (ticketNo != null)
                            {
                                extractedTicketNo = ticketNo[0].FareDetail.TicketNumber;
                            }

                            ticket.TicketNumber = extractedTicketNo;

                            ticket.BaseFare = fare.BaseFare;
                            ticket.SellingBaseFare = fare.SellingBaseFare;
                            ticket.FSC = fare.FSC;
                            ticket.SellingFSC = fare.SellingFSC;
                            ticket.Tax = fare.Tax;
                            ticket.SellingTax = fare.SellingTax;
                            ticket.AdditionalTxnFee = fare.AdditionalTxnFee;
                            ticket.SellingAdditionalTxnFee = fare.SellingAdditionalTxnFee;
                            ticket.AirlineTransFee = counter == 0 ? fare.AirlineTransFee : 0;
                            ticket.SellingAirlineTransFee = counter == 0 ? fare.SellingAirlineTransFee : 0;

                            ticket.ServiceTax = fare.ServiceTax;
                            ticket.SellingServiceTax = fare.SellingServiceTax;

                            ticket.OtherCharges = fare.OtherCharges != null ? (double)fare.OtherCharges : 0;
                            ticket.SellingOtherCharges = (double)fare.SellingOtherCharges;

                            ticket.MarkupAmount = fare.MarkupAmount;
                            ticket.DiscountAmount = fare.DiscountAmount;
                            ticket.CommissionAmount = fare.CommissionAmount;
                            ticket.Remarks = model.PNRDetails[i].Remarks;

                            if (models.PNRBookedList[0].TicketStatusId == 25)
                                ticket.TicketStatusId = 27;

                            _entity.ApplyCurrentValues(ticket.EntityKey.EntitySetName, ticket);
                            _entity.SaveChanges();
                            counter++;
                            ticketCounter++;
                        }



                        var airlinePnrResult = _entity.TBO_PNRsegments.Where(x => x.PNRId == currentPNRId).ToList();
                        int airlinePNRCount = airlinePnrResult.Count;

                        for (int k = 0; k < airlinePNRCount; k++)
                        {

                            airlinePnrResult[k].AirlineRefNumber = model.PNRDetails[i].SegmentDetail[k].AirlineRefNumber == null ? "" : model.PNRDetails[i].SegmentDetail[k].AirlineRefNumber.ToUpper();
                            airlinePnrResult[k].FlightNumber = model.PNRDetails[i].SegmentDetail[k].FlightNumber;
                            airlinePnrResult[k].DepartDate = model.PNRDetails[i].SegmentDetail[k].DepartDate.Value;
                            airlinePnrResult[k].DepartTime = model.PNRDetails[i].SegmentDetail[k].DepartDate.Value.TimeOfDay;
                            airlinePnrResult[k].ArrivalDate = model.PNRDetails[i].SegmentDetail[k].ArrivalDate.Value;
                            airlinePnrResult[k].ArrivalTime = model.PNRDetails[i].SegmentDetail[k].ArrivalDate.Value.TimeOfDay;

                            airlinePnrResult[k].AirlineId = model.PNRDetails[i].SegmentDetail[k].AirlineId;
                            airlinePnrResult[k].DepartCityId = model.PNRDetails[i].SegmentDetail[k].DepartCityId;
                            airlinePnrResult[k].ArrivalCityId = model.PNRDetails[i].SegmentDetail[k].ArrivalCityId;
                            airlinePnrResult[k].Baggage = model.PNRDetails[i].SegmentDetail[k].Baggage;


                            _entity.ApplyCurrentValues(airlinePnrResult[k].EntityKey.EntitySetName, airlinePnrResult[k]);
                            _entity.SaveChanges();

                            //Saving baggage inforation
                            Edit_TBO_Air_PassengerBaggage(1, airlinePnrResult[k].SegmentId, model.PNRDetails[i].SegmentDetail[k].Baggage);
                        }

                        var airlineSectorResult = _entity.TBO_PNRsectors.Where(x => x.PNRId == currentPNRId).ToList();
                        int airlinesectorPNRCount = airlineSectorResult.Count;
                        for (int s = 0; s < airlinesectorPNRCount; s++)
                        {
                            airlineSectorResult[s].PlatingCarrierId = model.PNRDetails[i].SegmentDetail[s].AirlineId;

                            airlineSectorResult[s].DepartDate = model.PNRDetails[i].SegmentDetail[s].DepartDate.Value;
                            airlineSectorResult[s].DepartTime = model.PNRDetails[i].SegmentDetail[s].DepartDate.Value.TimeOfDay;
                            airlineSectorResult[s].ArriveDate = model.PNRDetails[i].SegmentDetail[s].ArrivalDate.Value;
                            airlineSectorResult[s].ArriveTime = model.PNRDetails[i].SegmentDetail[s].ArrivalDate.Value.TimeOfDay;
                            airlineSectorResult[s].DepartCityId = model.PNRDetails[i].SegmentDetail[s].DepartCityId;
                            airlineSectorResult[s].DestinationCityId = model.PNRDetails[i].SegmentDetail[s].ArrivalCityId;

                        }


                        var passengerResult = _entity.TBO_Passengers.Where(x => x.PNRId == currentPNRId).ToList();
                        int passengerCount = passengerResult.Count;
                        for (int p = 0; p < passengerCount; p++)
                        {
                            passengerResult[p].PassengerTypeId = Convert.ToInt16(model.PNRDetails[i].PassengerDetail[p].PaxType);
                            //passengerResult[p].Prefix = model.PNRDetails[i].PassengerDetail[p].Prefix.ToString();
                            passengerResult[p].Prefix = model.PNRDetails[i].PassengerDetail[p].PrefixId;
                            passengerResult[p].FirstName = model.PNRDetails[i].PassengerDetail[p].FirstName;
                            passengerResult[p].MiddleName = model.PNRDetails[i].PassengerDetail[p].MiddleName;
                            passengerResult[p].LastName = model.PNRDetails[i].PassengerDetail[p].LastName;

                            if (model.PNRDetails[i].PassengerDetail[p].DOB != null)
                                passengerResult[p].DOB = Convert.ToDateTime(model.PNRDetails[i].PassengerDetail[p].DOB);

                            _entity.ApplyCurrentValues(passengerResult[p].EntityKey.EntitySetName, passengerResult[p]);
                            _entity.SaveChanges();

                        }



                    }
                    ts.Complete();
                }


                bool iseticketuploaded = UploadFile(models.ticket, mpnrId);
                if (iseticketuploaded == true)
                {
                    UpdateTBO_MasterPNRs(mpnrId);
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

        public void Edit_TBO_Air_PassengerBaggage(int paxTypeId, Int64 segmentId, string baggage)
        {
            var baggageList = _entity.TBO_Air_PassengerBaggage.Where(x => x.SegmentId == segmentId);

            foreach (var bag in baggageList)
            {
                if (!string.IsNullOrEmpty(baggage))
                {
                    bag.PassengerTypeId = 1;
                    bag.SegmentId = segmentId;
                    bag.Baggage = baggage;
                    _entity.ApplyCurrentValues(bag.EntityKey.EntitySetName, bag);
                    _entity.SaveChanges();
                }
            }
        }

        public void Save_TBO_Air_PassengerBaggage(int paxTypeId, Int64 segmentId, string baggage)
        {
            TBO_Air_PassengerBaggage bag = new TBO_Air_PassengerBaggage();
            bag.PassengerTypeId = 1;
            bag.SegmentId = segmentId;
            bag.Baggage = baggage;

            _entity.AddToTBO_Air_PassengerBaggage(bag);
            _entity.SaveChanges();
        }
        public void IssueTicket(long mpnrId, int AppUserId)
        {
            EntityModel _entity = new EntityModel();
            _entity.TBO_Air_IssueTickets(mpnrId, AppUserId);
            _entity.SaveChanges();
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
        public ServiceResponse Delete(long id, int MakerId, int ServiceProviderId)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _entity.Air_CancelTickets(id, null, null, false, 1, MakerId, ServiceProviderId);
                    _entity.SaveChanges();

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



        public bool Abacus_IssueTicket(Int64 PNRId, int UserId)
        {
            EntityModel ent = new EntityModel();

            string GDSRefNo = ent.TBO_PNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().RecLoc;
            Abacus.Ticketing.TicketIssueManager manager = new Abacus.Ticketing.TicketIssueManager();
            try
            {

                var retriveData = Abacus.BookingService.BookingManager.RetrievePNR(GDSRefNo, null);

                if (string.IsNullOrEmpty(retriveData.PassengerList.FirstOrDefault().TicketNumber))
                {
                    retriveData = manager.IssueTicket(GDSRefNo, (decimal)0);
                }

                int TicketStatusId = ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().TicketStatusId;

                if (TicketStatusId != 4 || TicketStatusId != 16 || TicketStatusId != 19)
                {
                    var dbPassengerList = ent.TBO_Passengers.Where(x => x.MPNRId == PNRId && x.IsDeleted == false).ToArray();
                    int paxCounter = 0;
                    foreach (var item in retriveData.PassengerList)
                    {
                        TBO_Passengers pass = dbPassengerList.ElementAt(paxCounter);
                        TBO_PNRTickets tickets = pass.TBO_PNRTickets.FirstOrDefault();

                        tickets.TicketNumber = item.TicketNumber;

                        ent.ApplyCurrentValues(tickets.EntityKey.EntitySetName, tickets);
                        ent.SaveChanges();
                        paxCounter++;
                    }
                    ent.TBO_Air_IssueTickets(PNRId, UserId);
                    UpdateTicketStatus(32, PNRId, UserId);
                }
                return true;
            }
            catch (GDS.GDSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Galileo_IssueTicket(Int64 PNRId, int UserId)
        {
            EntityModel ent = new EntityModel();
            string GDSRefNo = ent.TBO_PNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().RecLoc;
            Galileo.Ticketing.TicketIssueManager manager = new Galileo.Ticketing.TicketIssueManager();

            try
            {
                bool isIssued = false;
                bool isFromTerminal = true;
                bool doOnlineIssue = false;

                Galileo.PnrService.BookingManager tktBokManager = new Galileo.PnrService.BookingManager();
                var retriveData = tktBokManager.RetrievePNR(GDSRefNo);

                if (retriveData.TicketList.Count > 0)
                {
                    if (string.IsNullOrEmpty(retriveData.TicketList[0]))
                    {
                        doOnlineIssue = true;
                    }
                }
                else
                    doOnlineIssue = true;

                if (doOnlineIssue)
                {
                    if (!IsPNRAlreadyIssued(GDSRefNo))
                    {
                        isIssued = manager.IssueTicket(GDSRefNo);
                        retriveData = tktBokManager.RetrievePNR(GDSRefNo);
                        isFromTerminal = false;
                    }
                }

                int TicketStatusId = ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().TicketStatusId;

                if (TicketStatusId != 4 || TicketStatusId != 16 || TicketStatusId != 19 || TicketStatusId == 27 || TicketStatusId != 29 || TicketStatusId != 32)
                {
                    var dbPassengerList = ent.TBO_Passengers.Where(x => x.MPNRId == PNRId && x.IsDeleted == false).ToArray();
                    int paxCounter = 0;
                    foreach (var item in retriveData.TicketList)
                    {
                        TBO_Passengers pass = dbPassengerList.ElementAt(paxCounter);
                        TBO_PNRTickets tickets = pass.TBO_PNRTickets.FirstOrDefault();
                        tickets.TicketNumber = item;
                        ent.ApplyCurrentValues(tickets.EntityKey.EntitySetName, tickets);
                        paxCounter++;
                    }

                    var segments = ent.TBO_PNRsegments.Where(x => x.MPNRId == PNRId);
                    foreach (var segment in segments)
                    {
                        var vendorRecordLocatorList = retriveData.VendorRecordLocatorList.FirstOrDefault();
                        if (vendorRecordLocatorList != null)
                        {
                            segment.AirlineRefNumber = vendorRecordLocatorList.RecordLocator;
                        }
                        ent.ApplyCurrentValues(segment.EntityKey.EntitySetName, segment);

                    }
                    ent.SaveChanges();
                    ent.TBO_Air_IssueTickets(PNRId, UserId);

                    if (!isFromTerminal)
                        UpdateTicketStatus(32, PNRId, UserId);
                    else
                    {
                        Air_UpdateTicketStatusId(PNRId, "ISSUEPNR", false, UserId);
                    }
                }




                ////Start
                //int TicketStatusId = ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().TicketStatusId;
                //if (TicketStatusId != 4 || TicketStatusId != 16 || TicketStatusId != 19 || TicketStatusId == 27)
                //{
                //    var dbPassengerList = ent.TBO_Passengers.Where(x => x.MPNRId == PNRId && x.IsDeleted == false).ToArray();
                //    int paxCounter = 0;
                //    int noofPax = ent.TBO_Passengers.Where(x => x.MPNRId == PNRId).Count();
                //    List<string> ticketsList = new List<string>();

                //    for (int i = 1; i <= noofPax; i++)
                //    {
                //        ticketsList.Add("AAAAAAAAAAAA" + i);
                //    }

                //    foreach (var item in ticketsList)
                //    {
                //        TBO_Passengers pass = dbPassengerList.ElementAt(paxCounter);
                //        TBO_PNRTickets tickets = pass.TBO_PNRTickets.FirstOrDefault();
                //        tickets.TicketNumber = item;
                //        ent.ApplyCurrentValues(tickets.EntityKey.EntitySetName, tickets);
                //        paxCounter++;
                //    }
                //    ent.SaveChanges();
                //    ent.TBO_Air_IssueTickets(PNRId, UserId);
                //}
                ////End
                //UpdateTicketStatus(32, PNRId, UserId);

                return isIssued;
            }
            catch (GDS.GDSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void UpdateTicketStatus(int ticketStatusId, Int64 mPnrId, int UserId)
        {
            EntityModel entity = new EntityModel();
            entity.Air_SetTicketStatusId(mPnrId, ticketStatusId, UserId);
        }

        public bool Air_UpdateTicketStatusId(Int64 MPNRId, string task, bool hasException, int MakerId)
        {
            EntityModel entity = new EntityModel();
            entity.Air_UpdateTicketStatusId(MPNRId, task, hasException, MakerId);
            return true;
        }

        public bool IsPNRAlreadyIssued(string recLoc)
        {
            var result = _entity.TBO_PNRs.Where(x => x.RecLoc == recLoc);
            if (result != null)
            {
                Int64 ticketStatusId = result.FirstOrDefault().TicketStatusId.Value;
                if (ticketStatusId == 4 || ticketStatusId == 16 || ticketStatusId == 19 || ticketStatusId == 27 || ticketStatusId == 32)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public bool Yeti_IssueTicket(Int64 PNRId, int UserId)
        {
            EntityModel ent = new EntityModel();

            string GDSRefNo = ent.TBO_PNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().RecLoc;
            DomesticFlights.BookService.IssueService manager = new DomesticFlights.BookService.IssueService();
            try
            {
                var result = manager.IssueYetiTicket(GDSRefNo);

                if (result.IsTicketIssued)
                {
                    var passengerInfo = manager.GetPassengerDetail(GDSRefNo);

                    int TicketStatusId = ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().TicketStatusId;

                    if (TicketStatusId != 4 || TicketStatusId != 16 || TicketStatusId != 19)
                    {
                        var dbPassengerList = ent.TBO_Passengers.Where(x => x.MPNRId == PNRId && x.IsDeleted == false).ToArray();
                        int paxCounter = 0;
                        foreach (var item in dbPassengerList)
                        {
                            TBO_Passengers pass = dbPassengerList.ElementAt(paxCounter);
                            TBO_PNRTickets tickets = pass.TBO_PNRTickets.FirstOrDefault();

                            tickets.TicketNumber = passengerInfo[paxCounter].legI;

                            ent.ApplyCurrentValues(tickets.EntityKey.EntitySetName, tickets);
                            ent.SaveChanges();
                            paxCounter++;
                        }
                    }
                }
                ent.TBO_Air_IssueTickets(PNRId, UserId);
                return result.IsTicketIssued;
            }
            catch (GDS.GDSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetRecLoc(Int64 MPnrid)
        {
            string RecLoc = _entity.TBO_PNRs.Where(x => x.MPNRId == MPnrid).Select(x => x.RecLoc).FirstOrDefault();
            return RecLoc;
        }

        public void Abacus_CancelTicket(Int64 PNRId, int UserId)
        {
            EntityModel ent = new EntityModel();
            var result = ent.TBO_PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault();
            string GDSRefNo = result.RecLoc;
            try
            {
                if (Abacus.BookingService.BookingManager.CancelPNR(GDSRefNo, "Arihant Holidays"))
                    ent.Air_CancelTickets(PNRId, 0, 0, false, 1, UserId, 3);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CancelTicket(Int64 PNRId, int UserId, int serviceProviderId)
        {
            EntityModel ent = new EntityModel();
            string GDSRefNo = ent.TBO_PNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().RecLoc;
            try
            {
                if (Abacus.BookingService.BookingManager.CancelPNR(GDSRefNo, "Arihant Holidays"))
                    ent.Air_CancelTickets(PNRId, 0, 0, false, 1, 1, serviceProviderId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public SelectList GetCitiesByCityTypeId()
        {
            var result = _entity.AirlineCities.OrderBy(x => x.CityCode);

            return new SelectList(result, "CityID", "CityCode");
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

                        string filename = strTimeStamp + "_" + mPnrId + ".zip";
                        eTicketFile.SaveAs(photoDirectory + "/" + filename);
                        isSaved = true;
                        break;
                }
            }
            return isSaved;
        }

        public string GetLocationToSaveFile()
        {
            return WebConfigurationManager.AppSettings["OfflineTicketsPath"];
        }


        public void UpdateTBO_MasterPNRs(Int64 mPnrId)
        {
            TBO_MasterPNRs result = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mPnrId).FirstOrDefault();



            result.isTicketUploaded = true;

            _entity.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            _entity.SaveChanges();
        }


        public bool Save(OfflineBookViewModel models, double totalFare)
        {
            List<OfflineBookFareDetailModel> fareDetailsList = new List<OfflineBookFareDetailModel>();


            foreach (var fare in models.PNRDetails[0].PassengerDetail)
            {
                fareDetailsList.Add(fare.FareDetail);
            }

            try
            {
                int confirmTicketstatus = 14;
                var model = models;
                long masterpnr = 0;

                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    ATLTravelPortal.Areas.Airline.Repository.GeneralProvider generalProvider = new GeneralProvider();
                    var agent = generalProvider.GetAgents(model.UserDetail.AgentId);
                    bool isByPassDealByBranch = generalProvider.GetBranchSettings(agent.BranchOfficeId, 12);
                    bool isByPassDealByDistrubutor = generalProvider.GetDistributorSettings(agent.DistributorId, 13);

                    System.Data.Objects.ObjectParameter BranchaDeal = new System.Data.Objects.ObjectParameter("Amount", 0);
                    System.Data.Objects.ObjectParameter DistributorDeal = new System.Data.Objects.ObjectParameter("Amount", 0);

                    var currency = generalProvider.GetCurrencyByCode(fareDetailsList.FirstOrDefault().Currency);

                    //while saveing only feed basefare+markup amount to get deal of branch and distributor.

                    var branchDealAmount = _entity.Air_GetBranchDeal
                                        (agent.DistributorId,
                                            model.PNRDetails[0].SegmentDetail.FirstOrDefault().AirlineId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().DepartCityId,
                                             model.PNRDetails[0].SegmentDetail.FirstOrDefault().ArrivalCityId, false, totalFare, currency.CurrencyId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().BIC, BranchaDeal);


                    var distributorDealAmount = _entity.Air_GetDistrubutorDeal
                                        (agent.AgentId,
                                             model.PNRDetails[0].SegmentDetail.FirstOrDefault().AirlineId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().DepartCityId,
                                             model.PNRDetails[0].SegmentDetail.FirstOrDefault().ArrivalCityId, false, totalFare, currency.CurrencyId, model.PNRDetails[0].SegmentDetail.FirstOrDefault().BIC, DistributorDeal);


                    var mpnrDetail = new TBO_MasterPNRs
                    {
                        SessionId = model.UserDetail.SessionId.ToString(),
                        AgentId = model.UserDetail.AgentId,

                        Prefix = model.PNRDetails[0].PnrInfoPrefix.ToString(),

                        FirstName = model.PNRDetails[0].PnrInfoFirstName.ToUpper(),

                        MiddleName = model.PNRDetails[0].PnrInfoMiddleName == null ? "" : model.PNRDetails[0].PnrInfoMiddleName.ToUpper(),

                        LastName = model.PNRDetails[0].PnrInfoLastName.ToUpper(),
                        TicketStatusId = confirmTicketstatus,
                        Email = "reservation@arihantholidays.com",
                        Phone = model.PNRDetails[0].PassengerDetail[0].Phone == null ? "" : model.PNRDetails[0].PassengerDetail[0].Phone,
                        Address = "2nd Floor, Buddha Complex, Swayambhu, Kathmandu, Nepal",
                        CreatedBy = model.UserDetail.AppUserId,
                        CreatedDate = DateTime.UtcNow,
                        IssuedDate = DateTime.UtcNow,
                        DispatchedDate = null,
                        ServiceProviderId = Convert.ToInt32(models.PNRDetails[0].BookingSource),//pnrData.BookingSource,
                        isBranchByPassDeal = isByPassDealByBranch,
                        isDistributorByPassDeal = isByPassDealByDistrubutor
                    };
                    _entity.AddToTBO_MasterPNRs(mpnrDetail);
                    _entity.SaveChanges();

                    mpnrDetail.BookingReference = "AH" + RandomGenerator.GenerateRandomAlphanumeric() + mpnrDetail.MPNRId;
                    _entity.ApplyCurrentValues(mpnrDetail.EntityKey.EntitySetName, mpnrDetail);
                    _entity.SaveChanges();

                    masterpnr = mpnrDetail.MPNRId;

                    foreach (var pnrData in model.PNRDetails)
                    {
                        var pnrDetail = new TBO_PNRs
                        {
                            MPNRId = mpnrDetail.MPNRId,
                            BookingId = 0,
                            TicketStatusId = confirmTicketstatus,
                            RecLoc = pnrData.PNR == null ? "" : pnrData.PNR.ToUpper(),
                            PCC = pnrData.PCC == null ? "" : pnrData.PCC.ToUpper(),


                        };

                        _entity.AddToTBO_PNRs(pnrDetail);
                        _entity.SaveChanges();

                        var sectorDetail = new TBO_PNRsectors
                        {
                            MPNRId = mpnrDetail.MPNRId,
                            PNRId = pnrDetail.PNRId,
                            PlatingCarrierId = pnrData.SegmentDetail.FirstOrDefault().AirlineId,
                            DepartCityId = pnrData.SegmentDetail.FirstOrDefault().DepartCityId,
                            // DepartCityId = pnrData.SegmentDetail.FirstOrDefault().hdfDepartureCityId,
                            DepartDate = pnrData.SegmentDetail.FirstOrDefault().DepartDate.Value,
                            DepartTime = pnrData.SegmentDetail.FirstOrDefault().DepartTime.Value,
                            DestinationCityId = pnrData.SegmentDetail.Last().ArrivalCityId,
                            // DestinationCityId = pnrData.SegmentDetail.Last().hdfArrivalCityId,
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
                                //  DepartCityId = seg.hdfDepartureCityId,
                                DepartDate = seg.DepartDate.Value,
                                DepartTime = seg.DepartTime.Value,
                                ArrivalCityId = seg.ArrivalCityId,
                                // ArrivalCityId = seg.hdfArrivalCityId,
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

                                FareBasis = null,
                                FlightKey = null,
                                NVB = null,
                                NVA = null,

                            };

                            _entity.AddToTBO_PNRsegments(segmentDetail);
                            _entity.SaveChanges();

                            //Saving baggage inforation
                            Save_TBO_Air_PassengerBaggage(1, segmentDetail.SegmentId, seg.Baggage);
                        }

                        foreach (var paxData in pnrData.PassengerDetail)
                        {

                            var paxDetail = new TBO_Passengers();
                            paxDetail.PNRId = pnrDetail.PNRId;
                            paxDetail.MPNRId = mpnrDetail.MPNRId;
                            paxDetail.Prefix = paxData.Prefix.ToString();
                            paxDetail.FirstName = paxData.FirstName.ToUpper();
                            paxDetail.MiddleName = paxData.MiddleName == null ? "" : paxData.MiddleName.ToUpper();
                            paxDetail.LastName = paxData.LastName.ToUpper();
                            paxDetail.Gender = "N/A";
                            if (paxDetail.DOB != null)
                                paxDetail.DOB = Convert.ToDateTime(paxData.DOB);
                            paxDetail.Nationality = paxData.NationalityId;
                            paxDetail.Country = paxData.PassportIssuedCountryId;
                            paxDetail.PassportNumber = paxData.PassportNumber;
                            paxDetail.PassportExpDate = paxData.PassportExpDate;
                            paxDetail.Phone = paxData.Phone;
                            paxDetail.Email = "reservation@arihantholidays.com";
                            paxDetail.PassengerTypeId = (int)paxData.PaxType;
                            paxDetail.FFAirline =
                                paxData.FrequentFlyerAirlineCode != null
                                    ? _entity.Airlines.Where(
                                        x => x.AirlineCode == paxData.FrequentFlyerAirlineCode).
                                            Select(y => y.AirlineId).FirstOrDefault()
                                    : 0;
                            paxDetail.FFNumber = paxData.FrequentFlyerNo != "" ? paxData.FrequentFlyerNo : null;
                            paxDetail.DOCA = null;
                            paxDetail.SSR = paxData.Meal != null ? paxData.Meal.Code : null;
                            paxDetail.SSRDescription =
                                paxData.Meal != null
                                    ? paxData.Meal.Description = paxData.Meal.Code
                                    : null;
                            paxDetail.SeatName = paxData.Seat != null ? paxData.Seat.Code : null;
                            paxDetail.SeatDescription =
                                paxData.Seat != null ? paxData.Seat.Description : null;
                            paxDetail.UpdatedBy = 1;
                            paxDetail.UpdatedDate = DateTime.Now;

                            _entity.AddToTBO_Passengers(paxDetail);
                            _entity.SaveChanges();

                            var fare = fareDetailsList.Where(x => x.FarePaxType == paxData.PaxType).FirstOrDefault();


                            var fareDetail = new TBO_PNRTickets
                            {
                                PNRId = pnrDetail.PNRId,
                                MPNRId = mpnrDetail.MPNRId,
                                PassengerId = paxDetail.PassengerId,
                                TicketNumber = paxData.FareDetail.TicketNumber,
                                AdditionalTxnFee = fare.SellingAdditionalTxnFee == 0.0 ? 0 : fare.SellingAdditionalTxnFee,
                                AirlineTransFee = 0,
                                BaseFare = fare.BaseFare == 0 ? 0 : fare.BaseFare,
                                Tax = fare.Tax == 0 ? 0 : fare.Tax,
                                OtherCharges = (double)fare.OtherCharges,
                                ServiceTax = fare.ServiceTax,
                                MarkupAmount = fare.MarkupAmount,
                                CommissionAmount = fare.CommissionAmount,
                                DiscountAmount = fare.DiscountAmount,
                                Currency = fare.Currency,
                                FSC = fare.FSC,
                                TicketStatusId = confirmTicketstatus,
                                TktId = fare.TicketId,
                                TourCode = fare.TourCode,
                                ValidatingAirline = fare.ValidatingAirline,
                                //Remarks = fare.Remarks,
                                Remarks = model.PNRDetails[0].Remarks,
                                CorporateCode = fare.CorporateCode,
                                EndorseMent = fare.Endorsement,
                                LCY_FX_Rate = fare.ExchangeRate,

                                //value with Rounding
                                SellingAdditionalTxnFee =
                                    Math.Ceiling(fare.SellingAdditionalTxnFee == 0 ? 0 : fare.SellingAdditionalTxnFee),
                                SellingAirlineTransFee = 0,
                                SellingBaseFare = Math.Ceiling(fare.SellingBaseFare),
                                SellingTax = Math.Ceiling(fare.SellingTax),
                                SellingOtherCharges =
                                    Math.Ceiling((double)fare.OtherCharges),
                                SellingServiceTax =
                                    Math.Ceiling(fare.ServiceTax),
                                SellingFSC = Math.Ceiling(fare.SellingFSC),
                                BranchDealAmount = (double)BranchaDeal.Value,
                                DistrubutorDealAmount = (double)DistributorDeal.Value

                            };


                            _entity.AddToTBO_PNRTickets(fareDetail);
                            _entity.SaveChanges();

                        }
                    }

                    ts.Complete();
                }

                _entity.SaveChanges();
                bool iseticketuploaded = UploadFile(model.ticket, masterpnr);
                if (iseticketuploaded == true)
                {
                    UpdateTBO_MasterPNRs(masterpnr);
                }
                IssueTicket(masterpnr, model.UserDetail.AppUserId);
                _entity.Air_UpdateTicketStatusId(masterpnr, "ISSUEPNR", false, model.UserDetail.AppUserId);
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<AirlineCities> GetAirlineCity(string AirlineCityName, int maxResult)
        {
            return GetAllAirlineCityList(AirlineCityName, maxResult).ToList();
        }
        public IEnumerable<AirlineCities> GetAllAirlineCityList(string AirlineCityNameCode, int maxResult)
        {

            return _entity.AirlineCities.Where(x => ((x.CityName.ToLower().Contains(AirlineCityNameCode) ||
                x.CityName.ToLower().Contains(AirlineCityNameCode) ||
                x.CityCode.ToUpper().Contains(AirlineCityNameCode) ||
                x.CityCode.ToUpper().Contains(AirlineCityNameCode.ToUpper())))).Take(maxResult).ToList().Select(x =>
                   new AirlineCities { CityName = x.CityName, CityID = x.CityID, CityCode = x.CityCode }
                );
        }


        public List<PassengerTypes> GetPassengerList()
        {
            return _entity.PassengerTypes.ToList();
        }

        public int GetTicketStatus(int mpnrid)
        {
            int ticketstatusid = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrid).Select(x => x.TicketStatusId).FirstOrDefault();
            return ticketstatusid;
        }



        public string GetTicketStatusName(int id)
        {
            string result = _entity.TicketStatus.Where(x => x.ticketStatusId == id).Select(x => x.ticketStatusName).FirstOrDefault();
            return result;
        }


        public IEnumerable<SelectListItem> GetCityList()
        {
            List<AirlineCities> all = GetCities().ToList();
            var AirlineCityList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CityCode,
                    Value = item.CityID.ToString()
                };
                AirlineCityList.Add(teml);
            }
            return AirlineCityList.AsEnumerable();
        }

        public IQueryable<AirlineCities> GetCities()
        {
            return _entity.AirlineCities.OrderBy(xx => xx.CityName).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetAirlinesList()
        {
            List<Airlines> all = GetAirlines().ToList();
            var AirlinesList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AirlineCode,
                    Value = item.AirlineId.ToString()
                };
                AirlinesList.Add(teml);
            }
            return AirlinesList.AsEnumerable();
        }

        public IQueryable<Airlines> GetAirlines()
        {
            return _entity.Airlines.OrderBy(xx => xx.AirlineName).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetPassengerTypeList()
        {
            List<PassengerTypes> all = GetPassengerTypes().ToList();
            var PassengerTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.PassengerTypeName,
                    Value = item.PassengerTypeId.ToString()
                };
                PassengerTypeList.Add(teml);
            }
            return PassengerTypeList.AsEnumerable();
        }

        public IQueryable<PassengerTypes> GetPassengerTypes()
        {
            return _entity.PassengerTypes.OrderBy(xx => xx.PassengerTypeName).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetPassengerPrefixList()
        {
            IEnumerable<SelectListItem> Prefixlist = new List<SelectListItem>{
                                      new  SelectListItem { Text="Mr", Value="Mr"},
                                        new SelectListItem { Text = "Mrs", Value = "Mrs"},
                                        new SelectListItem { Text = "Ms", Value = "Ms"},
                                         new SelectListItem {Text = "Master", Value = "Master"},
                                            new SelectListItem { Text = "Miss", Value = "Miss"},
                                         
                                    };
            return Prefixlist.AsEnumerable();
        }


        public bool CheckDuplicateGDSPNR(string GDSPNR)
        {
            TBO_PNRs RECLOC = _entity.TBO_PNRs.Where(ii => ii.RecLoc == GDSPNR).FirstOrDefault();
            if (RECLOC != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void UpdateMasterPnrServiceProviderId(int serviceProviderId, Int64 masterPnrId)
        {
            var result = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == masterPnrId).FirstOrDefault();
            if (result != null)
            {
                result.ServiceProviderId = serviceProviderId;

                _entity.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                _entity.SaveChanges();
            }
        }

        public void UpdateMasterPnrTicketStatusID(OfflineBookViewModel model)
        {

            var result = model.PNRBookedList.FirstOrDefault();


            var mpnrResult = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == result.MPNRId).FirstOrDefault();
            if (model.PNRBookedList[0].TicketStatusId == 33 && mpnrResult.ServiceProviderId == 5)
            {
                mpnrResult.TicketStatusId = 24;
            }

            if (model.PNRBookedList[0].TicketStatusId == 34 && mpnrResult.ServiceProviderId == 5)
            {
                mpnrResult.TicketStatusId = 28;
            }

            _entity.ApplyCurrentValues(mpnrResult.EntityKey.EntitySetName, mpnrResult);
            _entity.SaveChanges();
        }

        public bool Buddha_IssueTicket(Int64 PNRId, int UserId)
        {
            EntityModel ent = new EntityModel();

            string GDSRefNo = ent.TBO_PNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().RecLoc;
            DomesticFlights.IssueTicketService.IssueTicketService issueTicketService = new DomesticFlights.IssueTicketService.IssueTicketService();
            BuddhaAir.ResponseData.IssueTicketResponse retriveData = new BuddhaAir.ResponseData.IssueTicketResponse();
            try
            {
                var ticketsToCheck = ent.TBO_PNRTickets.Where(x => x.MPNRId == PNRId).FirstOrDefault();
                if (string.IsNullOrEmpty(ticketsToCheck.TicketNumber))
                {
                    if (!string.IsNullOrEmpty(GDSRefNo))
                    {
                        retriveData = issueTicketService.SavePassengerDetails(GDSRefNo);
                    }

                    int TicketStatusId = ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().TicketStatusId;

                    if (TicketStatusId != 4 || TicketStatusId != 16 || TicketStatusId != 19)
                    {
                        var dbPassengerList = ent.TBO_Passengers.Where(x => x.MPNRId == PNRId && x.IsDeleted == false).ToArray();
                        int paxCounter = 0;
                        foreach (var item in retriveData)
                        {
                            TBO_Passengers pass = dbPassengerList.ElementAt(paxCounter);
                            TBO_PNRTickets tickets = pass.TBO_PNRTickets.FirstOrDefault();

                            tickets.TicketNumber = item.TicketNumber;

                            ent.ApplyCurrentValues(tickets.EntityKey.EntitySetName, tickets);
                            ent.SaveChanges();
                            paxCounter++;
                        }
                        if (retriveData != null && retriveData.Count > 0)
                        {
                            ent.TBO_Air_IssueTickets(PNRId, UserId);
                            UpdateTicketStatus(32, PNRId, UserId);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    ent.TBO_Air_IssueTickets(PNRId, UserId);
                    UpdateTicketStatus(32, PNRId, UserId);
                    return true;
                }
            }
            catch (GDS.GDSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public decimal GetTotalFareByMPNRID(long mpnrID)
        {
            var result = _entity.TBO_PNRTickets.Where(x => x.MPNRId == mpnrID);

            //var masterREsult = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrID).Select(x => x.isBranchByPassDeal && x.isDistributorByPassDeal).FirstOrDefault();

            var masterREsult = _entity.TBO_MasterPNRs.Where(x => x.MPNRId == mpnrID).FirstOrDefault();

            bool isBranchBypassDeal = masterREsult.isBranchByPassDeal;
            bool isdistributorByPassDeal = masterREsult.isDistributorByPassDeal;
            double BranchDealAmountValue = 0, DistrubutorDealAmountValue = 0;


            decimal totalFare = 0;
            foreach (var item in result)
            {
                if (!isBranchBypassDeal)
                    BranchDealAmountValue = item.BranchDealAmount;
                if (!isdistributorByPassDeal)
                    DistrubutorDealAmountValue = item.DistrubutorDealAmount;

                totalFare += Convert.ToDecimal(item.SellingAdditionalTxnFee + item.SellingAirlineTransFee + item.SellingBaseFare + item.SellingTax + item.SellingOtherCharges + item.SellingFSC + BranchDealAmountValue + DistrubutorDealAmountValue - item.DiscountAmount);
                BranchDealAmountValue = DistrubutorDealAmountValue = 0;
            }
            return totalFare;
        }



        public string GetCurrencyByMPNRID(long mpnrID)
        {
            var result = _entity.TBO_PNRTickets.Where(x => x.MPNRId == mpnrID).Select(x => x.Currency).FirstOrDefault();

            return result;
        }
    }
}

