using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;

namespace ATLTravelPortal.Provider.Admin
{
    public class CountryRepository
    {

        EntityModel ent = new EntityModel();
        /// <summary>
        /// Get All Country List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Countries> GetCountryList()
        {
          
            foreach (var x in ent.Countries)
            {
                yield return x;
            }

        }

        /// <summary>
        /// Get Country info by Id
        /// </summary>
        /// <param name="CId"></param>
        /// <returns></returns>
        public Countries GetCountryInfo(int CId)
        {
            return ent.Countries.SingleOrDefault(u => u.CountryId == CId);
        }
    }
}