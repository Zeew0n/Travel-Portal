using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.MobileRechargeCard.Models;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Areas.Train.Repository;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Repository
{
    public class TopUpProvider
    {
        EntityModel ent = new EntityModel();

        public List<SelectListItem> ddlServiceProviderList()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Add(new SelectListItem { Value = "", Text = "--Select--" });
            var list = ent.MRC_MobileServiceProvider;
            foreach (var item in list)
            {
                _list.Add(new SelectListItem { Value = item.PortalId.ToString(), Text = item.ServiceProviderName });
            }
            return _list;
        }

        public List<SelectListItem> ddlTypeList()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Add(new SelectListItem { Value = "", Text = "--Select--" });
            _list.Add(new SelectListItem { Value = "ALL", Text = "List" });
            _list.Add(new SelectListItem { Value = "", Text = "Total" });
            return _list;
        }

        public List<SelectListItem> ddlStatusList()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Add(new SelectListItem { Value = "1", Text = "Success" });
            _list.Add(new SelectListItem { Value = "0", Text = "False" });
            return _list;
        }


        public List<TopUpModel> List(TopUpModel model)
        {
            List<TopUpModel> _list = new List<TopUpModel>();
            bool? sStatus = null;
            if (model.sStatusId == 1)
                sStatus = true;
            else if (model.sStatusId == 0)
                sStatus = false;
            else
                sStatus = null;
            var obj = ent.MRC_RptRechargeSales(model.ServiceProviderId, model.sFromdate, model.sTodate, model.sMobileNo, model.sAmount, sStatus, model.AgentId, model.sType);
            foreach (var item in obj)
            {
                TopUpModel _model = new TopUpModel
                {
                    CustomerName = "",
                    MobileNo = item.CustomerMobileNo,
                    RechargeAmount = item.Amount == null ? 0 : item.Amount.Value,
                    ReferenceNo = item.ReferenceNo,
                    SalesDate = item.SalesDate,
                    SalesTranId = item.SalesTranId == null ? 0 : item.SalesTranId.Value
                };
                _list.Add(_model);
            }
            return _list;
        }

        public List<AgentTranModel> TranList(AgentTranModel model)
        {
            List<AgentTranModel> _list = new List<AgentTranModel>();
            if (model.ToDate != null)
                model.ToDate = model.ToDate.Value.AddHours(23).AddMinutes(59);

            var obj = ent.MRC_AgentTrans(model.FromDate, model.ToDate, model.ReportType).OrderBy(x => x.AgentCode);
            foreach (var item in obj)
            {
                AgentTranModel _model = new AgentTranModel
                {
                    AgentCode = item.AgentCode,
                    AgentName = item.AgentName,
                    IsSuccess = item.IsSuccess,
                    TranCount = item.TranCount,
                    TranDate = item.TranDate
                };
                _list.Add(_model);
            }
            return _list;
        }
        public IPagedList<AgentTranModel> PagedTranList(AgentTranModel model, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return TranList(model).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }
        public List<SelectListItem> ddlReportTypeList()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Add(new SelectListItem { Value = "All", Text = "All" });
            _list.Add(new SelectListItem { Value = "ByDate", Text = "By Date" });
            return _list;
        }
    }
}