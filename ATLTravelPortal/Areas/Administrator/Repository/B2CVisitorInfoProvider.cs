using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class B2CVisitorInfoProvider
    {
        EntityModel ent = new EntityModel();

        public List<B2CVisitorInfoModel> ListB2CVisitorInfoReport()
        {
            int sno = 0;
            var data = ent.VisitorInfo;

            List<B2CVisitorInfoModel> model = new List<B2CVisitorInfoModel>();

            foreach (var item in data.Select(x => x).OrderByDescending(x=>x.CreatedDate))
            {
                sno++;
                var B2CVisitorInfoModel = new B2CVisitorInfoModel();
                B2CVisitorInfoModel.SN0 = sno;
                B2CVisitorInfoModel.VisitorId = (int) item.VisitorId;
                B2CVisitorInfoModel.Name = item.Name;
                B2CVisitorInfoModel.Address = item.Address;
                B2CVisitorInfoModel.Email = item.Email;
                B2CVisitorInfoModel.ContactNo = item.ContactNo;
                B2CVisitorInfoModel.SRC = item.SRC;
                B2CVisitorInfoModel.Type = item.Type;
                B2CVisitorInfoModel.Profession = item.Profession;
                B2CVisitorInfoModel.CreatedDate = item.CreatedDate;

                model.Add(B2CVisitorInfoModel);
            }
            return model.ToList();
        }
    }
}