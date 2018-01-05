using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AdminBankAccountProvider
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        //For filling the Bank Dropdownlist
        public List<Banks> GetBankList()
        {
            return _ent.Banks.ToList();
        }

        public IEnumerable<SelectListItem> GetAllBankList()
        {
            List<Banks> all = GetBankList().ToList();
            var GetAllBankList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BankName,
                    Value = item.BankId.ToString()
                };
                GetAllBankList.Add(teml);
            }
            return GetAllBankList.AsEnumerable();
        }

        //For filling BankBranch DropdownList
        public List<BankBranches> GetBankBranchList(int id)
        {
            return _ent.BankBranches.Where(x => x.BankId == id).ToList();
        }



        //for filling BankAccountTypes
        public List<BankAccountTypes> GetBankAccountTypesList()
        {
            return _ent.BankAccountTypes.ToList();
        }

        //for listing 
        public IEnumerable<AdminBankAccountModel> List()
        {
            List<AdminBankAccountModel> model = new List<AdminBankAccountModel>();
            var result = _ent.Core_AdminBanks;
            foreach (var item in result)
            {
                AdminBankAccountModel obj = new AdminBankAccountModel();

                obj.AdminBankId = item.AdminBankId;
                obj.BankId = item.BankId;
                obj.BankName = item.Banks.BankName;
                obj.BankBranchId = item.BankBranchId;
                obj.BankBranchName = item.BankBranches.BranchName;
                obj.BankAccountTypeId = item.BankAccountTypeId;
                obj.BankAccountTypeName = item.BankAccountTypes.AccountTypeName;
                obj.AccountName = item.AccountName;
                if (obj.AccountNumber == "")
                {
                    obj.AccountNumber = "";
                }
                else
                {
                    obj.AccountNumber = item.AccountNumber;
                }
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        //for adding into Core_AdminBanks Table
        public ActionResponse Create(AdminBankAccountModel model, out ActionResponse _ores)
        {
            if (IsExists(model.AdminBankId, model.BankId, model.BankBranchId, model.AccountNumber) == false)
            {
                Core_AdminBanks datamodel = new Core_AdminBanks
                {
                    BankId = model.BankId,
                    BankBranchId = model.BankBranchId,
                    BankAccountTypeId = model.BankAccountTypeId,
                    AccountName = model.AccountName,
                    AccountNumber = model.AccountNumber
                };
                _ent.AddToCore_AdminBanks(datamodel);
                _ent.SaveChanges();
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
            return _res;
        }

        //for edit
        public ActionResponse Edit(AdminBankAccountModel model)
        {
            if (IsExists(model.AdminBankId, model.BankId, model.BankBranchId, model.AccountNumber) == false)
            {
                Core_AdminBanks result = _ent.Core_AdminBanks.Where(x => x.AdminBankId == model.AdminBankId).FirstOrDefault();
                result.AdminBankId = model.AdminBankId;
                result.BankId = model.BankId;
                result.BankBranchId = model.BankBranchId;
                result.BankAccountTypeId = model.BankAccountTypeId;
                result.AccountName = model.AccountName;
                result.AccountNumber = model.AccountNumber;
                _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bank detail");
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
            return _res;
        }
        public bool IsExists(int Pid, int BankId, int BranchId, string AcNo)
        {
            var obj = _ent.Core_AdminBanks.Where(x => x.AdminBankId != Pid && x.BankId == BankId && x.BankBranchId == BranchId && x.AccountNumber == AcNo).FirstOrDefault();
            if (obj == null)
                return false;
            else
                return true;
        }
        public AdminBankAccountModel Detail(int? id,out ActionResponse _ores)
        {
            AdminBankAccountModel model = new AdminBankAccountModel();

            if (id != null)
            {
                Core_AdminBanks result = _ent.Core_AdminBanks.Where(x => x.AdminBankId == id).FirstOrDefault();
                if (result != null)
                {
                    model.AdminBankId = result.AdminBankId;
                    model.BankId = result.BankId;
                    model.BankName = result.Banks.BankName;
                    model.BankBranchId = result.BankBranchId;
                    model.BankBranchName = result.BankBranches.BranchName;
                    model.BankAccountTypeId = result.BankAccountTypeId;
                    model.BankAccountTypeName = result.BankAccountTypes.AccountTypeName;
                    model.AccountName = result.AccountName;
                    model.AccountNumber = result.AccountNumber;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "My banks");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "My banks");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }

            _ores = _res;
            return model;

        }

        //for delete
        public ActionResponse Delete(int id)
        {
            Core_AdminBanks result = _ent.Core_AdminBanks.Where(x => x.AdminBankId == id).FirstOrDefault();
            _ent.DeleteObject(result);
            _ent.SaveChanges();
            _res.ActionMessage = String.Format(Resources.Message.SuccessfullyDeleted, "My bank");
            _res.ErrNumber = 1005;
            _res.ErrSource = "DataBase";
            _res.ErrType = "App";
            _res.ResponseStatus = true;
            return _res;
        }
        public AdminBankAccountModel FillDdl(AdminBankAccountModel model)
        {
            model.ddlBankList = new SelectList(GetBankList(), "BankId", "BankName");
            model.ddlBankBranchList = new SelectList(GetBankBranchList(model.BankId), "BankBranchId", "BranchName");
            model.ddlAccountTypeList = new SelectList(GetBankAccountTypesList(), "BankAccountTypeId", "AccountTypeName");
            return model;
        }


    }
}