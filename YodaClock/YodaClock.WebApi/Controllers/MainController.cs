using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YodaClock.DataContext;
using YodaClock.WebApi.Models;
using YodaClock.WebApi.MvvM;

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
        [Route("LoginRegister")]
        public MvvMUser GetUserToken(MvvMLoginRegister loginRegister)
        {
            return Helpers.LoginRegister(loginRegister);
        }

        [HttpGet]
        [Route("Delete")]
        public void DeleteAll()
        {
            Helpers.Delete();
        }

        [HttpGet]
        [Route("Exercises")]
        public List<Exercise> GetExercises()
        {
            return Helpers.GetExercises();
        }

        [HttpGet]
        [Route("UserPreconditions")]
        public List<UserPrecondition> GetUserPreconditions()
        {
            return Helpers.GetUserPreconditions();
        }

        [HttpGet]
        [Route("UserEnvironments")]
        public List<UserEnvironment> GetUserEnvironments()
        {
            return Helpers.GetUserEnvironments();
        }
    }
}
