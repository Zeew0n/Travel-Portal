using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class BankBranchProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public void CreateBankBranch(BankBranchModel model)
        {
            BankBranches obj = new BankBranches
            {

                BankId = model.BankId,
                CountryId = model.CountryId,
                BranchName = model.BranchName,
                BranchAddress = model.BranchAddress,
                PhoneNumber = model.PhoneNo,
                ContactPerson = model.ContactPerson,
                ContactPersonPhoneNo = model.ContactPersonPhoneNo,
                ContactPersonEmail = model.ContactPersonEmail


            };
            ent.AddToBankBranches(obj);
            ent.SaveChanges();
        }

        public IEnumerable<BankBranchModel> ListBankBranch()
        {
            var result = ent.BankBranches;
            List<BankBranchModel> model = new List<BankBranchModel>();
            foreach (var item in result)
            {
                BankBranchModel obj = new BankBranchModel
                {
                    BankBranchId = item.BankBranchId,
                    BankId  = item.BankId,
                    BankName = item.Banks.BankName,
                    CountryId = item.CountryId,
                    Country = item.Countries.CountryName,
                    BranchName = item.BranchName,
                    BranchAddress = item.BranchAddress,
                    PhoneNo = item.PhoneNumber,
                    ContactPerson = item.ContactPerson,
                    ContactPersonPhoneNo = item.ContactPersonPhoneNo,
                    ContactPersonEmail = item.ContactPersonEmail
                };
                model.Add(obj);
            }
            return model;
        }

        //for edit
        public void EditBankBranch(BankBranchModel model)
        {
            BankBranches result = ent.BankBranches.Where(x => x.BankBranchId == model.BankBranchId).FirstOrDefault();

            result.BankBranchId = model.BankBranchId;
            result.BankId = model.BankId;
            result.CountryId = model.CountryId;
            result.BranchName = model.BranchName;
            result.BranchAddress = model.BranchAddress;
            result.PhoneNumber = model.PhoneNo;
            result.ContactPerson = model.ContactPerson;
            result.ContactPersonPhoneNo = model.ContactPersonPhoneNo;
            result.ContactPersonEmail = model.ContactPersonEmail;
          

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public BankBranchModel BankBranchDetail(int BankBranchId)
        {
            BankBranches result = ent.BankBranches.Where(x => x.BankBranchId == BankBranchId).FirstOrDefault();
            BankBranchModel model = new BankBranchModel();

            model.BankBranchId = result.BankBranchId;
            model.BankId = result.BankId;
            model.BankName = result.Banks.BankName;
            model.CountryId = result.CountryId;
            model.Country = result.Countries.CountryName;
            model.BranchName = result.BranchName;
            model.BranchAddress = result.BranchAddress;
            model.PhoneNo = result.PhoneNumber;
            model.ContactPerson = result.ContactPerson;
            model.ContactPersonPhoneNo = result.ContactPersonPhoneNo;
            model.ContactPersonEmail = result.ContactPersonEmail;

            return model;

        }

        //for delete
        public void BankBranchDelete(int BankBranchId)
        {
            BankBranches result = ent.BankBranches.Where(x => x.BankBranchId == BankBranchId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public BankBranchModel FillDdl(BankBranchModel model)
        {
            GeneralProvider _gpro = new GeneralProvider();
            model.ddlCountriesList = new SelectList(_gpro.GetCountryList(), "CountryId", "CountryName");
            model.ddlBankList = new SelectList(_gpro.GetBankList(), "BankId", "BankName");
            return model;
        }
    }
}