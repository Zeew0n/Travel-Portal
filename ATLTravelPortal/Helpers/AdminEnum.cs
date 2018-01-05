using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ATLTravelPortal.Helpers
{
    public enum UserTypes
    {
        SuperUser = 1,
        User = 2,
        MEs=4,
        BranchUser=5,
        DistributorUser=6,
        CRMUser = 7,
        BackofficeUser=8
    }
    public enum PageSize
    {
        JePageSize = 30,
        LaPageSize = 10
    }

    public enum ProductType
    {
        Ticketing = 1,
        Hotel = 2,
        BackOffice=5
    }
}