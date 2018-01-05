using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class ConfigureAccountProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        public IEnumerable<LedgerModel> GetLedgerList(int ProductId)
        {
            var result = ent.GL_Ledgers.Where(x => x.ProductId == ProductId);
            List<LedgerModel> model = new List<LedgerModel>();
            foreach (var item in result)
            {
                LedgerModel obj = new LedgerModel
                {
                    LedgerId = item.LedgerId,
                    LedgerName = item.LedgerName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
       
        public IEnumerable<ConfigureAccountModel> GetConfigureAccountList(int productId)
        {
            List<ConfigureAccountModel> model = new List<ConfigureAccountModel>();
            var result = ent.GL_AccountConf.Where(x => x.ProductId == productId);
            foreach (var item in result)
            {
                ConfigureAccountModel obj = new ConfigureAccountModel();
                obj.AccountConfId = item.AccountConfId;
                obj.AccountConfName = item.AccountConfName;
                obj.AccountValue = item.AccountConfId.ToString();
                obj.LedgerId = item.MappedLedgerId;
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public ConfigureAccountModel GetDetailsOfAccount(int AccountConfId)
        {
            var result = ent.GL_AccountConf.Where(x => x.AccountConfId == AccountConfId).FirstOrDefault();
            ConfigureAccountModel model = new ConfigureAccountModel();
            model.LedgerId = result.GL_Ledgers.LedgerId;
            model.AccountConfName = result.AccountConfName;
            model.AccountConfId = result.AccountConfId;
            return model;
        }
        public void SaveConfigureAccount(int AccountConfId,int ProductId,int LedgerId)
        {
            GL_AccountConf result= ent.GL_AccountConf.Where(x=>x.AccountConfId == AccountConfId).FirstOrDefault();
            result.ProductId = ProductId;
            result.MappedLedgerId = LedgerId;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

    }
}