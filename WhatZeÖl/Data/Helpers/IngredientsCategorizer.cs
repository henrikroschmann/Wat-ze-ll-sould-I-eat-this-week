using Data.Models;
using System.Collections.Generic;

namespace WhatZeÖl.Helpers
{
    public static class IngredientsCategorizer
    {
        /// <summary>
        /// Simple Ingredient cartegorizer. All ingredients will be valided in this method
        /// and mapped in the dictionary list to get the key (the category)
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public static IngredientCategory CategorizeIngredients(string ingredient)
        {
            var categorizer = new Dictionary<IngredientCategory, List<string>> {
                { IngredientCategory.Bönor, new List<string> {"Kidneybönor, Kikärtor"}},
                { IngredientCategory.Bröd, new List<string> { "Pizzadeg, Minitortillas, Stenugnsbakad baguette, Tortillabröd" } },
                { IngredientCategory.Grönsaker, new List<string> { "Rödbeta, Champinjoner, Rucola, Röd paprika, Gul paprika, Grönsaksbuljong, Koriander, Lime, Krossade tomater, vitlök &amp; lök, Tomat, Tomat, Grön, Rödlök, Potatis, Morot, Citron, Bladpersilja, Schalottenlök, Timjan, Vitlöksklyfta, Salladsmix, Palsternacka, Spenat, Gräslök, Lök, Pak choi, Chili, Ingefära, Aubergine, Basilika, Kruspersilja, Oregano, Gurka, Zucchini, Blomkål, Mango, Mynta &amp; koriander, Gemsallad, Strimlad salladsmix, Jalapeno, Salladslök, Sötpotatis" } },
                { IngredientCategory.KöttochFisk, new List<string> { "Laxfilé, Strimlad kycklinglårfilé, Korv, gris/nötkött, Köttbuljong, Nötfärs, Kycklingbröstfilé, BBQ marinerat, Kummelfilé, Kycklinginnerfilé, Fläskkotlett hel, Kycklingbröstfilé" } },
                { IngredientCategory.Mejeri, new List<string> { "Crème fraiche, Pesto, grön, Grekisk salladsost, Gräddfil, Majonnäs, Aioli, Matlagningsgrädde, Mjölk*, Smör*, Riven hårdost, Halloumi, Ägg*, Kokosmjölk, Ricotta"  } },
                { IngredientCategory.Torrvaror, new List<string> { "Panamat, Salt*, Panko ströbröd, Sojasås, Honung, Jordnötter, Olivolja*, Tomatpuré, Worcestershiresås, Fullkornsnudlar, Hoisinsås, Tomatsås, Tagliatelle, Solrosfrön, Pärlcouscous, Basmatiris, Socker*, Balsamvinäger, Tikka masala, Vetemjöl*, Hello Mexico kryddmix, Nudlar, Linser, Cashewnötter, Ravioli med ricotta och spenat" } }
            };
            var result = IngredientCategory.NoCategoryFound;

            foreach (var item in categorizer)
            {
                if (item.Value[0].Contains(ingredient))
                {
                    result = item.Key;
                    break;
                }
            }

            return result;
        }
    }
}