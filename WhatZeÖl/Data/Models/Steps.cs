using System.Windows.Media;

namespace WhatZeÖl.Models
{
    public class Steps
    {
        public string Step { get; set; } = string.Empty;
        public ImageSource Image { get; set; }

        public string StepWithoutNumber {
            get {
                return Step.Remove(0, 2);
            }
        }
    }
}