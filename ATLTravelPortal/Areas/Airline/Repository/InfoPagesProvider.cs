using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class InfoPagesProvider
    {
        EntityModel ent = new EntityModel();
        public IEnumerable<InfoPagesModel> GetList()
        {
            int sno = 0;
            List<InfoPagesModel> ddlList = new List<InfoPagesModel>();
            var result = ent.InfoPages;
            foreach (var item in result)
            {
                sno++;
                InfoPagesModel obj = new InfoPagesModel
                {
                    SNO=sno,
                    InfoId = item.InfoId,
                    Name = item.Name,
                    Title = item.Title,
                    Description = item.Description
                };
                ddlList.Add(obj);
            }
            return ddlList.AsEnumerable();

        }
        public void Save(InfoPagesModel model)
        {
            InfoPages result = new InfoPages();
            result.Name = model.Name;
            result.Title = model.Title;
            //result.Description = Server.HtmlEncode(model.Description);
            result.Description = HttpContext.Current.Server.HtmlEncode(model.Description.Replace("/n", "<p> </p>"));
            ent.AddToInfoPages(result);
            ent.SaveChanges();
        }
        public void Edit(InfoPagesModel model)
        {
            var result = ent.InfoPages.Where(x => x.InfoId == model.InfoId).FirstOrDefault();
            result.Name = model.Name;
            result.Title = model.Title;
            result.Description = HttpContext.Current.Server.HtmlEncode(model.Description.Replace("/n", "<p> </p>"));
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }
        public InfoPagesModel GetDetails(int PId)
        {
            InfoPagesModel model = new InfoPagesModel();
            var result = ent.InfoPages.Where(x => x.InfoId == PId).FirstOrDefault();
            model.InfoId = result.InfoId;
            model.Name = result.Name;
            model.Title = result.Title;
            model.Description = result.Description;
            return model;
        }
        public string GetDescription(string Name)
        {
            string result = ent.InfoPages.Where(x => x.Name == Name).Select(x => x.Description).FirstOrDefault();
            if (result != null)
            {

                result.Replace("\n", "\\\\n");
                result.Replace("\r", "\\\\r");
                return result;
            }
            else
                return "Page not found";
        }
        public void Delete(int PId)
        {
            var result = ent.InfoPages.Where(x => x.InfoId == PId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }
    }
}