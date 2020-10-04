using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMMealExercise
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public int MealId { get; set; }
        public int ExerciseId { get; set; }
        public bool Ate { get; set; }
        public int Time { get; set; }
        public string Timestamp { get; set; }
    }
}
