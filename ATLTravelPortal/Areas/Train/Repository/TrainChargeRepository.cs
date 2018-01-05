using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Train.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Train.Repository
{
    public class TrainChargeRepository
    {
        public List<TrainChargeModel> Create(TrainChargeModel _model)
        {
            EntityModel _ent = new EntityModel();
            var result = _ent.Train_Charges.ToList();
            if (result.Count() == 0)
            {
                if (_model.List != null)
                {
                    foreach (var item in _model.List)
                    {
                        Train_Charges _obj = new Train_Charges
                        {
                            ClassCode = item.ClassCode,
                            IrctcsCharge=item.IrctcsCharge,
                            AgentCharge = item.AgentCharge,
                            AHMarkUp = item.AhMarkUp,
                            AgentComission = item.AgentCommission,
                            SupplierCommision=item.SupplierCommission,
                            TreminalId = "test",
                            CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(),
                            CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate(),
                        };
                        _ent.AddToTrain_Charges(_obj);
                    }
                    _ent.SaveChanges();
                }
            }
            else
            {
                List<TrainChargeModel> _list = new List<TrainChargeModel>();
                foreach(var item in result)
                {
                    TrainChargeModel _Model = new TrainChargeModel
                    {
                        ChargeId=item.ChargeId,
                        ClassCode=item.ClassCode,
                        IrctcsCharge=item.IrctcsCharge,
                        AgentCharge=item.AgentCharge,
                        AhMarkUp=item.AHMarkUp,
                        AgentCommission=item.AgentComission,
                        SupplierCommission=item.SupplierCommision,
                        TerminalId="test",
                        ClassName = GetNameFromCode(item.ClassCode)
                    };
                    _list.Add(_Model);
                }
                return _list;
            }
            return null;
        }

        private string GetNameFromCode(string code)
        {
            var result = Codelist().Where(x => x.Value == code).Select(x => x.Text).FirstOrDefault();
            return result;

        }

        public void Edit(TrainChargeModel _model)
        {
            EntityModel _ent = new EntityModel();
            if (_model.List != null)
            {
                foreach(var item in _model.List)
                {
                    var result = _ent.Train_Charges.Where(x => x.ChargeId == item.ChargeId).FirstOrDefault();
                    if (result != null)
                    {
                        result.ClassCode = item.ClassCode;
                        result.IrctcsCharge = item.IrctcsCharge;
                        result.AgentCharge = item.AgentCharge;
                        result.AHMarkUp = item.AhMarkUp;
                        result.AgentComission = item.AgentCommission;
                        result.SupplierCommision = item.SupplierCommission;
                        result.TreminalId = "test";
                        _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                        _ent.SaveChanges();
                    }                  
                }
            }
        }



        public List<SelectListItem> Codelist()
        {
            List<SelectListItem> _List = new List<SelectListItem>();
            _List.Add(new SelectListItem { Value = "1A", Text = "FIRST AC" });
            _List.Add(new SelectListItem { Value = "2A", Text = "SECOND AC" });
            _List.Add(new SelectListItem { Value = "3A", Text = "THIRD AC" });
            _List.Add(new SelectListItem { Value = "3E", Text = "3 AC Economy" });
            _List.Add(new SelectListItem { Value = "CC", Text = "AC CHAIR CARC" });
            _List.Add(new SelectListItem { Value = "FC", Text = "FIRST CLASS" });
            _List.Add(new SelectListItem { Value = "SL", Text = "SLEEPER CLASS" });
            _List.Add(new SelectListItem { Value = "2S", Text = "SECOND SEATING" });
            return _List;
        }
    }
}