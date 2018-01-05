using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Utility
{
    public class ServiceResponses
    {


        private bool _checkResponseStatus;
        private int _errNumber;
        private string _errMessage;
        // private string _errDetail;
        private string _errSource;
        private string _errType;
        //private string _successResponseMessage;

        public int ErrNumber
        {
            get { return _errNumber; }
            set { _errNumber = value; }
        }


        public string ErrMessage
        {
            get { return _errMessage; }
            set { _errMessage = value; }
        }


        public string ErrSource
        {
            get { return _errSource; }
            set { _errSource = value; }
        }


        public string ErrType
        {
            get { return _errType; }
            set { _errType = value; }
        }


        public bool CheckResponseStatus
        {
            get { return _checkResponseStatus; }
            set { _checkResponseStatus = value; }
        }

        //public string SuccessResponseMessage
        //{
        //    get { return _successResponseMessage; }
        //    set { _successResponseMessage = value; }
        //}

    }
}