using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMProductMeal
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 100)
        public decimal Carb { get; set; } // Carb
        public decimal Fat { get; set; } // Fat
        public decimal Protein { get; set; } // Protein
    }
}
