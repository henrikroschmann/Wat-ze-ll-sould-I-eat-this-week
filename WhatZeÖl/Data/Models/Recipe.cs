using System.Collections.Generic;
using System.Windows.Media;

namespace WhatZeÖl.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string ImageString { get; set; }
        public ImageSource Image { get; set; }
        public string ShortDescription { get; set; }
        public List<Steps> Instructions { get; set; } = new List<Steps>();
        public string Description { get; set; } = string.Empty;
        public string ArticleLink { get; set; }
        public List<Ingredient> Ingredient { get; set; } = new List<Ingredient>();

        public override string ToString()
        {
            return this.Name + ", " + this.ShortDescription;
        }
    }
}