using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
namespace ATLTravelPortal.Areas.Airline.Repository
{
    
    public class BankManagementProvider
    {
        EntityModel ent = new EntityModel();
        public void CreateBank(BankManagementsModel model)
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

        public void BranchCreate(BranchManagementsModel model)
        {
            model.BankId = GetLastBankId();
            BankBranches obj = new BankBranches
            {
                BankId = model.BankId,
                BranchName = model.BranchName,
                BranchAddress = model.BranchAddress,
                CountryId = model.CountryId,
                PhoneNumber = model.BranchPhoneNumber,
                ContactPerson = model.BranchContactPerson,
                ContactPersonPhoneNo = model.BranchContactPhoneNo,
                ContactPersonEmail = model.BranchContactEmail,
            };
            ent.AddToBankBranches(obj);
            ent.SaveChanges();
        }

        public void CreateBranch(BranchManagementsModel model)
        {
          
            BankBranches obj = new BankBranches
            {
                BankId = model.BankId,
                BranchName = model.BranchName,
                BranchAddress = model.BranchAddress,
                CountryId = model.BranchCountryId,
                PhoneNumber = model.BranchPhoneNumber,
                ContactPerson = model.BranchContactPerson,
                ContactPersonPhoneNo = model.BranchContactPhoneNo,
                ContactPersonEmail = model.BranchContactEmail,
            };
            ent.AddToBankBranches(obj);
            ent.SaveChanges();
        }
        public BankManagementsModel GetDetailsOfBank(int BankId)
        {
            
            var result = ent.Banks.Where(x => x.BankId == BankId).FirstOrDefault();
            BankManagementsModel model = new BankManagementsModel
            {
                BankId = result.BankId,
                BankName = result.BankName,
                BankAddress = result.BankAddress,
                PhoneNo = result.PhoneNo,
                ContactPerson = result.ContactPerson,
                ContactPersonPhoneNo = result.ContactPersonPhoneNo,
                ContactPersonMobileNo = result.ContactPersonMobileNo,
                ContactPersonEmail = result.ContactPersonEmail
            };
            
            return model;
            
        }

        public BankManagementsModel GetDetailsOfBranch(int BankBranchId)
        {
            BankBranches result = new BankBranches();
             result = ent.BankBranches.Where(x => x.BankBranchId == BankBranchId).FirstOrDefault();
            BankManagementsModel model = new BankManagementsModel 
            { 
             BranchName = result.BranchName,
             BranchAddress = result.BranchAddress,
             BranchContactPerson = result.ContactPerson,
             BranchContactEmail = result.ContactPersonEmail,
             BranchContactPhoneNo = result.ContactPersonPhoneNo,
             BankName = result.Banks.BankName,
             BranchPhoneNumber = result.PhoneNumber,
             BranchCountryName = result.Countries.CountryName,
             BranchCountryId = result.CountryId,
             BankBranchId = result.BankBranchId,
             BankId = result.BankId,
            };
            return model;
        }

        public BranchManagementsModel GetBranchDetails(int BankBranchId)
        {
            BankBranches result = new BankBranches();
            result = ent.BankBranches.Where(x => x.BankBranchId == BankBranchId).FirstOrDefault();
            BranchManagementsModel model = new BranchManagementsModel
            {
                BranchName = result.BranchName,
                BranchAddress = result.BranchAddress,
                BranchContactPerson = result.ContactPerson,
                BranchContactEmail = result.ContactPersonEmail,
                BranchContactPhoneNo = result.ContactPersonPhoneNo,
                BranchPhoneNumber = result.PhoneNumber,
                BranchCountryId = result.CountryId,
                BankBranchId = result.BankBranchId,
                BankId = result.BankId,
                BankName = result.Banks.BankName
            };
            return model;
        }
        public void UpdateBranch(BankManagementsModel model)
        {
            BankBranches result = ent.BankBranches.Where(x => x.BankBranchId == model.BankBranchId).FirstOrDefault();
            result.BranchAddress = model.BranchAddress;
            result.BranchName = model.BranchName;
            result.ContactPerson = model.BranchContactPerson;
            result.PhoneNumber = model.BranchPhoneNumber;
            result.ContactPersonPhoneNo = model.BranchContactPhoneNo;
            result.ContactPersonEmail = model.BranchContactEmail;
            result.CountryId = model.BranchCountryId;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }
        public void BranchUpdate(BranchManagementsModel model)
        {
            BankBranches result = ent.BankBranches.Where(x => x.BankBranchId == model.BankBranchId).FirstOrDefault();
            result.BranchAddress = model.BranchAddress;
            result.BranchName = model.BranchName;
            result.ContactPerson = model.BranchContactPerson;
            result.PhoneNumber = model.BranchPhoneNumber;
            result.ContactPersonPhoneNo = model.BranchContactPhoneNo;
            result.ContactPersonEmail = model.BranchContactEmail;
            result.CountryId = model.BranchCountryId;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }
        //public IEnumerable<BankManagementsModel> GetBanksBranchList(int BankId)
        //{
        //    var result = from a in ent.BankBranches
        //                 where a.BankId == BankId
        //                 select new { a.BankId, a.BankBranchId, a.BranchAddress, a.BranchName, a.ContactPerson, a.ContactPersonEmail, a.ContactPersonPhoneNo, a.CountryId };
            
