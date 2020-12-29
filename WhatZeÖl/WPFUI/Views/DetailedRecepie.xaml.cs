using System.Windows;

namespace WhatZeÖl.Views
{
    /// <summary>
    /// Interaction logic for DetailedRecepie.xaml
    /// </summary>
    public partial class DetailedRecepie : Window
    {
        public Models.Recipe recipe { get; set; } = new Models.Recipe();

        /// <summary>
        /// Data source to Binding mapping.
        /// </summary>
        /// <param name="_recipe"></param>
        public DetailedRecepie(Models.Recipe _recipe)
        {
            InitializeComponent();

            this.recipe = _recipe;
            Title.Text = this.recipe.Name;
            ShortDescription.Text = this.recipe.ShortDescription;
            rc_Image.Source = this.recipe.Image;
            Ingredients.ItemsSource = this.recipe.Ingredient;
            Instructions.ItemsSource = this.recipe.Instructions;
        }
        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}