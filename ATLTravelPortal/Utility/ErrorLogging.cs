using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;

namespace ATLTravelPortal.Utility
{
    public class ErrorLogging 
    {

        public static void LogException(Exception lastException)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Error(lastException);
        }

        public static void BookingLogException(Exception ex, Int64 mPnrId)
        {
            TravelPortalEntity.EntityModel_Logs entity = new EntityModel_Logs();

            BookingExceptions bookingExceptions = new BookingExceptions();
            bookingExceptions.Time_Stamp = DateTime.UtcNow;
            bookingExceptions.Host = "Admin";
            bookingExceptions.MPNRId = mPnrId;
            bookingExceptions.source = ex.Source;
            if (ex.InnerException != null)
                bookingExceptions.message = ex.InnerException.Message;
            else
                bookingExceptions.message = "";
            bookingExceptions.stacktrace = ex.StackTrace;
            entity.AddToBookingExceptions(bookingExceptions);
            entity.SaveChanges();
        }             
    }
}