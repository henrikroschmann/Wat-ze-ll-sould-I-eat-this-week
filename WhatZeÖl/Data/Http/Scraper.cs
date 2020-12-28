using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WhatZeÖl.Models;

namespace WhatZeÖl.Http
{
    public class Scraper
    {
        private readonly CookBook cookBook = new CookBook();
        public string BaseURl { get { return "https://www.hellofresh.se"; } }
        public string Site { get; set; }

        /// <summary>
        /// WebSite scraper design to extract information from hellofresh recipe homepage
        /// To reduce risk of error 500 becuase of multiple scrapes a file is created and read from
        /// on first get.
        /// </summary>
        public async Task<CookBook> ScrapeWebSite()
        {
            string html = string.Empty;
            // check if file exist and use that.
            if (File.Exists("./recepie.txt"))
            {
                html = System.IO.File.ReadAllText("./recepie.txt");
            }
            else
            {
                var httpClient = new HttpClient();
                html = await httpClient.GetStringAsync(BaseURl + this.Site);
                File.WriteAllText("./recepie.txt", html);
            }

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Due to page scraping prevention the divs change name, I had to use a wild-card
            var RecepieDivs = htmlDocument.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("class", "")
            .Contains("dsav dsab dsaw")).ToList();

            foreach (var recipe in RecepieDivs)
            {
                Match m = Regex.Match(recipe.InnerHtml, "<img src=(.+?)\"");
                // if img-tag is found row is valid
                if (!string.IsNullOrEmpty(m.Value))
                {
                    // Populate the Recipe model with the result from the web scraper.
                    var _recipe = new Recipe
                    {
                        ImageString = Helpers.ParseText.Parser(m.Value, "<img src=\"", "\""),
                        Image = Helpers.ImageHelper.GetImage(Helpers.ParseText.Parser(m.Value, "<img src=\"", "\"")),
                        ArticleLink = BaseURl + Helpers.ParseText.Parser(Regex.Match(recipe.InnerHtml, "<a href=(.+?)\"").Value, "<a href=\"", "\""),
                        Name = Helpers.ParseText.Parser(Regex.Match(recipe.InnerHtml, "<h3(.+?)</h3>").Value, ">", "<"),
                        ShortDescription = Helpers.ParseText.Parser(Regex.Match(recipe.InnerHtml, "<p(.+?)</p>").Value, ">", "<")
                    };

                    try
                    {
                        // remove invalid entry
                        if (_recipe.Name != "<p>Våra populäraste recept</p>")
                            cookBook.Recipes.Add(_recipe);
                    }
                    catch (System.Exception)
                    {
                        // TODO: Add error handler
                        throw;
                    }
                }
            }

            return cookBook;
        }

        public async Task<CookBook> ScrapeWebSiteForDetails(CookBook cookBook)
        {
            var i_name = new List<string>();
            foreach (var recipe in cookBook.Recipes)
            {
                string html = string.Empty;

                // check if file exist and use that.
                if (File.Exists($"{recipe.Name}.txt"))
                {
                    html = File.ReadAllText($"./{recipe.Name}.txt");
                }
                else
                {
                    var httpClient = new HttpClient();
                    html = await httpClient.GetStringAsync(recipe.ArticleLink);
                    File.WriteAllText($"./{ recipe.Name}.txt", html);
                }
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                #region Ingredients

                // Due to page scraping prevention the divs change name, I had to use a wild-card
                var IngredientsDivs = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("data-test-id", "")
                .Contains("recipeDetailFragment.ingredients")).ToList();

                var ingreds = new HtmlDocument();
                ingreds.LoadHtml(IngredientsDivs[0].InnerHtml);
                var ingredients = ingreds.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("dsf dsg dsh")).ToList();

                foreach (var ingredient in ingredients)
                {
                    try
                    {
                        var parser = new HtmlDocument();
                        parser.LoadHtml(ingredient.InnerHtml);
                        var _ingredient = parser.DocumentNode.Descendants("p")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Contains("dsa")).ToList();

                        recipe.Ingredient.Add(new Ingredient
                        {
                            Amount = _ingredient[0].InnerText,
                            Name = _ingredient[1].InnerText,
                            Category = Helpers.IngredientsCategorizer.CategorizeIngredients(_ingredient[1].InnerText)
                        });
                        i_name.Add(_ingredient[1].InnerText);
                    }
                    catch (System.Exception)
                    {
                    }
                }

                #endregion Ingredients

                #region Descriptions

                var description = htmlDocument.DocumentNode.Descendants("span")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("dsa dsb")).ToList();
                recipe.Description = description[0].InnerText;

                #endregion Descriptions

                #region Instructions

                var steps = htmlDocument.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("data-test-id", "")
                    .Contains("recipeDetailFragment.instructions.step")).ToList();

                foreach (var step in steps.Where(node => node.InnerText.Length > 3))
                {
                    //add space to number and character
                    recipe.Instructions.Add(new Steps
                    {
                        Image = Helpers.ImageHelper.GetImage(Helpers.ParseText.Parser(step.InnerHtml, "<picture data-iesrc=\"", "\" data-alt=")),
                        Step = Helpers.ParseText.SpaceIt(step.InnerText)
                    });
                }

                #endregion Instructions
            }
            File.WriteAllLines($"./ingreds.txt", i_name.ToArray());
            return cookBook;
        }
    }
}