﻿using System;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;

namespace WhatZeÖl.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Helper method to transform url to bitmap ImageSource to display in WPF 
        /// based on https://stackoverflow.com/questions/3148163/wpf-image-urisource-and-data-binding-using-http-url
        /// forced to add image.Freeze to not encounter threading issues.
        /// </summary>
        /// <param name="imgSrc"></param>
        /// <returns></returns>
        public static BitmapImage GetImage(string imgSrc)
        {
            var image = new BitmapImage();
            int BytesToRead = 100;

            WebRequest request = WebRequest.Create(new Uri(imgSrc, UriKind.Absolute));
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
            image.Freeze();
            return image;
        }
    }
}