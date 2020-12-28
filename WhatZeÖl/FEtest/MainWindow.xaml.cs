using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using WhatZeÖl.Helpers;
using WhatZeÖl.Models;

namespace FEtest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker fetchDetailsOnRecepies = new BackgroundWorker();
        private CookBook cookBook = new CookBook();
        public MainWindow()
        {
            InitializeComponent();
            fetchDetailsOnRecepies.DoWork += new DoWorkEventHandler(this.fetchDetailsOnRecepies_DoWork);
            CardContent.Visibility = Visibility.Hidden;
        }

        private async void Inspiration_ClickAsync(object sender, RoutedEventArgs e)
        {
            Inspiration.Visibility = Visibility.Hidden;

            var scraper = new WhatZeÖl.Http.Scraper()
            {
                Site = "/recipes/mest-populär-recept?page=1"
            };

            cookBook = await scraper.ScrapeWebSite();

            //lvRecepies.ItemsSource = cookBook.Recipes;
            int i = 1;
            //cookBook.Recipes.ForEach(node =>
            //{
            //    card1_titel.Text = node.Name;
            //    card1_img.Source = ImageHelper.GetImage(node.Image);
            //    card1_short.Text = node.ShortDescription;
            //});


            fetchDetailsOnRecepies.DoWork += new DoWorkEventHandler(this.fetchDetailsOnRecepies_DoWork);
            // Start the backgroundworker to fetch details and ingredients on each recepie.
            fetchDetailsOnRecepies.RunWorkerAsync();

            CardContent.Visibility = Visibility.Visible;

            StackPanel stackPanel = new StackPanel();
            MaterialDesignThemes.Wpf.Card card = new MaterialDesignThemes.Wpf.Card();
            StringBuilder sb = new StringBuilder();

            //Create card
            sb.Append(@"<materialDesign:Card xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' xmlns:materialDesign='http://materialdesigninxaml.net/winfx/xaml/themes' Background='#03a9f4' Foreground = '{DynamicResource PrimaryHueDarkForegroundBrush}' Padding = '0' Width = '200'> ");
            sb.Append(@"<Grid><Grid.RowDefinitions><RowDefinition Height='Auto' /><RowDefinition Height = 'Auto' /><RowDefinition Height = 'Auto' /></Grid.RowDefinitions> ");
            sb.Append(@"<TextBlock Grid.Row='0' Margin = '16 16 16 4' Style = '{StaticResource MaterialDesignHeadline4TextBlock}'>r"+$" {"testset"}"+"</TextBlock><Separator Grid.Row = '1' Style = '{StaticResource MaterialDesignLightSeparator}' /><TextBlock Grid.Row = '2' Margin = '16 0 16 8' VerticalAlignment = 'Center' HorizontalAlignment = 'Left' Style = '{StaticResource MaterialDesignBody2TextBlock}'> March 19, 2016 </TextBlock>");
            sb.Append(@"</Grid></materialDesign:Card>");

            card = (MaterialDesignThemes.Wpf.Card)XamlReader.Parse(sb.ToString().Replace("<?xml version=\"1.0\" encoding=\"UTF - 8\"?>", ""));
            // Add created button to previously created container.
            stackPanel.Children.Add(card);
            this.Content = stackPanel ;
        }

        private void fetchDetailsOnRecepies_DoWork(object sender, DoWorkEventArgs e)
        {
            var details = new WhatZeÖl.Http.Scraper();
            details.ScrapeWebSiteForDetails(cookBook);
        }
    }
}