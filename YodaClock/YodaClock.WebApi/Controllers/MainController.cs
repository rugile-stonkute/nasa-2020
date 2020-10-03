using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YodaClock.WebApi.Models;

namespace YodaClock.WebApi.Controllers
{
    [ApiController]
    [Route("")]
    [EnableCors("Cors")]
    public class MainController : ControllerBase
    {
        public MainController()
        {
        }

        [HttpPost]
        public Data Get(Data data)
        {
            return data;
        }
    }
}
