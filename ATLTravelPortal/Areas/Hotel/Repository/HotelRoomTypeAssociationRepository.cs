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
    public class HotelRoomTypeAssociationRepository
    {
        EntityModel ent = new EntityModel();
        public IEnumerable<Htl_RoomTypeAssociation> GetHotelRoomTypeAssociationByHotelId(int HotelId)
        {
           
            var res = ent.Htl_RoomTypeAssociation.Where(x => x.HotelId == HotelId);

            foreach (var x in res)
            {
                yield return x;
            }
        }
    }
}