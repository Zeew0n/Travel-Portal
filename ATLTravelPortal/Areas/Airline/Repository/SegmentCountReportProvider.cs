using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class SegmentCountReportProvider
    {
        EntityModel ent = new EntityModel();
        
                                   
        public double TotalSumJan   = 0;
        public double TotalSumFeb = 0;
        public double TotalSumMarch = 0;
        public double TotalSumApril = 0;
        public double TotalSumMay   = 0;
        public double TotalSumJune  = 0;
        public double TotalSumJuly  = 0;
        public double TotalSumAug   = 0;
        public double TotalSumSep  = 0;
        public double TotalSumOct  = 0;
        public double TotalSumNov  = 0;
        public double TotalSumDec  = 0;
        public double TotalSumAllMonths = 0;
        public double TotalBooked = 0;
        public double TotalCanceled = 0;


        public List<SegmentCountReportModel> ListSegmentCountReport(int YearId, int ServiceProviderId, int? AgentId)
        {
            var data = ent.Air_GetSegmentCountReport(YearId, ServiceProviderId, AgentId);

            List<SegmentCountReportModel> model = new List<SegmentCountReportModel>();

            int totalBookJan= 0;
            int totalCancelJan = 0;
            int totalBookFeb = 0;
            int totalCancelFeb = 0;
            int totalBookMarch = 0;
            int totalCancelMarch = 0;
            int totalBookApril = 0;
            int totalCancelApril = 0;
            int totalBookMay = 0;
            int totalCancelMay = 0;
            int totalBookJune = 0;
            int totalCancelJune = 0;
            int totalBookJuly = 0;
            int totalCancelJuly = 0;
            int totalBookAugust = 0;
            int totalCancelAugust = 0;
            int totalBookSep = 0;
            int totalCancelSep = 0;
            int totalBookOct = 0;
            int totalCancelOct = 0;
            int totalBookNov = 0;
            int totalCancelNov = 0;
            int totalBookDec = 0;
            int totalCancelDec = 0;

            
            foreach (var item in data.Select(x => x))
            {
               
                var SegmentCountReportModel = new SegmentCountReportModel();
                SegmentCountReportModel.Info = item.Info;

                SegmentCountReportModel.Jan = item.Jan;
                if(item.Info=="Booked")
                    totalBookJan = int.Parse(item.Jan);
                else
                    totalCancelJan = int.Parse(item.Jan);
                SegmentCountReportModel.SumJan = totalBookJan - totalCancelJan;

                SegmentCountReportModel.Feb = item.Feb;
                if (item.Info == "Booked")
                    totalBookFeb = int.Parse(item.Feb);
                else
                    totalCancelFeb = int.Parse(item.Feb);
                SegmentCountReportModel.SumFeb = totalBookFeb - totalCancelFeb;

                SegmentCountReportModel.Mar = item.March;
                if (item.Info == "Booked")
                    totalBookMarch = int.Parse(item.March);
                else
                    totalCancelMarch = int.Parse(item.March);
                SegmentCountReportModel.SumMarch = totalBookMarch - totalCancelMarch;

                
                SegmentCountReportModel.April = item.April;
                if (item.Info == "Booked")
                    totalBookApril = int.Parse(item.April);
                else
                    totalCancelApril = int.Parse(item.April);
                SegmentCountReportModel.SumApril = totalBookApril - totalCancelApril;

               
                SegmentCountReportModel.May = item.May;
                if (item.Info == "Booked")
                    totalBookMay = int.Parse(item.May);
                else
                    totalCancelMay = int.Parse(item.May);
                SegmentCountReportModel.SumMay = totalBookMay - totalCancelMay;


                SegmentCountReportModel.Jun = item.June;
                if (item.Info == "Booked")
                    totalBookJune = int.Parse(item.June);
                else
                    totalCancelJune = int.Parse(item.June);
                SegmentCountReportModel.SumJune = totalBookJune - totalCancelJune;


                SegmentCountReportModel.July = item.July;
                if (item.Info == "Booked")
                    totalBookJuly = int.Parse(item.July);
                else
                    totalCancelJuly = int.Parse(item.July);
                SegmentCountReportModel.SumJuly = totalBookJuly - totalCancelJuly;

                SegmentCountReportModel.Aug = item.Aug;
                if (item.Info == "Booked")
                    totalBookAugust = int.Parse(item.Aug);
                else
                    totalCancelAugust = int.Parse(item.Aug);
                SegmentCountReportModel.SumAug = totalBookAugust - totalCancelAugust;

                SegmentCountReportModel.Sep = item.Sept;
                if (item.Info == "Booked")
                    totalBookSep = int.Parse(item.Sept);
                else
                    totalCancelSep = int.Parse(item.Sept);
                SegmentCountReportModel.SumSep = totalBookSep - totalCancelSep;

                SegmentCountReportModel.Oct = item.Oct;
                if (item.Info == "Booked")
                    totalBookOct = int.Parse(item.Oct);
                else
                    totalCancelOct = int.Parse(item.Oct);
                SegmentCountReportModel.SumOct = totalBookOct - totalCancelOct;

                
                SegmentCountReportModel.Nov = item.Nov;
                if (item.Info == "Booked")
                    totalBookNov = int.Parse(item.Nov);
                else
                    totalCancelNov = int.Parse(item.Nov);
                SegmentCountReportModel.SumNov = totalBookNov - totalCancelNov;

              
                SegmentCountReportModel.Dec = item.Dec;
                if (item.Info == "Booked")
                    totalBookDec = int.Parse(item.Dec);
                else
                    totalCancelDec = int.Parse(item.Dec);
                SegmentCountReportModel.SumDec = totalBookDec - totalCancelDec;

                if (item.Info == "Booked")
                {
                    TotalBooked = TotalBooked + double.Parse(item.Jan) + double.Parse(item.Feb) + double.Parse(item.March) + double.Parse(item.April) +
                        double.Parse(item.May) + double.Parse(item.June) + double.Parse(item.July) + double.Parse(item.Aug) + double.Parse(item.Sept) +
                        double.Parse(item.Oct) + double.Parse(item.Nov) + double.Parse(item.Dec);
                    SegmentCountReportModel.SumBooked = TotalBooked;
                }
                else if (item.Info == "Cancelled")
                {
                    TotalCanceled = TotalCanceled + double.Parse(item.Jan) + double.Parse(item.Feb) + double.Parse(item.March) + double.Parse(item.April) +
                        double.Parse(item.May) + double.Parse(item.June) + double.Parse(item.July) + double.Parse(item.Aug) + double.Parse(item.Sept) +
                        double.Parse(item.Oct) + double.Parse(item.Nov) + double.Parse(item.Dec);
                    SegmentCountReportModel.SumCancelled = TotalCanceled;
                }

                SegmentCountReportModel.SumAllMonths = TotalBooked - TotalCanceled;

                model.Add(SegmentCountReportModel);

            }
            return model;
        }
    }
}