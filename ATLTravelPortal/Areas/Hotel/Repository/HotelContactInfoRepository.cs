using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics;
using System.Data.Objects;
using System.Data;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelContactInfoRepository
    {
        EntityModel ent = new EntityModel();
        public Htl_HotelContactInfos HotelContactInfoHotelId(Int64 HotelId)
        {
            return ent.Htl_HotelContactInfos.Where(x => x.HotelId == HotelId).FirstOrDefault();
        }
    }
}