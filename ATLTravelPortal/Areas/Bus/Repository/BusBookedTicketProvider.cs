using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusBookedTicketProvider
    {
        EntityModel entity = new EntityModel();
        public bool CancelBookedBusTickets(Int64 busPNRId, int appUserId)
        {
            Bus_PNRs objToUpdate = entity.Bus_PNRs.Where(x => x.BusPNRId == busPNRId).FirstOrDefault();
            objToUpdate.TicketStatusId = 2;
            objToUpdate.UpdatedBy = appUserId;
            objToUpdate.UpdateDate = DateTime.UtcNow;
            entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            entity.SaveChanges();
            return true;
        }

        public IPagedList<BusPNRModel> GetDistributorPagedBookedTicketList(int? page, DateTime? fromDate, DateTime? toDate, int agentId, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return DistributorBookedTicketList(fromDate, toDate, agentId, distributorID).ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }

        public List<BusPNRModel> DistributorBookedTicketList(DateTime? fromdate, DateTime? todate, int AgentId, int distributorID)
        {
            IEnumerable<Bus_PNRs> _res = null;

            if (AgentId != 0)
            {
                if (fromdate != null && todate != null)
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.DistributorId == distributorID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate && a.CreateDate <= todate)
                           orderby a.CreateDate
                           select a;
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.DistributorId == distributorID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate)
                           orderby a.CreateDate
                           select a;
                }
                else
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.DistributorId == distributorID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)

                           orderby a.CreateDate
                           select a;
                }
            }
            else
            {
                if (fromdate != null && todate != null)
                {

                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where b.DistributorId == distributorID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate && a.CreateDate <= todate)
                           orderby a.CreateDate
                           select a;
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where
                                   b.DistributorId == distributorID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate)
                           orderby a.CreateDate
                           select a;
                }
                else
                {

                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where b.DistributorId == distributorID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                           orderby a.CreateDate
                           select a;
                }
            }


            List<BusPNRModel> list = new List<BusPNRModel>();
            int SNo = 1;

            foreach (var item in _res)
            {
                BusPNRModel busPnrModel = new BusPNRModel()
                {
                    Sno = SNo++,
                    BusPNRId = item.BusPNRId,
                    ServiceProviderId = item.ServiceProviderId,
                    AgentId = item.AgentId,
                    RefrenceNumber = item.RefrenceNumber,
                    BusMasterId = item.BusMasterId,
                    BusMasterName = item.Bus_Master.BusMasterName,
                    BusCategoryId = item.BusCategoryId,
                    BusCategoryName = item.Bus_Categories.BusCategoryName,
                    BusNo = item.BusNo,
                    NoOfSeat = item.NoOfSeat,
                    TicketStatusId = item.TicketStatusId,
                    FromCityId = item.FromCityId,
                    FromCityName = item.Bus_Cities.BusCityName,
                    ToCityId = item.ToCityId,
                    ToCityName = item.Bus_Cities1.BusCityName,
                    DepartureDate = item.DepartureDate,
                    ArrivalDate = item.ArrivalDate,
                    ArrivalTime = item.ArrivalTime,
                    InsurenceAmount = item.InsurenceAmount,
                    Remarks = item.Remarks,
                    FareRule = item.FareRule,
                    FacilityDetails = item.FacilityDetails,
                    Prefix = item.Prefix,
                    FullName = item.FullName,
                    EmailAddress = item.EmailAddress,
                    MobileNumber = item.MobileNumber,
                    PhoneNumber = item.PhoneNumber,
                    ContactAddress = item.ContactAddress,
                    DepartureTime = item.DepartureTime,
                    Type = item.Type,
                    IssuedDate = item.IssuedDate
                };
                list.Add(busPnrModel);
            }
            return list;
        }

        public IPagedList<BusPNRModel> GetBranchPagedBookedTicketList(int? page, DateTime? fromDate, DateTime? toDate, int agentId, int branchID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return BranchBookedTicketList(fromDate, toDate, agentId, branchID).ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }

        public List<BusPNRModel> BranchBookedTicketList(DateTime? fromdate, DateTime? todate, int AgentId, int branchID)
        {
            IEnumerable<Bus_PNRs> _res = null;

            if (AgentId != 0)
            {
                if (fromdate != null && todate != null)
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate && a.CreateDate <= todate)
                           orderby a.CreateDate
                           select a;
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate)
                           orderby a.CreateDate
                           select a;
                }
                else
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)

                           orderby a.CreateDate
                           select a;
                }
            }
            else
            {
                if (fromdate != null && todate != null)
                {

                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where  (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate && a.CreateDate <= todate)
                           orderby a.CreateDate
                           select a;
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where
                                   b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                                  && (a.CreateDate >= fromdate)
                           orderby a.CreateDate
                           select a;
                }
                else
                {

                    _res = from a in entity.Bus_PNRs
                           join b in entity.Agents on a.AgentId equals b.AgentId
                           where b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 1 || a.TicketStatusId == 7)
                           orderby a.CreateDate
                           select a;
                }
            }


            List<BusPNRModel> list = new List<BusPNRModel>();
            int SNo = 1;

            foreach (var item in _res)
            {
                BusPNRModel busPnrModel = new BusPNRModel()
                {
                    Sno = SNo++,
                    BusPNRId = item.BusPNRId,
                    ServiceProviderId = item.ServiceProviderId,
                    AgentId = item.AgentId,
                    RefrenceNumber = item.RefrenceNumber,
                    BusMasterId = item.BusMasterId,
                    BusMasterName = item.Bus_Master.BusMasterName,
                    BusCategoryId = item.BusCategoryId,
                    BusCategoryName = item.Bus_Categories.BusCategoryName,
                    BusNo = item.BusNo,
                    NoOfSeat = item.NoOfSeat,
                    TicketStatusId = item.TicketStatusId,
                    FromCityId = item.FromCityId,
                    FromCityName = item.Bus_Cities.BusCityName,
                    ToCityId = item.ToCityId,
                    ToCityName = item.Bus_Cities1.BusCityName,
                    DepartureDate = item.DepartureDate,
                    ArrivalDate = item.ArrivalDate,
                    ArrivalTime = item.ArrivalTime,
                    InsurenceAmount = item.InsurenceAmount,
                    Remarks = item.Remarks,
                    FareRule = item.FareRule,
                    FacilityDetails = item.FacilityDetails,
                    Prefix = item.Prefix,
                    FullName = item.FullName,
                    EmailAddress = item.EmailAddress,
                    MobileNumber = item.MobileNumber,
                    PhoneNumber = item.PhoneNumber,
                    ContactAddress = item.ContactAddress,
                    DepartureTime = item.DepartureTime,
                    Type = item.Type,
                    IssuedDate = item.IssuedDate
                };
                list.Add(busPnrModel);
            }
            return list;
        }
    }
}