#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: SessionExpire.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
 using ATLTravelPortal.Helpers;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public interface IAirlineCachingRepository
    {
        void ClearCache();
        IEnumerable<Airlines> GetCacheAirlines();
    }
    public class AirlineCachingRepository : IAirlineCachingRepository
    {
        protected EntityModel DataContext { get; private set; }

        public ICacheProvider Cache { get; set; }

        public AirlineCachingRepository()
            : this(new DefaultCacheProvider())
        {
        }

        public AirlineCachingRepository(ICacheProvider cacheProvider)
        {
            this.DataContext = new EntityModel();
            this.Cache = cacheProvider;
        }

        public IEnumerable<Airlines> GetCacheAirlines()
        {
            // First, check the cache
            IEnumerable<Airlines> AirlineData = Cache.Get("AirlineCache") as IEnumerable<Airlines>;

            // If it's not in the cache, we need to read it from the repository
            if (AirlineData == null)
            {
                // Get the repository data
                AirlineData = DataContext.Airlines.OrderBy(v => v.AirlineName).ToList();

                if (AirlineData.Any())
                {
                    // Put this data into the cache for 30 minutes
                    Cache.Set("AirlineCache", AirlineData, 30);
                }
            }

            return AirlineData;
        }

        public void ClearCache()
        {
            Cache.Invalidate("AirlineCache");
        }
    }
}