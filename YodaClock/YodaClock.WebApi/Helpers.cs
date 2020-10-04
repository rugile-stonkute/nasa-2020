using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YodaClock.DataContext;
using YodaClock.WebApi.Models;
using YodaClock.WebApi.MvvM;

namespace YodaClock.WebApi
{
    public static class Helpers
    {
        public static SF GetSF(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new SF();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn.Percentage = 0;

                    var userPrecondition = context.UserPreconditions.FirstOrDefault(up => up.UserId == existingUser.Id);
                    var userEnvironment = context.UserEnvironments.FirstOrDefault(up => up.UserId == existingUser.Id);
                    var plans = context.Plans.FirstOrDefault(p => p.Id == existingUser.PlanId);
                    var dbResponses = context.DbResponses.ToList();
                    var luxResponses = context.LuxResponses.ToList();

                    var diffSleepDuration = plans.SleepDuration - userPrecondition.SleepDuration;
                    if(diffSleepDuration > 0 && diffSleepDuration <= 60)
                    {
                        toReturn.Percentage -= 10;
                    }
                    else if(diffSleepDuration > 60)
                    {
                        toReturn.Percentage -= 30;
                    }

                    if(userPrecondition.SleepInterruptions > 7)
                    {
                        toReturn.Percentage -= 40;
                    }
                    else if(userPrecondition.SleepInterruptions >= 6)
                    {
                        toReturn.Percentage -= 20;
                    }
                    else if (userPrecondition.SleepInterruptions >= 3)
                    {
                        toReturn.Percentage -= 10;
                    }
                    else if (userPrecondition.SleepInterruptions >= 1)
                    {
                        toReturn.Percentage -= 5;
                    }

                    foreach(var db in dbResponses)
                    {
                        if(db.Db > userEnvironment.Noise)
                        {
                            toReturn.Percentage += db.Percentage;
                            break;
                        }
                    }

                    foreach (var lux in luxResponses)
                    {
                        if (lux.Lux > userEnvironment.Noise)
                        {
                            toReturn.Percentage += lux.Percentage;
                            break;
                        }
                    }

                    //After Preconditions

                    //TODO: FINISH PROJECT


                }

