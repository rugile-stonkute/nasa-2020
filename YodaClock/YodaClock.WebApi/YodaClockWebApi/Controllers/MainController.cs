using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YodaClock.Controllers
{
    [ApiController]
    [Route("")]
    [EnableCors("Cors")]
    public class MainController : ControllerBase
    {
        public MainController()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}
