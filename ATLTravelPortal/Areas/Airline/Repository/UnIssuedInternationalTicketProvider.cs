using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;
using Abacus.BookingService;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class UnIssuedInternationalTicketProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public IEnumerable<UnIssuedInternationalTicketModel> GetList()
        {
            List<UnIssuedInternationalTicketModel> model = new List<UnIssuedInternationalTicketModel>();

            var data = ent.Air_GetUnIssuedInternationTickets(null);
            foreach (var item in data)
            {
                UnIssuedInternationalTicketModel temp = new UnIssuedInternationalTicketModel();
                temp.AgentId = item.AgentId;
                temp.AgentName = item.AgentName;
                temp.AirlineCode = item.AirlineCode;
                temp.BookedBy = item.BookedBy;
                temp.BookedDate = item.BookedDate;
                temp.GDSRefrenceNumber = item.GDSRefrenceNumber;
                temp.PassengerName = item.Passenger;
                temp.Sector = item.Sector;
                temp.PNRid = item.PNRId;
                temp.ServiceProviderId = 3;
                temp.FlightDate = item.FlightDate;
                model.Add(temp);
            }

            return model.AsEnumerable();
        }


        //public bool IssueTicket(Int64 PNRId, int UserId)
        //{
        //    string GDSRefNo = ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault().GDSRefrenceNumber;
        //    Abacus.Ticketing.TicketIssueManager manager = new Abacus.Ticketing.TicketIssueManager();
        //    try
        //    {
        //        var retriveData = BookingManager.RetrievePNR(GDSRefNo);

        //        if (string.IsNullOrEmpty(retriveData.PassengerList.FirstOrDefault().TicketNumber))
        //        {
        //            retriveData = manager.IssueTicket(GDSRefNo, (decimal)0);
        //        }

        //        int TicketStatusId = ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault().TicketStatusId;

        //        if (TicketStatusId != 4)
        //        {
        //            var dbPassengerList = ent.Passengers.Where(x => x.PNRId == PNRId && x.isDeleted == false).ToArray();
        //            int paxCounter = 0;
        //            foreach (var item in retriveData.PassengerList)
        //            {
        //                Passengers pass = dbPassengerList.ElementAt(paxCounter);
        //                pass.TicketNumber = item.TicketNumber;

        //                ent.ApplyCurrentValues(pass.EntityKey.EntitySetName, pass);
        //                ent.SaveChanges();
        //                paxCounter++;
        //            }
        //            ent.Air_IssueTickets(PNRId, UserId);
        //        }
        //        return true;
        //    }
        //    catch (GDS.GDSException ex)
        //    {

        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        public bool IssueTicket(Int64 PNRId, int UserId)
        {
            var result = ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault();

            if (result != null)
            {
                string GDSRefNo = result.GDSRefrenceNumber;
                Abacus.Ticketing.TicketIssueManager manager = new Abacus.Ticketing.TicketIssueManager();
                try
                {
                    var retriveData = BookingManager.RetrievePNR(GDSRefNo,null);

                    if (string.IsNullOrEmpty(retriveData.PassengerList.FirstOrDefault().TicketNumber))
                    {
                        retriveData = manager.IssueTicket(GDSRefNo, (decimal)0);
                    }

                    int TicketStatusId = ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault().TicketStatusId;

                    if (TicketStatusId != 4)
                    {
                        var dbPassengerList = ent.Passengers.Where(x => x.PNRId == PNRId && x.isDeleted == false).ToArray();
                        int paxCounter = 0;
                        foreach (var item in retriveData.PassengerList)
                        {
                            Passengers pass = dbPassengerList.ElementAt(paxCounter);
                            pass.TicketNumber = item.TicketNumber;

                            ent.ApplyCurrentValues(pass.EntityKey.EntitySetName, pass);
                            ent.SaveChanges();
                            paxCounter++;
                        }
                        ent.Air_IssueTickets(PNRId, UserId);
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
            else
            {
                string GDSRefNo = ent.TBO_PNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().RecLoc;
                Abacus.Ticketing.TicketIssueManager manager = new Abacus.Ticketing.TicketIssueManager();
                try
                {
                    var retriveData = BookingManager.RetrievePNR(GDSRefNo, null);

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
        }


        public void CancelTicket(Int64 PNRId, UnIssuedInternationalTicketModel model)
        {
            var result = ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault();
            if (result == null)
            {
                TBOCancelTicket(PNRId, model);
                return;
            }
            string GDSRefNo = result.GDSRefrenceNumber;
            try
            {
                if (Abacus.BookingService.BookingManager.CancelPNR(GDSRefNo, "Arihant Holidays"))
                    ent.Air_CancelTickets(PNRId, model.AirlineCancellationCharge, model.ArihantCancellationCharge, model.isAgentWillPaycharge, 1, model.UserID, 3);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void TBOCancelTicket(Int64 PNRId, UnIssuedInternationalTicketModel model)
        {
            string GDSRefNo = ent.TBO_PNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().RecLoc;
            try
            {
                if (Abacus.BookingService.BookingManager.CancelPNR(GDSRefNo, "Arihant Holidays"))
                    ent.Air_CancelTickets(PNRId, model.AirlineCancellationCharge, model.ArihantCancellationCharge, model.isAgentWillPaycharge, 1, model.UserID, 3);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}