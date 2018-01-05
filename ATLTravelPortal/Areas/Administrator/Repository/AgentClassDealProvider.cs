using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentClassDealProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public IEnumerable<AgentClassDealModel> GetAllAgentClassList()
        {
            ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider mDealProvider = new ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider();

            List<AgentClassDealModel> model = new List<AgentClassDealModel>();
            var result = ent.AgentClasses;
            foreach (var item in result)
            {
                AgentClassDealModel obj = new AgentClassDealModel();

                obj.AgentClassId = item.AgentClassId;

                IList<AgentClassDeals> dealIds = GetMasterDealIdbyClassId(item.AgentClassId);
                foreach (var x in dealIds)
                {
                    int productId = GetProductIdByMasterDealId(x.DealMasterId);
                    if (productId == 1)
                        obj.DealMasterId = x.DealMasterId;
                    else if (productId == 2)
                        obj.HotelMasterDealId = x.DealMasterId;
                }
                obj.AgentClassName = item.AgentClassName;
                obj.ClassDescription = item.ClassDescription;

                obj.AirlineDealList = mDealProvider.GetAllDealMasterForAgentClassList(1);
                obj.HotelDealList = mDealProvider.GetAllDealMasterForAgentClassList(2);


                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public IEnumerable<AgentClassDealModel> GetAllDistributorAgentClassList(int distributorID)
        {
            ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider mDealProvider = new ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider();

            List<AgentClassDealModel> model = new List<AgentClassDealModel>();
            var result = ent.AgentClasses;
            foreach (var item in result)
            {
                AgentClassDealModel obj = new AgentClassDealModel();

                obj.AgentClassId = item.AgentClassId;

                IList<AgentClassDeals> dealIds = GetMasterDealIdbyDistributorClassId(item.AgentClassId, distributorID);
                foreach (var x in dealIds)
                {
                    int productId = GetProductIdByDistributorMasterDealId(x.DealMasterId);
                    if (productId == 1)
                        obj.DealMasterId = x.DealMasterId;
                    else if (productId == 2)
                        obj.HotelMasterDealId = x.DealMasterId;
                    else if (productId == 3)
                        obj.MobileMasterDealId = x.DealMasterId;
                    else if (productId == 4)
                        obj.BusMasterDealId = x.DealMasterId;
                }
                obj.AgentClassName = item.AgentClassName;
                obj.ClassDescription = item.ClassDescription;

                obj.AirlineDealList = mDealProvider.GetAllDealMasterForDistributorAgentClassList(1, distributorID);
                obj.HotelDealList = mDealProvider.GetAllDealMasterForDistributorAgentClassList(2, distributorID);
                obj.BusDealList = mDealProvider.GetAllDealMasterForDistributorAgentClassList(4, distributorID);
                obj.MobileDealList = mDealProvider.GetAllDealMasterForDistributorAgentClassList(3, distributorID);

                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public IList<AgentClassDeals> GetMasterDealIdbyClassId(int ClassId)
        {
            var result = ent.AgentClassDeals.Where(dd => dd.AgentClassId == ClassId);
            return result.ToList();
        }

        public IList<AgentClassDeals> GetMasterDealIdbyDistributorClassId(int ClassId, int distributorID)
        {
            var result = ent.AgentClassDeals.Where(dd => dd.AgentClassId == ClassId && dd.DistributorId == distributorID);
            return result.ToList();
        }


        public int GetProductIdByMasterDealId(int masterDealId)
        {
            return ent.Tkt_DealMasters.Where(z => z.DealMasterId == masterDealId).FirstOrDefault().ProductId;
        }

        public int GetProductIdByDistributorMasterDealId(int masterDealId)
        {
            return ent.Core_DistributorDealMasters.Where(z => z.DistributorDealMasterId == masterDealId).FirstOrDefault().ProductId;
        }

        public bool SaveAgentClassDeal(int? agentClassId, int? masterDealId, int? hotelMasterDealId, int appUserId)
        {
            if (masterDealId != null)
            {
                if (!IsAirlineDealInserted(agentClassId))
                {
                    AgentClassDeals obj = new AgentClassDeals
                    {
                        AgentClassId = agentClassId ?? 0,
                        DealMasterId = masterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now
                    };
                    ent.AddToAgentClassDeals(obj);
                }
                else
                {
                    if (!IsSameMasterDealAlreadyExists(agentClassId, masterDealId))
                    {
                        var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetProductIdByMasterDealId(delete.DealMasterId);
                            if (productId == 1)
                                ent.DeleteObject(delete);
                        }
                        AgentClassDeals obj = new AgentClassDeals
                        {
                            AgentClassId = agentClassId ?? 0,
                            DealMasterId = masterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now
                        };
                        ent.AddToAgentClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetProductIdByMasterDealId(delete.DealMasterId);
                    if (productId == 1)
                        ent.DeleteObject(delete);
                }
            }

            if (hotelMasterDealId != null)
            {
                if (!IsHotelDealInserted(agentClassId))
                {
                    AgentClassDeals obj = new AgentClassDeals
                    {
                        AgentClassId = agentClassId ?? 0,
                        DealMasterId = hotelMasterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now
                    };
                    ent.AddToAgentClassDeals(obj);
                }
                else
                {
                    if (!IsSameMasterDealAlreadyExists(agentClassId, hotelMasterDealId))
                    {
                        var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetProductIdByMasterDealId(delete.DealMasterId);
                            if (productId == 2)
                                ent.DeleteObject(delete);
                        }
                        AgentClassDeals obj = new AgentClassDeals
                        {
                            AgentClassId = agentClassId ?? 0,
                            DealMasterId = hotelMasterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now
                        };
                        ent.AddToAgentClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetProductIdByMasterDealId(delete.DealMasterId);
                    if (productId == 2)
                        ent.DeleteObject(delete);
                }
            }
            ent.SaveChanges();
            return true;
        }

        public bool SaveAgentDistributorClassDeal(int? agentClassId, int? masterDealId, int? hotelMasterDealId, int? busMasterDealId, int? mobileMasterDealId, int appUserId, int distributorID)
        {
            if (masterDealId != null)
            {
                if (!IsDistributorAirlineDealInserted(agentClassId, distributorID))
                {
                    AgentClassDeals obj = new AgentClassDeals
                    {
                        AgentClassId = agentClassId ?? 0,
                        DealMasterId = masterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now,
                        DistributorId = distributorID
                    };
                    ent.AddToAgentClassDeals(obj);
                }
                else
                {
                    if (!IsDistributorSameMasterDealAlreadyExists(agentClassId, masterDealId, distributorID))
                    {
                        var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                            if (productId == 1)
                                ent.DeleteObject(delete);
                        }
                        AgentClassDeals obj = new AgentClassDeals
                        {
                            AgentClassId = agentClassId ?? 0,
                            DealMasterId = masterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now,
                            DistributorId = distributorID
                        };
                        ent.AddToAgentClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId && z.DistributorId == distributorID);
                foreach (var delete in objToDelete)
                {
                    int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                    if (productId == 1)
                        ent.DeleteObject(delete);
                }
            }

            if (hotelMasterDealId != null)
            {
                if (!IsDistributorHotelDealInserted(agentClassId, distributorID))
                {
                    AgentClassDeals obj = new AgentClassDeals
                    {
                        AgentClassId = agentClassId ?? 0,
                        DealMasterId = hotelMasterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now,
                        DistributorId = distributorID
                    };
                    ent.AddToAgentClassDeals(obj);
                }
                else
                {
                    if (!IsDistributorSameMasterDealAlreadyExists(agentClassId, hotelMasterDealId, distributorID))
                    {
                        var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                            if (productId == 2)
                                ent.DeleteObject(delete);
                        }
                        AgentClassDeals obj = new AgentClassDeals
                        {
                            AgentClassId = agentClassId ?? 0,
                            DealMasterId = hotelMasterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now,
                            DistributorId = distributorID
                        };
                        ent.AddToAgentClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                    if (productId == 2)
                        ent.DeleteObject(delete);
                }
            }


            if (busMasterDealId != null)
            {
                if (!IsDistributorBusDealInserted(agentClassId, distributorID))
                {
                    AgentClassDeals obj = new AgentClassDeals
                    {
                        AgentClassId = agentClassId ?? 0,
                        DealMasterId = busMasterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now,
                        DistributorId = distributorID
                    };
                    ent.AddToAgentClassDeals(obj);
                }
                else
                {
                    if (!IsDistributorSameMasterDealAlreadyExists(agentClassId, busMasterDealId, distributorID))
                    {
                        var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                            if (productId == 4)
                                ent.DeleteObject(delete);
                        }
                        AgentClassDeals obj = new AgentClassDeals
                        {
                            AgentClassId = agentClassId ?? 0,
                            DealMasterId = busMasterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now,
                            DistributorId = distributorID
                        };
                        ent.AddToAgentClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                    if (productId == 4)
                        ent.DeleteObject(delete);
                }
            }



            if (mobileMasterDealId != null)
            {
                if (!IsDistributorMobileDealInserted(agentClassId, distributorID))
                {
                    AgentClassDeals obj = new AgentClassDeals
                    {
                        AgentClassId = agentClassId ?? 0,
                        DealMasterId = mobileMasterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now,
                        DistributorId = distributorID
                    };
                    ent.AddToAgentClassDeals(obj);
                }
                else
                {
                    if (!IsDistributorSameMasterDealAlreadyExists(agentClassId, mobileMasterDealId, distributorID))
                    {
                        var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                            if (productId == 3)
                                ent.DeleteObject(delete);
                        }
                        AgentClassDeals obj = new AgentClassDeals
                        {
                            AgentClassId = agentClassId ?? 0,
                            DealMasterId = mobileMasterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now,
                            DistributorId = distributorID
                        };
                        ent.AddToAgentClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetProductIdByDistributorMasterDealId(delete.DealMasterId);
                    if (productId == 3)
                        ent.DeleteObject(delete);
                }
            }




            ent.SaveChanges();
            return true;
        }

        public bool IsSameMasterDealAlreadyExists(int? agentClassId, int? masterDealId)
        {
            var result = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId && z.DealMasterId == masterDealId).FirstOrDefault();
            if (result != null)
                return true;
            return false;
        }

        public bool IsDistributorSameMasterDealAlreadyExists(int? agentClassId, int? masterDealId, int distributorID)
        {
            var result = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId && z.DealMasterId == masterDealId && z.DistributorId == distributorID).FirstOrDefault();
            if (result != null)
                return true;
            return false;
        }


        public bool IsAirlineDealInserted(int? agentClassId)
        {
            bool isFound = false;
            var allInsertedRecords = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetProductIdByMasterDealId(insertedRecord.DealMasterId);
                if (productId == 1)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public bool IsDistributorAirlineDealInserted(int? agentClassId, int distributorID)
        {
            bool isFound = false;
            var allInsertedRecords = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId && z.DistributorId == distributorID);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetProductIdByDistributorMasterDealId(insertedRecord.DealMasterId);
                if (productId == 1)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }
        public bool IsHotelDealInserted(int? agentClassId)
        {
            bool isFound = false;
            var allInsertedRecords = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetProductIdByMasterDealId(insertedRecord.DealMasterId);
                if (productId == 2)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public bool IsDistributorHotelDealInserted(int? agentClassId, int distributorID)
        {
            bool isFound = false;
            var allInsertedRecords = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId && z.DistributorId == distributorID);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetProductIdByDistributorMasterDealId(insertedRecord.DealMasterId);
                if (productId == 2)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public bool IsDistributorBusDealInserted(int? agentClassId, int distributorID)
        {
            bool isFound = false;
            var allInsertedRecords = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId && z.DistributorId == distributorID);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetProductIdByDistributorMasterDealId(insertedRecord.DealMasterId);
                if (productId == 4)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public bool IsDistributorMobileDealInserted(int? agentClassId, int distributorID)
        {
            bool isFound = false;
            var allInsertedRecords = ent.AgentClassDeals.Where(z => z.AgentClassId == agentClassId && z.DistributorId == distributorID);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetProductIdByDistributorMasterDealId(insertedRecord.DealMasterId);
                if (productId == 3)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        /////////////////////////////////////////// Branch Class Deal starts from here/////////////////////////////////////

        public IEnumerable<AgentClassDealModel> GetAllBranchClassList()
        {

            ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider mDealProvider = new ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider();
            List<AgentClassDealModel> model = new List<AgentClassDealModel>();
            var result = ent.BranchClasses;
            foreach (var item in result)
            {
                AgentClassDealModel obj = new AgentClassDealModel();

                obj.AgentClassId = item.BranchClassId;

                IList<BranchClassDeals> dealIds = GetBranchMasterDealIdbyClassId(item.BranchClassId);
                foreach (var x in dealIds)
                {
                    int productId = GetProductIdByBranchMasterDealId(x.BranchDealMasterId);
                    if (productId == 1)
                        obj.DealMasterId = x.BranchDealMasterId;
                    else if (productId == 2)
                        obj.HotelMasterDealId = x.BranchDealMasterId;
                    else if (productId == 3)
                        obj.MobileMasterDealId = x.BranchDealMasterId;
                    else if (productId == 4)
                        obj.BusMasterDealId = x.BranchDealMasterId;
                }
                obj.AgentClassName = item.BranchClassName;
                obj.ClassDescription = item.ClassDescription;

                obj.AirlineDealList = mDealProvider.GetAllDealMasterForAgentClassList(1);
                obj.HotelDealList = mDealProvider.GetAllDealMasterForAgentClassList(2);
                obj.BusDealList = mDealProvider.GetAllDealMasterForAgentClassList(4);
                obj.MobileDealList = mDealProvider.GetAllDealMasterForAgentClassList(3);

                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public IList<BranchClassDeals> GetBranchMasterDealIdbyClassId(int ClassId)
        {
            var result = ent.BranchClassDeals.Where(dd => dd.BranchClassId == ClassId);
            return result.ToList();
        }
        public int GetProductIdByBranchMasterDealId(int masterDealId)
        {
            return ent.Tkt_DealMasters.Where(z => z.DealMasterId == masterDealId && z.DealTypeId == 6).FirstOrDefault().ProductId;
        }
        private IEnumerable<SelectListItem> GetAllBranchDealMasterListForBranchClassList(int productId)
        {
            //string BranchCode = GetBranchCodeByBranchId(branchofficeid);
            List<Core_BranchDealMasters> all = GetAllDealMaster(productId).OrderBy(z => z.BranchDealName).ToList();
            var GetAllDealMasterList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BranchDealName,
                    Value = item.BranchDealMasterId.ToString()
                };
                GetAllDealMasterList.Add(teml);
            }
            return GetAllDealMasterList.AsEnumerable();
        }
        private IQueryable<Core_BranchDealMasters> GetAllDealMaster(int productId)
        {
            return ent.Core_BranchDealMasters.Where(x => (x.ProductId == productId)).OrderBy(xx => xx.BranchDealMasterId).AsQueryable();
        }


        private string GetBranchCodeByBranchId(int branchofficeid)
        {
            var res = ent.BranchOffices.Where(x => x.BranchOfficeId == branchofficeid).Select(x => x.BranchOfficeCode).FirstOrDefault();
            return res;
        }


        public bool SaveBranchClassDeal(int? branchClassId, int? masterDealId, int? hotelMasterDealId, int? busMasterDealId, int? mobileMasterDealId, int appUserId)
        {
            if (masterDealId != null)
            {
                if (!IsBranchOfficeAirlineDealInserted(branchClassId))
                {
                    BranchClassDeals obj = new BranchClassDeals
                    {
                        BranchClassId = branchClassId ?? 0,
                        BranchDealMasterId = masterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now
                    };
                    ent.AddToBranchClassDeals(obj);
                }
                else
                {
                    if (!IsSameBranchOfficeMasterDealAlreadyExists(branchClassId, masterDealId))
                    {
                        var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                            if (productId == 1)
                                ent.DeleteObject(delete);
                        }
                        BranchClassDeals obj = new BranchClassDeals
                        {
                            BranchClassId = branchClassId ?? 0,
                            BranchDealMasterId = masterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now
                        };
                        ent.AddToBranchClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                    if (productId == 1)
                        ent.DeleteObject(delete);
                }
            }

            if (hotelMasterDealId != null)
            {
                if (!IsBranchOfficeHotelDealInserted(branchClassId))
                {
                    BranchClassDeals obj = new BranchClassDeals
                    {
                        BranchClassId = branchClassId ?? 0,
                        BranchDealMasterId = hotelMasterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now
                    };
                    ent.AddToBranchClassDeals(obj);
                }
                else
                {
                    if (!IsSameBranchOfficeMasterDealAlreadyExists(branchClassId, hotelMasterDealId))
                    {
                        var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                            if (productId == 2)
                                ent.DeleteObject(delete);
                        }
                        BranchClassDeals obj = new BranchClassDeals
                        {
                            BranchClassId = branchClassId ?? 0,
                            BranchDealMasterId = hotelMasterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now
                        };
                        ent.AddToBranchClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                    if (productId == 2)
                        ent.DeleteObject(delete);
                }
            }

            if (busMasterDealId != null)
            {
                if (!IsBranchOfficeHotelDealInserted(branchClassId))
                {
                    BranchClassDeals obj = new BranchClassDeals
                    {
                        BranchClassId = branchClassId ?? 0,
                        BranchDealMasterId = busMasterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now
                    };
                    ent.AddToBranchClassDeals(obj);
                }
                else
                {
                    if (!IsSameBranchOfficeMasterDealAlreadyExists(branchClassId, busMasterDealId))
                    {
                        var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                            if (productId == 4)
                                ent.DeleteObject(delete);
                        }
                        BranchClassDeals obj = new BranchClassDeals
                        {
                            BranchClassId = branchClassId ?? 0,
                            BranchDealMasterId = busMasterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now
                        };
                        ent.AddToBranchClassDeals(obj);
                    }
                }

            }
            else
            {
                var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                    if (productId == 4)
                        ent.DeleteObject(delete);
                }
            }




            if (mobileMasterDealId != null)
            {
                if (!IsBranchOfficeMobileDealInserted(branchClassId))
                {
                    BranchClassDeals obj = new BranchClassDeals
                    {
                        BranchClassId = branchClassId ?? 0,
                        BranchDealMasterId = mobileMasterDealId ?? 0,
                        CreatedBy = appUserId,
                        CreatedDate = DateTime.Now
                    };
                    ent.AddToBranchClassDeals(obj);
                }
                else
                {
                    if (!IsSameBranchOfficeMasterDealAlreadyExists(branchClassId, mobileMasterDealId))
                    {
                        var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                        foreach (var delete in objToDelete)
                        {
                            int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                            if (productId == 3)
                                ent.DeleteObject(delete);
                        }
                        BranchClassDeals obj = new BranchClassDeals
                        {
                            BranchClassId = branchClassId ?? 0,
                            BranchDealMasterId = mobileMasterDealId ?? 0,
                            CreatedBy = appUserId,
                            CreatedDate = DateTime.Now
                        };
                        ent.AddToBranchClassDeals(obj);
                    }
                }
            }
            else
            {
                var objToDelete = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
                foreach (var delete in objToDelete)
                {
                    int productId = GetBranchOfficeProductIdByMasterDealId(delete.BranchDealMasterId);
                    if (productId == 3)
                        ent.DeleteObject(delete);
                }
            }



            ent.SaveChanges();
            return true;
        }
        public bool IsBranchOfficeAirlineDealInserted(int? branchClassId)
        {
            bool isFound = false;
            var allInsertedRecords = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetBranchOfficeProductIdByMasterDealId(insertedRecord.BranchDealMasterId);
                if (productId == 1)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }
        public int GetBranchOfficeProductIdByMasterDealId(int masterDealId)
        {
            return ent.Tkt_DealMasters.Where(z => z.DealMasterId == masterDealId).FirstOrDefault().ProductId;
        }


        public bool IsSameBranchOfficeMasterDealAlreadyExists(int? branchClassId, int? masterDealId)
        {
            var result = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId && z.BranchDealMasterId == masterDealId).FirstOrDefault();
            if (result != null)
                return true;
            return false;
        }


        public bool IsBranchOfficeHotelDealInserted(int? branchClassId)
        {
            bool isFound = false;
            var allInsertedRecords = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetBranchOfficeProductIdByMasterDealId(insertedRecord.BranchDealMasterId);
                if (productId == 2)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }



        public bool IsBranchOfficeMobileDealInserted(int? branchClassId)
        {
            bool isFound = false;
            var allInsertedRecords = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetBranchOfficeProductIdByMasterDealId(insertedRecord.BranchDealMasterId);
                if (productId == 3)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }


        public bool IsBranchOfficeBusDealInserted(int? branchClassId)
        {
            bool isFound = false;
            var allInsertedRecords = ent.BranchClassDeals.Where(z => z.BranchClassId == branchClassId);
            foreach (var insertedRecord in allInsertedRecords)
            {
                int productId = GetBranchOfficeProductIdByMasterDealId(insertedRecord.BranchDealMasterId);
                if (productId == 4)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////






    }
}