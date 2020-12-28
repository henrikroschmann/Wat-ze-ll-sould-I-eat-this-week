﻿using System.Collections.Generic;
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

            List<Ingredient> test = new List<Ingredient>();

            foreach (var item in selectedRecepies.Recipes)
            {
                test = test.Union(item.Ingredient).ToList();
            }

            List<User> items = new List<User>();
            items.Add(new User() { Name = "John Doe", Age = 42, Sex = SexType.Male });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Sex = SexType.Female });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = SexType.Male });
            lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            view.GroupDescriptions.Add(groupDescription);
        }
    }

    public enum SexType { Male, Female };

    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }

        public SexType Sex { get; set; }
    }
}