using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMEnvironment
    {
        public decimal Noise { get; set; }
        public decimal Illumination { get; set; }
    }
}
