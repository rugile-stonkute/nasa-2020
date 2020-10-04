using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMNutrition
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProductId { get; set; } // ProductId
        public int MealId { get; set; } // MealId
        public int Amount { get; set; } // Amount
        public string Timestamp { get; set; } // Timestamp
    }

    public class MvvMNutritionRequest
    {
        public int Id { get; set; } // Id (Primary key)
        public int ProductId { get; set; } // ProductId
        public int MealId { get; set; } // MealId
        public int Amount { get; set; } // Amount
        public string Timestamp { get; set; } // Timestamp
    }
}
