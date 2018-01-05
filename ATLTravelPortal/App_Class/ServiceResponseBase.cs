using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
namespace ATLTravelPortal.App_Class
{
    public abstract class ServiceResponseBase
    {

        public ServiceResponseBase(string message, MessageType messageType
            , bool responseStatus, string responseTransactionMode = null)
        {
            ResponseMessage = message;
            ResponseMessageType = messageType;
            ResponseStatus = responseStatus;
            ResponseTransactionMode = responseTransactionMode;
        }

        public string ResponseMessage { get; private set; }

        public MessageType ResponseMessageType { get; private set; }

        public string ResponseTransactionMode { get; private set; }

        public bool ResponseStatus { get; private set; }

        public void AppendMessage(string errorMessage)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(ResponseMessage))
            {
                sb.Append(ResponseMessage);
                sb.Append("/r/n");
                sb.Append(errorMessage);
                ResponseMessage = sb.ToString();
            }
            else
                ResponseMessage = errorMessage;
        }

    }

    public enum MessageType
    {
        Warning,
        Error,
        Success,
        Exception,
        SqlException,
    }
}