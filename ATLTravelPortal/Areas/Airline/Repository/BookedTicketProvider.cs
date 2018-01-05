using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Repository;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class BookedTicketProvider
    {
        EntityModel ent = new EntityModel();
        GeneralProvider _ser = new GeneralProvider();
        public List<BookedTicketModel> GetBookedTicketList()
        {
            List<BookedTicketModel> model = new List<BookedTicketModel>();
            var result = from a in ent.PNRs where a.TicketStatusId == 1 select a;
            foreach (var item in result)
            {
                BookedTicketModel obj = new BookedTicketModel
                {
                    PNRId = item.PNRId,
                    PNR = item.GDSRefrenceNumber,
                    BookedDate = item.CreatedDate,
                    
                    ArrivalCity = _ser.GetCityName(item.PNRSectors.Where(x => x.PNRId == item.PNRId).Select(x => x.DestinationCityId).FirstOrDefault()),
                    FullName = item.Prefix + "." + item.FirstName + " " + item.MiddleName + " " + item.LastName,
                    FlightDate = item.PNRSectors.Where(x => x.PNRId == item.PNRId).Select(x => x.DepartDate).FirstOrDefault(),
                    DepartureCity = _ser.GetCityName(item.PNRSectors.Where(x => x.PNRId == item.PNRId).Select(x => x.DepartCityId).FirstOrDefault()),


                };
                model.Add(obj);
            }
            return model;
        }

        public BookedTicketModel GetBookedTicketById(int PNRId)
        {
             
            var result = ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault();

            BookedTicketModel model = new BookedTicketModel();
            model.PNR = result.GDSRefrenceNumber;
            model.PNRId = result.PNRId;
            model.BookedDate = result.CreatedDate;
           
            
            model.ArrivalCity = _ser.GetCityName(result.PNRSectors.Where(x => x.PNRId == result.PNRId).Select(x => x.DestinationCityId).FirstOrDefault());
            model.FullName = result.Prefix + "." + result.FirstName + " " + result.MiddleName + " " + result.LastName;
            model.FlightDate = result.PNRSectors.Where(x => x.PNRId == result.PNRId).Select(x => x.DepartDate).FirstOrDefault();
            model.DepartureCity = _ser.GetCityName(result.PNRSectors.Where(x => x.PNRId == result.PNRId).Select(x => x.DepartCityId).FirstOrDefault());
            model.AgentName = _ser.GetAgentName(result.AgentId);

            return model;
        }

        //public List<BookedTicketModel> GetTicketList(BookedTicketModel model)
        //{
        //    IQueryable<IGrouping<long, Passengers>> ticketGroup1 = ent.Passengers.AsQueryable().GroupBy(x => x.PNRId);
        //    List<BookedTicketModel> item = new List<BookedTicketModel>();
        //    foreach (IGrouping<long, Passengers> ticket in ticketGroup1)
        //    { 
             
        //    }
            
        //}
        //public decimal CalculateTotalFare(long PNRId)
        //{
        //    BookedTicketModel model = new BookedTicketModel();
        //    IQueryable<IGrouping<long, BookedTicketModel>> ticketGroup1 = model.BookedTicketList.AsQueryable().GroupBy(x => x.PNRId);
        //    decimal fare = 0;
        //    foreach (IGrouping<long, BookedTicketModel> ticketgroup in ticketGroup1)
        //    { 
        //     fare = fare+ticketgroup.
        //    }
        //}
    }
}