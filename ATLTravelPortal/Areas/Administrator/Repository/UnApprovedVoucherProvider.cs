using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class UnApprovedVoucherProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public List<UnApprovedVoucherModel> GetUnapprovedvoucherList()
        {
            var data = ent.GL_GetUnApprovedVoucher();

            List<UnApprovedVoucherModel> model = new List<UnApprovedVoucherModel>();

            foreach (var item in data)
            {
                var UnApprovedVoucherModel = new UnApprovedVoucherModel
                {
                  VoucherNo = item.VoucherNo,
                  TranDate = item.TranDate,
                  ProductName = item.ProductName,
                  LedgerName = item.LedgerName,
                  Narration1 = item.Narration1,
                  CreditAmount = item.CreditAmount,
                  DebitAmount = item.DebitAmount
                };
                model.Add(UnApprovedVoucherModel);

            }
            return model;
        }


       



        public void Approve(long Id, int userid)
        {
            //GL_Transactions result = ent.GL_Transactions.Where(x => x.VoucherNo == Id).FirstOrDefault();

            List<GL_Transactions> result = ent.GL_Transactions.Where(x => x.VoucherNo == Id).ToList();
            foreach (var rslt in result)
            {
                
                rslt.TranStatusId = 2;
                rslt.CheckerId = userid;
                rslt.CheckerDate = DateTime.Now;

                ent.ApplyCurrentValues(rslt.EntityKey.EntitySetName, rslt);
                ent.SaveChanges();
            }

        }

        public void Cancel(long id, int userid)
        {
           // GL_Transactions result = ent.GL_Transactions.Where(x => x.VoucherNo == id).FirstOrDefault();

            List<GL_Transactions> result = ent.GL_Transactions.Where(x => x.VoucherNo == id).ToList();
            foreach (var item in result)
            {
                item.TranStatusId = 3;
                item.CheckerId = userid;
                item.CheckerDate = DateTime.Now;

                ent.ApplyCurrentValues(item.EntityKey.EntitySetName, item);
                ent.SaveChanges();
            }

            //result.TranStatusId = 3;
            //result.CheckerId = userid;
            //result.CheckerDate = DateTime.Now;

          
        }




    }
}