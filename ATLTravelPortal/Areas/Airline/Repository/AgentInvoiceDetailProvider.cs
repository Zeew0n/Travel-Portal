using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using System.Text;
using HtmlAgilityPack;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AgentInvoiceDetailProvider
    {

        private int createdBy { get; set; }
        private DateTime createdDate { get; set; }

        EntityModel _ent = new EntityModel();
        public AgentInvoiceDetailProvider()
        { }

        public InvoiceViewModel GetInvoiceDetailMain(int masterPNRId)
        {
            var masterPnrDetails = _ent.TBO_MasterPNRs.Where(x => x.MPNRId == masterPNRId).FirstOrDefault();
            var OldPnrDetails = _ent.PNRs.Where(x => x.PNRId == masterPNRId).FirstOrDefault();

            if (masterPnrDetails == null)
            {

                GetPNRDetail(OldPnrDetails.AgentId, masterPNRId);
            }
            else
            {
                GetMasterPNRDetail(masterPnrDetails.AgentId, masterPNRId);
            }

            var pnrDetails = _ent.TBO_PNRs.Where(x=>x.MPNRId==masterPNRId).Select(x => x.PNRId).ToList();
            if (pnrDetails.Count == 0)
            {
                var pnrsDetail = _ent.PNRs.Where(x=>x.PNRId==masterPNRId).Select(x => x.PNRId).ToList();
                InvoiceViewModel viewModel = new InvoiceViewModel();

                viewModel.ServiceProviderId = OldPnrDetails.ServiceProviderId;

                int pnrcount = pnrsDetail.Count;

                foreach (var pnr in pnrsDetail)
                {
                    InvoicePNRDetailModel model = new InvoicePNRDetailModel();

                    var agentdetail = GetAgentDetail(OldPnrDetails.AgentId);

                    var pnrDetail = GetOldPNRDetailById((int)pnr);
                    var paxDetailByPNRId = GetOldPassengerDetails((int)pnrDetail.PNRId);

                    model.AgencyDetail = agentdetail;
                  //  model.BilledBy = "Travel Planner Pvt.Ltd";
                    model.TicketedToAgent = agentdetail.AgencyName;
                    model.BilledByAgent = agentdetail.AgencyName;
                    model.TicketedToPassenger = paxDetailByPNRId.FirstOrDefault().FirstName + paxDetailByPNRId.FirstOrDefault().LastName;
                    model.PNRId = (int)pnrDetail.PNRId;
                    model.PNR = pnrDetail.GDSRefrenceNumber;
                    model.InvoiceDate = createdDate;
                    model.VendorDetail = GetDistributorDetail(OldPnrDetails.AgentId);
                    model.BilledBy = model.VendorDetail.VendorName;
                    model.InvoiceNo = GetVoucherByTransactionRef(masterPNRId).ToString().PadLeft(4, '0');

                    InvoiceItineraryDetailModel itinerary = new InvoiceItineraryDetailModel();

                    var sectorDetail = GetOldPNRSectorDetail((int)pnrDetail.PNRId);
                    model.TravelDate = sectorDetail.DepartDate;
                    List<int> segDepCityIdList = new List<int>();
                    var segmentdetail = GetOldSegmentDetail((int)pnrDetail.PNRId);
                    int departcityid = 0;
                    int arrivecityid = 1;

                    foreach (PNRSegments segment in segmentdetail)
                    {
                        departcityid = segmentdetail[0].DepartCityId;
                        arrivecityid = segment.ArriveCityId;

                        segDepCityIdList.Add(segment.DepartCityId);

                        InvoiceItinerarySegment invoiceSegment = new InvoiceItinerarySegment();
                        var airlineDetail = GetAirlineDetailById(segment.AirlineId);
                        invoiceSegment.Airline = airlineDetail.AirlineName;
                        invoiceSegment.AirlineCode = airlineDetail.AirlineCode;
                        invoiceSegment.FlightNo = segment.FlightNumber;
                        invoiceSegment.Class = segment.BIC;
                        invoiceSegment.DepartureDate = segment.DepartDate.ToString();
                        itinerary.Segments.Add(invoiceSegment);
                    }

                    if (departcityid != arrivecityid)
                        model.Journey = "OneWay";
                    else
                    {
                        model.Journey = "RoundTrip";
                    }
                    string sector = string.Empty;
                    foreach (var cityId in segDepCityIdList)
                    {
                        sector += GetCityDetailsByCityId(cityId).CityCode + " - ";
                    }
                    if (model.Journey == "OneWay")
                        sector += GetCityDetailsByCityId(sectorDetail.DestinationCityId).CityCode;

                    if (model.Journey == "RoundTrip")
                        sector += GetCityDetailsByCityId(sectorDetail.DepartCityId).CityCode;
                    itinerary.Sector = sector;

                    double grossAmt = 0;
                    double discountAmt = 0;
                    double serviceTax = 0;
                    double transFee = 0;
                    var paxDetail = GetOldPassengerDetails((int)pnr);
                    int paxcounter = paxDetail.Count;
                    foreach (Passengers pax in paxDetail)
                    {
                        InvoicePassenger invPax = new InvoicePassenger();
                        invPax.PassengerName = pax.FirstName + " " + pax.MiddleName + " " + pax.LastName;
                        invPax.PassengerType = GetPassengerTypeById(pax.PassengerTypeId).PassengerTypeName;
                        var pnrtickets = GetOldPNRTickets((int)pax.PassengerId);
                        if (pnrtickets != null)
                        {
                            model.Currency = pnrtickets.Currency;
                            invPax.FxRate = pnrtickets.LCY_FX_Rate;
                            if (invPax.FxRate == 0)
                                invPax.FxRate = 1;
                            if (model.Currency != "USD")
                            {
                                invPax.Fare = (pnrtickets.Fare + pnrtickets.MarkupAmount) * invPax.FxRate;
                                invPax.OtherCharge = pnrtickets.FSC * invPax.FxRate;
                                invPax.FuelSurcharge = pnrtickets.FSC * invPax.FxRate;
                                invPax.ServiceCharge = pnrtickets.ServiceCharge * invPax.FxRate;
                                invPax.Tax = (pnrtickets.TaxAmount + pnrtickets.ServiceCharge + pnrtickets.FSC) * invPax.FxRate; //+ pnrtickets.MarkupAmount;
                                grossAmt += invPax.Fare + invPax.OtherCharge + invPax.Tax + invPax.FuelSurcharge;// + invPax.ServiceCharge
                                invPax.MarkupAmount = pnrtickets.MarkupAmount * invPax.FxRate;
                                model.AgentAirlineMarkUp = pnrtickets.MarkupAmount * invPax.FxRate;
                                discountAmt += pnrtickets.DiscountAmount * invPax.FxRate;
                            }
                            else
                            {
                                invPax.Fare = pnrtickets.Fare + pnrtickets.MarkupAmount;
                                invPax.OtherCharge = pnrtickets.FSC;
                                invPax.FuelSurcharge = pnrtickets.FSC;
                                invPax.ServiceCharge = pnrtickets.ServiceCharge;
                                invPax.Tax = pnrtickets.TaxAmount + pnrtickets.ServiceCharge + pnrtickets.FSC; //+ pnrtickets.MarkupAmount;
                                grossAmt += invPax.Fare + invPax.OtherCharge + invPax.Tax + invPax.FuelSurcharge;// + invPax.ServiceCharge
                                invPax.MarkupAmount = pnrtickets.MarkupAmount;
                                model.AgentAirlineMarkUp = pnrtickets.MarkupAmount;
                                discountAmt += pnrtickets.DiscountAmount;
                            }

                            itinerary.TicketNo = pnrtickets.TicketNumber;
                            invPax.TicketNo = pnrtickets.TicketNumber;

                            serviceTax += 0;
                            transFee += 0;

                            model.TicketStatusId = pnrtickets.TicketStatusId;
                        }
                        itinerary.PassengerDetail.Add(invPax);
                    }
                    model.ItineraryDetails.Add(itinerary);
                    model.GrossAmount = grossAmt;
                    string aaa = discountAmt.ToString();
                    if (!aaa.Contains("-"))
                    {
                        model.CommissionEarned = discountAmt;
                    }
                    if (aaa.Contains("-"))
                    {
                        string bbb = aaa.TrimStart('-');
                        model.TransactionFee = Convert.ToDouble(bbb) + transFee;
                    }
                    else
                    {
                        model.TransactionFee = transFee;
                    }
                    model.ServiceTax = serviceTax;
                    model.TaxDeductionAtSource = Math.Ceiling(discountAmt * 0.1);
                    model.NetAmount = model.GrossAmount - model.CommissionEarned + model.ServiceTax + model.TransactionFee;
                    model.NetReceivable = model.NetAmount;
                    viewModel.PNRDetails.Add(model);
                }
                return viewModel;
            }
            else
            {
                InvoiceViewModel viewModel = new InvoiceViewModel();

                viewModel.ServiceProviderId = masterPnrDetails.ServiceProviderId;

                int pnrcount = pnrDetails.Count;

                foreach (var pnr in pnrDetails)
                {
                    InvoicePNRDetailModel model = new InvoicePNRDetailModel();

                    var agentdetail = GetAgentDetail(masterPnrDetails.AgentId);

                    var pnrDetail = GetPNRDetailById((int)pnr);
                    var paxDetailByPNRId = GetPassengerDetails((int)pnrDetail.PNRId);

                    model.AgencyDetail = agentdetail;
                    //model.BilledBy = "Travel Planner Pvt.Ltd";
                    model.TicketedToAgent = agentdetail.AgencyName;
                    model.BilledByAgent = agentdetail.AgencyName;
                    model.TicketedToPassenger = paxDetailByPNRId.FirstOrDefault().FirstName + paxDetailByPNRId.FirstOrDefault().LastName;
                    model.PNRId = (int)pnrDetail.PNRId;
                    model.PNR = pnrDetail.RecLoc;
                    model.InvoiceDate = createdDate;
                    model.VendorDetail = GetDistributorDetail(masterPnrDetails.AgentId);
                    model.BilledBy = model.VendorDetail.VendorName;
                    model.InvoiceNo = GetVoucherByTransactionRef(masterPNRId).ToString().PadLeft(4, '0');

                    InvoiceItineraryDetailModel itinerary = new InvoiceItineraryDetailModel();

                    var sectorDetail = GetPNRSectorDetail((int)pnrDetail.PNRId);
                    model.TravelDate = sectorDetail.DepartDate;
                    List<int> segDepCityIdList = new List<int>();
                    var segmentdetail = GetSegmentDetail((int)pnrDetail.PNRId);
                    int departcityid = 0;
                    int arrivecityid = 1;

                    foreach (TBO_PNRsegments segment in segmentdetail)
                    {
                        departcityid = segmentdetail[0].DepartCityId;
                        arrivecityid = segment.ArrivalCityId;

                        segDepCityIdList.Add(segment.DepartCityId);

                        InvoiceItinerarySegment invoiceSegment = new InvoiceItinerarySegment();
                        var airlineDetail = GetAirlineDetailById(segment.AirlineId);
                        invoiceSegment.Airline = airlineDetail.AirlineName;
                        invoiceSegment.AirlineCode = airlineDetail.AirlineCode;
                        invoiceSegment.FlightNo = segment.FlightNumber;
                        invoiceSegment.Class = segment.BIC;
                        invoiceSegment.DepartureDate = segment.DepartDate.ToString();
                        itinerary.Segments.Add(invoiceSegment);
                    }

                    if (departcityid != arrivecityid)
                        model.Journey = "OneWay";
                    else
                    {
                        model.Journey = "RoundTrip";
                    }
                    string sector = string.Empty;
                    foreach (var cityId in segDepCityIdList)
                    {
                        sector += GetCityDetailsByCityId(cityId).CityCode + " - ";
                    }
                    if (model.Journey == "OneWay")
                        sector += GetCityDetailsByCityId(sectorDetail.DestinationCityId).CityCode;

                    if (model.Journey == "RoundTrip")
                        sector += GetCityDetailsByCityId(sectorDetail.DepartCityId).CityCode;
                    itinerary.Sector = sector;

                    double grossAmt = 0;
                    double discountAmt = 0;
                    double serviceTax = 0;
                    double agentServiceCharge = 0;
                    double transFee = 0;

                    double totalCalculatedDiscount = 0;
                    double totalSummedDiscount = 0;
                    double totalTranFee = 0;
                    var paxDetail = GetPassengerDetails((int)pnr);

                    int paxcounter = paxDetail.Count;
                    foreach (TBO_Passengers pax in paxDetail)
                    {
                        InvoicePassenger invPax = new InvoicePassenger();

                        invPax.PassengerName = pax.FirstName + " " + pax.MiddleName + " " + pax.LastName;
                        invPax.PassengerType = GetPassengerTypeById(pax.PassengerTypeId).PassengerTypeName;

                        var pnrtickets = GetPNRTickets((int)pax.PassengerId);
                        if (pnrtickets != null)
                        {
                            model.Currency = pnrtickets.Currency;
                            invPax.FxRate = pnrtickets.LCY_FX_Rate;
                            if (invPax.FxRate == 0)
                                invPax.FxRate = 1;
                            if (model.Currency != "USD")
                            {
                                invPax.Fare = pnrtickets.SellingBaseFare * invPax.FxRate;
                                invPax.OtherCharge = pnrtickets.SellingOtherCharges * invPax.FxRate;
                                invPax.FuelSurcharge = pnrtickets.SellingFSC * invPax.FxRate;
                                invPax.ServiceCharge = pnrtickets.ServiceCharge * invPax.FxRate;
                                if (viewModel.ServiceProviderId == 5)//TBO ALREADY CONTAIN FSC ON TAX
                                    invPax.Tax = (pnrtickets.SellingTax + pnrtickets.SellingAdditionalTxnFee) * invPax.FxRate; //+ pnrtickets.MarkupAmount;
                                else
                                    invPax.Tax = (pnrtickets.SellingTax + pnrtickets.SellingAdditionalTxnFee + pnrtickets.SellingFSC) * invPax.FxRate; //+ pnrtickets.MarkupAmount;
                                grossAmt += invPax.Fare + invPax.OtherCharge + invPax.Tax;// + invPax.ServiceCharge
                                invPax.MarkupAmount = pnrtickets.MarkupAmount * invPax.FxRate;
                                discountAmt += pnrtickets.DiscountAmount * invPax.FxRate;

                                totalCalculatedDiscount = pnrtickets.DiscountAmount > 0 ? pnrtickets.DiscountAmount : 0;

                                totalTranFee += (pnrtickets.DiscountAmount < 0 ? Math.Abs(pnrtickets.DiscountAmount) : 0);

                                if (masterPnrDetails.isBranchByPassDeal == false)
                                {
                                    totalCalculatedDiscount = pnrtickets.BranchDealAmount < 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0;
                                    totalTranFee += (pnrtickets.BranchDealAmount > 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0);
                                }
                                if (masterPnrDetails.isDistributorByPassDeal == false)
                                {
                                    totalCalculatedDiscount = pnrtickets.DistrubutorDealAmount < 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0;
                                    totalTranFee += (pnrtickets.DistrubutorDealAmount > 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0);
                                }


                                //totalCalculatedDiscount += (pnrtickets.DiscountAmount > 0 ? pnrtickets.DiscountAmount : 0 +
                                //          (pnrtickets.BranchDealAmount < 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0) +
                                //          (pnrtickets.DistrubutorDealAmount < 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0));
                                //totalTranFee += ((pnrtickets.DiscountAmount < 0 ? Math.Abs(pnrtickets.DiscountAmount) : 0) +
                                //         (pnrtickets.BranchDealAmount > 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0) +
                                //         (pnrtickets.DistrubutorDealAmount > 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0));

                                serviceTax += pnrtickets.SellingServiceTax * invPax.FxRate;
                                agentServiceCharge += (pnrtickets.ServiceCharge * invPax.FxRate);
                                transFee += pnrtickets.SellingAirlineTransFee * invPax.FxRate;
                                model.AgentAirlineMarkUp = pnrtickets.MarkupAmount * invPax.FxRate;


                            }
                            else
                            {
                                invPax.Fare = pnrtickets.SellingBaseFare;
                                invPax.OtherCharge = pnrtickets.SellingOtherCharges;
                                invPax.FuelSurcharge = pnrtickets.SellingFSC;
                                invPax.ServiceCharge = pnrtickets.ServiceCharge;
                                if (viewModel.ServiceProviderId == 5)//TBO ALREADY CONTAIN FSC ON TAX
                                    invPax.Tax = (pnrtickets.SellingTax + pnrtickets.SellingAdditionalTxnFee); //+ pnrtickets.MarkupAmount;
                                else
                                    invPax.Tax = (pnrtickets.SellingTax + pnrtickets.SellingAdditionalTxnFee + pnrtickets.SellingFSC); //+ pnrtickets.MarkupAmount;
                                grossAmt += invPax.Fare + invPax.OtherCharge + invPax.Tax;// + invPax.ServiceCharge
                                invPax.MarkupAmount = pnrtickets.MarkupAmount;
                                discountAmt += pnrtickets.DiscountAmount;

                                totalCalculatedDiscount = pnrtickets.DiscountAmount > 0 ? pnrtickets.DiscountAmount : 0;
                                totalTranFee = (pnrtickets.DiscountAmount < 0 ? Math.Abs(pnrtickets.DiscountAmount) : 0);
                                if (masterPnrDetails.isBranchByPassDeal == false)
                                {
                                    totalCalculatedDiscount = pnrtickets.BranchDealAmount < 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0;
                                    totalTranFee += (pnrtickets.BranchDealAmount > 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0);
                                }
                                if (masterPnrDetails.isDistributorByPassDeal == false)
                                {
                                    totalCalculatedDiscount = pnrtickets.DistrubutorDealAmount < 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0;
                                    totalTranFee += (pnrtickets.DistrubutorDealAmount > 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0);
                                }

                                //totalCalculatedDiscount += (pnrtickets.DiscountAmount > 0 ? pnrtickets.DiscountAmount : 0 +
                                //        (pnrtickets.BranchDealAmount < 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0) +
                                //        (pnrtickets.DistrubutorDealAmount < 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0));
                                //totalTranFee += ((pnrtickets.DiscountAmount < 0 ? Math.Abs(pnrtickets.DiscountAmount) : 0) +
                                //         (pnrtickets.BranchDealAmount > 0 ? Math.Abs(pnrtickets.BranchDealAmount) : 0) +
                                //         (pnrtickets.DistrubutorDealAmount > 0 ? Math.Abs(pnrtickets.DistrubutorDealAmount) : 0));


                                serviceTax += pnrtickets.SellingServiceTax;
                                agentServiceCharge += (pnrtickets.ServiceCharge);
                                transFee += pnrtickets.SellingAirlineTransFee;
                                model.AgentAirlineMarkUp = pnrtickets.MarkupAmount;

                            }
                            totalSummedDiscount += totalCalculatedDiscount;

                            itinerary.TicketNo = pnrtickets.TicketNumber;
                            invPax.TicketNo = pnrtickets.TicketNumber;


                            model.AgentAirlineMarkUp = pnrtickets.MarkupAmount;
                            model.TicketStatusId = pnrtickets.TicketStatusId;
                        }
                        itinerary.PassengerDetail.Add(invPax);
                    }
                    model.ItineraryDetails.Add(itinerary);
                    model.GrossAmount = grossAmt;

                    model.CommissionEarned = totalSummedDiscount;
                    model.TransactionFee = totalTranFee + transFee;

                    //string aaa = discountAmt.ToString();
                    //if (!aaa.Contains("-"))
                    //{
                    //    model.CommissionEarned = discountAmt;
                    //}
                    //if (aaa.Contains("-"))
                    //{
                    //    string bbb = aaa.TrimStart('-');
                    //    model.TransactionFee = Convert.ToDouble(bbb) + transFee;
                    //}
                    //else
                    //{
                    //    model.TransactionFee = transFee;
                    //}


                    model.ServiceTax = serviceTax;

                    model.TaxDeductionAtSource = Math.Ceiling(totalSummedDiscount * 0.1);

                    model.NetAmount = model.GrossAmount - model.CommissionEarned + model.ServiceTax + model.TransactionFee;
                    model.NetReceivable = model.NetAmount;
                    viewModel.PNRDetails.Add(model);
                }
                return viewModel;
            }
        }






        private void GetMasterPNRDetail(int agentId, int masterPNRId)
        {
            var masterPNRS = _ent.TBO_MasterPNRs.Where(x=>x.AgentId==agentId).ToList();
            var filterdPNRS = masterPNRS.FindAll(id => id.MPNRId == masterPNRId).ToList();

            var detail = filterdPNRS.Find(id => id.MPNRId == masterPNRId);
            createdBy = detail.CreatedBy;
            createdDate = detail.CreatedDate;

        }
        private InvoiceAgencyDetailModel GetAgentDetail(int agentid)
        {
            var agentDetail = _ent.Agents.Where(x=>x.AgentId==agentid).FirstOrDefault();

            InvoiceAgencyDetailModel agencyDetail = new InvoiceAgencyDetailModel();
            string zonename = agentDetail.Zones != null ? agentDetail.Zones.ZoneName : string.Empty;
            agencyDetail.AgencyName = agentDetail.AgentName;
            agencyDetail.Address = GetCountryById(agentDetail.NativeCountry).CountryName + " " +
                                  zonename;
            agencyDetail.PhoneNo = agentDetail.Phone;
            agencyDetail.PanNo = agentDetail.PanNo;



            var userDetail = GetUserDetailByCreatedId(createdBy);
            if (userDetail != null)
                agencyDetail.ContactPerson = userDetail.FullName;


            return agencyDetail;
        }

        private InvoiceAgencyDetailModel GetBranchDetail(int agentid)
        {
            var agentDetail = _ent.Agents.ToList().Find(id => id.AgentId == agentid);
            var branchDetail = _ent.BranchOffices.Where(x => x.BranchOfficeId == agentDetail.BranchOfficeId).FirstOrDefault();
            InvoiceAgencyDetailModel agencyDetail = new InvoiceAgencyDetailModel();

            string zonename = branchDetail.Zones != null ? branchDetail.Zones.ZoneName : string.Empty;
            agencyDetail.AgencyName = branchDetail.BranchOfficeName;
            agencyDetail.Address = zonename + " " + GetCountryById(branchDetail.NativeCountryId).CountryName;
            agencyDetail.PhoneNo = branchDetail.Phone;
            agencyDetail.PanNo = branchDetail.PanNo;
            var userDetail = GetUserDetailByCreatedId(createdBy);
            if (userDetail != null)
                agencyDetail.ContactPerson = userDetail.FullName;

            return agencyDetail;
        }

        private InvoiceVendorDetailModel GetDistributorDetail(int agentid)
        {
            var agentDetail = _ent.Agents.Where(x=>x.AgentId==agentid).FirstOrDefault();
            var distributorDetail = _ent.Distributors.Where(x => x.DistributorId == agentDetail.DistributorId).FirstOrDefault();
            InvoiceVendorDetailModel agencyDetail = new InvoiceVendorDetailModel();

            string zonename = distributorDetail.Zones != null ? distributorDetail.Zones.ZoneName : string.Empty;
            agencyDetail.VendorName = distributorDetail.DistributorName;
            agencyDetail.Address = zonename + " " + GetCountryById(distributorDetail.NativeCountryId).CountryName;
            agencyDetail.PhoneNo = distributorDetail.Phone;
            agencyDetail.PanNo = distributorDetail.PanNo;

            return agencyDetail;
        }


        private Countries GetCountryById(int countryId)
        {
            var country = _ent.Countries.ToList().Find(id => id.CountryId == countryId);
            return country;
        }

        private Zones GetZonesById(int? zoneId)
        {
            var zone = _ent.Zones.ToList().Find(id => id.ZoneId == zoneId);
            return zone;
        }

        private Districts GetDistrictsById(int districtId)
        {
            var district = _ent.Districts.ToList().Find(id => id.DistrictId == districtId);
            return district;
        }
        private UsersDetails GetUserDetailByCreatedId(int createdId)
        {
            var userdetail = _ent.UsersDetails.ToList().Find(id => id.CreatedBy == createdId);
            return userdetail;
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);

        }

        private InvoiceVendorDetailModel GetVendorDetail()
        {
            InvoiceVendorDetailModel detail = new InvoiceVendorDetailModel();
            detail.VendorName = "Travel Planner Pvt.Ltd.";
            detail.Address = " Halchowk, Shyambhu, Kathmandu, Nepal";
            detail.PhoneNo = @"Tel: +977-1-4033700, 4033800
                                Fax: +977-1-4033688";
            detail.Email = "accounts@travelplanner.com.np";
            detail.PanNo = "300057436";

            return detail;
        }
        private TBO_PNRs GetPNRDetailById(int pnr)
        {
            var pnrdetails = _ent.TBO_PNRs.Where(x=>x.PNRId==pnr).FirstOrDefault();
            return pnrdetails;
        }
        private List<TBO_Passengers> GetPassengerDetails(int PNRId)
        {
            var paxDetail = _ent.TBO_Passengers.Where(x=>x.PNRId==PNRId).ToList();
            return paxDetail;
        }
        private long GetVoucherByTransactionRef(long masterPNRId)
        {
            var pnrDetail = _ent.GL_Transactions.Where(id => id.RefNo == masterPNRId).FirstOrDefault();
            if (pnrDetail != null)
            {
                return pnrDetail.VoucherNo;
            }
            else
            {
                return 0;
            }

        }

        private TBO_PNRsectors GetPNRSectorDetail(int pnrId)
        {
            var sectorDetail = _ent.TBO_PNRsectors.Where(x=>x.PNRId==pnrId).FirstOrDefault();
            return sectorDetail;
        }

        private List<TBO_PNRsegments> GetSegmentDetail(int sectorId)
        {
            var segmentDetail = _ent.TBO_PNRsegments.Where(x=>x.PNRId==sectorId);
            return segmentDetail.ToList();
        }

        private Airlines GetAirlineDetailById(int airlineId)
        {
            var airlineDetail = _ent.Airlines.Where(x=>x.AirlineId==airlineId).FirstOrDefault();
            return airlineDetail;
        }

        private AirlineCities GetCityDetailsByCityId(int cityId)
        {
            var city = _ent.AirlineCities.Where(x=>x.CityID==cityId).FirstOrDefault();
            return city;
        }

        private PassengerTypes GetPassengerTypeById(int? paxId)
        {
            var paxType = _ent.PassengerTypes.Where(id => id.PassengerTypeId == paxId).FirstOrDefault();
            return paxType;
        }

        private TBO_PNRTickets GetPNRTickets(int paxId)
        {
            var pnrTickets = _ent.TBO_PNRTickets.Where(x=>x.PassengerId==paxId).FirstOrDefault();
            return pnrTickets;
        }


        public InvoiceViewModel GetInvoiceDetail(int agentId, int masterPNRId)
        {
            StringBuilder builder = new StringBuilder();

            GetMasterPNRDetail(agentId, masterPNRId);

            var masterPnrDetails = _ent.TBO_MasterPNRs.Where(x => x.MPNRId == masterPNRId).FirstOrDefault();


            var pnrDetails = _ent.TBO_PNRs.ToList().FindAll(id => id.MPNRId == masterPNRId).Select(x => x.PNRId).ToList();
            InvoiceViewModel viewModel = new InvoiceViewModel();

            int pnrcount = pnrDetails.Count;

            foreach (var pnr in pnrDetails)
            {
                InvoicePNRDetailModel model = new InvoicePNRDetailModel();

                var agentdetail = GetAgentDetail(agentId);

                var pnrDetail = GetPNRDetailById((int)pnr);
                var paxDetailByPNRId = GetPassengerDetails((int)pnrDetail.PNRId);

                model.AgencyDetail = agentdetail;
                model.BilledBy = "Travel Planner Pvt.Ltd";
                model.TicketedToAgent = agentdetail.AgencyName;

                model.BilledByAgent = agentdetail.AgencyName;
                model.TicketedToPassenger = paxDetailByPNRId.FirstOrDefault().FirstName + paxDetailByPNRId.FirstOrDefault().LastName;


                model.PNRId = (int)pnrDetail.PNRId;
                model.PNR = pnrDetail.RecLoc;

                model.InvoiceDate = createdDate;
                model.VendorDetail = GetVendorDetail();

                model.InvoiceNo = "AH" + GetVoucherByTransactionRef(masterPNRId).ToString().PadLeft(4, '0');

                InvoiceItineraryDetailModel itinerary = new InvoiceItineraryDetailModel();

                var sectorDetail = GetPNRSectorDetail((int)pnr);
                model.TravelDate = sectorDetail.DepartDate;

                List<int> segDepCityIdList = new List<int>();
                ;
                var segmentdetail = GetSegmentDetail((int)sectorDetail.SectorId);

                int departcityid = 0;
                int arrivecityid = 1;

                foreach (TBO_PNRsegments segment in segmentdetail)
                {
                    departcityid = segmentdetail[0].DepartCityId;
                    arrivecityid = segment.ArrivalCityId;

                    segDepCityIdList.Add(segment.DepartCityId);

                    InvoiceItinerarySegment invoiceSegment = new InvoiceItinerarySegment();
                    var airlineDetail = GetAirlineDetailById(segment.AirlineId);
                    invoiceSegment.Airline = airlineDetail.AirlineName;
                    invoiceSegment.AirlineCode = airlineDetail.AirlineCode;
                    invoiceSegment.FlightNo = segment.FlightNumber;
                    invoiceSegment.Class = segment.BIC;
                    itinerary.Segments.Add(invoiceSegment);
                }

                if (departcityid != arrivecityid)
                    model.Journey = "OneWay";

                else
                {
                    model.Journey = "RoundTrip";
                }

                string sector = string.Empty;
                foreach (var cityId in segDepCityIdList)
                {
                    sector += GetCityDetailsByCityId(cityId).CityCode + " - ";
                }
                if (model.Journey == "OneWay")
                    sector += GetCityDetailsByCityId(sectorDetail.DestinationCityId).CityCode;

                if (model.Journey == "RoundTrip")
                    sector += GetCityDetailsByCityId(sectorDetail.DepartCityId).CityCode;

                itinerary.Sector = sector;

                double grossAmt = 0;
                double discountAmt = 0;
                double serviceTax = 0;
                double transFee = 0;
                var paxDetail = GetPassengerDetails((int)pnr);
                int paxcounter = paxDetail.Count;
                foreach (TBO_Passengers pax in paxDetail)
                {
                    InvoicePassenger invPax = new InvoicePassenger();

                    invPax.PassengerName = pax.FirstName + " " + pax.MiddleName + " " + pax.LastName;
                    invPax.PassengerType = GetPassengerTypeById(pax.PassengerTypeId).PassengerTypeName;

                    var pnrtickets = GetPNRTickets((int)pax.PassengerId);
                    if (pnrtickets != null)
                    {
                        invPax.Fare = pnrtickets.SellingBaseFare;
                        invPax.OtherCharge = pnrtickets.SellingOtherCharges;
                        invPax.FuelSurcharge = pnrtickets.SellingFSC;
                        invPax.ServiceCharge = pnrtickets.ServiceCharge;
                        invPax.Tax = pnrtickets.SellingTax + pnrtickets.SellingAdditionalTxnFee + pnrtickets.MarkupAmount;
                        grossAmt += invPax.Fare + invPax.OtherCharge + invPax.Tax + invPax.FuelSurcharge;
                        invPax.MarkupAmount = pnrtickets.MarkupAmount;
                        itinerary.TicketNo = pnrtickets.TicketNumber;

                        discountAmt = pnrtickets.DiscountAmount;
                        serviceTax = pnrtickets.SellingServiceTax;
                        transFee += pnrtickets.SellingAirlineTransFee;
                        model.AgentAirlineMarkUp = pnrtickets.MarkupAmount;
                        model.TicketStatusId = pnrtickets.TicketStatusId;

                        model.NetAmount = pnrtickets.BaseFare - pnrtickets.DiscountAmount + pnrtickets.FSC + pnrtickets.Tax + pnrtickets.MarkupAmount +
                            pnrtickets.OtherCharges + pnrtickets.ServiceTax + pnrtickets.ServiceCharge + pnrtickets.AirlineTransFee
                            + pnrtickets.AdditionalTxnFee;

                    }
                    itinerary.PassengerDetail.Add(invPax);
                }
                model.ItineraryDetails.Add(itinerary);
                model.GrossAmount = grossAmt;
                model.CommissionEarned = discountAmt;
                model.ServiceTax = serviceTax;
                model.TransactionFee = transFee;


                model.NetReceivable = model.NetAmount;
                viewModel.PNRDetails.Add(model);


            }
            return viewModel;
        }

        public int GetMPNRIdFromPNRId(long? pnrid)
        {
            long? MPNRId = _ent.TBO_PNRs.Where(x => x.PNRId == pnrid).Select(x => x.MPNRId).FirstOrDefault();
            return (int)MPNRId;
        }




        public bool SendEmail(string to, string htmlTemplate, string subject)
        {
            try
            {
                _ent.CORE_SendEmails(to, string.Empty, string.Empty, subject, htmlTemplate, "HTML", "HIGH");
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public string RemoveSendEmailFields(string bodyHtml)
        {
            HtmlDocument htmDocument = new HtmlDocument();
            htmDocument.LoadHtml(bodyHtml);
            ATLTravelPortal.Helpers.ImagePathFixer pathFixer = new ATLTravelPortal.Helpers.ImagePathFixer();
            pathFixer.RemoveSendEmailFields(htmDocument);
            return htmDocument.DocumentNode.OuterHtml;
        }
        private List<Passengers> GetOldPassengerDetails(int PNRId)
        {
            var paxDetail = _ent.Passengers.Where(x=>x.PNRId==PNRId).ToList();
            return paxDetail;
        }
        private void GetPNRDetail(int agentId, int masterPNRID)
        {
            var PNR = _ent.PNRs.Where(x=>x.AgentId==agentId).ToList();
            var filteredPNRS = PNR.FindAll(id => id.PNRId == masterPNRID).ToList();
            var detail = filteredPNRS.Find(id => id.PNRId == masterPNRID);
            createdBy = detail.CreatedBy;
            createdDate = detail.CreatedDate;
        }

        private PNRs GetOldPNRDetailById(int pnr)
        {
            var pnrdetails = _ent.PNRs.Where(x=>x.PNRId==pnr).FirstOrDefault();
            return pnrdetails;
        }

        private PNRSectors GetOldPNRSectorDetail(int pnrId)
        {
            var sectorDetail = _ent.PNRSectors.Where(x=>x.PNRId==pnrId).FirstOrDefault();
            return sectorDetail;
        }

        private List<PNRSegments> GetOldSegmentDetail(int sectorId)
        {
            var segmentDetail = _ent.PNRSegments.Where(x=>x.PNRId==sectorId);
            return segmentDetail.ToList();
        }
        private Passengers GetOldPNRTickets(int paxId)
        {
            var pnrTickets = _ent.Passengers.Where(x=>x.PassengerId==paxId).FirstOrDefault();
            return pnrTickets;
        }


    }
}
