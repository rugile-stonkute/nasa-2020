using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMLoginRegister
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public MvvMPrecondition Precondition { get; set; }
        public MvvMPlan Plan { get; set; }
    }
}
