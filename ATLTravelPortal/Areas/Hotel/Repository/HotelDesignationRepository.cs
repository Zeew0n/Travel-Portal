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
    public class HotelDesignationRepository
    {
        EntityModel entity = new EntityModel();
        public IEnumerable<Htl_HotelDesignations> HotelDesignationList()
        {
            foreach (var x in entity.Htl_HotelDesignations)
            {
                yield return x;
            }
        }
    }
}