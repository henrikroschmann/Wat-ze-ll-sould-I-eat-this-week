using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatZeÖl.Helpers
{
    class IngredientsCategorizer
    {
        public void CategorizeIngredients()
        {
            var inCategory = new Hashtable()
            {
                {"Bönor", "Kidneybönor, Kikärtor" },
                {"Bröd","Pizzadeg, Minitortillas, Stenugnsbakad baguette, Tortillabröd" },
                {"Grönsaker", "Rödbeta, Champinjoner, Rucola, Röd paprika, Gul paprika, Grönsaksbuljong, Koriander, Lime, Krossade tomater, vitlök &amp; lök, Tomat, Tomat, Grön, Rödlök, Potatis, Morot, Citron, Bladpersilja, Schalottenlök, Timjan, Vitlöksklyfta, Salladsmix, Palsternacka, Spenat, Gräslök, Lök, Pak choi, Chili, Ingefära, Aubergine, Basilika, Kruspersilja, Oregano, Gurka, Zucchini, Blomkål, Mango, Mynta &amp; koriander, Gemsallad, Strimlad salladsmix, Jalapeno, Salladslök, Sötpotatis" },
                {"Kött & Fisk", "Laxfilé, Strimlad kycklinglårfilé, Korv, gris/nötkött, Köttbuljong, Nötfärs, Kycklingbröstfilé, BBQ marinerat, Kummelfilé, Kycklinginnerfilé, Fläskkotlett hel, Kycklingbröstfilé" },
                {"Mejeri", "Crème fraiche, Pesto, grön, Grekisk salladsost, Gräddfil, Majonnäs, Aioli, Matlagningsgrädde, Mjölk*, Smör*, Riven hårdost, Halloumi, Ägg*, Kokosmjölk, Ricotta"},
                {"Torrvara", "Panamat, Salt*, Panko ströbröd, Sojasås, Honung, Jordnötter, Olivolja*, Tomatpuré, Worcestershiresås, Fullkornsnudlar, Hoisinsås, Tomatsås, Tagliatelle, Solrosfrön, Pärlcouscous, Basmatiris, Socker*, Balsamvinäger, Tikka masala, Vetemjöl*, Hello Mexico kryddmix, Nudlar, Linser, Cashewnötter, Ravioli med ricotta och spenat" }
            };
        }
    }
}
