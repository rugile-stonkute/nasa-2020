using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMPlan
    {
        public string Name { get; set; }
        public decimal ExercisePercentage { get; set; }
        public int ExcerciseTime { get; set; }
        public decimal Carb { get; set; }
        public decimal Fat { get; set; }
        public decimal Protein { get; set; }
        public MvvMEnvironment Environment { get; set; }
        public List<MvvMDbResponse> DbResponses { get; set; }
        public List<MvvMLuxResponse> LuxResponses { get; set; }
        public List<MvvMMeal> Meals { get; set; }
        public List<MvvMNap> Naps { get; set; }
        public List<MvvMProduct> Products { get; set; }
        public List<MvvMExercise> Exercises { get; set; }
    }
}
