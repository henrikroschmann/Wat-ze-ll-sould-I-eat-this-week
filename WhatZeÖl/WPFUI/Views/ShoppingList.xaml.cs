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

            List<Ingredient> IngredientList = new List<Ingredient>();

            foreach (var item in selectedRecepies.Recipes)
            {
                IngredientList = IngredientList.Union(item.Ingredient).ToList();
            }

            lvUsers.ItemsSource = IngredientList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Category");
            view.GroupDescriptions.Add(groupDescription);
        }
    }

}