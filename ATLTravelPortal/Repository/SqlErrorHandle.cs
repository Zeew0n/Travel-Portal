using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ATLTravelPortal.Repository
{
    public class SqlErrorHandle
    {
        public static string Message(SqlException ex)
        {
            if (ex.Number == 50000)
                return ex.Message;
            else if (ex.Number == 241)
                return Resources.SQLErrorMessage.Error241;
            else if (ex.Number == 242)
                return Resources.SQLErrorMessage.Error242;
            else if (ex.Number == 245)
                return Resources.SQLErrorMessage.Error245;
            else if (ex.Number == 2627)
                return Resources.SQLErrorMessage.Error2627;
            else if (ex.Number == 8152)
                return Resources.SQLErrorMessage.Error8152;
            else if (ex.Number == 547)
                return Resources.SQLErrorMessage.Error547;
            else
                return Resources.SQLErrorMessage.Error;
        }
    }
}
