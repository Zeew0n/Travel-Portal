using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
  

    public class BankProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public void CreateBank(BankModel model)
        {
            Banks obj = new Banks
            {
                BankName = model.BankName,
                BankAddress = model.BankAddress,
                PhoneNo = model.PhoneNo,
                ContactPerson = model.ContactPerson,
                ContactPersonPhoneNo = model.ContactPersonPhoneNo,
                ContactPersonMobileNo = model.ContactPersonMobileNo,
                ContactPersonEmail = model.ContactPersonEmail,
                CountryId = model.CountryId
            };
            ent.AddToBanks(obj);
            ent.SaveChanges();
        }

        public IEnumerable<BankModel> ListBank()
        {
            var result = ent.Banks;
            List<BankModel> model = new List<BankModel>();
            foreach (var item in result)
            {
                BankModel obj = new BankModel
                {
                    BankId = item.BankId,
                    BankName = item.BankName,
                    BankAddress = item.BankAddress,
                    PhoneNo = item.PhoneNo,
                    ContactPerson = item.ContactPerson,
                    ContactPersonPhoneNo = item.ContactPersonPhoneNo,
                    ContactPersonMobileNo = item.ContactPersonMobileNo,
                    ContactPersonEmail = item.ContactPersonEmail
                };
                model.Add(obj);
            }
            return model;
        }


        //for edit
        public void EditBank(BankModel model)
        {
            Banks result = ent.Banks.Where(x => x.BankId == model.BankId).FirstOrDefault();

            result.BankId = model.BankId;
            result.BankName = model.BankName;
            result.BankAddress = model.BankAddress;
            result.PhoneNo = model.PhoneNo;
            result.ContactPerson = model.ContactPerson;
            result.ContactPersonPhoneNo = model.ContactPersonPhoneNo;
            result.ContactPersonMobileNo = model.ContactPersonMobileNo;
            result.ContactPersonEmail = model.ContactPersonEmail;
            result.CountryId = model.CountryId;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }


        public BankModel BankDetail(int BankId)
        {
            Banks result = ent.Banks.Where(x => x.BankId == BankId).FirstOrDefault();
            BankModel model = new BankModel();

            model.BankId = result.BankId;
            model.BankName = result.BankName;
            model.BankAddress = result.BankAddress;
            model.PhoneNo = result.PhoneNo;
            model.ContactPerson = result.ContactPerson;
            model.ContactPersonPhoneNo = result.ContactPersonPhoneNo;
            model.ContactPersonMobileNo = result.ContactPersonMobileNo;
            model.ContactPersonEmail = result.ContactPersonEmail;
            model.CountryId = result.CountryId;
            

            return model;

        }

        //for delete
        public void BankDelete(int BankId)
        {
            Banks result = ent.Banks.Where(x => x.BankId == BankId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public BankModel FillDdl(BankModel model)
        {
            GeneralProvider _gpro = new GeneralProvider();
            model.ddlCountriesList = new SelectList(_gpro.GetCountryList(), "CountryId", "CountryName");
            return model;
        }





    }
}