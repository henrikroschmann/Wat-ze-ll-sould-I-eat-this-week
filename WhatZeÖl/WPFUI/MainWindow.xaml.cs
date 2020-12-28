using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WhatZeÖl.Models;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker fetchDetailsOnRecepies = new BackgroundWorker();
        private CookBook cookBook = new CookBook();
        private CookBook selectedRecepies = new CookBook();

        public MainWindow()
        {
            InitializeComponent();

            // Button for handling recipe parsing
            ParseRecipies.ToolTip = "Parse recipes from HelloFresh";
            ParseRecipies.Content = "Click to Parse List from Hello fresh";

            // Button for generationg shoppinglist
            GenerateShoppingList.ToolTip = "Generate a shopping list based on the selected items";
            GenerateShoppingList.Content = "Click to generate the shopping list based on selected items";
            //GenerateShoppingList.IsEnabled = false;
        }

        private async void ParseRecipies_ClickAsync(object sender, RoutedEventArgs e)
        {
            var scraper = new WhatZeÖl.Http.Scraper()
            {
                Site = "/recipes/mest-populär-recept?page=1"
            };

            cookBook = await scraper.ScrapeWebSite();
            recepiesThisWeek.ItemsSource = cookBook.Recipes;
            fetchDetailsOnRecepies.DoWork += new DoWorkEventHandler(this.fetchDetailsOnRecepies_DoWorkAsync);

            // Start the background worker to fetch details and ingredients on each recipe.
            fetchDetailsOnRecepies.RunWorkerAsync();
            ParseRecipies.IsEnabled = false;
            GenerateShoppingList.IsEnabled = true;
            AppInstructions.Visibility = Visibility.Hidden;
        }

        private async void fetchDetailsOnRecepies_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            var details = new WhatZeÖl.Http.Scraper();
            await details.ScrapeWebSiteForDetails(cookBook);
        }

        private void RecipieDetails_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                var tb = (TextBlock)e.OriginalSource;
                var dataCon = tb.DataContext;
                var recepieWindow = new WhatZeÖl.Views.DetailedRecepie((Recipe)dataCon);
                recepieWindow.Show();
            }
        }

        private void GenerateShoppingList_Click(object sender, RoutedEventArgs e)
        {
            var shoppingList = new WPFUI.Views.ShoppingList(selectedRecepies);
            shoppingList.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)e.OriginalSource;
            var dataContext = cb.DataContext;
            selectedRecepies.Recipes.Add((Recipe)dataContext);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)e.OriginalSource;
            var dataContext = cb.DataContext;
            selectedRecepies.Recipes.Remove((Recipe)dataContext);
        }
    }
}