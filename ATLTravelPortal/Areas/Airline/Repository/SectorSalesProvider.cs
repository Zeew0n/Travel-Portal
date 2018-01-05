using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    

    public class SectorSalesProvider
    {
        EntityModel ent = new EntityModel();

        public List<SectorSalesModel> SectorSalesList(DateTime fromdate, DateTime todate, int? CurrencyId)
        {
            var data = ent.Air_GetSectorSales(fromdate, todate, CurrencyId);

            List<SectorSalesModel> model = new List<SectorSalesModel>();

            foreach (var item in data.Select(x => x))
            {
                var SectorSalesModel = new SectorSalesModel
                {
                    MPNRId = item.MPNRId,
                    AgentId = item.AgentId,
                    BranchOfficeId = item.BranchOfficeId,
                    DistributorId = item.DistributorId,
                    CreatedDate = item.CreatedDate,
                    GDSReferenceNumber = item.GDSRefrenceNumber,
                    ServiceProviderName = item.ServiceProviderName,
                    AirlineCode = item.AirlineCode,
                    Sector = item.Sector,
                    Class = item.Class,
                   TicketNumber = item.TicketNumber,
                   AdminAmount = item.AdminAmount,
                   AgentAmount = item.AgentAmount,
                   BranchAmount = item.BranchAmount,
                   DistributorAmount = item.DistributorAmount,
                };
                model.Add(SectorSalesModel);

            }
            return model.OrderByDescending(x => x.CreatedDate).ToList();
        }


        //for pagination//
        public IQueryable<SectorSalesModel> GetSectorSalesReportByPagination(SectorSalesModel m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.SectorSalesList.Count();
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
            IQueryable<SectorSalesModel> pagingdata = m.SectorSalesList.OrderByDescending(x=>x.CreatedDate).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();

        }

        public List<Airlines> GetAirlinesList()
        {
            return ent.Airlines.Where(x => x.AirlineTypeId == 1).ToList();
        }

        public List<Agents> GetAgentsList()
        {
            return ent.Agents.ToList();
        }

        public List<Currencies> GetCurrenciesList()
        {
            return ent.Currencies.Where(x=>(x.CurrencyId != 4 && x.CurrencyId !=5)).ToList();
        }

        public List<Airlines> GetAirline(string AirlineCityName, int maxResult)
        {
            return GetAllAirlineList(AirlineCityName, maxResult).ToList();
        }
        public IEnumerable<Airlines> GetAllAirlineList(string AirlineNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x => ((x.AirlineName.ToLower().Contains(AirlineNameCode) ||
                x.AirlineName.ToLower().Contains(AirlineNameCode) ||
                x.AirlineCode.ToUpper().Contains(AirlineNameCode) ||
                x.AirlineCode.ToUpper().Contains(AirlineNameCode.ToUpper()))) && (x.AirlineTypeId == 1)).Take(maxResult).ToList().Select(x =>
                   new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }




    }
}