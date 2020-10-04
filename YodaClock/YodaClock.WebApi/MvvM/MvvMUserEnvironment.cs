using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMUserEnvironment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public decimal Noise { get; set; }
        public decimal Illumination { get; set; }
    }
}
