using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMMeal
    {
        public string Name { get; set; }
        public MvvMPlanMealTime PlanMealTime { get; set; }
    }
}