        //    List<BankManagementsModel> model = new List<BankManagementsModel>();
        //    foreach (var item in result)
        //    {
                
        //    }
        //    return model;
        //}
        public IEnumerable<BranchManagementsModel> GetBranchOfBank(int BankId)
        {    List<BranchManagementsModel> obj = new List<BranchManagementsModel>();
            var result = ent.BankBranches.Where(x => x.BankId == BankId);
            foreach(var item in result)
            {
             BranchManagementsModel model = new BranchManagementsModel
             {
              BankBranchId = item.BankBranchId,
              CountryId = item.CountryId,
              BankId = item.BankId,
              BranchName = item.BranchName,
              BranchAddress = item.BranchAddress,
              BranchContactPerson = item.ContactPerson,
              BranchContactPhoneNo = item.ContactPersonPhoneNo,
              BranchPhoneNumber = item.PhoneNumber,
              BranchContactEmail = item.ContactPersonEmail,
              BankName = item.Banks.BankName
             };
             obj.Add(model);
            }
            return obj;
        }

        public void DeleteBank(int BankId)
        {
            Banks model = ent.Banks.First(x => x.BankId == BankId);
            ent.DeleteObject(model);
            ent.SaveChanges();
        }
        public void DeleteBranch(int BankBranchId)
        {
            BankBranches model = ent.BankBranches.First(x => x.BankBranchId == BankBranchId);
            ent.DeleteObject(model);
            ent.SaveChanges();
        }

        public IEnumerable<BankManagementsModel> GetBanksList()
        {
            var result = ent.Banks;
            List<BankManagementsModel> model = new List<BankManagementsModel>();
            foreach (var item in result)
            {
                BankManagementsModel obj = new BankManagementsModel 
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

        public void UpdateBanks(BankManagementsModel model)
        {
            Banks result = ent.Banks.Where(x => x.BankId == model.BankId).FirstOrDefault();
            Banks item = new Banks{
                BankId = model.BankId,
             BankName = model.BankName,
             BankAddress = model.BankAddress,
             PhoneNo = model.PhoneNo,
             ContactPerson = model.ContactPerson,
             ContactPersonPhoneNo = model.ContactPersonPhoneNo,
             ContactPersonMobileNo = model.ContactPersonMobileNo,
             ContactPersonEmail = model.ContactPersonEmail,
             CountryId = model.CountryId
            };
            
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, item);
            ent.SaveChanges();
        }

        public List<Banks> GetBanks()
        {
            var result = ent.Banks;
            return result.ToList();
        }

        public void CreateBranch(BankManagementsModel model)
        {
            BankBranches obj = new BankBranches
            {   BankId = model.BankId,
                CountryId = model.CountryId,
                BranchName = model.BranchName,
                BranchAddress = model.BranchAddress,
                PhoneNumber = model.BranchPhoneNumber,
                ContactPerson = model.BranchContactPerson,
                ContactPersonPhoneNo = model.BranchContactPerson,
                ContactPersonEmail = model.BranchContactEmail

            };
            ent.AddToBankBranches(obj);
            ent.SaveChanges();
        }
        public bool VerifyBankInput(string bankname, string address, string phoneno, string person)
        {
            if (bankname == "" || address == "" || phoneno == "" || person == "")
            {
                return false;
            }
            else
                return true;
        }
        public bool VerifyBranchInput(int BankId,string branchName,string branchAddress,int countryId,string branchPhoneNo)
        {
            if(BankId ==0|| branchName == "" || branchAddress ==""|| countryId== 0 || branchPhoneNo == "")
            {
             return false;
            }
            return true;
         }
        public BranchManagementsModel ConverToBranch(BankManagementsModel model)
        {
            BranchManagementsModel item = new BranchManagementsModel
            {
                BankId = model.BankId,
                BranchAddress = model.BranchAddress,
                CountryId = model.BranchCountryId,
                BranchName = model.BranchName,
                BranchPhoneNumber = model.BranchPhoneNumber,
                BranchContactPerson = model.BranchContactPerson,
                BranchContactEmail = model.BranchContactEmail,
                BranchContactPhoneNo = model.BranchContactPhoneNo,

            };
            return item;
        }
        public int GetLastBankId()
        {
            int Id = ent.Banks.Select(x => x.BankId).Max();
            return Id;
        }
        public int GetLastBranchId(int BankId)
        {
            int Id = ent.BankBranches.Where(x => x.BankId == BankId).Select(x => x.BankBranchId).Max();
            return Id;
        }
        
    }
}