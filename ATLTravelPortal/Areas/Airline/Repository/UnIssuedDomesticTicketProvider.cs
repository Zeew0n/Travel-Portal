using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class UnIssuedDomesticTicketProvider
    {
        EntityModel ent = new EntityModel();



        public List<UnIssuedDomesticTicketModel> ListUnIssuedDomesticTicket()
        {
            var data = ent.Air_GetUnIssuedDomesticTickets(null);

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
                    AgentName=item.AgentName
                };
                model.Add(UnIssuedDomesticTicketModel);

            }
            return model.OrderByDescending(x=>x.BookedDate).ToList();
        }



        public void Issue(long Id, int userid)
        {
            //PNRs result = ent.PNRs.Where(x => x.PNRId == Id).FirstOrDefault();
            //result.TicketStatusId = 1;
            //result.UpdatedBy = userid;
            //result.UpdatedDate = DateTime.Now;
            //ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            //ent.SaveChanges();

           // ent.Air_IssueTickets(Id, userid);

        }



        //for pagination//
        public IQueryable<UnIssuedDomesticTicketModel> GetUnIssuedDomesticTicketByPagination(UnIssuedDomesticTicketModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
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
            IQueryable<UnIssuedDomesticTicketModel> pagingdata = m.UsIssuedDomesticTicketList.OrderByDescending(x=>x.BookedDate).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();

        }





    }
}