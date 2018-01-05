using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;


namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelCancellationPolicyRepository
    {
        public HotelCancellationPolicyModel Get(HotelCancellationPolicyModel model, HotelSearchResultModel _resmodel)
        {
             HotelCore.Utility.HotelDetailSearchRows _rowsForDetail = new HotelCore.Utility.HotelDetailSearchRows();
            _rowsForDetail.CheckInDate = _resmodel.CheckInDate;
            _rowsForDetail.CheckOutDate = _resmodel.CheckOutDate;
            _rowsForDetail.CityName = _resmodel.CityName;
            _rowsForDetail.CountryName = _resmodel.CountryName;
            _rowsForDetail._resultsRows = _resmodel.Result;
            //HotelCancellationPolicyModel _model = new HotelCancellationPolicyModel();
            HotelMessageModel _msg = new HotelMessageModel();
            HotelCore.API api = new HotelCore.API();
            HotelCore.GetCancellationPolicy.Response _res = new HotelCore.GetCancellationPolicy.Response();
            HotelCore.GetHotelDetails.RoomDescRequest _req = new HotelCore.GetHotelDetails.RoomDescRequest();
            _req.SearchIndex = model.SearchIndex;
            _req.NoOfRooms = model.NoOfRoom;
            _req.RatePlanCode = model.RatePlanCode;
            _req.RoomTypeCode = model.RoomTypeCode;
            _req.SessionId = model.SessiobId;
            _req.HotelCode = model.HotelCode;
            _req.GDSID = _resmodel.GDSID;
            _res = api.RoomPolicy(_req, _rowsForDetail);
            _msg.ActionMessage = _res.Status.Description;
            _msg.MsgNumber = _res.Status.StatusNumber == 0 ? 1 : 1000; ;
            _msg.MsgStatus = _res.Status.StatusNumber == 1 ? false : true;
            _msg.MsgType = _res.Status.StatusNumber == 0 ? 1 : 3;
            model.Message = _msg;
            model.CancellationPolicy = _res.CancellationPolicy;
            model.CancellationPolicyAvailable = _res.CancellationPolicyAvailable;
            model.HotelNorms = _res.HotelNorms;
            model.HotelNormsAvailable = _res.HotelNormsAvailable;
            return model; 
        }
    }
}