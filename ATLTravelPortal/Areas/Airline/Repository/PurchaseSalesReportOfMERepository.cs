using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PurchaseSalesReportOfMERepository
    {
        EntityModel entity = new EntityModel();




        public IEnumerable<PurchaseSalesReportOfMEModel> GetPurchaseSalesReportOfME(PurchaseSalesReportOfMEModel model)
        {

            var Data = entity.Air_GetPurchseSalesOfMEs(model.MEsNameID,model.FromDate,model.ToDate,model.CurrencyID);
            List<PurchaseSalesReportOfMEModel> collection = new List<PurchaseSalesReportOfMEModel>();
            double PurchaseTotal = 0;
            double SalesTotal = 0;
            double RecieptTotal = 0;
            
            foreach (var item in Data)
            {
                PurchaseSalesReportOfMEModel single = new PurchaseSalesReportOfMEModel()
                {
                   
                    AgentName = item.AgentName,
                    Purchase = item.Pruchase,
                    Sales = item.Sales,
                    Receipt = item.Receipt
                };

                
                collection.Add(single);
                PurchaseTotal += item.Pruchase??0;
                SalesTotal += item.Sales??0;
                RecieptTotal += item.Receipt;
                
            }
            PurchaseSalesReportOfMEModel add = new PurchaseSalesReportOfMEModel();
            add.Purchase = PurchaseTotal;
            add.Sales = SalesTotal;
            add.Receipt = RecieptTotal;
            
            collection.Add(add);
            return collection;
        }


        public IEnumerable<SelectListItem> GetMEName()
        {
            var Data = entity.UsersDetails.Where(x => x.UserTypeId == 4);
            List<SelectListItem> collection = new List<SelectListItem>();

            foreach (var item in Data)
            {
                SelectListItem singleone = new SelectListItem()
                {
                    Value = item.AppUserId.ToString(),
                    Text = item.FullName
                };
                collection.Add(singleone);
            }
            return collection;
        }


        public IEnumerable<SelectListItem> GetMENameOnly(int AppUserId, int UserTypeId)
        {
            var Data = entity.UsersDetails.Where(x => (x.UserTypeId == UserTypeId && x.AppUserId == AppUserId));
            List<SelectListItem> collection = new List<SelectListItem>();

            foreach (var item in Data)
            {
                SelectListItem singleone = new SelectListItem()
                {
                    Value = item.AppUserId.ToString(),
                    Text = item.FullName
                };
                collection.Add(singleone);
            }
            return collection;
        }

        public IEnumerable<SelectListItem> GetCurrency()
        {
            var Data = entity.Currencies.Where(x => x.CurrencyId == 1 || x.CurrencyId == 2);

            List<SelectListItem> collection = new List<SelectListItem>();
            foreach (var item in Data)
            {
                SelectListItem singleone = new SelectListItem()
                {
                    Value = item.CurrencyId.ToString(),
                    Text = item.CurrencyCode
                };
                collection.Add(singleone);
            }
            return collection;
        }
    }
}