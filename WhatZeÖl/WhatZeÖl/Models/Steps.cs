namespace WhatZeÖl.Models
{
    public class Steps
    {
        public string Step { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public override string ToString()
        {
            return this.Step;
        }
    }
}