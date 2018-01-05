using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class WaitListRequestProvider
    {
        EntityModel ent = new EntityModel();

        public List<WaitListRequestModel> WaitListRequestList()
        {
            var data = ent.Air_GetWaitListRequest(null);

            List<WaitListRequestModel> model = new List<WaitListRequestModel>();

            foreach (var item in data.Select(x => x))
            {
                var WaitListRequestModel = new WaitListRequestModel
                {
                    PNRId = item.PNRId,
                    PassengerName = item.PassengerName,
                    Sector = item.Sector,
                    BookedOn = item.BookedOn.Value,
                    BookedBy = item.BookedBy,
                    GDSRefrenceNumber = item.GDSRefrenceNumber,
                    TicketStatusName = item.ticketStatusName,
                    AgentName = item.AgentName
                };
                model.Add(WaitListRequestModel);
            }
            return model;
        }
        
        public void Confirm(long Id, int userid)
        {
            PNRs result = ent.PNRs.Where(x => x.PNRId == Id).FirstOrDefault();
            if (result != null)
            {
                result.TicketStatusId = 10;
                result.UpdatedBy = userid;
                result.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
            else
            {
                TBO_MasterPNRs tboResult = ent.TBO_MasterPNRs.Where(x => x.MPNRId == Id).FirstOrDefault();
                tboResult.TicketStatusId = 10;
                tboResult.UpdatedBy = userid;
                tboResult.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(tboResult.EntityKey.EntitySetName, tboResult);
                ent.SaveChanges();
            }
        }

        public void Cancel(long Id, int userid)
        {
            PNRs result = ent.PNRs.Where(x => x.PNRId == Id).FirstOrDefault();
            if (result != null)
            {
                result.TicketStatusId = 11;
                result.UpdatedBy = userid;
                result.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
            else
            {
                TBO_MasterPNRs tboResult = ent.TBO_MasterPNRs.Where(x => x.MPNRId == Id).FirstOrDefault();
                tboResult.TicketStatusId = 11;
                tboResult.UpdatedBy = userid;
                tboResult.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(tboResult.EntityKey.EntitySetName, tboResult);
                ent.SaveChanges();
            }
        }

        public void Close(long Id, int userid)
        {
            PNRs result = ent.PNRs.Where(x => x.PNRId == Id).FirstOrDefault();
            if (result != null)
            {
                result.TicketStatusId = 9;
                result.UpdatedBy = userid;
                result.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
            else
            {
                TBO_MasterPNRs tboResult = ent.TBO_MasterPNRs.Where(x => x.MPNRId == Id).FirstOrDefault();
                tboResult.TicketStatusId = 9;
                tboResult.UpdatedBy = userid;
                tboResult.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(tboResult.EntityKey.EntitySetName, tboResult);
                ent.SaveChanges();
            }
        }

        public void Issue(long Id, int userid)
        {
            PNRs result = ent.PNRs.Where(x => x.PNRId == Id).FirstOrDefault();
            if (result != null)
            {
                result.TicketStatusId = 1;
                result.UpdatedBy = userid;
                result.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
            else
            {
                TBO_MasterPNRs tboResult = ent.TBO_MasterPNRs.Where(x => x.MPNRId == Id).FirstOrDefault();
                tboResult.TicketStatusId = 1;
                tboResult.UpdatedBy = userid;
                tboResult.UpdatedDate = DateTime.UtcNow;

                ent.ApplyCurrentValues(tboResult.EntityKey.EntitySetName, tboResult);
                ent.SaveChanges();
            }
        }

        //for pagination//
        public IQueryable<WaitListRequestModel> GetWaitListRequestByPagination(WaitListRequestModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.WaitListRequestList.Count();
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
            IQueryable<WaitListRequestModel> pagingdata = m.WaitListRequestList.Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();

        }

    }
}