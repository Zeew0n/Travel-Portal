using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Models;
using ATLTravelPortal.Areas.Bus.Models;
using TravelPortalEntity;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;


namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusSearchLogRepository
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();

        public BusSearchLogModel GetSearchLogList(BusSearchLogModel mdl )
        {
            var LogList = _ent.Bus_SearchRequest.Where(x=>x.CreatedDate > mdl.FromDate && x.CreatedDate < mdl.ToDate);
            if (mdl.AgentId != null) { LogList = LogList.Where(y => y.AgentId == mdl.AgentId); }

            List<BusSearchLogModel> Templst = new List<BusSearchLogModel>();
            List<BusSearchLogModel> Reallst = new List<BusSearchLogModel>();
            if (LogList != null && LogList.Any())
            {
                foreach (var item in LogList)
                {
                    BusSearchLogModel model = new BusSearchLogModel
                    {
                        AgentName = item.Agents.AgentName
                    };
                    Templst.Add(model);
                }
                //==================
                
                foreach (var tempitm in Templst)
                {
                   

                    if (Reallst != null && Reallst.Any())
                    {
                        int count = 0;
                        foreach (var realitm in Reallst)
                        {
                            if (tempitm.AgentName == realitm.AgentName)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            //add new   to real list..
                            var fillitm = Templst.Where(x => x.AgentName == tempitm.AgentName).ToList();
                            BusSearchLogModel model = new BusSearchLogModel
                            {
                                AgentName = fillitm.FirstOrDefault().AgentName,
                                NoOfSearch = fillitm.Count()
                            };
                            Reallst.Add(model);

                        }
                    }
                    else
                    {
                        //add new  //add new   to real list..
                        var fillitm = Templst.Where(x => x.AgentName == tempitm.AgentName).ToList();
                        BusSearchLogModel model = new BusSearchLogModel
                        {
                            AgentName = fillitm.FirstOrDefault().AgentName,
                            NoOfSearch = fillitm.Count()
                        };
                        Reallst.Add(model);
                    }
                }
            }
            //------------------
            mdl.SeachList = Reallst;
            return mdl;
        }

        public BusSearchLogModel FillModelddl(BusSearchLogModel mdl)
        {
            mdl.AgentListddl = AgentListddl();
            return mdl;
        }
        public List<SelectListItem> AgentListddl()
        {
            var AgentList = _ent.Agents;
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem {Value="",Text = "--Select--" });
            if (AgentList != null && AgentList.Any())
            {
                foreach (var item in AgentList)
                {
                    list.Add(new SelectListItem { Value = item.AgentId.ToString(), Text = item.AgentName });
                }
            }
            return list;
        }
    }
}