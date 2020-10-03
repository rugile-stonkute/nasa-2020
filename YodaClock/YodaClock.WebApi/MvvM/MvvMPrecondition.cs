using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMPrecondition
    {
        public int SleepDuration { get; set; }
        public int SleepInterruptions { get; set; }
        public decimal Noise { get; set; }
        public decimal Illumination { get; set; }
    }
}
