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
        }

        /// <summary>
        /// Show me the menu recipe button action calling the scraper in the helper category to
        /// fetch the data from Hello fresh. If the result is fetched once already the result
        /// will be read from files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ParseRecipies_ClickAsync(object sender, RoutedEventArgs e)
        {
            CardIntro.Visibility = Visibility.Hidden;
            var scraper = new WhatZeÖl.Http.Scraper()
            {
                Site = "/recipes/mest-populär-recept?page=1"
            };

            cookBook = await scraper.ScrapeWebSite();
            recepiesThisWeek.ItemsSource = cookBook.Recipes;
            fetchDetailsOnRecepies.DoWork += new DoWorkEventHandler(this.FetchDetailsOnRecepies_DoWorkAsync);

            // Start the background worker to fetch details and ingredients on each recipe.
            fetchDetailsOnRecepies.RunWorkerAsync();
            GenerateShoppingList.IsEnabled = true;
        }

        private async void FetchDetailsOnRecepies_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            var details = new WhatZeÖl.Http.Scraper();
            await details.ScrapeWebSiteForDetails(cookBook).ConfigureAwait(false);
        }

        /// <summary>
        /// Click event for shopping list button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateShoppingList_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecepies.Recipes.Count != 0)
            {
                var shoppingList = new WPFUI.Views.ShoppingList(selectedRecepies);
                shoppingList.Show();
            }
        }
        /// <summary>
        /// Checked event for check-box
        /// add item to selectedRecepies list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = (Button)e.OriginalSource;
            var dataContext = cb.DataContext;
            selectedRecepies.Recipes.Add((Recipe)dataContext);
            ShopplingListBadge.Badge = (int.Parse(ShopplingListBadge.Badge.ToString())+1).ToString();
        }
        /// <summary>
        /// Unchecked event for check-box,
        /// remove item from selectedRecepies list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var cb = (Button)e.OriginalSource;
            var dataContext = cb.DataContext;
            selectedRecepies.Recipes.Remove((Recipe)dataContext);
            if (ShopplingListBadge.Badge.ToString() != "0")
                ShopplingListBadge.Badge = (int.Parse(ShopplingListBadge.Badge.ToString()) - 1).ToString();
        }
        /// <summary>
        /// Button to start a new window with more detailed information of the recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LearnMore_Click(object sender, RoutedEventArgs e)
        {
            var tb = (Button)e.OriginalSource;
            var dataCon = tb.DataContext;
            var recepieWindow = new WhatZeÖl.Views.DetailedRecepie((Recipe)dataCon);
            recepieWindow.Show();
        }
    }
}