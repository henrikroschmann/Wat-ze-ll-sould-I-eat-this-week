using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using WhatZeÖl.Models;

namespace WPFUI.Views
{
    /// <summary>
    /// Interaction logic for ShoppingList.xaml
    /// </summary>
    public partial class ShoppingList : Window
    {
        public ShoppingList(WhatZeÖl.Models.CookBook selectedRecepies)
        {
            InitializeComponent();

            List<Ingredient> Ingredients = new List<Ingredient>();

            foreach (var item in selectedRecepies.Recipes)
            {
                Ingredients = Ingredients.Union(item.Ingredient).ToList();
            }

            lvIngredients.ItemsSource = Ingredients;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvIngredients.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Category");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}