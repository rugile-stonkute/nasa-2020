using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace YodaClock.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("")]
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
