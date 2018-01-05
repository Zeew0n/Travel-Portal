using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ATLTravelPortal.Areas.Train.Models;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;
using TravelPortalEntity;
using System.IO;

namespace ATLTravelPortal.Areas.Train.Repository
{
    public class TrainBookingRequestRepository
    {
        TrainMessageModel _msg = new TrainMessageModel();
        DateTime CurrentDateTime = ATLTravelPortal.Repository.GeneralRepository.CurrentDateTime();
        int LoggedUserId = ATLTravelPortal.Repository.GeneralRepository.LoggedUserId();
        public List<TrainBookingRequestModel> List(TrainBookingRequestModel model)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            //if(model.FromDate>model.ToDate)
            //{


            //    return null;
            //}

            if (model.AgentId != 0)
            {
                _res = _ent.Train_PNRs.Where(x => (x.TicketStatusId == model.StatusId) && x.AgentId == model.AgentId && x.CreateDate >= model.FromDate && x.CreateDate <= model.ToDate);
            }
            else
            {
                _res = _ent.Train_PNRs.Where(x => (x.TicketStatusId == model.StatusId) && x.CreateDate >= model.FromDate && x.CreateDate <= model.ToDate);
            }
            //  var obj = _ent.Train_PNRs.Where(x => (x.TicketStatusId == 1 || x.TicketStatusId == 7) && x.CreateDate >= model.FromDate && x.CreateDate <= model.ToDate);
            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }
            //return _list.OrderByDescending(x => x.CreateDate).ToList();
            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> DistributorList(TrainBookingRequestModel model, int distributorID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {
                //_res = _ent.Train_PNRs.Where(x => (x.TicketStatusId == model.StatusId)  && x.AgentId == model.AgentId && x.CreateDate >= model.FromDate && x.CreateDate <= model.ToDate);

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                             && a.AgentId == model.AgentId
                             && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                //_res = _ent.Train_PNRs.Where(x => (x.TicketStatusId == model.StatusId) && x.CreateDate >= model.FromDate && x.CreateDate <= model.ToDate);
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                             && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }

            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> DistributorProcessList(TrainBookingRequestModel model, int distributorID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 7
                             && a.AgentId == model.AgentId
                            && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 7
                             && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }
            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> DistributorCancelledBookingList(TrainBookingRequestModel model, int distributorID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 2
                             && a.AgentId == model.AgentId
                           // && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 2
                           // && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }
            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> BranchCancelledBookingList(TrainBookingRequestModel model, int branchID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 2
                             && a.AgentId == model.AgentId
                            && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 2
                            && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }
            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> BranchProcessList(TrainBookingRequestModel model, int branchID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 7
                             && a.AgentId == model.AgentId
                            && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == 7
                            && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }
            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> BranchIssuedList(TrainBookingRequestModel model, int branchID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                             && a.AgentId == model.AgentId
                            && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                            && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }
            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> DistributorIssuedList(TrainBookingRequestModel model, int distributorID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                             && a.AgentId == model.AgentId
                            && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                            && b.DistributorId == distributorID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }
            return _list.OrderBy(x => x.CreateDate).ToList();
        }

        public List<TrainBookingRequestModel> BranchList(TrainBookingRequestModel model, int branchID)
        {
            int Sno = 0;
            IEnumerable<Train_PNRs> _res = null;

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (model.FromDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().AddDays(-30);
            }
            else
            {
                model.FromDate = Convert.ToDateTime(Convert.ToDateTime(model.FromDate).ToShortDateString() + " 12:00:00 AM");
            }
            if (model.ToDate == null)
            {
                model.ToDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            }
            else
            {
                model.ToDate = Convert.ToDateTime(Convert.ToDateTime(model.ToDate).ToShortDateString() + " 11:59:59 PM");
            }

            if (model.AgentId != 0)
            {
                //_res = _ent.Train_PNRs.Where(x => (x.TicketStatusId == model.StatusId)  && x.AgentId == model.AgentId && x.CreateDate >= model.FromDate && x.CreateDate <= model.ToDate);

                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                             && a.AgentId == model.AgentId
                             && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }
            else
            {
                //_res = _ent.Train_PNRs.Where(x => (x.TicketStatusId == model.StatusId) && x.CreateDate >= model.FromDate && x.CreateDate <= model.ToDate);
                _res = from a in _ent.Train_PNRs
                       join b in _ent.Agents on a.AgentId equals b.AgentId
                       where a.TicketStatusId == model.StatusId
                              && b.BranchOfficeId == branchID
                             && a.CreateDate >= model.FromDate
                             && a.CreateDate <= model.ToDate
                       select a;
            }

            List<TrainBookingRequestModel> _list = new List<TrainBookingRequestModel>();
            foreach (var item in _res)
            {
                Sno++;
                TrainBookingRequestModel _model = new TrainBookingRequestModel
                {
                    SNo = Sno,
                    CreateDate = item.CreateDate,
                    CreatedBy = item.CreatedBy,
                    CreatedByName = item.UsersDetails.FullName,
                    DepartureDate = item.DepartureDate,
                    TrainPNRId = item.TrainPNRId,
                    FullName = item.Prefix + " " + item.FullName,
                    Sector = "[" + item.Train_Stations.TrainStationName + " - " + item.Train_Stations1.TrainStationName + "]",
                    StatusId = item.TicketStatusId
                };
                _list.Add(_model);
            }

            return _list.OrderBy(x => x.CreateDate).ToList();
        }



        public IPagedList<TrainBookingRequestModel> GetPendingBookingPagedList(TrainBookingRequestModel model, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return List(model).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }

        public IPagedList<TrainBookingRequestModel> GetDistributorPendingBookingPagedList(TrainBookingRequestModel model, int? page, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return DistributorList(model, distributorID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }

        public IPagedList<TrainBookingRequestModel> GetDistributorProcessBookingPagedList(TrainBookingRequestModel model, int? page, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return DistributorProcessList(model, distributorID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }

        public IPagedList<TrainBookingRequestModel> GetDistributorCancelledBookingPagedList(TrainBookingRequestModel model, int? page, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return DistributorCancelledBookingList(model, distributorID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }

        public IPagedList<TrainBookingRequestModel> GetBranchCancelledBookingPagedList(TrainBookingRequestModel model, int? page, int branchID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return BranchCancelledBookingList(model, branchID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }

        public IPagedList<TrainBookingRequestModel> GetBrachPendingBookingPagedList(TrainBookingRequestModel model, int? page, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return BranchList(model, distributorID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }


        public IPagedList<TrainBookingRequestModel> GetBranchProcessBookingPagedList(TrainBookingRequestModel model, int? page, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return BranchProcessList(model, distributorID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }

        public IPagedList<TrainBookingRequestModel> GetBranchIssuedPagedList(TrainBookingRequestModel model, int? page, int branchID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return BranchIssuedList(model, branchID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }


        public IPagedList<TrainBookingRequestModel> GetDistributorIssuedPagedList(TrainBookingRequestModel model, int? page, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return DistributorIssuedList(model, distributorID).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }


        public List<SelectListItem> ddlAgeList(int min, int max, string age)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            List<SelectListItem> _List = new List<SelectListItem>();
            _List.Add(new SelectListItem { Value = "", Text = "--Select--" });
            for (var i = min; i <= max; i++)
            {
                _List.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString(), Selected = age == i.ToString() ? true : false });
            }
            return _List;
        }





        public TrainPNRModel Detail(long? id)
        {
            string _IDTypeName = "";

            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            TrainPNRModel _model = new TrainPNRModel();
            var obj = _ent.Train_PNRs.Where(x => x.TrainPNRId == id).FirstOrDefault();
            // int noOfAdult = obj.Train_Passengers.Where(x => x.PassengerType == "Adult").Count();
            // int noOfChild = obj.Train_Passengers.Where(x => x.PassengerType == "Child").Count();
            if (obj != null)
            {
                List<TrainPassengerModel> _passList = new List<TrainPassengerModel>();
                foreach (var item in obj.Train_Passengers)
                {
                    if (item.Core_IDTypes != null)
                        _IDTypeName = item.Core_IDTypes.IDTypeName;

                    TrainPassengerModel _passenger = new TrainPassengerModel
                    {
                        Age = item.Age,
                        FullName = item.FullName,
                        Gender = item.Gender,
                        IDNumber = item.IDNumber,
                        IDTypeId = item.IDTypeId,
                        IDTypeName = item.Core_IDTypes == null ? "" : item.Core_IDTypes.IDTypeName,
                        PassengerType = item.PassengerType,
                        Prefix = item.Prefix,
                        Nationality = item.Nationality,
                        IsPrimary = item.IsPrimary,
                        TrainPassengerId = item.TrainPassengerId,
                        Fare = item.Fare,
                        ddlPrefixList = ddlPrefixList(item.Prefix),
                        ddlGenderList = ddlGenderList(item.Gender),
                        ddlIDTypeList = ddlIDTypeList(item.Core_IDTypes == null ? "" : item.Core_IDTypes.IDTypeName),
                        ddlAdultAgeList = ddlAgeList(12, 60, item.Age.ToString()),
                        ddlChaildAgeList = ddlAgeList(5, 11, item.Age.ToString()),
                        ddlSMAgeList = ddlAgeList(60, 120, item.Age.ToString()),
                        ddlSFAgeList = ddlAgeList(60, 120, item.Age.ToString()),
                    };
                    _passList.Add(_passenger);
                }

                TrainPNRModel model = new TrainPNRModel
                {
                    CreateDate = obj.CreateDate,
                    CreatedBy = obj.CreatedBy,
                    CreatedByName = obj.UsersDetails.FullName,
                    DepartureDate = obj.DepartureDate,
                    //  FullName = obj.FullName,
                    JourneyType = obj.JourneyType,
                    NoOfAdult = obj.NoOfAdult,
                    NoOfChild = obj.NoOfChild,
                    NoOfSM = obj.NoOfSeniorMen,
                    NoOfSF = obj.NoOfSeniorWomen,
                    NoOfSeat = (obj.NoOfAdult + obj.NoOfChild + obj.NoOfSeniorMen + obj.NoOfSeniorWomen),
                    Passengers = _passList,
                    TicketStatusName = obj.TicketStatus.ticketStatusName,
                    Age = obj.Age,
                    ArrivalDate = obj.ArrivalDate,
                    ArrivalTime = obj.ArrivalTime,
                    ChoiceSubjects = obj.ChoiceSubjects,
                    ContactAddress = obj.ContactAddress,
                    DepartureTime = obj.DepartureTime,
                    EmailAddress = obj.EmailAddress,
                    FromStationId = obj.FromStationId,
                    FromStationName = obj.Train_Stations.TrainStationName,
                    Gender = obj.Gender,
                    IDNumber = obj.IDNumber,
                    IDTypeId = obj.IDTypeId,
                    IDTypeName = obj.Core_IDTypes == null ? string.Empty : obj.Core_IDTypes.IDTypeName,
                    IssuedBy = obj.IssuedBy,
                    IssuedByName = obj.UsersDetails2 == null ? "" : obj.UsersDetails2.FullName,
                    IssuedDate = obj.IssuedDate,
                    MobileNumber = obj.MobileNumber,
                    Nationality = obj.Nationality,
                    PhoneNumber = obj.PhoneNumber,
                    Prefix = obj.Prefix,
                    //Quota = obj.Quota,
                    Remarks = obj.Remarks,
                    ReturnDate = obj.ReturnDate,
                    ReturnTime = obj.ReturnTime,
                    TicketStatusId = obj.TicketStatusId,
                    ToStationId = obj.ToStationId,
                    ToStationName = obj.Train_Stations1.TrainStationName,
                    TrainClassId = obj.TrainClassId,
                    TrainClassName = obj.Train_Calss.TrainClassName,
                    TrainPNRId = obj.TrainPNRId,
                    UpdateDate = obj.UpdateDate,
                    UpdatedBy = obj.UpdatedBy,
                    UpdatedByName = obj.UsersDetails1 == null ? "" : obj.UsersDetails1.FullName,
                    AgentAddress = obj.Agents.Address,
                    AgentCode = obj.Agents.AgentCode,
                    AgentEmial = obj.Agents.Email,
                    AgentName = obj.Agents.AgentName,
                    AgentPhone = obj.Agents.Phone,
                    AgentId = obj.AgentId,
                    TrainName = obj.TrainName,
                    TrainNo = obj.TrainNo,
                    RailWayPNR = obj.RailWayPNR,
                    AHMarkUp = obj.AHMarkUp,
                    ExchangeRate = obj.ExchangeRate,
                    Fair = obj.TotalFair,
                    GSASCharge = obj.GSASCharge,
                    IRCTCSCharge = obj.IRCTCSCharge,
                    AgentCharge = obj.AgentCharge,



                };
                _model = model;
                _msg.ActionMessage = "Success";
                _msg.MsgNumber = 0;
                _msg.MsgStatus = false;
                _msg.MsgType = 0;
            }
            else
            {
                _msg.ActionMessage = "Invalid Operation.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 3;
            }
            _model.Message = _msg;
            _model.AvilableBalance = AvilableBalance(obj.AgentId);
            //_model.ddlChaildAgeList = ddlAgeList(5, 11, _model.Passengers[3].Age.ToString());
            //_model.ddlAdultAgeList = ddlAgeList(12, 60, _model.Passengers[0].Age.ToString());

            //_model.ddlSMAgeList = ddlAgeList(60, 120, _model.Passengers[1].Age.ToString());
            //_model.ddlSFAgeList = ddlAgeList(60, 120, _model.Passengers[2].Age.ToString());
            return _model;
        }

        public AvailableBalanceViewModel AvilableBalance(int AgentId)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var AvailableBalanceResult = _ent.Air_GetAvailableBalance(AgentId).ToList();
            var Balanceviewmodel = new AvailableBalanceViewModel();
            /// For NPR balance
            ///  //Currency
            Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
            Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
            Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;

            /// For USD balance
            Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
            Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

            /// For INR balance
            Balanceviewmodel.CurrencyINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode : "";
            Balanceviewmodel.CreditLimitINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).Amount : double.Parse("");


            if (Balanceviewmodel.CurrentBalanceNPR == null)
                Balanceviewmodel.CurrentBalanceNPR = 0;


            double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceNPR = true;
            else
                Balanceviewmodel.isLowBalanceNPR = false;

            double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceUSD = true;
            else
                Balanceviewmodel.isLowBalanceUSD = false;

            double minBalanceINR = Balanceviewmodel.CreditLimitINR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceINR <= minBalanceINR)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceINR = true;
            else
                Balanceviewmodel.isLowBalanceINR = false;
            return Balanceviewmodel;

        }


        public List<SelectListItem> ddlTrainCalssList()
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            List<SelectListItem> _List = new List<SelectListItem>();
            _List.Add(new SelectListItem { Value = "", Text = "--Select Class--" });
            var obj = _ent.Train_Calss;
            foreach (var item in obj)
            {
                _List.Add(new SelectListItem { Value = item.TrainCalssId.ToString(), Text = item.TrainClassName });
            }
            return _List;
        }
        public List<SelectListItem> ddlIDTypeList(string IdType)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            List<SelectListItem> _List = new List<SelectListItem>();
            _List.Add(new SelectListItem { Value = "", Text = "--Select Type--" });
            var obj = _ent.Core_IDTypes;
            foreach (var item in obj)
            {
                _List.Add(new SelectListItem { Value = item.CoreIDTypeId.ToString(), Text = item.IDTypeName, Selected = IdType == item.IDTypeName.ToString() ? true : false });
            }
            return _List;
        }
        public List<SelectListItem> ddlPrefixList(string prefix)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            List<SelectListItem> _List = new List<SelectListItem>();
            _List.Add(new SelectListItem { Value = "Mr", Text = "Mr", Selected = prefix == "Mr" ? true : false });
            _List.Add(new SelectListItem { Value = "Mrs", Text = "Mrs", Selected = prefix == "Mrs" ? true : false });
            _List.Add(new SelectListItem { Value = "Ms", Text = "Ms", Selected = prefix == "Ms" ? true : false });
            return _List;
        }
        public List<SelectListItem> ddlGenderList(string gender)
        {
            List<SelectListItem> _List = new List<SelectListItem>();
            _List.Add(new SelectListItem { Value = "Male", Text = "Male", Selected = gender == "Male" ? true : false });
            _List.Add(new SelectListItem { Value = "Female", Text = "Female", Selected = gender == "Female" ? true : false });
            return _List;
        }
        public TrainMessageModel Edit(TrainPNRModel model)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj1 = _ent.Train_Passengers.Where(x => x.TrainPNRId == model.TrainPNRId && x.IsPrimary == true).FirstOrDefault();

            var obj = _ent.Train_PNRs.Where(x => x.TrainPNRId == model.TrainPNRId).FirstOrDefault();
            if (obj != null)
            {
                // obj.Age = model.Age;
                //  obj.FullName = obj1.FullName;
                obj.ContactAddress = model.ContactAddress;
                obj.MobileNumber = model.MobileNumber;
                obj.PhoneNumber = model.PhoneNumber;
                // obj.Nationality = obj1.Nationality;
                obj.IDTypeId = obj1.IDTypeId;
                //  obj.IDNumber = obj1.IDNumber;
                obj.UpdateDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                obj.UpdatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                //obj.DepartureDate = model.DepartureDate;
                obj.EmailAddress = model.EmailAddress;
                //obj.FromStationId = model.FromStationId;
                //obj.ToStationId = model.ToStationId;
                //obj.TrainClassId = model.TrainClassId;
                //obj.ExchangeRate = model.ExchangeRate;
                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                _ent.SaveChanges();
            }
            else
            {
                _msg.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Train Booking ");
                _msg.MsgNumber = 1005;
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 3;
                _msg.MsgStatus = true;
                return _msg;
            }


            //else
            //{
            //    _msg.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Train Booking ");
            //    _msg.MsgNumber = 1005;
            //    _msg.ErrSource = "DataBase";
            //    _msg.MsgType = 3;
            //    _msg.MsgStatus = true;
            //    return _msg;
            //}

            if (model.Passengers != null)
            {
                if (model.Passengers.Count() > 0)
                {
                    foreach (var item in model.Passengers)
                    {
                        var obj2 = _ent.Train_Passengers.Where(x => x.TrainPNRId == model.TrainPNRId && x.TrainPassengerId == item.TrainPassengerId).FirstOrDefault();
                        if (obj2 != null)
                        {
                            obj2.Age = item.Age;
                            obj2.FullName = item.FullName;
                            obj2.Gender = item.Gender;
                            obj2.IDNumber = item.IDNumber;
                            obj2.IDTypeId = item.IDTypeId;
                            obj2.Nationality = item.Nationality;
                            obj2.Prefix = item.Prefix;
                            _ent.ApplyCurrentValues(obj2.EntityKey.EntitySetName, obj2);
                            _ent.SaveChanges();
                        }
                    }

                }
            }
            _msg.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Train Booking ");
            _msg.MsgNumber = 0;
            _msg.ErrSource = "DataBase";
            _msg.MsgType = 0;
            _msg.MsgStatus = true;
            return _msg;
        }
        public TrainMessageModel Book(TrainPNRModel model)
        {
            if (!string.IsNullOrEmpty(model.RailWayPNR))
            {
                TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
                var obj = _ent.Train_PNRs.Where(x => x.TrainPNRId == model.TrainPNRId).FirstOrDefault();
                if (obj != null)
                {
                    string _PNRFileName = "";
                    _msg = UploadFileMaster(model.PNRFile, out _PNRFileName);
                    if (_msg.MsgNumber > 0)
                    {
                        return _msg;
                    } 
                    var fromstationcode = _ent.Train_Stations.Where(x => x.TrainStationId == obj.FromStationId).Select(x => x.TrainStationCode).FirstOrDefault();
                    var tosatationcode = _ent.Train_Stations.Where(x => x.TrainStationId == obj.ToStationId).Select(x => x.TrainStationCode).FirstOrDefault();
                    _ent.Train_SaveSalesTransaction(obj.TrainPNRId, obj.RailWayPNR, fromstationcode, tosatationcode, CurrentDateTime, LoggedUserId, ATLTravelPortal.Repository.GeneralRepository.getIPAddress);

                    obj.RailWayPNR = model.RailWayPNR;
                    obj.TicketStatusId = 4;
                    obj.PNRFileName = _PNRFileName;
                    obj.IssuedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                    obj.IssuedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                    _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                    _ent.SaveChanges();

                }
                else
                {
                    _msg.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Train Booking ");
                    _msg.MsgNumber = 1005;
                    _msg.ErrSource = "DataBase";
                    _msg.MsgType = 3;
                    _msg.MsgStatus = true;
                    return _msg;
                }
                _msg.ActionMessage = String.Format(Resources.Message.SuccessfullySaved, "Train Booking ");
                _msg.MsgNumber = 0;
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 0;
                _msg.MsgStatus = true;
                return _msg;
            }
            else
            {
                _msg.ActionMessage = "Rail Way PNR is required.";
                _msg.MsgNumber = 1000;
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 3;
                _msg.MsgStatus = true;
                return _msg;
            }
        }
        public TrainMessageModel Cancel(long? id)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj = _ent.Train_PNRs.Where(x => x.TrainPNRId == id).FirstOrDefault();
            if (obj != null)
            {
                obj.TicketStatusId = 2;
                obj.CanceledDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                obj.CanceledBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                _ent.SaveChanges();
            }
            else
            {
                _msg.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Train Booking ");
                _msg.MsgNumber = 1005;
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 3;
                _msg.MsgStatus = true;
                return _msg;
            }
            _msg.ActionMessage = String.Format(Resources.Message.SuccessfullySaved, "Canceled ");
            _msg.MsgNumber = 0;
            _msg.ErrSource = "DataBase";
            _msg.MsgType = 0;
            _msg.MsgStatus = true;
            return _msg;
        }
        public TrainMessageModel Process(long? id)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj = _ent.Train_PNRs.Where(x => x.TrainPNRId == id).FirstOrDefault();
            if (obj != null)
            {
                obj.TicketStatusId = 7;
                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                _ent.SaveChanges();
                _msg.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Train PNR to In Process.");
                _msg.MsgNumber = 0;
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 0;
                _msg.MsgStatus = true;
            }
            else
            {
                _msg.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Train Booking ");
                _msg.MsgNumber = 1005;
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 3;
                _msg.MsgStatus = true;
                return _msg;
            }
            _msg.ActionMessage = String.Format(Resources.Message.SuccessfullySaved, "Process");
            _msg.MsgNumber = 0;
            _msg.ErrSource = "DataBase";
            _msg.MsgType = 0;
            _msg.MsgStatus = true;
            return _msg;
        }

        public void SendEmail(string Boby, string Rece, long? id)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj = _ent.Train_PNRs.Where(x => x.TrainPNRId == id).FirstOrDefault();
            if (obj != null)
            {
                obj.TicketStatusId = 7;
                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                _ent.SaveChanges();
            }
            else
            {
                _msg.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Train Booking ");
                _msg.MsgNumber = 1005;
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 3;
                _msg.MsgStatus = true;

            }

            EntityModel ent = new EntityModel();
            ent.CORE_SendEmails(Rece, string.Empty, string.Empty, "Train eTicket", Boby, "HTML", "HIGH");
        }
        private string ValidateImage(HttpPostedFileBase file)
        {
            foreach (string item in TrainGeneralRepository.PNRFileFormat)
            {
                var x = file.FileName.ToLower().EndsWith(item.ToLower());
                if (x == true)
                {
                    return item;
                }
            }
            return "";
        }

        private TrainMessageModel UploadFileMaster(HttpPostedFileBase UploadedFile, out string ImageName)
        {
            string ImageFileName = "";
            if (UploadedFile != null)
            {
                string Extensions = ValidateImage(UploadedFile);
                if (Extensions != "")
                {
                    try
                    {
                        var fname = UploadedFile.FileName;
                        string UploadDirPath = TrainGeneralRepository.TrainPNRLocation;
                        if (UploadedFile.ContentLength > 0)
                        {
                            ImageFileName = TrainGeneralRepository.RandomFileName + Extensions;
                            var path = Path.Combine(UploadDirPath, ImageFileName);
                            UploadedFile.SaveAs(path);
                        }
                        else
                        {
                            ImageFileName = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        _msg.ActionMessage = ex.Message;
                        _msg.ErrSource = "DataBase";
                        _msg.MsgType = 3;
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                    }
                }
                else
                {
                    _msg.ActionMessage = "Invalid File Format, valid format are ( PNG , JPG , GIF). ";
                    _msg.ErrSource = "DataBase";
                    _msg.MsgType = 3;
                    _msg.MsgNumber = 1001;
                    _msg.MsgStatus = true;
                }
            }
            else
            {
                _msg.ActionMessage = "Select PNR File. ";
                _msg.ErrSource = "DataBase";
                _msg.MsgType = 3;
                _msg.MsgNumber = 1001;
                _msg.MsgStatus = true;
            }
            ImageName = ImageFileName;
            return _msg;
        }
        public string IsValidFile(long? id)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj = _ent.Train_PNRs.Where(x => x.TrainPNRId == id).FirstOrDefault();
            if (obj != null)
            {
                return obj.PNRFileName;
            }
            else
            {
                return "";
            }
        }

        //for train search log report....
        public List<TrainSearchLogModel> ListSearchResult(int? AgentId, DateTime? FromDate, DateTime? ToDate)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var result = _ent.Train_RptSearchLog(FromDate, ToDate, AgentId);
            List<TrainSearchLogModel> _model = new List<TrainSearchLogModel>();

            foreach (var item in result)
            {
                var SearchLogList = new TrainSearchLogModel()
                {
                    AgentName = item.AgentName,
                    NoOfSearch = item.NoOfSearch,
                };

                _model.Add(SearchLogList);
            }
            return _model;

        }
        public IPagedList<TrainSearchLogModel> GetList(TrainSearchLogModel _model, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return ListSearchResult(_model.AgentId, _model.FromDate, _model.ToDate).ToPagedList(currentPageIndex, TrainGeneralRepository.DefaultPageSize);
        }

    }
}