using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using System.Text;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class BookedTicketReportProvider
    {

        EntityModel ent = new EntityModel();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();


        public List<BookedTicketModels> ListBookedReport(int? AgentId, DateTime? fromdate, DateTime? todate)
        {

            var data = ent.Air_GetBookedTicket(AgentId, fromdate, todate);

            List<BookedTicketModels> model = new List<BookedTicketModels>();

            foreach (var item in data.Select(x => x))
            {
                var BookedTicketModel = new BookedTicketModels
                {
                    PNRId = item.PNRId,
                    PassengerName = item.PassengerName,
                    Sector = item.Sector,
                    BookedOn = (DateTime)item.BookedOn,
                    BookedBy = item.BookedBy,
                    GDSRefrenceNumber = item.GDSRefrenceNumber,
                    AgentName = item.AgentName,
                    FlightDate = item.FlightDate,
                    ServiceProviderId=item.ServiceProviderId,
                    AgentId=item.AgentId,
                    DistributorId =item.DistributorId,
                    BranchOfficeId=item.BranchOfficeId,
                    AgentCode = GetAgentCodeById(item.AgentId),                    
                };

                var distributor=distributorManagementProvider.GetDistributorByDistributorId(item.DistributorId);
                if (distributor != null)
                { 
                    BookedTicketModel.DistributorName=distributor.DistributorName+"("+distributor.DistributorCode+")";
                }
                var branchOffice = branchOfficeManagementProvider.GetBranchOfficeInfo(item.BranchOfficeId);
                if (branchOffice != null)
                {
                    BookedTicketModel.BranchOfficeName = branchOffice.BranchOfficeName +"(" +branchOffice.BranchOfficeCode +")";
                }
                model.Add(BookedTicketModel);

            }
            return model.OrderByDescending(x=>x.BookedOn).ToList();
        }


        public string GetAgentCodeById(int AgentId)
        {
            string agentcode = ent.Agents.Where(x => x.AgentId == AgentId).Select(x => x.AgentCode).FirstOrDefault();
            return agentcode;
        }

        public List<AirlineTypes> GetAirlineTypesList()
        {
            return ent.AirlineTypes.Where(x => x.isActive == true).ToList();
        }

        public List<Airlines> GetAirlinesList()
        {
            return ent.Airlines.Where(x => x.AirlineTypeId == 1).ToList();
        }

        public void Issue(long Id, int userid)
        {


            PNRs result = ent.PNRs.Where(x => x.PNRId == Id).FirstOrDefault();

            result.TicketStatusId = 1;
            result.UpdatedBy = userid;
            result.UpdatedDate = DateTime.Now;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        public void Cancel(long Id, int userid)
        {
            PNRs result = ent.PNRs.Where(x => x.PNRId == Id).FirstOrDefault();

            result.TicketStatusId = 2;
            result.UpdatedBy = userid;
            result.UpdatedDate = DateTime.Now;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }



        //for pagination//
        public IQueryable<BookedTicketModels> GetBookedTicketReportByPagination(BookedTicketModels m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.BookedTicketList.Count();
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
            IQueryable<BookedTicketModels> pagingdata = m.BookedTicketList.OrderByDescending(x=>x.BookedOn).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();

        }

        public void SendCanceledEmail(long Pnrid, string PNR, string PassengerName, string AgentName, string City, DateTime BookedOn)
        {
            try
            {
                int agentid = ent.PNRs.Where(x => x.PNRId == Pnrid).Select(y => y.AgentId).FirstOrDefault();

                string agentemailaddress = ent.Agents.Where(x => x.AgentId == agentid).Select(y => y.Email).FirstOrDefault();

                
                string subject = "Cancellation Notification:" + " " + PNR + " " + PassengerName;

               
                StringBuilder st = new StringBuilder();
            st.AppendFormat(@"<p>
        Dear {0} ,<br />
        <br />
        The following reservation has been cancelled by the airline:</p>
    <div style='background-color: #521831; padding: 0.5% 2%; font-family: Arial, 

Helvetica, sans-serif;
        width: 94%; margin: 0px 1%; text-align: center; color: #fff;'>
        <h2>
            Ticket Cancel Notification</h2>

        <table width='100%' cellpadding='' cellspacing='' style='border: 1px solid 

#fff;
            background-color: #eaeaea; text-align: left; color: #000;'>
            <tbody>
                <tr>
                    <td>
                        <strong>Agency</strong></td>
                    <td>
                      {1}
                    </td>
                </tr>

                <tr>
                    <td>
                        <strong>PNR Name</strong>
                    </td>
                    <td>
                       {2}
                    </td>
                </tr>
                <tr>

                    <td>
                        <strong>Sector</strong>
                    </td>
                    <td>
                       {3}
                    </td>
                </tr>
                <tr>
                    <td>

                        <strong>Booking Ref. No</strong>
                    </td>
                    <td>
                        {4}
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Booked Date</strong></td>

                    <td>
                       {5}</td>
                </tr>
            </tbody>
        </table>
    </div> ", AgentName, AgentName, PassengerName, City, PNR, TimeFormat.DateFormat(BookedOn.ToString()));

                
                ent.CORE_SendEmails(agentemailaddress, string.Empty, string.Empty, subject, st.ToString(), "HTML", "HIGH");
            }
            catch
            {
            }
        }

       

        //public Models.ServiceResponses Delete(int id)
        //{

        //    try
        //    {
        //        response.CheckResponseStatus = dal.Delete(id, App_Classes.AppSession.LogUserID);
        //    }
        //    catch (SqlException e)
        //    {
        //        return Utility.UtilityProvider.SqlExceptionMessage(e);
        //    }
        //    catch (Exception e)
        //    {
        //        return Utility.UtilityProvider.ExceptionMessage(e);
        //    }

        //    return response;
        //}

    }

    }
