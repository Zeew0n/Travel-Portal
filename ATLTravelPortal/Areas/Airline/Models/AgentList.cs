using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ATLTravelPortal.Areas.Airline.Repository;
using TravelPortalEntity;



namespace ATLTravelPortal.Areas.Airline.Models
{  
    public class AgentList
    {   
        GeneralProvider _provider = new GeneralProvider();
    private IEnumerable<Agents> _AgentList;
    //public IEnumerable<Agents> AgentList
    //{
    //    get { return _AgentList; }
    //    set
    //    {

    //    }
    //}   
        public string AgentName { get; set; }
        public bool IsSelected { get; set; }
    }
}