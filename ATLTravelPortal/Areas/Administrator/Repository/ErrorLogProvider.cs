using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class ErrorLogProvider
    {
        TravelPortalEntity.EntityModel_Logs ent = new TravelPortalEntity.EntityModel_Logs();
        
        public List<ErrorLogModel> ListErrorLog(DateTime? FromDate, DateTime? ToDate)
        {
            var data = ent.NLog_Error.Where(x=> (x.time_stamp >= FromDate && x.time_stamp <= ToDate));

            List<ErrorLogModel> model = new List<ErrorLogModel>();

            foreach (var item in data)
            {
                var ErrorLogModel = new ErrorLogModel
                {
                    time_stamp = item.time_stamp,
                    source = item.source,
                    message = !string.IsNullOrEmpty(item.message) ? item.message.Trim() : null,
                    logger = !string.IsNullOrEmpty(item.logger) ? item.logger.Trim() : null
                };
                model.Add(ErrorLogModel);

            }
            return model.OrderByDescending(x => x.time_stamp).ToList();
        }
    }
}