using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Collections;
using System.Data;

namespace AirLines.Provider.Admin
{
    public class SectorSalesReportProvider
    {


        EntityModel ent = new EntityModel();

        public decimal TotalMainSegment = 0;
        public decimal TotalSegment = 0;

        public decimal TotalCancelledTicketStatus = 0;
        public decimal TotalBookedTicketStatus = 0;
        public decimal Difference = 0;

       

        
        public List<SectorSalesReportModel> ListSegmentSalesReport( DateTime fromdate, DateTime todate, int? departsId, int? arriveId, int? agentId, int airlinetypeId)
        {
            
            var data = ent.Air_GetSegmentSalesReport(fromdate, todate, departsId, arriveId, agentId);
           
            List<SectorSalesReportModel> model = new List<SectorSalesReportModel>();

            foreach (var item in data.Select(x=>x))
            {
               
                var SectorSalesReportModel = new SectorSalesReportModel();
                SectorSalesReportModel.TicketStatusName = item.TicketStatusName;
                SectorSalesReportModel.DepartCityId = item.DepartCityId;
                SectorSalesReportModel.ArriveCityId = item.ArriveCityId;
                SectorSalesReportModel.DepartCity = item.Depart;
                SectorSalesReportModel.ArriveCity = item.Arrive;
                SectorSalesReportModel.SegmentId = item.Segment_;

                TotalMainSegment = TotalMainSegment + (Decimal) item.Segment_;
                SectorSalesReportModel.txtSumMainSegment = TotalMainSegment;


                if (SectorSalesReportModel.TicketStatusName == "Booked")
                {
                    TotalBookedTicketStatus = TotalBookedTicketStatus + (Decimal)item.Segment_;
                }
                else if (SectorSalesReportModel.TicketStatusName == "Cancelled")
                {
                    TotalCancelledTicketStatus = TotalCancelledTicketStatus + (Decimal)item.Segment_;
                }
                SectorSalesReportModel.txtSumTotalBookedTicketStatus = TotalBookedTicketStatus;
                SectorSalesReportModel.txtSumTotalCancelledTicketStatus = TotalCancelledTicketStatus;
                Difference = TotalBookedTicketStatus - TotalCancelledTicketStatus;
                SectorSalesReportModel.txtDifference = Difference;

               

                model.Add(SectorSalesReportModel);

            }
            return model;
        }
        public List<AirlineCities> GetCityList(int cityTypeId)
        {
            return ent.AirlineCities.Where(z => z.AirlineCityTypeId == cityTypeId).ToList();
        }
        public List<AirlineTypes> GetAirlineTypesList()
        {
            return ent.AirlineTypes.Where(x => x.isActive == true).ToList();
        }
        public IEnumerable<SectorSalesReportModel> GetSegmentSalesDetailsReport(DateTime? fromdate, DateTime? todate, int? departcityId, int? arrivecityId)
        {
          

            IEnumerable<Air_GetSegmentSalesDetailsReport_Result> result = ent.Air_GetSegmentSalesDetailsReport(fromdate, todate, departcityId, arrivecityId).AsQueryable();

            List<SectorSalesReportModel> model = new List<SectorSalesReportModel>();
           
            foreach (var item in result.Select(x => x))
            {
                var obj = new SectorSalesReportModel();
                obj.TicketStatusName = item.TicketStatusName;
                obj.Agent = item.AgentName;
                obj.SegmentId = item.Segment_;
                TotalSegment = TotalSegment + (Decimal) item.Segment_;
                obj.txtSumSegment = TotalSegment;


                if (obj.TicketStatusName == "Booked")
                {
                    TotalBookedTicketStatus = TotalBookedTicketStatus + (Decimal)item.Segment_;
                }
                else if (obj.TicketStatusName == "Cancelled")
                {
                    TotalCancelledTicketStatus = TotalCancelledTicketStatus + (Decimal)item.Segment_;
                }

                obj.txtSumTotalBookedTicketStatus = TotalBookedTicketStatus;
                obj.txtSumTotalCancelledTicketStatus = TotalCancelledTicketStatus;
                Difference = TotalBookedTicketStatus - TotalCancelledTicketStatus;
              
                obj.txtDifference = Difference;


                model.Add(obj);
                
            }
            return model.AsEnumerable();
        }

        //for pagination//
        public IQueryable<SectorSalesReportModel> GetSectorSalesReportByPagination(SectorSalesReportModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.SegmentSalesReportList.Count();
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
            IQueryable<SectorSalesReportModel> pagingdata = m.SegmentSalesReportList.Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();



        }
        








        public List<AirlineCities> GetAirlineCity(string AirlineCityName, int maxResult,int AirlineTypesId)
        {
            return GetAllAirlineCityList(AirlineCityName, maxResult, AirlineTypesId).ToList();
        }
        public IEnumerable<AirlineCities> GetAllAirlineCityList(string AirlineCityNameCode, int maxResult, int AirlineTypesId)
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineCities.Where(x => ((x.CityName.ToLower().Contains(AirlineCityNameCode) || 
                x.CityName.ToLower().Contains(AirlineCityNameCode) ||
                x.CityCode.ToUpper().Contains(AirlineCityNameCode) ||
                x.CityCode.ToUpper().Contains(AirlineCityNameCode.ToUpper()))) && (x.AirlineCityTypeId == AirlineTypesId)).Take(maxResult).ToList().Select(x =>
                   new AirlineCities { CityName = x.CityName, CityID = x.CityID, CityCode = x.CityCode }
                );
        }



        //public List<AirlineCities> GetCityList(int cityTypeId)
        //{
        //    return ent.AirlineCities.Where(z => z.AirlineCityTypeId == cityTypeId).ToList();
        //}
    }
}