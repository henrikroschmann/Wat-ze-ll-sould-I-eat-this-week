using Data.Models;

namespace WhatZeÖl.Models
{
    public class Ingredient
    {
        public string Name { get; set; } = string.Empty;
        public IngredientCategory Category { get; set; }
        public string Amount { get; set; } = string.Empty;
    }
}