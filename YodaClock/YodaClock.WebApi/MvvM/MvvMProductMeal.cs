﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YodaClock.WebApi.MvvM
{
    public class MvvMProductMeal
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MealId { get; set; }
        public int Amount { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Timestamp { get; set; }
    }
}
