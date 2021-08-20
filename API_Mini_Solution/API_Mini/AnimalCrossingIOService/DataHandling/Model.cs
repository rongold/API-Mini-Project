using System;
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

	public class FishResponse
	{
		public int id { get; set; }
		public string filename { get; set; }
		public Name name { get; set; }
		public Availability availability { get; set; }
		public string shadow { get; set; }
		public int price { get; set; }
		public int pricecj { get; set; }
		public string catchphrase { get; set; }
		public string museumphrase { get; set; }
		public string image_uri { get; set; }
		public string icon_uri { get; set; }
	}

	public class Availability
	{
		public string monthnorthern { get; set; }
		public string monthsouthern { get; set; }
		public string time { get; set; }
		public bool isAllDay { get; set; }
		public bool isAllYear { get; set; }
		public string location { get; set; }
		public string rarity { get; set; }
		public int[] montharraynorthern { get; set; }
		public int[] montharraysouthern { get; set; }
		public int[] timearray { get; set; }
	}


	public class SeaCreaturesResponse
	{
		public int id { get; set; }
		public string filename { get; set; }
		public Name name { get; set; }
		public SeaCreatureAvailability availability { get; set; }
		public string speed { get; set; }
		public string shadow { get; set; }
		public int price { get; set; }
		public string catchphrase { get; set; }
		public string image_uri { get; set; }
		public string icon_uri { get; set; }
		public string museumphrase { get; set; }
	}

	public class SeaCreatureAvailability
	{
		public string monthnorthern { get; set; }
		public string monthsouthern { get; set; }
		public string time { get; set; }
		public bool isAllDay { get; set; }
		public bool isAllYear { get; set; }
		public int[] montharraynorthern { get; set; }
		public int[] montharraysouthern { get; set; }
		public int[] timearray { get; set; }
	}

	public class BugsResponse
	{
		public int id { get; set; }
		public string filename { get; set; }
		public Name name { get; set; }
		public Availability availability { get; set; }
		public int price { get; set; }
		public int priceflick { get; set; }
		public string catchphrase { get; set; }
		public string museumphrase { get; set; }
		public string image_uri { get; set; }
		public string icon_uri { get; set; }
	}


}
