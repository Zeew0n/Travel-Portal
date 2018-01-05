using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    
    public class BankManagementProvider
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        GeneralProvider _gpro = new GeneralProvider();
        BankManagementsModel _model = new BankManagementsModel();
        public BankManagementsModel Create(BankManagementsModel model, out ActionResponse _ores)
        {
            if (IsExists(model.BankId, model.BankName) == false)
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
                _ent.AddToBanks(obj);
                _ent.SaveChanges();
                model.BankId = obj.BankId;
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullySaved, "Bank detail");
                _res.ErrNumber = 0;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bank detail");
                _res.ErrNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            _ores = _res;
            return model;
        }
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
            _ent.AddToBanks(obj);
            _ent.SaveChanges();
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
            _ent.AddToBankBranches(obj);
            _ent.SaveChanges();
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
            _ent.AddToBankBranches(obj);
            _ent.SaveChanges();
        }
        public BankManagementsModel BankDetail(int? Id, out ActionResponse _ores)
        {
            if (Id != null)
            {
                var result = _ent.Banks.Where(x => x.BankId == Id).FirstOrDefault();
                if (result != null)
                {
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
                    _ores = _res;
                    return model;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bank");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                    _ores = _res;
                    return _model;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bank");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                _ores = _res;
                return _model;
            }
            
        }

        public BankManagementsModel BranchDetail(int? Id,out ActionResponse _ores)
        {
            if (Id != null)
            {
                BankBranches result = new BankBranches();
                result = _ent.BankBranches.Where(x => x.BankBranchId == Id).FirstOrDefault();
                if (result != null)
                {
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
                    _ores = _res;
                    return model;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Branch");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                    _ores = _res;
                    return _model;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Branch");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                _ores = _res;
                return _model;
            }
           
        }

        public BranchManagementsModel GetBranchDetails(int BankBranchId)
        {
            BankBranches result = new BankBranches();
            result = _ent.BankBranches.Where(x => x.BankBranchId == BankBranchId).FirstOrDefault();
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
            BankBranches result = _ent.BankBranches.Where(x => x.BankBranchId == model.BankBranchId).FirstOrDefault();
            result.BranchAddress = model.BranchAddress;
            result.BranchName = model.BranchName;
            result.ContactPerson = model.BranchContactPerson;
            result.PhoneNumber = model.BranchPhoneNumber;
            result.ContactPersonPhoneNo = model.BranchContactPhoneNo;
            result.ContactPersonEmail = model.BranchContactEmail;
            result.CountryId = model.BranchCountryId;
            _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            _ent.SaveChanges();
        }
        public void BranchUpdate(BranchManagementsModel model)
        {
            BankBranches result = _ent.BankBranches.Where(x => x.BankBranchId == model.BankBranchId).FirstOrDefault();
            result.BranchAddress = model.BranchAddress;
            result.BranchName = model.BranchName;
            result.ContactPerson = model.BranchContactPerson;
            result.PhoneNumber = model.BranchPhoneNumber;
            result.ContactPersonPhoneNo = model.BranchContactPhoneNo;
            result.ContactPersonEmail = model.BranchContactEmail;
            result.CountryId = model.BranchCountryId;
            _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            _ent.SaveChanges();
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
        public IEnumerable<BranchManagementsModel> BranchList(int? BankId)
        {    List<BranchManagementsModel> obj = new List<BranchManagementsModel>();
            var result = _ent.BankBranches.Where(x => x.BankId == BankId);
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
            Banks model = _ent.Banks.First(x => x.BankId == BankId);
            _ent.DeleteObject(model);
            _ent.SaveChanges();
        }
        public void DeleteBranch(int BankBranchId)
        {
            BankBranches model = _ent.BankBranches.First(x => x.BankId == BankBranchId);
            _ent.DeleteObject(model);
            _ent.SaveChanges();
        }

        public IEnumerable<BankManagementsModel> List()
        {
            var result = _ent.Banks;
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
            Banks result = _ent.Banks.Where(x => x.BankId == model.BankId).FirstOrDefault();
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
            
            _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, item);
            _ent.SaveChanges();
        }

        public List<Banks> GetBanks()
        {
            var result = _ent.Banks;
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
            _ent.AddToBankBranches(obj);
            _ent.SaveChanges();
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
            int Id = _ent.Banks.Select(x => x.BankId).Max();
            return Id;
        }
        public int GetLastBranchId(int BankId)
        {
            int Id = _ent.BankBranches.Where(x => x.BankId == BankId).Select(x => x.BankBranchId).Max();
            return Id;
        }
        private bool IsExists(int BankId, string Name, int? BranchId = null)
        {
            if (BranchId == null)
            {
                var obj = _ent.Banks.Where(x => x.BankId != BankId && x.BankName == Name).FirstOrDefault();
                if (obj == null)
                    return false;
                else
                    return true;
            }
            else
            {
                var obj = _ent.BankBranches.Where(x => x.BankId == BankId && x.BankBranchId != BranchId.Value && x.BranchName == Name).FirstOrDefault();
                if (obj == null)
                    return false;
                else
                    return true;
            }
        }
        public BankManagementsModel FillDdl(BankManagementsModel model)
        {
           model.ddlCountriesList= new SelectList(_gpro.GetCountryList(), "CountryId", "CountryName");
           return model;
        }


        //for delete
        public void BankDelete(int BankId)
        {
            Banks result = _ent.Banks.Where(x => x.BankId == BankId).FirstOrDefault();
            _ent.DeleteObject(result);
            _ent.SaveChanges();
        }


       


    }
}