using System.Windows;

namespace WhatZeÖl.Views
{
    /// <summary>
    /// Interaction logic for DetailedRecepie.xaml
    /// </summary>
    public partial class DetailedRecepie : Window
    {
        public Models.Recipe Recipe { get; set; } = new Models.Recipe();

        public DetailedRecepie(Models.Recipe _recipe)
        {
            InitializeComponent();

            this.Recipe = _recipe;
            tbTitle.Text = this.Recipe.Name;
            ShortDescription.Text = this.Recipe.ShortDescription;
            rc_Image.Source = this.Recipe.Image;

            Ingredients.ItemsSource = this.Recipe.Ingredient;
            Instructions.ItemsSource = this.Recipe.Instructions;
        }
    }
}