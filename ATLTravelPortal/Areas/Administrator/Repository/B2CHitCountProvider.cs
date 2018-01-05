using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Repository
{

    public class B2CHitCountProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public int GetHitCount(B2CHitCountModel model)
        {
            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("Count", 0);
           ent.Core_GetSiteHitCount("B2C", model.FromDate, model.ToDate, param);
           return int.Parse(param.Value.ToString());

            
            
        }

    }
}