using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WhatZeÖl.Models;

namespace WhatZeÖl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private BackgroundWorker fetchDetailsOnRecepies = new BackgroundWorker();
        private CookBook cookBook = new CookBook();

        public MainWindow()
        {
            InitializeComponent();
            // register the background worker
            fetchDetailsOnRecepies.DoWork += new DoWorkEventHandler(this.fetchDetailsOnRecepies_DoWork);
            btShoppingCart.IsEnabled = false;
        }

        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            // Launch the GitHub site...
        }

        private void DeployCupCakes(object sender, RoutedEventArgs e)
        {
            // deploy some CupCakes...
        }

        /// <summary>
        /// Button will fetch the data from the Scraper class
        /// Once sufficient data is present the list will be populated
        /// and a background task will start to fetch the remaining data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            GenerateContentGrid();

            //var scraper = new Http.Scraper()
            //{
            //    Site = "/recipes/mest-populär-recept?page=1"
            //};

            //cookBook = await scraper.ScrapeWebSite();
            //lvRecepies.ItemsSource = cookBook.Recipes;
            //fetchDetailsOnRecepies.DoWork += new DoWorkEventHandler(this.fetchDetailsOnRecepies_DoWork);
            //// Start the backgroundworker to fetch details and ingredients on each recepie.
            //fetchDetailsOnRecepies.RunWorkerAsync();
            //btnParseList.IsEnabled = false;
            //btShoppingCart.IsEnabled = true;
        }

        private void btShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            var a = lvRecepies.SelectedItems;
            System.Console.WriteLine();
        }

        private void fetchDetailsOnRecepies_DoWork(object sender, DoWorkEventArgs e)
        {
            var details = new Http.Scraper();
            details.ScrapeWebSiteForDetails(cookBook);
        }

        private void lvRecepies_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            var recepieWindow = new Views.DetailedRecepie((Recipe)lvRecepies.SelectedItem);
            recepieWindow.Show();
            System.Console.WriteLine();
        }


        public void GenerateContentGrid()
        {
            Recipe.ShowGridLines = true;
            

            // Create Columns

            ColumnDefinition gridCol1 = new ColumnDefinition();
            Recipe.ColumnDefinitions.Add(gridCol1);

            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(45);
            Recipe.RowDefinitions.Add(gridRow1);

            Label test = new Label();
            test.Content = "hej hej";
            test.Foreground = new SolidColorBrush(Colors.Green);

            Grid.SetRow(test, 0);
            Grid.SetColumn(test, 0);
        }

        private void CreateDynamicWPFGrid()

        {

            // Create the Grid


            banana.Width = 400;

            banana.HorizontalAlignment = HorizontalAlignment.Left;

            banana.VerticalAlignment = VerticalAlignment.Top;

            banana.ShowGridLines = true;

            banana.Background = new SolidColorBrush(Colors.LightSteelBlue);



            // Create Columns

            ColumnDefinition gridCol1 = new ColumnDefinition();

            ColumnDefinition gridCol2 = new ColumnDefinition();

            ColumnDefinition gridCol3 = new ColumnDefinition();

            banana.ColumnDefinitions.Add(gridCol1);

            banana.ColumnDefinitions.Add(gridCol2);

            banana.ColumnDefinitions.Add(gridCol3);



            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();

            gridRow1.Height = new GridLength(45);

            RowDefinition gridRow2 = new RowDefinition();

            gridRow2.Height = new GridLength(45);

            RowDefinition gridRow3 = new RowDefinition();

            gridRow3.Height = new GridLength(45);

            banana.RowDefinitions.Add(gridRow1);

            banana.RowDefinitions.Add(gridRow2);

            banana.RowDefinitions.Add(gridRow3);



            // Add first column header

            TextBlock txtBlock1 = new TextBlock();

            txtBlock1.Text = "Author Name";

            txtBlock1.FontSize = 14;

            txtBlock1.FontWeight = FontWeights.Bold;

            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock1.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock1, 0);

            Grid.SetColumn(txtBlock1, 0);



            // Add second column header

            TextBlock txtBlock2 = new TextBlock();

            txtBlock2.Text = "Age";

            txtBlock2.FontSize = 14;

            txtBlock2.FontWeight = FontWeights.Bold;

            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 0);

            Grid.SetColumn(txtBlock2, 1);



            // Add third column header

            TextBlock txtBlock3 = new TextBlock();

            txtBlock3.Text = "Book";

            txtBlock3.FontSize = 14;

            txtBlock3.FontWeight = FontWeights.Bold;

            txtBlock3.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock3.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock3, 0);

            Grid.SetColumn(txtBlock3, 2);



            //// Add column headers to the Grid

            banana.Children.Add(txtBlock1);

            banana.Children.Add(txtBlock2);

            banana.Children.Add(txtBlock3);



            // Create first Row

            TextBlock authorText = new TextBlock();

            authorText.Text = "Mahesh Chand";

            authorText.FontSize = 12;

            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 1);

            Grid.SetColumn(authorText, 0);



            TextBlock ageText = new TextBlock();

            ageText.Text = "33";

            ageText.FontSize = 12;

            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 1);

            Grid.SetColumn(ageText, 1);



            TextBlock bookText = new TextBlock();

            bookText.Text = "GDI+ Programming";

            bookText.FontSize = 12;

            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 1);

            Grid.SetColumn(bookText, 2);

            // Add first row to Grid

            banana.Children.Add(authorText);

            banana.Children.Add(ageText);

            banana.Children.Add(bookText);



            // Create second row

            authorText = new TextBlock();

            authorText.Text = "Mike Gold";

            authorText.FontSize = 12;

            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 2);

            Grid.SetColumn(authorText, 0);



            ageText = new TextBlock();

            ageText.Text = "35";

            ageText.FontSize = 12;

            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 2);

            Grid.SetColumn(ageText, 1);



            bookText = new TextBlock();

            bookText.Text = "Programming C#";

            bookText.FontSize = 12;

            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 2);

            Grid.SetColumn(bookText, 2);



            // Add second row to Grid

            banana.Children.Add(authorText);

            banana.Children.Add(ageText);

            banana.Children.Add(bookText);



            // Display grid into a Window

            //test.Content = banana;


        }
    }
}