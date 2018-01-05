
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ATLTravelPortal.App_Class
{
    public class ServiceResponse : ServiceResponseBase
    {

        public ServiceResponse(string message, MessageType messageType
            , bool responseStatus, string responseTransactionMode = null)
            : base(message, messageType
            , responseStatus, responseTransactionMode)
        {

        }
        public long CurrentIdentityId { get; set; }
        public string CurrentIdentityValue { get; set; }
    }


    public static class ServiceResponsesProvider
    {

        public static string SqlExceptionMessage(SqlException ex)
        {
            string message = ex.Number >= 50000 ? ex.Message : ResposeMessage(ex.Number.ToString());
            return message;

        }

        public static string ResposeMessage(string key, string msgParm = "")
        {
            ViewDataDictionary viewDictionary = MessageCollection();
            if (viewDictionary[key] != null)
                return string.Format(viewDictionary[key].ToString(), msgParm);
            else
                return "Unknown Error. Please contact to administrator.";
        }

        private static ViewDataDictionary MessageCollection()
        {
            return new ViewDataDictionary{
                new KeyValuePair<string, object>("Duplicate","Duplicate record found {0}."),
                new KeyValuePair<string, object>("Add","Error in adding {0}."),
                new KeyValuePair<string, object>("Edit","Error in edting {0}."),
                new KeyValuePair<string, object>("547", "This record has been used in child record."),
                new KeyValuePair<string, object>("1011", "Unable to delete."),
                new KeyValuePair<string, object>("1020", "Record has changed since last read in table {0}."),
                new KeyValuePair<string, object>("1022", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("1029", "View doesn't exist {0}."),
                new KeyValuePair<string, object>("1040", "Too many connections."),
                new KeyValuePair<string, object>("1053", "Server shutdown in progress."),
                new KeyValuePair<string, object>("10223", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("10224", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("10225", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("10226", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("10227", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("10228", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("10229", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("102211", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("102212", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("102213", "Duplicate column found {0}."),
                new KeyValuePair<string, object>("102214", "Duplicate column found {0}."),
               
            };
        }




    }
}