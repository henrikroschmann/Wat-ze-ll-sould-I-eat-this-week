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
        /// <summary>
        /// Parse the selected menu list and display shopping list categorized.
        /// </summary>
        /// <param name="selectedRecepies"></param>
        public ShoppingList(WhatZeÖl.Models.CookBook selectedRecepies)
        {
            InitializeComponent();

<<<<<<< HEAD
            List<Ingredient> IngredientList = new List<Ingredient>();

            foreach (var item in selectedRecepies.Recipes)
            {
                IngredientList = IngredientList.Union(item.Ingredient).ToList();
            }

            lvUsers.ItemsSource = IngredientList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
=======
            List<Ingredient> Ingredients = new List<Ingredient>();

            foreach (var item in selectedRecepies.Recipes)
            {
                Ingredients = Ingredients.Union(item.Ingredient).ToList();
            }

            lvIngredients.ItemsSource = Ingredients;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvIngredients.ItemsSource);
>>>>>>> main
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Category");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
<<<<<<< HEAD

=======
>>>>>>> main
}