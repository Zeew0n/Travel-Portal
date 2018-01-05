using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentProductViewModel
    {
        public int MappingId { get; set; }

        public int ProductId { get; set; }

        public int AgentId { get; set; }

        public String ProductName { get; set; }

        public bool IsActive { get; set; }

    }
    public class ModelAgentProductExtension
    {
        //////
        public static bool IsActiveAgentProduct(int ProductId, List<AgentProductViewModel> ProductIdHelper)
        {
            bool flag = false;
            List<int> ProductIds = ProductIdHelper.Select(ii => ii.ProductId).ToList();
            foreach (int aPid in ProductIds)
            {
                if (ProductId == aPid)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}