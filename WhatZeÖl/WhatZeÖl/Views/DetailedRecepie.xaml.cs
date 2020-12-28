using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WhatZeÖl.Views
{
    /// <summary>
    /// Interaction logic for DetailedRecepie.xaml
    /// </summary>
    public partial class DetailedRecepie : Window
    {
        public Models.Recipe recipe { get; set; } = new Models.Recipe();

        public DetailedRecepie(Models.Recipe _recipe)
        {
            InitializeComponent();
            this.recipe = _recipe;
            title.Content = this.recipe.Name;
            shortDescription.Content = this.recipe.ShortDescription;
            ingredients.ItemsSource = this.recipe.Ingredient;
            steps.ItemsSource = this.recipe.Instructions;

            //
            var image = new BitmapImage();
            int BytesToRead = 100;

            WebRequest request = WebRequest.Create(new Uri(this.recipe.Image, UriKind.Absolute));
            request.Timeout = -1;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            BinaryReader reader = new BinaryReader(responseStream);
            MemoryStream memoryStream = new MemoryStream();

            byte[] bytebuffer = new byte[BytesToRead];
            int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

            while (bytesRead > 0)
            {
                memoryStream.Write(bytebuffer, 0, bytesRead);
                bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
            }

            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);

            image.StreamSource = memoryStream;
            image.EndInit();

            Re_image.Source = image;
        }

        private void ingredients_SelectionChanged(object sender, MouseButtonEventArgs e)
        {

        }
    }
}