                return toReturn;
            }
        }

        public static List<Exercise> GetExercises(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<Exercise>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);
                
                if(existingUser != null)
                {
                    toReturn = context.Exercises.Where(e => e.PlanId == existingUser.PlanId).ToList();
                }

                return toReturn;
            }
        }

        public static List<MvvMProductMeal> GetUserProductMeals(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMProductMeal>();
                var userProducMeals = new List<UserProductMeal>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    userProducMeals = context.UserProductMeals.Where(e => e.UserId == existingUser.Id).ToList();

                    foreach(var userProductMeal in userProducMeals)
                    {
                        toReturn.Add(new MvvMProductMeal()
                        {
                            ProductId = userProductMeal.ProductId,
                            MealId = userProductMeal.MealId,
                            Amount = userProductMeal.Amount,
                            Timestamp = userProductMeal.Timestamp.ToString("HH:MM"),
                            Username = existingUser.Username,
                            Token = existingUser.Token,
                            Id = userProductMeal.Id
                        });
                    }
                }

                return toReturn;
            }
        }

        public static List<MvvMProductMeal> SetUserProductMeals(List<MvvMProductMeal> productMeals)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMProductMeal>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == productMeals[0].Username && u.Token == productMeals[0].Token);

                if (existingUser != null)
                {
                    context.UserProductMeals.RemoveRange(context.UserProductMeals.Where(upm => upm.UserId == existingUser.Id));
                    context.SaveChanges();

                    foreach (var productMeal in productMeals)
                    {
                        var userProductMeal = new UserProductMeal()
                        {
                            Id = productMeal.Id,
                            UserId = existingUser.Id,
                            ProductId = productMeal.ProductId,
                            MealId = productMeal.MealId,
                            Amount = productMeal.Amount,
                            Timestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        Convert.ToInt32(productMeal.Timestamp.Split(":")[0]), Convert.ToInt32(productMeal.Timestamp.Split(":")[1]), 0),
                        };

                        context.UserProductMeals.Add(userProductMeal);
                        context.SaveChanges();

                        productMeal.Id = userProductMeal.Id;
                    }
                }

                return toReturn;
            }
        }

        public static List<MvvMUserEnvironment> GetUserEnvironments(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMUserEnvironment>();
                var userEnvironments = new List<UserEnvironment>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    userEnvironments = context.UserEnvironments.Where(e => e.UserId == existingUser.Id).ToList();

                    foreach (var userEnvironment in userEnvironments)
                    {
                        toReturn.Add(new MvvMUserEnvironment()
                        {
                            Illumination = userEnvironment.Illumination,
                            Noise = userEnvironment.Noise,
                            Username = existingUser.Username,
                            Token = existingUser.Token,
                            Id = userEnvironment.Id
                        });
                    }
                }

                return toReturn;
            }
        }

        public static List<MvvMUserEnvironment> SetUserEnvironments(List<MvvMUserEnvironment> userEnvironments)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMUserEnvironment>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == userEnvironments[0].Username && u.Token == userEnvironments[0].Token);

                if (existingUser != null)
                {
                    context.UserEnvironments.RemoveRange(context.UserEnvironments.Where(upm => upm.UserId == existingUser.Id));
                    context.SaveChanges();

                    foreach (var userEnvironment in userEnvironments)
                    {
                        var environment = new UserEnvironment()
                        {
                            Id = userEnvironment.Id,
                            UserId = existingUser.Id,
                            Illumination = userEnvironment.Illumination,
                            Noise = userEnvironment.Noise
                        };

                        context.UserEnvironments.Add(environment);
                        context.SaveChanges();

                        userEnvironment.Id = environment.Id;
                    }
                }

                return toReturn;
            }
        }

        public static List<MvvMMealExercise> GetMealExercises(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMMealExercise>();
                var userMealExercises = new List<UserMealExercise>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    userMealExercises = context.UserMealExercises.Where(e => e.UserId == existingUser.Id).ToList();

                    foreach (var userMealExercise in userMealExercises)
                    {
                        toReturn.Add(new MvvMMealExercise()
                        {
                            Ate = userMealExercise.Ate,
                            ExerciseId = userMealExercise.ExerciseId,
                            MealId = userMealExercise.MealId,
                            Time = userMealExercise.Time,
                            Timestamp = userMealExercise.Timestamp.ToString("HH:MM"),
                            Username = existingUser.Username,
                            Token = existingUser.Token,
                            Id = userMealExercise.Id
                        });
                    }
                }

                return toReturn;
            }
        }

        public static List<MvvMMealExercise> SetMealExercises(List<MvvMMealExercise> mvvMMealExercises)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMMealExercise>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == mvvMMealExercises[0].Username && u.Token == mvvMMealExercises[0].Token);

                if (existingUser != null)
                {
                    context.UserMealExercises.RemoveRange(context.UserMealExercises.Where(upm => upm.UserId == existingUser.Id));
                    context.SaveChanges();

                    foreach (var mvvMMealExercise in mvvMMealExercises)
                    {
                        var userMealExercise = new UserMealExercise()
                        {
                            Ate = mvvMMealExercise.Ate,
                            ExerciseId = mvvMMealExercise.ExerciseId,
                            MealId = mvvMMealExercise.MealId,
                            Time = mvvMMealExercise.Time,
                            Timestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        Convert.ToInt32(mvvMMealExercise.Timestamp.Split(":")[0]), Convert.ToInt32(mvvMMealExercise.Timestamp.Split(":")[1]), 0),
                        };

                        context.UserMealExercises.Add(userMealExercise);
                        context.SaveChanges();

                        mvvMMealExercise.Id = userMealExercise.Id;
                    }
                }

                return toReturn;
            }
        }

        public static List<Meal> GetMeals(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<Meal>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.Meals.Where(e => e.PlanId == existingUser.PlanId).ToList();
                }

                return toReturn;
            }
        }

        public static List<Nap> GetNaps(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<Nap>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.Naps.Where(e => e.PlanId == existingUser.PlanId).ToList();
                }

                return toReturn;
            }
        }

        public static Plan GetPlan(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new Plan();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.Plans.FirstOrDefault(e => e.Id == existingUser.PlanId);
                }

                return toReturn;
            }
        }

        public static List<PlanMealTime> GetPlanMealTimes(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<PlanMealTime>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.PlanMealTimes.Where(e => e.PlanId == existingUser.PlanId).ToList();
                }

                return toReturn;
            }
        }

        public static List<Product> GetProducts(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<Product>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.Products.Where(e => e.PlanId == existingUser.PlanId).ToList();
                }

                return toReturn;
            }
        }

        public static UserEnvironment GetUserEnvironment(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new UserEnvironment();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.UserEnvironments.FirstOrDefault(e => e.UserId == existingUser.Id);
                }

                return toReturn;
            }
        }

        public static List<UserMealExercise> GetUserMealExercises(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<UserMealExercise>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.UserMealExercises.Where(e => e.UserId == existingUser.Id).ToList();
                }

                return toReturn;
            }
        }

        public static List<MvvMUserNap> GetUserNaps(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMUserNap>();
                var userNaps = new List<UserNap>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    userNaps = context.UserNaps.Where(e => e.UserId == existingUser.Id).ToList();

                    foreach(var userNap in userNaps)
                    {
                        toReturn.Add(new MvvMUserNap()
                        {
                            Id = userNap.Id,
                            NapId = userNap.NapId,
                            Timestamp = userNap.Timestamp.ToString("HH:MM"),
                            Token = existingUser.Token,
                            Username = existingUser.Username
                        });
                    }
                }

                return toReturn;
            }
        }

        public static List<MvvMUserNap> SetUserNaps(List<MvvMUserNap> userNaps)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<MvvMUserNap>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == userNaps[0].Username && u.Token == userNaps[0].Token);

                if (existingUser != null)
                {
                    context.UserNaps.RemoveRange(context.UserNaps.Where(upm => upm.UserId == existingUser.Id));
                    context.SaveChanges();

                    foreach (var userNap in userNaps)
                    {
                        var nap = new UserNap()
                        {
                            Id = userNap.Id,
                            UserId = existingUser.Id,
                            NapId = userNap.NapId,
                            Timestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        Convert.ToInt32(userNap.Timestamp.Split(":")[0]), Convert.ToInt32(userNap.Timestamp.Split(":")[1]), 0),
                        };

                        context.UserNaps.Add(nap);
                        context.SaveChanges();

                        userNap.Id = nap.Id;
                    }
                }

                return toReturn;
            }
        }

        public static UserPrecondition GetUserPrecondition(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new UserPrecondition();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.UserPreconditions.FirstOrDefault(e => e.UserId == existingUser.Id);
                }

                return toReturn;
            }
        }

        public static List<DbResponse> GetDbResponses(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<DbResponse>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.DbResponses.ToList();
                }

                return toReturn;
            }
        }

        public static List<LuxResponse> GetLuxResponses(Request request)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new List<LuxResponse>();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == request.Username && u.Token == request.Token);

                if (existingUser != null)
                {
                    toReturn = context.LuxResponses.ToList();
                }

                return toReturn;
            }
        }

        public static void Delete()
        {
            using (var context = new YodaClockDbContext())
            {
                context.DbResponses.RemoveRange(context.DbResponses.ToList());
                context.SaveChanges();
                context.LuxResponses.RemoveRange(context.LuxResponses.ToList());
                context.SaveChanges();
                context.UserEnvironments.RemoveRange(context.UserEnvironments.ToList());
                context.SaveChanges();
                context.UserPreconditions.RemoveRange(context.UserPreconditions.ToList());
                context.SaveChanges();
                context.PlanMealTimes.RemoveRange(context.PlanMealTimes.ToList());
                context.SaveChanges();
                context.UserNaps.RemoveRange(context.UserNaps.ToList());
                context.SaveChanges();
                context.Naps.RemoveRange(context.Naps.ToList());
                context.SaveChanges();
                context.UserProductMeals.RemoveRange(context.UserProductMeals.ToList());
                context.SaveChanges();
                context.UserMealExercises.RemoveRange(context.UserMealExercises.ToList());
                context.SaveChanges();
                context.Users.RemoveRange(context.Users.ToList());
                context.SaveChanges();
                context.Exercises.RemoveRange(context.Exercises.ToList());
                context.SaveChanges();
                context.Products.RemoveRange(context.Products.ToList());
                context.SaveChanges();
                context.Meals.RemoveRange(context.Meals.ToList());
                context.SaveChanges();
                context.Plans.RemoveRange(context.Plans.ToList());
                context.SaveChanges();
            }
        }

        public static MvvMUser LoginRegister(MvvMLoginRegister loginRegister)
        {
            using (var context = new YodaClockDbContext())
            {
                var toReturn = new MvvMUser();

                var existingUser = context.Users.FirstOrDefault(u => u.Username == loginRegister.Username);

                if (existingUser == null)
                {
                    Plan plan = SetPlans(loginRegister, context);
                    SetDbResponses(loginRegister, context);
                    SetLuxResponses(loginRegister, context);
                    SetMeals(loginRegister, context, plan);
                    SetNaps(loginRegister, context, plan);
                    SetProducts(loginRegister, context, plan);
                    SetExercises(loginRegister, context, plan);
                    existingUser = SetUser(loginRegister, context, plan);
                    SetPrecondition(loginRegister, context, existingUser);
                    SetEnvironment(loginRegister, context, existingUser);

                    GetUser(toReturn, existingUser);
                }
                else
                {
                    if(existingUser.Token == loginRegister.Token)
                    {
                        GetUser(toReturn, existingUser);
                    }
                }

                return toReturn;
            }
        }

        private static void SetEnvironment(MvvMLoginRegister loginRegister, YodaClockDbContext context, User existingUser)
        {
            var environment = new UserEnvironment()
            {
                UserId = existingUser.Id,
                Illumination = loginRegister.Precondition.Illumination,
                Noise = loginRegister.Precondition.Noise
            };

            context.UserEnvironments.Add(environment);
            context.SaveChanges();
        }

        private static void SetPrecondition(MvvMLoginRegister loginRegister, YodaClockDbContext context, User existingUser)
        {
            var precondition = new UserPrecondition()
            {
                UserId = existingUser.Id,
                SleepDuration = loginRegister.Precondition.SleepDuration,
                SleepInterruptions = loginRegister.Precondition.SleepInterruptions
            };

            context.UserPreconditions.Add(precondition);
            context.SaveChanges();
        }

        private static void GetUser(MvvMUser toReturn, User existingUser)
        {
            toReturn.Id = existingUser.Id;
            toReturn.Username = existingUser.Username;
            toReturn.Token = existingUser.Token;
            toReturn.PlanId = existingUser.PlanId;
        }

        private static User SetUser(MvvMLoginRegister register, YodaClockDbContext context, Plan plan)
        {
            User existingUser = new User()
            {
                Username = register.Username,
                PlanId = plan.Id,
                Token = Guid.NewGuid().ToString()
            };
            context.Users.Add(existingUser);
            context.SaveChanges();
            return existingUser;
        }

        private static Plan SetPlans(MvvMLoginRegister register, YodaClockDbContext context)
        {
            var plan = new Plan()
            {
                Name = register.Plan.Name,
                ExercisePercentage = register.Plan.ExercisePercentage,
                ExcerciseTime = register.Plan.ExcerciseTime,
                Carb = register.Plan.Carb,
                Fat = register.Plan.Fat,
                Protein = register.Plan.Protein,
                SleepDuration = register.Plan.SleepDuration
            };

            context.Plans.Add(plan);
            context.SaveChanges();
            return plan;
        }

        private static void SetDbResponses(MvvMLoginRegister register, YodaClockDbContext context)
        {
            var dbResponses = new List<DbResponse>();

            foreach (var dbResponse in register.Plan.DbResponses)
            {
                var db = new DbResponse()
                {
                    Db = dbResponse.Db,
                    Percentage = dbResponse.Percentage
                };

                dbResponses.Add(db);
            }

            context.DbResponses.AddRange(dbResponses);
            context.SaveChanges();
        }

        private static void SetLuxResponses(MvvMLoginRegister register, YodaClockDbContext context)
        {
            var luxResponses = new List<LuxResponse>();

            foreach (var luxResponse in register.Plan.LuxResponses)
            {
                var lux = new LuxResponse()
                {
                    Lux = luxResponse.Lux,
                    Percentage = luxResponse.Percentage
                };

                luxResponses.Add(lux);
            }

            context.LuxResponses.AddRange(luxResponses);
            context.SaveChanges();
        }

        private static void SetMeals(MvvMLoginRegister register, YodaClockDbContext context, Plan plan)
        {
            foreach (var meal in register.Plan.Meals)
            {
                var m = new Meal()
                {
                    Name = meal.Name,
                    PlanId = plan.Id
                };

                context.Meals.Add(m);
                context.SaveChanges();

                var planMealTime = new PlanMealTime()
                {
                    PlanId = plan.Id,
                    MealId = m.Id,
                    Percentage = meal.PlanMealTime.Percentage,
                    Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        Convert.ToInt32(meal.PlanMealTime.Start.Split(":")[0]), Convert.ToInt32(meal.PlanMealTime.Start.Split(":")[1]), 0),
                    End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        Convert.ToInt32(meal.PlanMealTime.End.Split(":")[0]), Convert.ToInt32(meal.PlanMealTime.End.Split(":")[1]), 0),
                };

                context.PlanMealTimes.Add(planMealTime);
                context.SaveChanges();
            }
        }

        private static void SetNaps(MvvMLoginRegister register, YodaClockDbContext context, Plan plan)
        {
            var naps = new List<Nap>();

            foreach (var nap in register.Plan.Naps)
            {
                var n = new Nap()
                {
                    PlanId = plan.Id,
                    Name = nap.Name,
                    Percentage = nap.Percentage
                };

                naps.Add(n);
            }

            context.Naps.AddRange(naps);
            context.SaveChanges();
        }

        private static void SetProducts(MvvMLoginRegister register, YodaClockDbContext context, Plan plan)
        {
            var products = new List<Product>();

            foreach (var product in register.Plan.Products)
            {
                var prod = new Product()
                {
                    PlanId = plan.Id,
                    Name = product.Name,
                    Carb = product.Carb,
                    Fat = product.Fat,
                    Protein = product.Protein
                };

                products.Add(prod);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void SetExercises(MvvMLoginRegister register, YodaClockDbContext context, Plan plan)
        {
            var exercises = new List<Exercise>();

            foreach (var exercise in register.Plan.Exercises)
            {
                var ex = new Exercise()
                {
                    Name = exercise.Name,
                    PlanId = plan.Id
                };

                exercises.Add(ex);
            }

            context.Exercises.AddRange(exercises);
            context.SaveChanges();
        }
    }
}
