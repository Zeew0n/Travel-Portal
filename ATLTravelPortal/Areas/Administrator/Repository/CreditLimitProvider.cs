using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class CreditLimitProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public void GetMaxandMinDateFromBranchOffice(int BranchOfficeId)
        {
            var date = ent.Core_BranchOfficeCreditLimits.Where(x => x.BranchOfficeId == BranchOfficeId);



            //var maxdate = ent.Core_BranchOfficeCreditLimits.Where(x => x.BranchOfficeId == BranchOfficeId).Select(x => x.EffectiveFrom).FirstOrDefault();
            //var mindate = ent.Core_BranchOfficeCreditLimits.Where(x => x.BranchOfficeId == BranchOfficeId).Select(x => x.ExpireOn).Last();
        }

        public IEnumerable<CreditLimitModel> GetDateList(int BranchOfficeId)
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();

            var result = ent.Core_BranchOfficeCreditLimits.Where(x => x.BranchOfficeId == BranchOfficeId);
            foreach (var item in result.Select(x => x))
            {
                CreditLimitModel obj = new CreditLimitModel();
                obj.hdfEffectiveFrom = item.EffectiveFrom;
                obj.hdfExpireOn = item.ExpireOn;
                obj.txtAmount = item.Amount;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.AgencyName = item.BranchOffices.BranchOfficeName;
                obj.AgencyCode = item.BranchOffices.BranchOfficeCode;
                obj.isApproved = item.isApproved;
                obj.isActive = item.isActive;
                model.Add(obj);
            }
            return model.AsEnumerable();
        }






        public bool CanBranchAssignCreditlimit(int branchofficeid, double amount, int currencyid)
        {
            System.Data.Objects.ObjectParameter Parm_result = new System.Data.Objects.ObjectParameter("CanAssignCreditLimit", false);
            ent.Core_CanBranchAssignCreditlimit(branchofficeid, amount, currencyid, Parm_result);
            if ((Boolean)Parm_result.Value == false)
                return false;
            else
                return true;
        }


        public IEnumerable<CreditLimitModel> GetDistributorDateList(int DistributorId)
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();

            var result = ent.Core_DistributorCreditLimits.Where(x => x.DistributorId == DistributorId);
            foreach (var item in result.Select(x => x))
            {
                CreditLimitModel obj = new CreditLimitModel();
                obj.hdfEffectiveFrom = item.EffectiveFrom;
                obj.hdfExpireOn = item.ExpireOn;
                obj.txtAmount = item.Amount;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.AgencyName = item.Distributors.DistributorName;
                obj.AgencyCode = item.Distributors.DistributorCode;
                obj.isApproved = item.isApproved;
                obj.isActive = item.isActive;
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public int GetBranchOfficeIdbyDistributorId(int distributorid)
        {
            var res = ent.Distributors.Where(x => x.DistributorId == distributorid).Select(x => x.BranchOfficeId).FirstOrDefault();
            return res;
        }



        //For filling Agent dropdownlist
        public List<Agents> GetAgentList()
        {
            return ent.Agents.OrderBy(x => x.AgentName).ToList();
        }

        public List<BranchOffices> GetBrachOfficeList()
        {
            return ent.BranchOffices.OrderBy(x => x.BranchOfficeName).ToList();
        }

        public IEnumerable<SelectListItem> GetAllAgentList()
        {
            List<Agents> all = GetAgentList().ToList();
            var GetAllAgentList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentName,
                    Value = item.AgentId.ToString()
                };
                GetAllAgentList.Add(teml);
            }
            return GetAllAgentList.AsEnumerable();
        }

        public List<Agents> GetDistributorAgentList(int distributorid)
        {
            return ent.Agents.Where(x => x.DistributorId == distributorid).OrderBy(x => x.AgentName).ToList();
        }
        public IEnumerable<SelectListItem> GetAllDistributorAgentList(int distributorid)
        {
            List<Agents> all = GetDistributorAgentList(distributorid).ToList();
            var GetAllAgentList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentName,
                    Value = item.AgentId.ToString()
                };
                GetAllAgentList.Add(teml);
            }
            return GetAllAgentList.AsEnumerable();
        }


        public List<Distributors> GetBranchDistributorList(int BranchOfficeId)
        {
            return ent.Distributors.Where(x => x.BranchOfficeId == BranchOfficeId).OrderBy(x => x.DistributorName).ToList();
        }
        public IEnumerable<SelectListItem> GetAllBranchDistributorList(int BranchOfficeId)
        {
            List<Distributors> all = GetBranchDistributorList(BranchOfficeId).ToList();
            var GetAllBranchDistributorList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DistributorName,
                    Value = item.DistributorId.ToString()
                };
                GetAllBranchDistributorList.Add(teml);
            }
            return GetAllBranchDistributorList.AsEnumerable();
        }


        public IEnumerable<SelectListItem> GetAllBranchOfficeList()
        {
            List<BranchOffices> all = GetBrachOfficeList().ToList();
            var GetAllAgentList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BranchOfficeName,
                    Value = item.BranchOfficeId.ToString()
                };
                GetAllAgentList.Add(teml);
            }
            return GetAllAgentList.AsEnumerable();
        }




        public List<Distributors> GetDistributorList()
        {
            var ts = SessionStore.GetTravelSession();

            return ent.Distributors.OrderBy(x => x.DistributorName).Where(x => x.CreatedBy == ts.AppUserId).ToList();

        }





        public IEnumerable<SelectListItem> GetAllDistributorList()
        {
            List<Distributors> all = GetDistributorList().ToList();
            var GetAllDistributorList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DistributorName,
                    Value = item.DistributorId.ToString()
                };
                GetAllDistributorList.Add(teml);
            }
            return GetAllDistributorList.AsEnumerable();
        }

        //public List<BranchOffices> GetBranchOfficeList()
        //{
        //    var ts = SessionStore.GetTravelSession();

        //    return ent.BranchOffices.OrderBy(x => x.BranchOfficeName).ToList();

        //}

        //public IEnumerable<SelectListItem> GetAllBranchOfficeList()
        //{
        //    List<BranchOffices> all = GetBranchOfficeList().ToList();
        //    var GetAllDistributorList = new List<SelectListItem>();
        //    foreach (var item in all)
        //    {
        //        var teml = new SelectListItem
        //        {
        //            Text = item.BranchOfficeName,
        //            Value = item.BranchOfficeId.ToString()
        //        };
        //        GetAllDistributorList.Add(teml);
        //    }
        //    return GetAllDistributorList.AsEnumerable();
        //}


        public List<Agents> GetAgentListByDistributorId()
        {
            var ts = SessionStore.GetTravelSession();

            return ent.Agents.OrderBy(x => x.AgentName).Where(x => x.CreatedBy == ts.AppUserId).ToList();

        }
        public IEnumerable<SelectListItem> GetAllAgentListByDistributorId()
        {
            List<Agents> all = GetAgentListByDistributorId().ToList();
            var GetAllAgentListByDistributorId = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentName,
                    Value = item.AgentId.ToString()
                };
                GetAllAgentListByDistributorId.Add(teml);
            }
            return GetAllAgentListByDistributorId.AsEnumerable();
        }




        public IEnumerable<SelectListItem> GetAllAgentListByDistributorId(int distributorId)
        {
            List<Agents> all = GetAgentList().Where(x => x.DistributorId == distributorId).ToList();
            var GetAllAgentList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentName,
                    Value = item.AgentId.ToString()
                };
                GetAllAgentList.Add(teml);
            }
            return GetAllAgentList.AsEnumerable();
        }


        //For Filling Type dropdownlist
        public List<Core_CreditLimitTypes> GetTypeList()
        {
            return ent.Core_CreditLimitTypes.ToList();
        }
        public IEnumerable<SelectListItem> GetAllTypeList()
        {
            List<Core_CreditLimitTypes> all = GetTypeList().ToList();
            var GetAllTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CreditLimitTypeName,
                    Value = item.CreditLimitTypeId.ToString()
                };
                GetAllTypeList.Add(teml);
            }
            return GetAllTypeList.AsEnumerable();
        }

        public List<Currencies> GetCurrencies()
        {
            return ent.Currencies.Where(x => (x.CurrencyId == 1 || x.CurrencyId == 2)).ToList();
            //return ent.Currencies.ToList();
        }
        public IEnumerable<SelectListItem> GetAllCurrenciesList()
        {
            List<Currencies> all = GetCurrencies().ToList();

            var GetAllFurrenciesList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CurrencyCode,
                    Value = item.CurrencyId.ToString()
                };
                GetAllFurrenciesList.Add(teml);
            }
            return GetAllFurrenciesList.AsEnumerable();

        }



        public IEnumerable<SelectListItem> GetCurrencyList()
        {
            List<Currencies> all = ent.Currencies.OrderBy(xx => xx.CurrencyId).AsQueryable().ToList();

            var GetAllCurrencyList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {

                    Text = item.CurrencyCode,
                    Value = item.CurrencyId.ToString()
                };
                GetAllCurrencyList.Add(teml);
            }
            return GetAllCurrencyList.AsEnumerable();
        }


        //For Filling Bank dropdownlist
        public List<Banks> GetBankList()
        {
            return ent.Banks.ToList();
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


        public CreditLimitModel GetCreditLimit(int id)
        {
            var model = (from aa in ent.Core_AgentCreditLimits.Where(ii => (ii.AgentCreditLimitId == id))

                         select new CreditLimitModel
                         {
                             AgentCreditLimitId = aa.CreditLimitTypeId,
                             ddlAgentId = aa.AgentId,
                             ddlTypeId = aa.CreditLimitTypeId,
                             txtAmount = aa.Amount,
                             ddlBankId = aa.BankId,
                             FromDate = aa.EffectiveFrom,
                             ToDate = aa.ExpireOn,
                             CurrencyId = aa.CurrencyId


                         }).FirstOrDefault();

            return model;

        }

        public CreditLimitModel GetAdminCreditLimit(int id)
        {
            var model = (from aa in ent.Core_BranchOfficeCreditLimits.Where(ii => (ii.BranchOfficeCreditLimitId == id))

                         select new CreditLimitModel
                         {
                             AgentCreditLimitId = aa.CreditLimitTypeId,
                             ddlAgentId = aa.BranchOfficeId,
                             ddlTypeId = aa.CreditLimitTypeId,
                             txtAmount = aa.Amount,
                             ddlBankId = aa.BankId,
                             FromDate = aa.EffectiveFrom,
                             ToDate = aa.ExpireOn,
                             CurrencyId = aa.CurrencyId


                         }).FirstOrDefault();

            return model;

        }

        public CreditLimitModel GetBranchOfficeCreditLimit(int id)
        {
            var model = (from aa in ent.Core_DistributorCreditLimits.Where(ii => (ii.DistributorCreditLimitId == id))

                         select new CreditLimitModel
                         {
                             AgentCreditLimitId = aa.CreditLimitTypeId,
                             ddlAgentId = aa.DistributorId,
                             ddlTypeId = aa.CreditLimitTypeId,
                             txtAmount = aa.Amount,
                             ddlBankId = aa.BankId,
                             FromDate = aa.EffectiveFrom,
                             ToDate = aa.ExpireOn,
                             CurrencyId = aa.CurrencyId


                         }).FirstOrDefault();

            return model;

        }






        public CreditLimitModel GetCreditLimitDetail(int id)
        {
            Core_AgentCreditLimits result = ent.Core_AgentCreditLimits.Where(x => x.AgentCreditLimitId == id).FirstOrDefault();
            CreditLimitModel model = new CreditLimitModel();


            model.AgentCreditLimitId = result.AgentCreditLimitId;
            model.ddlAgentId = result.AgentId;
            model.ddlTypeId = result.Core_CreditLimitTypes.CreditLimitTypeId;
            model.ddlBankId = result.BankId;
            model.txtAmount = result.Amount;
            model.FromDate = result.EffectiveFrom;
            model.ToDate = result.ExpireOn;
            model.CurrencyId = result.CurrencyId;
            model.Comments = result.Comments;
            model.isApproved = (bool)result.isApproved;

            return model;

        }

        public CreditLimitModel GetAdminCreditLimitDetail(int id)
        {
            Core_BranchOfficeCreditLimits result = ent.Core_BranchOfficeCreditLimits.Where(x => x.BranchOfficeCreditLimitId == id).FirstOrDefault();
            CreditLimitModel model = new CreditLimitModel();


            model.AgentCreditLimitId = result.BranchOfficeCreditLimitId;
            model.ddlAgentId = result.BranchOfficeId;
            model.ddlTypeId = result.Core_CreditLimitTypes.CreditLimitTypeId;
            model.ddlBankId = result.BankId;
            model.txtAmount = result.Amount;
            model.FromDate = result.EffectiveFrom;
            model.ToDate = result.ExpireOn;
            model.CurrencyId = result.CurrencyId;
            model.isApproved = (bool)result.isApproved;

            return model;

        }

        public CreditLimitModel GetBranchOfficeCreditLimitDetail(int id)
        {
            Core_DistributorCreditLimits result = ent.Core_DistributorCreditLimits.Where(x => x.DistributorCreditLimitId == id).FirstOrDefault();
            CreditLimitModel model = new CreditLimitModel();


            model.AgentCreditLimitId = result.DistributorCreditLimitId;
            model.ddlAgentId = result.DistributorId;
            model.ddlTypeId = result.Core_CreditLimitTypes.CreditLimitTypeId;
            model.ddlBankId = result.BankId;
            model.txtAmount = result.Amount;
            model.FromDate = result.EffectiveFrom;
            model.ToDate = result.ExpireOn;
            model.CurrencyId = result.CurrencyId;
            model.isApproved = (bool)result.isApproved;

            return model;

        }


        public bool CanDistrubutorAssignCreditLimit(int distributorid, double amount, int currencyid)
        {
            System.Data.Objects.ObjectParameter Parm_result = new System.Data.Objects.ObjectParameter("CanAssignCreditLimit", false);
            ent.Core_CanDistrubutorAssignCreditLimit(distributorid, amount, currencyid, Parm_result);
            if ((Boolean)Parm_result.Value == false)
                return false;
            else
                return true;



        }
        public int GetDistributorIdbyAgentId(int agentid)
        {
            var res = ent.Agents.Where(x => x.AgentId == agentid).Select(x => x.DistributorId).FirstOrDefault();
            return res;
        }

        //for adding into Core_AgentCreditLimits Table
        public void CreditLimitAdd(CreditLimitModel modelToSave)
        {
            Core_AgentCreditLimits datamodel = new Core_AgentCreditLimits
            {
                AgentId = modelToSave.hdfagentid,
                CreditLimitTypeId = modelToSave.hdfTypeid,
                Amount = (Double)modelToSave.txtAmount,
                BankId = modelToSave.ddlBankId,
                EffectiveFrom = modelToSave.FromDate,
                ExpireOn = modelToSave.ToDate,
                MakerId = modelToSave.MakerId,
                MakerDate = DateTime.UtcNow,
                //CheckerId = modelToSave.CheckerId,
                //CheckerDate = DateTime.Now,
                isApproved = false,
                Comments = modelToSave.Comments,
                isActive = true,
                CurrencyId = modelToSave.CurrencyId,
            };
            ent.AddToCore_AgentCreditLimits(datamodel);
            ent.SaveChanges();

            // return datamodel.CreditLimitTypeId;

        }


        public void AdminCreditLimitAdd(CreditLimitModel modelToSave)
        {
            Core_BranchOfficeCreditLimits datamodel = new Core_BranchOfficeCreditLimits
            {
                BranchOfficeId = modelToSave.hdfagentid,
                CreditLimitTypeId = modelToSave.hdfTypeid,
                Amount = (Double)modelToSave.txtAmount,
                BankId = modelToSave.ddlBankId,
                EffectiveFrom = modelToSave.FromDate,
                ExpireOn = modelToSave.ToDate,
                MakerId = modelToSave.MakerId == 0 ? 0 : modelToSave.MakerId,
                MakerDate = DateTime.Now,
                CheckerId = modelToSave.CheckerId,
                CheckerDate = DateTime.Now,
                isApproved = true,
                Comments = modelToSave.Comments == "" ? "" : modelToSave.Comments,
                isActive = true,
                CurrencyId = modelToSave.CurrencyId,
            };
            ent.AddToCore_BranchOfficeCreditLimits(datamodel);
            ent.SaveChanges();
        }


        //for adding into Core_AgentCreditLimits Table
        public void BranchOfficeCreditLimitAdd(CreditLimitModel modelToSave)
        {
            Core_DistributorCreditLimits datamodel = new Core_DistributorCreditLimits
            {
                DistributorId = modelToSave.hdfagentid,
                CreditLimitTypeId = modelToSave.hdfTypeid,
                Amount = (Double)modelToSave.txtAmount,
                BankId = modelToSave.ddlBankId,
                EffectiveFrom = modelToSave.FromDate,
                ExpireOn = modelToSave.ToDate,
                MakerId = modelToSave.MakerId == 0 ? 0 : modelToSave.MakerId,
                MakerDate = DateTime.Now,
                CheckerId = modelToSave.CheckerId,
                CheckerDate = DateTime.Now,
                isApproved = true,
                Comments = modelToSave.Comments == "" ? "" : modelToSave.Comments,
                isActive = true,
                CurrencyId = modelToSave.CurrencyId,
            };
            ent.AddToCore_DistributorCreditLimits(datamodel);
            ent.SaveChanges();
        }



        public int CheckDuplicateRowForAdmin()
        {
            var chk = ent.Core_AgentCreditLimits.FirstOrDefault();

            if (chk != null)
            {
                //return chk.CreditLimitTypeId;

                return chk.AgentCreditLimitId;
            }
            else
            {
                return 0;
            }
        }

        public int CheckDuplicateRow()
        {
            var chk = ent.Core_BranchOfficeCreditLimits.FirstOrDefault();

            if (chk != null)
            {
                return chk.BranchOfficeCreditLimitId;
            }
            else
            {
                return 0;
            }
        }

        public int CheckDuplicateRowForBranchOfficeAdmin()
        {
            var chk = ent.Core_DistributorCreditLimits.FirstOrDefault();

            if (chk != null)
            {

                return chk.DistributorCreditLimitId;
            }
            else
            {
                return 0;
            }
        }



        public void CreditLimitEdit(CreditLimitModel model)
        {
            Core_AgentCreditLimits result = ent.Core_AgentCreditLimits.Where(x => (x.AgentCreditLimitId == model.AgentCreditLimitId)).FirstOrDefault();
          
            result.CreditLimitTypeId = model.ddlTypeId;
            result.Amount = (Double)model.txtAmount;
            result.BankId = model.hdfbank;
            result.EffectiveFrom = model.hdfEffectiveFrom;
            result.ExpireOn = model.hdfExpireOn;

            result.CheckerId = model.CheckerId;
            result.CheckerDate = DateTime.UtcNow;
            result.isApproved = model.isApproved;
            result.Comments = model.Comments;
            result.isActive = true;
            result.CurrencyId = model.CurrencyId;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }


        public void AdminCreditLimitEdit(CreditLimitModel model)
        {
            Core_BranchOfficeCreditLimits result = ent.Core_BranchOfficeCreditLimits.Where(x => (x.BranchOfficeCreditLimitId == model.AgentCreditLimitId)).FirstOrDefault();

            result.CreditLimitTypeId = model.ddlTypeId;
            result.Amount = (Double)model.txtAmount;
            result.BankId = model.hdfbank;
            result.EffectiveFrom = model.hdfEffectiveFrom;
            result.ExpireOn = model.hdfExpireOn;
            result.MakerId = model.MakerId == 0 ? 0 : model.MakerId;
            result.MakerDate = DateTime.Now;
            result.CheckerId = model.CheckerId;
            result.CheckerDate = DateTime.Now;
            result.isApproved = model.isApproved;
            result.Comments = model.Comments == "" ? "" : model.Comments;
            result.isActive = true;
            result.CurrencyId = 1;// model.CurrencyId;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        public void BranchOfficeCreditLimitEdit(CreditLimitModel model)
        {
            Core_DistributorCreditLimits result = ent.Core_DistributorCreditLimits.Where(x => (x.DistributorCreditLimitId == model.AgentCreditLimitId)).FirstOrDefault();

            result.CreditLimitTypeId = model.ddlTypeId;
            result.Amount = (Double)model.txtAmount;
            result.BankId = model.hdfbank;
            result.EffectiveFrom = model.hdfEffectiveFrom;
            result.ExpireOn = model.hdfExpireOn;
            result.MakerId = model.MakerId == 0 ? 0 : model.MakerId;
            result.MakerDate = DateTime.Now;
            result.CheckerId = model.CheckerId;
            result.CheckerDate = DateTime.Now;
            result.isApproved = model.isApproved;
            result.Comments = model.Comments == "" ? "" : model.Comments;
            result.isActive = true;
            result.CurrencyId = 1;


            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }



        public IEnumerable<CreditLimitModel> GetAgentCreditLimitList()
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();
            var result = ent.Core_AgentCreditLimits;
            foreach (var item in result.Select(x => x))
            {

                CreditLimitModel obj = new CreditLimitModel();
                obj.AgentCreditLimitId = item.AgentCreditLimitId;
                obj.ddlAgentId = item.AgentId;
                obj.AgencyName = item.Agents.AgentName;
                obj.AgencyCode = item.Agents.AgentCode;
                obj.CreditLimitTypeId = item.CreditLimitTypeId;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.CurrencyName = item.Currencies.CurrencyName;
                obj.txtAmount = item.Amount;
                obj.isApproved = item.isApproved;

                obj.isActive = item.isActive;
                obj.CreatedBy = GetCheckerUserName(item.MakerId);

                obj.ApprovedBy = item.CheckerId != null ? GetCheckerUserName(item.CheckerId) : "Not Approved";
                obj.Comments = item.Comments;
                obj.hdfbank = item.BankId;
                if (item.BankId == null)
                {
                    obj.BankName = "-";
                }
                else
                {
                    obj.BankName = item.Banks.BankName;
                }

                if (item.EffectiveFrom == null)
                {
                    obj.hdfEffectiveFrom = null;
                }
                else
                {
                    obj.hdfEffectiveFrom = item.EffectiveFrom;
                }
                if (item.ExpireOn == null)
                {
                    obj.hdfExpireOn = null;
                }
                else
                {
                    obj.hdfExpireOn = item.ExpireOn;
                }


                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public IEnumerable<CreditLimitModel> GetAgentCreditLimitListByAgentId(int agentId)
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();
            var result = ent.Core_AgentCreditLimits.Where(x => x.AgentId == agentId).OrderByDescending(x => x.MakerDate);

            foreach (var item in result.Select(x => x))
            {
                CreditLimitModel obj = new CreditLimitModel();
                obj.AgentCreditLimitId = item.AgentCreditLimitId;
                obj.ddlAgentId = item.AgentId;
                obj.AgencyName = item.Agents.AgentName;
                obj.AgencyCode = item.Agents.AgentCode;
                obj.CreditLimitTypeId = item.CreditLimitTypeId;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.CurrencyName = item.Currencies.CurrencyName;
                obj.txtAmount = item.Amount;
                obj.isApproved = item.isApproved;

                obj.isActive = item.isActive;
                obj.CreatedBy = GetCheckerUserName(item.MakerId);

                obj.ApprovedBy = item.CheckerId != null ? GetCheckerUserName(item.CheckerId) : "Not Approved";
                obj.Comments = item.Comments;
                obj.hdfbank = item.BankId;
                if (item.BankId == null)
                {
                    obj.BankName = "-";
                }
                else
                {
                    obj.BankName = item.Banks.BankName;
                }

                if (item.EffectiveFrom == null)
                {
                    obj.hdfEffectiveFrom = null;
                }
                else
                {
                    obj.hdfEffectiveFrom = item.EffectiveFrom;
                }
                if (item.ExpireOn == null)
                {
                    obj.hdfExpireOn = null;
                }
                else
                {
                    obj.hdfExpireOn = item.ExpireOn;
                    obj.DaysLeft = (int)item.ExpireOn.Value.Subtract(DateTime.Now).TotalDays;
                }


                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        //for listing 
        public IEnumerable<CreditLimitModel> GetCreditLimitList()
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();
            var ts = SessionStore.GetTravelSession();
            var result = from a in ent.Core_AgentCreditLimits
                         join b in ent.Agents on a.AgentId equals b.AgentId
                         where b.DistributorId == ts.LoginTypeId
                         select a;

            //var result = ent.Core_AgentCreditLimits;
            foreach (var item in result.Select(x => x))
            {

                CreditLimitModel obj = new CreditLimitModel();
                obj.AgentCreditLimitId = item.AgentCreditLimitId;
                obj.ddlAgentId = item.AgentId;
                obj.AgencyName = item.Agents.AgentName;
                obj.AgencyCode = item.Agents.AgentCode;
                obj.CreditLimitTypeId = item.CreditLimitTypeId;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.CurrencyName = item.Currencies.CurrencyName;
                obj.txtAmount = item.Amount;
                obj.isApproved = item.isApproved;

                obj.isActive = item.isActive;
                obj.CreatedBy = GetCheckerUserName(item.MakerId);

                obj.ApprovedBy = item.CheckerId != null ? GetCheckerUserName(item.CheckerId) : "Not Approved";
                obj.Comments = item.Comments;
                obj.hdfbank = item.BankId;
                if (item.BankId == null)
                {
                    obj.BankName = "-";
                }
                else
                {
                    obj.BankName = item.Banks.BankName;
                }

                if (item.EffectiveFrom == null)
                {
                    obj.hdfEffectiveFrom = null;
                }
                else
                {
                    obj.hdfEffectiveFrom = item.EffectiveFrom;
                }
                if (item.ExpireOn == null)
                {
                    obj.hdfExpireOn = null;
                }
                else
                {
                    obj.hdfExpireOn = item.ExpireOn;
                }


                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        private int[] GetDistributorsIdByBranchOfficeId(int branchOfficeId)
        {
            var agents = ent.Agents.Where(x => x.BranchOfficeId == branchOfficeId);
            string distributorsIds = String.Empty;
            foreach (var agent in agents)
            {
                distributorsIds += agent.DistributorId.ToString() + ',';
            }
            distributorsIds = distributorsIds.TrimEnd(',');

            List<int> ints = distributorsIds.Split(',').ToList().ConvertAll<int>(s => Convert.ToInt32(s));
            return ints.ToArray();
        }


        //for listing 
        public IEnumerable<CreditLimitModel> GetBranchOfficeCreditLimitList()
        {

            var ts = SessionStore.GetTravelSession();
            //int[] distributorIds = GetDistributorsIdByBranchOfficeId(ts.AgentId);

            List<CreditLimitModel> model = new List<CreditLimitModel>();

            //var result = from a in ent.Core_DistributorCreditLimits
            //             where distributorIds.Contains(a.DistributorId)                       
            //             select a;

            var result = from T1 in ent.Core_DistributorCreditLimits
                         join T2 in ent.Distributors on T1.DistributorId equals T2.DistributorId
                         where T2.BranchOfficeId == ts.LoginTypeId
                         select T1;

            foreach (var item in result.Select(x => x))
            {

                CreditLimitModel obj = new CreditLimitModel();
                obj.AgentCreditLimitId = item.DistributorCreditLimitId;
                obj.ddlAgentId = item.DistributorId;
                obj.AgencyName = item.Distributors.DistributorName;
                obj.AgencyCode = item.Distributors.DistributorCode;
                obj.CreditLimitTypeId = item.CreditLimitTypeId;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.CurrencyName = item.Currencies.CurrencyName;
                obj.txtAmount = item.Amount;
                obj.isApproved = item.isApproved;

                obj.isActive = item.isActive;
                obj.CreatedBy = GetCheckerUserName(item.MakerId);

                obj.ApprovedBy = item.CheckerId != null ? GetCheckerUserName(item.CheckerId) : "Not Approved";
                obj.Comments = item.Comments;
                obj.hdfbank = item.BankId;
                if (item.BankId == null)
                {
                    obj.BankName = "-";
                }
                else
                {
                    obj.BankName = item.Banks.BankName;
                }

                if (item.EffectiveFrom == null)
                {
                    obj.hdfEffectiveFrom = null;
                }
                else
                {
                    obj.hdfEffectiveFrom = item.EffectiveFrom;
                }
                if (item.ExpireOn == null)
                {
                    obj.hdfExpireOn = null;
                }
                else
                {
                    obj.hdfExpireOn = item.ExpireOn;
                }


                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        //for listing 
        public IEnumerable<CreditLimitModel> GetAdminCreditLimitList()
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();

            var result = ent.Core_BranchOfficeCreditLimits;
            foreach (var item in result.Select(x => x))
            {

                CreditLimitModel obj = new CreditLimitModel();
                obj.AgentCreditLimitId = item.BranchOfficeCreditLimitId;
                obj.ddlAgentId = item.BranchOfficeId;
                obj.AgencyName = item.BranchOffices.BranchOfficeName;
                obj.AgencyCode = item.BranchOffices.BranchOfficeCode;
                obj.CreditLimitTypeId = item.CreditLimitTypeId;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.CurrencyName = item.Currencies.CurrencyName;
                obj.txtAmount = item.Amount;
                obj.isApproved = item.isApproved;

                obj.isActive = item.isActive;
                obj.CreatedBy = GetCheckerUserName(item.MakerId);

                obj.ApprovedBy = item.CheckerId != null ? GetCheckerUserName(item.CheckerId) : "Not Approved";
                obj.Comments = item.Comments;
                obj.hdfbank = item.BankId;
                if (item.BankId == null)
                {
                    obj.BankName = "-";
                }
                else
                {
                    obj.BankName = item.Banks.BankName;
                }

                if (item.EffectiveFrom == null)
                {
                    obj.hdfEffectiveFrom = null;
                }
                else
                {
                    obj.hdfEffectiveFrom = item.EffectiveFrom;
                }
                if (item.ExpireOn == null)
                {
                    obj.hdfExpireOn = null;
                }
                else
                {
                    obj.hdfExpireOn = item.ExpireOn;
                }


                model.Add(obj);
            }
            return model.AsEnumerable();
        }



        //for delete
        public void DeleteCreditLimit(int Id)
        {
            Core_AgentCreditLimits result = ent.Core_AgentCreditLimits.Where(x => x.AgentCreditLimitId == Id).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        private string GetCheckerUserName(int? userid)
        {
            UsersDetails result = ent.UsersDetails.Where(x => x.AppUserId == userid).FirstOrDefault();
            if (result != null)
                return result.FullName;
            else
                return "Not Approved";
        }

        //public void ApproveCreditLimit(CreditLimitModel model)
        //{
        //    Core_AgentCreditLimits result = ent.Core_AgentCreditLimits.Where(x => (x.AgentCreditLimitId == model.AgentCreditLimitId)).FirstOrDefault();

        //    result.CheckerId = model.CheckerId;
        //    result.EffectiveFrom = model.FromDate;
        //    result.ExpireOn = model.ToDate;
        //    result.CheckerDate = DateTime.Now;
        //    result.Comments = model.Comments;
        //    result.isApproved = true;

        //    ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
        //    ent.SaveChanges();

        //}

        public void ApproveCreditLimit(CreditLimitModel model)
        {
            ent.Core_ApproveCreditLimit(model.AgentCreditLimitId, model.FromDate, model.ToDate, model.CheckerId, model.Comments);
        }
        public void ApproveBranchOfficesCreditLimit(CreditLimitModel model)
        {
            ent.Core_ApproveBranchOfficeCreditLimit(model.AgentCreditLimitId, model.FromDate, model.ToDate, model.CheckerId, model.Comments);
        }

        public void RejectCreditLimit(int id, int CheckerId)
        {
            Core_AgentCreditLimits result = ent.Core_AgentCreditLimits.Where(x => (x.AgentCreditLimitId == id)).FirstOrDefault();
            result.isActive = false;
            result.CheckerId = CheckerId;
            result.CheckerDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }


        public void AdminApproveCreditLimit(CreditLimitModel model)
        {
            Core_BranchOfficeCreditLimits result = ent.Core_BranchOfficeCreditLimits.Where(x => (x.BranchOfficeCreditLimitId == model.AgentCreditLimitId)).FirstOrDefault();

            result.CheckerId = model.CheckerId;
            result.EffectiveFrom = model.FromDate;
            result.ExpireOn = model.ToDate;
            result.CheckerDate = DateTime.Now;
            result.Comments = model.Comments;
            result.isApproved = true;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        public void ApproveBranchOfficeCreditLimit(CreditLimitModel model)
        {
            Core_DistributorCreditLimits result = ent.Core_DistributorCreditLimits.Where(x => (x.DistributorCreditLimitId == model.AgentCreditLimitId)).FirstOrDefault();

            result.CheckerId = model.CheckerId;
            result.EffectiveFrom = model.FromDate;
            result.ExpireOn = model.ToDate;
            result.CheckerDate = DateTime.Now;
            result.Comments = model.Comments;
            result.isApproved = true;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }


        public void RejectBranchOfficeCreditLimit(int id, int CheckerId)
        {
            Core_BranchOfficeCreditLimits result = ent.Core_BranchOfficeCreditLimits.Where(x => (x.BranchOfficeCreditLimitId == id)).FirstOrDefault();
            result.isActive = false;
            result.CheckerId = CheckerId;
            result.CheckerDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        public void RejectCreditLimit(int id)
        {
            Core_AgentCreditLimits result = ent.Core_AgentCreditLimits.Where(x => (x.AgentCreditLimitId == id)).FirstOrDefault();

            result.isActive = false;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        public void RejectAdminCreditLimit(int id)
        {
            Core_BranchOfficeCreditLimits result = ent.Core_BranchOfficeCreditLimits.Where(x => (x.BranchOfficeCreditLimitId == id)).FirstOrDefault();

            result.isActive = false;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }


        public void RejectBranchOfficeCreditLimit(int id)
        {
            Core_DistributorCreditLimits result = ent.Core_DistributorCreditLimits.Where(x => (x.DistributorCreditLimitId == id)).FirstOrDefault();

            result.isActive = false;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }



        public List<Distributors> GetAdminDistributorList()
        {
            var ts = SessionStore.GetTravelSession();

            return ent.Distributors.OrderBy(x => x.DistributorName).ToList();

        }
        public IEnumerable<SelectListItem> GetAllAdminDistributorList()
        {
            List<Distributors> all = GetAdminDistributorList().ToList();
            var GetAllDistributorList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DistributorName,
                    Value = item.DistributorId.ToString()
                };
                GetAllDistributorList.Add(teml);
            }
            return GetAllDistributorList.AsEnumerable();
        }


        //for listing 
        public IEnumerable<CreditLimitModel> GetBranchOfficeCreditLimitList(int BranchOfficeId)
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();

            var result = ent.Core_BranchOfficeCreditLimits.Where(x => x.BranchOfficeId == BranchOfficeId);
            foreach (var item in result.Select(x => x))
            {

                CreditLimitModel obj = new CreditLimitModel();
                obj.AgentCreditLimitId = item.BranchOfficeCreditLimitId;
                obj.ddlAgentId = item.BranchOfficeId;
                obj.AgencyName = item.BranchOffices.BranchOfficeName;
                obj.AgencyCode = item.BranchOffices.BranchOfficeCode;
                obj.CreditLimitTypeId = item.CreditLimitTypeId;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.CurrencyName = item.Currencies.CurrencyName;
                obj.txtAmount = item.Amount;
                obj.isApproved = item.isApproved;

                obj.isActive = item.isActive;
                obj.CreatedBy = GetCheckerUserName(item.MakerId);

                obj.ApprovedBy = item.CheckerId != null ? GetCheckerUserName(item.CheckerId) : "Not Approved";
                obj.Comments = item.Comments;
                obj.hdfbank = item.BankId;
                if (item.BankId == null)
                {
                    obj.BankName = "-";
                }
                else
                {
                    obj.BankName = item.Banks.BankName;
                }

                if (item.EffectiveFrom == null)
                {
                    obj.hdfEffectiveFrom = null;
                }
                else
                {
                    obj.hdfEffectiveFrom = item.EffectiveFrom;
                }
                if (item.ExpireOn == null)
                {
                    obj.hdfExpireOn = null;
                }
                else
                {
                    obj.hdfExpireOn = item.ExpireOn;
                }


                model.Add(obj);
            }
            return model.AsEnumerable();
        }





        //for listing 
        public IEnumerable<CreditLimitModel> GetLedgerCreditLimitList(int distributorId)
        {
            List<CreditLimitModel> model = new List<CreditLimitModel>();
            var ts = SessionStore.GetTravelSession();
            var result = from a in ent.Core_AgentCreditLimits
                         join b in ent.Agents on a.AgentId equals b.AgentId
                         where b.DistributorId == distributorId
                         select a;
            foreach (var item in result.Select(x => x))
            {

                CreditLimitModel obj = new CreditLimitModel();
                obj.AgentCreditLimitId = item.AgentCreditLimitId;
                obj.ddlAgentId = item.AgentId;
                obj.AgencyName = item.Agents.AgentName;
                obj.AgencyCode = item.Agents.AgentCode;
                obj.CreditLimitTypeId = item.CreditLimitTypeId;
                obj.CreditLimitTypeName = item.Core_CreditLimitTypes.CreditLimitTypeName;
                obj.CurrencyName = item.Currencies.CurrencyName;
                obj.txtAmount = item.Amount;
                obj.isApproved = item.isApproved;

                obj.isActive = item.isActive;
                obj.CreatedBy = GetCheckerUserName(item.MakerId);

                obj.ApprovedBy = item.CheckerId != null ? GetCheckerUserName(item.CheckerId) : "Not Approved";
                obj.Comments = item.Comments;
                obj.hdfbank = item.BankId;
                if (item.BankId == null)
                {
                    obj.BankName = "-";
                }
                else
                {
                    obj.BankName = item.Banks.BankName;
                }

                if (item.EffectiveFrom == null)
                {
                    obj.hdfEffectiveFrom = null;
                }
                else
                {
                    obj.hdfEffectiveFrom = item.EffectiveFrom;
                }
                if (item.ExpireOn == null)
                {
                    obj.hdfExpireOn = null;
                }
                else
                {
                    obj.hdfExpireOn = item.ExpireOn;
                }


                model.Add(obj);
            }
            return model.AsEnumerable();
        }






        public List<Distributors> GetDistributorName(string DistributorName, int maxResult)
        {
            return GetAllDistributorNameList(DistributorName, maxResult).ToList();
        }

        public IEnumerable<Distributors> GetAllDistributorNameList(string DistributorName, int maxResult)
        {
            return ent.Distributors.Where(x => (x.DistributorName.ToLower().StartsWith(DistributorName.ToLower()))).Take(maxResult).ToList().Select(x =>
                               new Distributors { DistributorName = x.DistributorName, DistributorId = x.DistributorId }
               );
        }





        public IEnumerable<CreditLimitModel> FindDistributorsByNameOrCode(string name, int branchid)
        {
            return ent.Distributors.Where(x => (x.DistributorName.ToLower().Contains(name.ToUpper()) || x.DistributorCode.ToLower().Contains(name.ToUpper())) && x.BranchOfficeId == branchid).Take(10).ToList().Select(x =>
                                  new CreditLimitModel { AgencyName = x.DistributorName, AgencyCode = x.DistributorCode, agentid = x.DistributorId }
                                  );
        }

        public IEnumerable<CreditLimitModel> FindBrachOfficeByNameOrCode(string name, int branchid)
        {
            return ent.BranchOffices.Where(x => (x.BranchOfficeName.ToLower().Contains(name.ToUpper()) || x.BranchOfficeCode.ToLower().Contains(name.ToUpper()))).Take(10).ToList().Select(x =>
                                  new CreditLimitModel { AgencyName = x.BranchOfficeName, AgencyCode = x.BranchOfficeCode, agentid = x.BranchOfficeId }
                                  );
        }


    }
}