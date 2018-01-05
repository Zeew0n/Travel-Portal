using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Data.Objects.DataClasses;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class LedgerMasterProvider
    {
        
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        //for listing 
        public IEnumerable<LedgerMasterModel> List(){
            int sno = 0;
            List<LedgerMasterModel> model = new List<LedgerMasterModel>();
            var result = ent.GL_Ledgers.Where(x=>x.GL_AccTypes.AccTypeName!="Agent");
            foreach (var item in result)
            {
                sno=sno+1;
                LedgerMasterModel obj = new LedgerMasterModel
                {
                    SNO=sno,
                    // AccTypeName =item.GL_AccTypes.AccTypeName ,
                    // AccTypeId = item.AccTypeId,
                    //  ProductId = item.ProductId,
                    //AccGroupId = item.AccGroupId,
                    // AccSubGroupId = item.AccSubGroupId,
                    // ddlAirLines = item.Id,
                    // AirlineName = item.
                    LedgerId = (int) item.LedgerId,
                    ProductName = item.Core_Products.ProductName,
                    AccGroupName = item.GL_AccGroups.AccGroupName,
                    AccSubGroupName = item.GL_AccSubGroups.AccSubGroupName,
                    AccTypeName = item.GL_AccTypes.AccTypeName,
                    LedgerName = item.LedgerName
                };
                model.Add(obj);
            }
            //return model.Where(x => x.AccTypeName != "Agent" ).AsEnumerable();
            return model.AsEnumerable();
        }

     
        ////////////////////////////////////////////////for detail/////////////////////////////////////////////
        public LedgerMasterModel Detail(int id)
        {
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.LedgerId == id).FirstOrDefault();
            LedgerMasterModel model = new LedgerMasterModel();

            model.LedgerId = (int)result.LedgerId;
            model.ProductId = result.ProductId;
            model.ProductName = result.Core_Products.ProductName;
            model.AccGroupId = result.AccGroupId; 
            model.AccGroupName = result.GL_AccGroups.AccGroupName;
            model.AccSubGroupId = result.AccSubGroupId;
            model.AccSubGroupName = result.GL_AccSubGroups.AccSubGroupName; 
            model.AccTypeId = result.AccTypeId;
            model.AccTypeName = result.GL_AccTypes.AccTypeName;
            model.ddlAirLines = result.Id;
            model.LedgerName = result.LedgerName;
            model.MapTable = result.GL_AccTypes.MapTable;
            model.ValueMember = result.GL_AccTypes.ValueMember;
            model.DisplayMember = result.GL_AccTypes.DisplayMember;
           

            return model;

        }
        //to get ledger name
        public string GetLedgerDetail(int id)
        {
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.LedgerId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.LedgerId = (int) result.LedgerId;
            model.LedgerName = result.LedgerName;

            return model.LedgerName;
        }

        //to get product detail
        public string GetProductDetail(int id)
        {
            Core_Products result = ent.Core_Products.Where(x => x.ProductId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.ProductId = result.ProductId;
            model.ProductName = result.ProductName;

            return model.ProductName;
        }

        //to get account group detail
        public string GetAccountGroupDetail(int id)
        {
            GL_AccGroups result = ent.GL_AccGroups.Where(x => x.AccGroupId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.AccGroupId = result.AccGroupId;
            model.AccGroupName = result.AccGroupName;

            return model.AccGroupName;
        }

        //to get account sub group detail
        public string GetAccountSubGroupDetail(int id)
        {
            GL_AccSubGroups result = ent.GL_AccSubGroups.Where(x => x.AccSubGroupId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.AccSubGroupId = result.AccSubGroupId;
            model.AccSubGroupName = result.AccSubGroupName;

            return model.AccSubGroupName;
        }

        //to get account type detail
        public int GetAccountTypeDetail(int id)
        {
            GL_AccTypes result = ent.GL_AccTypes.Where(x => x.AccTypeId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.AccTypeId = result.AccTypeId;
            model.AccTypeName = result.AccTypeName;

            model.MapTable = result.MapTable;
            model.DisplayMember = result.DisplayMember;
            model.ValueMember = result.ValueMember;

            return model.AccTypeId;
        }

        //to get airline detail
        public string GetAirlineDetail(int? id)
        {
            TravelPortalEntity.Airlines result = ent.Airlines.Where(x => x.AirlineId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.AirlineId = result.AirlineId;
            model.AirlineName = result.AirlineName;

            return model.AirlineName;
        }
     
        //to get ddlairlinesdetail
        public string GetddlAirlinesDetail(string MapTable, string DisplayMember, string ValueMember)
        {
            var result = ent.Air_GetAccMappedValues(MapTable, DisplayMember, ValueMember).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.DisplayMember = result.DisplayMember;

            return model.DisplayMember;


        }


        //to get agent detail
        public string GetAgentDetail(int? id)
        {
            Agents result = ent.Agents.Where(x => x.AgentId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.AgentId = result.AgentId;
            model.AgentName = result.AgentName;

            return model.AgentName;
        }

        //to get ledger account type detail
        public string GetLedgerAccountTypesDetail(int? id)
        {
            GL_LedgerAccTypes result = ent.GL_LedgerAccTypes.Where(x => x.LedgerAccTypeId == id).FirstOrDefault();

            LedgerMasterModel model = new LedgerMasterModel();

            model.LedgerAccTypeId = result.LedgerAccTypeId;
            model.LedgerAccTypeName = result.LedgerAccTypeName;

            return model.LedgerAccTypeName;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //for delete
        public void DeleteLedgerMaster(int LedgerMasterId)
        {
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.LedgerId == LedgerMasterId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        //for edit
        public void EditLedgerMaster(LedgerMasterModel model)
        {
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.LedgerId == model.LedgerId).FirstOrDefault();
            result.LedgerId = model.LedgerId;
            result.ProductId = model.ProductId;
            result.AccGroupId = model.AccGroupId;
            result.AccSubGroupId = model.AccSubGroupId;
            result.AccTypeId = model.AccTypeId;
            result.Id = model.ddlAirLines;
            result.LedgerName = model.LedgerName;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

       


        //For filling the Product Dropdownlist
        public List<Core_Products> GetProductList()
        {
            return ent.Core_Products.Where(tt => tt.isActive == true).ToList();
        }

        public IEnumerable<SelectListItem> GetAllProductList()
        {
            List<Core_Products> all = GetProductList().ToList();
            var GetAllProductList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.ProductName,
                    Value = item.ProductId.ToString()
                };
                GetAllProductList.Add(teml);
            }
            return GetAllProductList.AsEnumerable();
        }

        //For filling AccountGroupName dropdownlist
        public List<GL_AccGroups> GetAccountGroupList()
        {
            return ent.GL_AccGroups.ToList();
        }

        public IEnumerable<SelectListItem> GetAllAccountGroupList()
        {
            List<GL_AccGroups> all = GetAccountGroupList().ToList();
            var GetAllAccountGroupList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AccGroupName,
                    Value = item.AccGroupId.ToString()
                };
                GetAllAccountGroupList.Add(teml);
            }
            return GetAllAccountGroupList.AsEnumerable();
        }


        public List<GL_AccTypes> GetAccTypeList()
        {
            return ent.GL_AccTypes.ToList();
        }

        public IEnumerable<SelectListItem> GetAllAccTypeList()
        {
            List<GL_AccTypes> all = GetAccTypeList().ToList();
            var GetAllAccountGroupList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DisplayMember,
                    Value = item.ValueMember.ToString()
                };
                GetAllAccountGroupList.Add(teml);
            }
            return GetAllAccountGroupList.AsEnumerable();
        }



        //For Filling AccountSubGroupName dropdownlist
        public List<GL_AccSubGroups> GetAccountSubGroupName()
        {
            return ent.GL_AccSubGroups.ToList();
        }

        public IEnumerable<SelectListItem> GetAllAccountSubGroupName()
        {
            List<GL_AccSubGroups> all = GetAccountSubGroupName().ToList();
            var GetAllAccountSubGroupName = new List<SelectListItem>();
            foreach (var item in all)
            {
                var tem = new SelectListItem
                {
                    Text = item.AccSubGroupName,
                    Value = item.AccSubGroupId.ToString()
                };
                GetAllAccountSubGroupName.Add(tem);
            }
            return GetAllAccountSubGroupName.AsEnumerable();
        }

        //For filling AccountTypeName dropdownlist
        public List<GL_AccTypes> GetAccountTypeName()
        {
            return ent.GL_AccTypes.Where(x=>x.AccTypeId !=2).ToList();
        }

        public IEnumerable<SelectListItem> GetAllAccountTypeName()
        {
            List<GL_AccTypes> all = GetAccountTypeName().ToList();
            var GetAllAccountTypeName = new List<SelectListItem>();
            foreach (var item in all)
            {
                var tem = new SelectListItem
                {
                    Text = item.AccTypeName,
                    Value = item.AccTypeId.ToString()
                };
                GetAllAccountTypeName.Add(tem);
            }
            return GetAllAccountTypeName.AsEnumerable();
        }

        ///For filling AirlinesName dropdownlist
        public List<TravelPortalEntity.Airlines> GetAirlinesname()
        {
            return ent.Airlines.ToList();
        }

        public List<Agents> GetAgentName()
        {
            return ent.Agents.ToList();
        }

        public List<GL_LedgerAccTypes> GetLedgerAccountTypesName()
        {
            return ent.GL_LedgerAccTypes.ToList();
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>


        public IEnumerable<SelectListItem> GetAllAirlinesName()
        {
            List<TravelPortalEntity.Airlines> all = GetAirlinesname().ToList();
            var GetAllAirlinesName = new List<SelectListItem>();
            foreach (var item in all)
            {
                var tem = new SelectListItem
                {
                    Text = item.AirlineName,
                    Value = item.AirlineId.ToString()
                };
                GetAllAirlinesName.Add(tem);
            }
            return GetAllAirlinesName.AsEnumerable();
        }

        //for adding into GL_Ledgers Table
        public void LedgerAdd(LedgerMasterModel modelToSave)
        {
            GL_Ledgers datamodel = new GL_Ledgers
            {
                ProductId = modelToSave.ProductId,
                AccGroupId = modelToSave.AccGroupId,
                AccSubGroupId = modelToSave.AccSubGroupId,
                AccTypeId = modelToSave.AccTypeId,
                Id = modelToSave.ddlAirLines,
                LedgerName = modelToSave.LedgerName,
                CreatedDate = DateTime.Now,
            };
            ent.AddToGL_Ledgers(datamodel);
            ent.SaveChanges();
        }

        public List<GL_AccTypes> GetAccTypesName()
        {
            return ent.GL_AccTypes.Where(x=>x.MapTable != null).ToList();
        }


        //public List<LedgerMasterModel> GetAllAccTypesName(int id)
        //{

        //    TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        //    var cc = (from aa in ent.GL_AccTypes

        //              select new LedgerMasterModel
        //              {
                         
                         
        //              }).ToList();
        //    return cc;

        //}


        /*-----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// /
        /// </summary>
        /// <param name="MapTable"></param>
        /// <param name="DisplayMember"></param>
        /// <param name="ValueMember"></param>
        /// <returns></returns>
        public List<LedgerMasterModel> GetAllAirlineNameBasedonAccTypeName(string MapTable, string DisplayMember, string ValueMember)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
           var result= ent.Air_GetAccMappedValues(MapTable, DisplayMember, ValueMember);
           List<LedgerMasterModel> Search = new List<LedgerMasterModel>();
           foreach (var item in result)
           {
               LedgerMasterModel obj = new LedgerMasterModel
               {
                   ValueMember  = item.ValueMember.ToString(),
                   DisplayMember = item.DisplayMember,
               };
               Search.Add(obj);
           }
           return Search.ToList();
        }

        public IEnumerable<SelectListItem> GetAllDisplayValueMenberForDropdown(string MapTable, string DisplayMember, string ValueMember)
        {
            List<LedgerMasterModel> all = GetAllAirlineNameBasedonAccTypeName(MapTable, DisplayMember, ValueMember).ToList();
            var GetAllDisplayValueMenberForDropdown = new List<SelectListItem>();
            foreach (var item in all)
            {
                var tem = new SelectListItem
                {
                    Text = item.DisplayMember,
                    Value = item.ValueMember.ToString()
                };
                GetAllDisplayValueMenberForDropdown.Add(tem);
            }
            return GetAllDisplayValueMenberForDropdown.AsEnumerable();
        }

        public LedgerMasterModel GetGLAccTypesBasedOnTypeName(int AccTypeId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.GL_AccTypes.Where(x=>x.AccTypeId==AccTypeId)

                      select new LedgerMasterModel
                      {
                          MapTable = aa.MapTable,
                          DisplayMember = aa.DisplayMember,
                          ValueMember=aa.ValueMember,
                      }).SingleOrDefault();
            return cc;

        }
          /*---------------------------------------------------------------------------------------------------------------------------*/

        public List<GL_AccTypes> GetAccTypeNameList(int productid)
        {
            return ent.GL_AccTypes.Where(z => (z.ProductId == productid && z.AccTypeId!=2) ).ToList();
        }


        public List<GL_AccSubGroups> GetAccSubGroupBasedOnProductNameandAccountGroupNameList(int id, int accgroupid)
        {
            return ent.GL_AccSubGroups.Where(x =>x.AccGroupId == accgroupid).ToList();
        }
             

        public List<LedgerMasterModel> GetAllAgentNameBasedonAccTypeName(int AgentId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.Agents
                     
                      select new LedgerMasterModel
                      {
                          AgentId = aa.AgentId,
                          AgentName = aa.AgentName
                      }).ToList();
            return cc;

        }

      

        public List<LedgerMasterModel> GetAllLedgerAccountBasedonAccTypeName(int LedgerAccountId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.GL_LedgerAccTypes
                      
                      select new LedgerMasterModel
                      {
                          LedgerAccTypeId = aa.LedgerAccTypeId,
                          LedgerAccTypeName = aa.LedgerAccTypeName
                          
                      }).ToList();
            return cc;

        }


        //////////////////to check the duplicate ledgername/////////////////
      
        public bool CheckDuplicateLedgerName(int? id, string LedgerName)
        {
            bool result = ent.GL_Ledgers.Where(x => x.Id == id).Select(x => x.LedgerName == LedgerName).FirstOrDefault();
            return result;
        }

      //   return ent.GL_AccTypes.Where(tt => (tt.AccTypeId == 3) || (tt.AccTypeId == 4)).ToList();
        public bool CheckDuplicateLedgerNameforEdit(int LedgerId, int? id, string LedgerName)
        {
            bool result = ent.GL_Ledgers.Where(x => (x.LedgerId == LedgerId) && (x.Id == id)).Select(x => x.LedgerName == LedgerName).FirstOrDefault();
            return result;
        }

        ///////////////////////////////////////////////////////////////////


        public LedgerMasterModel FillDdl(LedgerMasterModel model)
        {
            
                model.ProductNameList = GetAllProductList();
                model.AccGroupNameList = GetAllAccountGroupList();
                model.AccSubGroupNameList = GetAllAccountSubGroupName();
                model.AccTypeNameList = GetAllAccountTypeName();
                model.ddlAirLinesList = GetAllAirlinesName();
            return model;
        }







    }
}