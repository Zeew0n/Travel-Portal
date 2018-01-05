using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusMessageModel
    {
        public int MsgNumber { get; set; }
        public string ActionMessage { get; set; }
        public string ErrSource { get; set; }
        public int MsgType { get; set; }

        /// <summary>
        /// MsgType 
        /// 0: Success
        /// 1: Info
        /// 2: Alart
        /// 3: Error
        /// </summary>

        public bool MsgStatus { get; set; }
    }
}