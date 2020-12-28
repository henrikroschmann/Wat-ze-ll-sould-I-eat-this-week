namespace WhatZeÖl.Models
{
    public class Ingredient
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;

        public override string ToString()
        {
            return this.Amount + ", " + this.Name + ", " + (Category == string.Empty ? "!!No Category set click on row to set!!" : Category) ;
        }
    }
}