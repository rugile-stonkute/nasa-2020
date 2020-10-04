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

        [HttpPost]
        [Route("Exercises")]
        public List<Exercise> GetExercises(Request request)
        {
            return Helpers.GetExercises(request);
        }

        [HttpPost]
        [Route("Meals")]
        public List<Meal> GetMeals(Request request)
        {
            return Helpers.GetMeals(request);
        }

        [HttpPost]
        [Route("Naps")]
        public List<Nap> GetNaps(Request request)
        {
            return Helpers.GetNaps(request);
        }

        [HttpPost]
        [Route("Plan")]
        public Plan GetPlan(Request request)
        {
            return Helpers.GetPlan(request);
        }

        [HttpPost]
        [Route("PlanMealTimes")]
        public List<PlanMealTime> GetPlanMealTimes(Request request)
        {
            return Helpers.GetPlanMealTimes(request);
        }

        [HttpPost]
        [Route("Products")]
        public List<Product> GetProducts(Request request)
        {
            return Helpers.GetProducts(request);
        }

        [HttpPost]
        [Route("UserEnvironment")]
        public UserEnvironment GetUserEnvironment(Request request)
        {
            return Helpers.GetUserEnvironment(request);
        }

        [HttpPost]
        [Route("UserMealExercises")]
        public List<UserMealExercise> GetUserMealExercises(Request request)
        {
            return Helpers.GetUserMealExercises(request);
        }

        [HttpPost]
        [Route("Nutritions")]
        public List<MvvMNutrition> GetNutrition(Request request)
        {
            return Helpers.GetNutrition(request);
        }

        [HttpPost]
        [Route("NutritionChanges")]
        public List<MvvMNutrition> SetNutritions(Request request)
        {
            return Helpers.SetNutritions(request);
        }

        [HttpPost]
        [Route("UserNaps")]
        public List<UserNap> GetUserNaps(Request request)
        {
            return Helpers.GetUserNaps(request);
        }

        [HttpPost]
        [Route("UserPrecondition")]
        public UserPrecondition GetUserPrecondition(Request request)
        {
            return Helpers.GetUserPrecondition(request);
        }

        [HttpPost]
        [Route("UserProductMeals")]
        public List<UserProductMeal> GetUserProductMeals(Request request)
        {
            return Helpers.GetUserProductMeals(request);
        }

        [HttpPost]
        [Route("DbResponses")]
        public List<DbResponse> GetDbResponses(Request request)
        {
            return Helpers.GetDbResponses(request);
        }

        [HttpPost]
        [Route("LuxResponses")]
        public List<LuxResponse> GetLuxResponses(Request request)
        {
            return Helpers.GetLuxResponses(request);
        }

        [HttpGet]
        [Route("Delete")]
        public void DeleteAll()
        {
            Helpers.Delete();
        }
    }
}
