﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Mini.AnimalCrossingIOService.DataHandling
{

    public class VillagerResponse
    {
        public int id { get; set; }
        public string filename { get; set; }
        public Name name { get; set; }
        public string personality { get; set; }
        public string birthdaystring { get; set; }
        public string birthday { get; set; }
        public string species { get; set; }
        public string gender { get; set; }
        public string subtype { get; set; }
        public string hobby { get; set; }
        public string catchphrase { get; set; }
        public string icon_uri { get; set; }
        public string image_uri { get; set; }
        public string bubblecolor { get; set; }
        public string textcolor { get; set; }
        public string saying { get; set; }
        public CatchTranslations catchtranslations { get; set; }
    }

    public class Name
    {
        public string nameUSen { get; set; }
        public string nameEUen { get; set; }
        public string nameEUde { get; set; }
        public string nameEUes { get; set; }
        public string nameUSes { get; set; }
        public string nameEUfr { get; set; }
        public string nameUSfr { get; set; }
        public string nameEUit { get; set; }
        public string nameEUnl { get; set; }
        public string nameCNzh { get; set; }
        public string nameTWzh { get; set; }
        public string nameJPja { get; set; }
        public string nameKRko { get; set; }
        public string nameEUru { get; set; }
    }

    public class CatchTranslations
    {
        public string catchUSen { get; set; }
        public string catchEUen { get; set; }
        public string catchEUde { get; set; }
        public string catchEUes { get; set; }
        public string catchUSes { get; set; }
        public string catchEUfr { get; set; }
        public string catchUSfr { get; set; }
        public string catchEUit { get; set; }
        public string catchEUnl { get; set; }
        public string catchCNzh { get; set; }
        public string catchTWzh { get; set; }
        public string catchJPja { get; set; }
        public string catchKRko { get; set; }
        public string catchEUru { get; set; }
    }

}
