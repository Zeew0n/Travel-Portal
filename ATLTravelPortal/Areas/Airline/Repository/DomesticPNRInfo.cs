#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class DomesticPNRInfo
    {
        EntityModel entity = new EntityModel();

        public Int64 SavePNRInformation(int AgentId,
                                            int ServiceProviderId, 
                                            string Prefix, 
                                            string FirstName, 
                                            string MiddleName, 
                                            string LastName, 
                                            string Email, 
                                            string ContactNumber, 
                                            string GDSRefrenceNumber, 
                                            int TicketStatusId,
                                            int CreatedBy, 
                                            DateTime CreatedDate)
        {
            var obj = new PNRs
            {
                AgentId=AgentId,
                ServiceProviderId=ServiceProviderId,
                Prefix=Prefix,
                FirstName=FirstName,
                MiddleName=MiddleName,
                LastName=LastName,
                EmailAddress=Email,
                ContactNumber=ContactNumber,
                GDSRefrenceNumber=GDSRefrenceNumber,
                TicketStatusId=TicketStatusId,
                CreatedBy=CreatedBy,
                CreatedDate=CreatedDate,
                IssuedDate=DateTime.Now,
            };

            entity.AddToPNRs(obj);
            entity.SaveChanges();

            return obj.PNRId;
        }

        public Int64 SavePNRSectorInformation(Int64 PNRId,
                                            int AirlineId,
                                            int DepartureCityId, 
                                            DateTime DepartureDate, 
                                            string DepartureTime, 
                                            int DestinationCityId, 
                                            DateTime ArriveDate, 
                                            string ArriveTime, 
                                            string TerminalNumber, 
                                            int CreatedBy, 
                                            DateTime CreatedDate)
        {
            var obj = new PNRSectors
            {
              PNRId=PNRId,
              PlatingCarrierId = AirlineId,
              DepartCityId=DepartureCityId,
              DepartDate=DepartureDate,
              DepartTime= TimeSpan.Parse(  DepartureTime),
              DestinationCityId=DestinationCityId,
              ArriveDate=ArriveDate,
              ArriveTime=TimeSpan.Parse( ArriveTime),
             // TerminalNumber=TerminalNumber,
             StartTerminal=TerminalNumber,
             EndTerminal=TerminalNumber,
              CreatedBy = CreatedBy,
              CreatedDate = CreatedDate
            };

            entity.AddToPNRSectors(obj);
            entity.SaveChanges();

            return obj.SectorId;
        }

        public void SavePNRSegmentInformation(Int64 PNRId, 
                                                Int64 SectorId, 
                                                int AirlineId, 
                                                string FlightNumber, 
                                                int DepartCityId, 
                                                DateTime DepartDate, 
                                                string DepartTime, 
                                                int ArriveCityId, 
                                                DateTime ArriveDate,
                                                string ArriveTime , 
                                                string BIC,
                                                string TerminalNumber, 
                                                string AirlineRefrenceNumber, 
                                                int CreatedBy, 
                                                DateTime CreatedDate)
        {
            var obj = new PNRSegments
            {
                PNRId = PNRId,
                SectorId = SectorId,
                AirlineId=AirlineId,
                FlightNumber=FlightNumber,
                DepartCityId = DepartCityId,
                DepartDate = DepartDate,
                DepartTime =TimeSpan.Parse( DepartTime),
                ArriveCityId=ArriveCityId,              
                ArriveDate = ArriveDate,
                ArriveTime =TimeSpan.Parse( ArriveTime),
                BIC=BIC,
                //TerminalNumber = TerminalNumber,
                StartTerminal=TerminalNumber,
                EndTerminal=TerminalNumber,
                AirlineRefrenceNumber=AirlineRefrenceNumber,
                CreatedBy = CreatedBy,
                CreatedDate = CreatedDate
            };

            entity.AddToPNRSegments(obj);
            entity.SaveChanges();
        }

        public void SavepassangerInformation(Int64 PNRId, 
                                            string Prefix, 
                                            string FirstName, 
                                            string MiddleName, 
                                            string LastName, 
                                            DateTime DOB, 
                                            string PassportNumber, 
                                            string MobileNumber, 
                                            string EmailAddress, 
                                            int PassengerTypeId,
                                            double? Fare, 
                                            double? Taxes,
                                            double? Markup,
                                            double? Commission,
                                            double ServiceCharge,
                                            string TicketNumber, 
                                            int TicketStatusId, 
                                            int CreatedBy, 
                                            DateTime CreatedDate)
        {
            var obj = new Passengers
            {
                PNRId = PNRId,
                Prefix="MR",
                FirstName=FirstName,
                MiddleName=MiddleName,
                LastName=LastName,
                DOB=DOB,
                PassportNumber=PassportNumber,
                MobileNumber=MobileNumber,
                EmailAddress=EmailAddress,
                PassengerTypeId=PassengerTypeId,
                Fare=(double)Fare,
                TaxAmount=(double)Taxes,
                MarkupAmount = (double)Markup,
                CommissionAmount = (double)Commission,
                ServiceCharge=ServiceCharge ,
                TicketNumber=TicketNumber,
                TicketStatusId=TicketStatusId ,
                CreatedBy = CreatedBy,
                CreatedDate = CreatedDate
            };

            entity.AddToPassengers(obj);
            entity.SaveChanges();
        }


        public IQueryable<GetPNRsListByAgentId_Result> GetPNRsListByAgentId(int TicketStatusId,int AgentId)
        {
            return entity.GetPNRsListByAgentId(TicketStatusId, AgentId).AsQueryable();
        }
    }
}