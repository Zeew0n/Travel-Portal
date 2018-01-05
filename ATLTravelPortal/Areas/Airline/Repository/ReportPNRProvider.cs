using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
namespace AirLines.Provider.Admin
{
    public class ReportPNRProvider
    {

        EntityModel _ent = new EntityModel();

        public  IEnumerable<PNRReportModel> GetAirRetrievePNRInfoList(PNRReportModel m)
        {

            m.PNRId = (m.PNRId.ToString() == "")? null : m.PNRId;
            m.AgentId = (m.AgentId.ToString() == "") ? null : m.AgentId;
            m.GDSRefrenceNumber = string.IsNullOrEmpty(m.GDSRefrenceNumber) ? null : m.GDSRefrenceNumber;
            m.FullName = string.IsNullOrEmpty(m.FullName) ? null : m.FullName;
           
       



            var result = _ent.Air_RetrievePNRInfo(m.PNRId, m.AgentId, m.GDSRefrenceNumber, m.FullName);
            List<PNRReportModel> model = new List<PNRReportModel>();
            foreach (var item in result)
            {
                PNRReportModel obj = new PNRReportModel
                {
                    AgentName = item.AgentName,
                    FullName= item.FullName,
                    Address = item.Address,
                    CreatedDate = item.CreatedDate,

                    GDSRefrenceNumber= item.GDSRefrenceNumber,
                    ServiceProviderName= item.GDSRefrenceNumber,
                    AirlineCode = item.AirlineCode,
                    Sector= item.Sector,
                    Class = item.Class,
                    BaseFare = item.BaseFare,
                    SurCharge = item.SurCharge,
                    CommissionOnBF = item.CommissionOnBF,
                    ServiceCharge = item.ServiceCharge,
                    TotalTax = item.TotalTax,
                    TotalFare = item.TotalFare,
                    ticketStatusName = item.ticketStatusName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        
        }

    }



}