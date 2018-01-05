using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class CancelRequestProvider
    {
        EntityModel ent = new EntityModel();
        public List<CancelRequestModel> CancelListRequestList()
        {
            int sno = 0;
            var data = ent.Air_GetCancelListRequest(null);

            List<CancelRequestModel> model = new List<CancelRequestModel>();

            foreach (var item in data.Select(x => x).OrderByDescending(x => x.BookedBy))
            {
                sno++;
                var CancelRequestModel = new CancelRequestModel
                {
                    SNO=sno,
                    PNRId = item.PNRId,
                    PassengerName = item.PassengerName,
                    Sector = item.Sector,
                    BookedOn = (DateTime)item.BookedOn,
                    BookedBy = item.BookedBy,
                    GDSRefrenceNumber = item.GDSRefrenceNumber,
                    TicketStatusName = item.ticketStatusName,
                    TicketStatusID = item.TicketStatusId,
                    AgentName = item.AgentName,
                    serviceproviderid = item.ServiceProviderId
                };
                model.Add(CancelRequestModel);

            }
            return model.ToList();
        }

        public List<CancelRequestModel> GetCommemtList(Int64 id)
        {
            List<CancelRequestModel> model = new List<CancelRequestModel>();
            var result = ent.TransactionLog.Where(xx => xx.PNRId == id).ToList();
            foreach (var item in result)
            {

                CancelRequestModel obj = new CancelRequestModel();
                obj.TransactionLogId = item.TransactionLogId;
                obj.TransactionType = item.TransactionType;
                obj.PNRId = item.PNRId;
                obj.Remark = item.Remark;
                obj.CreatedBy = item.CreatedBy;
                obj.CreatedName = GetUserName(item.CreatedBy);
                obj.CreatedDate = item.CreatedDate;

                model.Add(obj);
            }

            return model;
        }
        public string GetUserName(int createdBy)
        {
            string Username = ent.UsersDetails.Where(x => x.AppUserId == createdBy).Select(x => x.FullName).FirstOrDefault();
            return Username;
        }

        public void CancelledTicketRemarks(CancelRequestModel model, string CancelledTicket)
        {
            TransactionLog obj = new TransactionLog
            {
                PNRId = model.PNRId,
                TransactionType = 1,
                TransactionCharge = (decimal)model.ArihantCancellationCharge,
                RequestStatus = CancelledTicket == "Approve Cancel" ? "Cancel-Request" : "Cancel-Request-Reject",
                Remark = model.Remarks,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.UtcNow,
            };
            ent.AddToTransactionLog(obj);
            ent.SaveChanges();
        }

        //for pagination//
        public IQueryable<CancelRequestModel> GetCancelRequestByPagination(CancelRequestModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.CancelRequestList.Count();
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
            IQueryable<CancelRequestModel> pagingdata = m.CancelRequestList.OrderByDescending(x => x.BookedBy).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();

        }




        public void Confirm(long PnrId, double AirlineCancellationCharge, double ArihantCancellationCharge, bool isAgentPayCharge, int currencyid, int userid, int serviceproviderid)
        {
            ent.Air_CancelTickets(PnrId, AirlineCancellationCharge, ArihantCancellationCharge, isAgentPayCharge, currencyid, userid, serviceproviderid);
        }

        public void RevertCancel(Int64 MPNRId)
        {
            PNRs pnrResult = ent.PNRs.Where(x => x.PNRId == MPNRId).FirstOrDefault();
            if (pnrResult != null)
            {
                pnrResult.TicketStatusId = 31;
                ent.ApplyCurrentValues(pnrResult.EntityKey.EntitySetName, pnrResult);
                ent.SaveChanges();
            }
            else
            {
                TBO_MasterPNRs result = ent.TBO_MasterPNRs.Where(x => x.MPNRId == MPNRId).FirstOrDefault();

                result.TicketStatusId = 31;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
        }
    }
}