using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMUserNap
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public int NapId { get; set; }
        public string Timestamp { get; set; }
    }
}
