using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Administrator.Models.Enums
{
    public enum MassEmailingType
    {
        [Description("Agent Class")] AgentClass=1,
        [Description("Agent Deal")] AgentDeal=2,
        [Description("Zone")] Zone=3,
        [Description("District")] District=4,
        [Description("Agent Specify")] AgentSpecify=5,
        [Description("Free Email")] FreeEmail=6
    }
}