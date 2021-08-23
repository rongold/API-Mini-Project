using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Mini.AnimalCrossingIOService.DataHandling
{

	public class VillagerResponse : IResponse
	{
		public int id { get; set; }
		[JsonProperty("file-name")]
		public string filename { get; set; }
		public Name name { get; set; }
		public string personality { get; set; }
		[JsonProperty("birthday-string")]
		public string birthdaystring { get; set; }
		public string birthday { get; set; }
		public string species { get; set; }
		public string gender { get; set; }
		public string subtype { get; set; }
		public string hobby { get; set; }
		[JsonProperty("catch-phrase")]
		public string catchphrase { get; set; }
		public string icon_uri { get; set; }
		public string image_uri { get; set; }
		[JsonProperty("bubble-color")]
		public string bubblecolor { get; set; }
		[JsonProperty("text-color")]
		public string textcolor { get; set; }
		public string saying { get; set; }
		[JsonProperty("catch-translations")]
		public CatchTranslations catchtranslations { get; set; }
	}

	public class Name
	{
		[JsonProperty("name-USen")]
		public string nameUSen { get; set; }
		[JsonProperty("name-EUen")]
		public string nameEUen { get; set; }
		[JsonProperty("name-EUde")]
		public string nameEUde { get; set; }
		[JsonProperty("name-EUes")]
		public string nameEUes { get; set; }
		[JsonProperty("name-USes")]
		public string nameUSes { get; set; }
		[JsonProperty("name-EUfr")]
		public string nameEUfr { get; set; }
		[JsonProperty("name-USfr")]
		public string nameUSfr { get; set; }
		[JsonProperty("name-EUit")]
		public string nameEUit { get; set; }
		[JsonProperty("name-EUnl")]
		public string nameEUnl { get; set; }
		[JsonProperty("name-CNzh")]
		public string nameCNzh { get; set; }
		[JsonProperty("name-TWzh")]
		public string nameTWzh { get; set; }
		[JsonProperty("name-JPja")]
		public string nameJPja { get; set; }
		[JsonProperty("name-KRko")]
		public string nameKRko { get; set; }
		[JsonProperty("name-EUru")]
		public string nameEUru { get; set; }
	}

	public class CatchTranslations
	{
		[JsonProperty("catch-USen")]
		public string catchUSen { get; set; }
		[JsonProperty("catch-EUen")]
		public string catchEUen { get; set; }
		[JsonProperty("catch-EUde")]
		public string catchEUde { get; set; }
		[JsonProperty("catch-EUes")]
		public string catchEUes { get; set; }
		[JsonProperty("catch-USes")]
		public string catchUSes { get; set; }
		[JsonProperty("catch-EUfr")]
		public string catchEUfr { get; set; }
		[JsonProperty("catch-USfr")]
		public string catchUSfr { get; set; }
		[JsonProperty("catch-EUit")]
		public string catchEUit { get; set; }
		[JsonProperty("catch-EUnl")]
		public string catchEUnl { get; set; }
		[JsonProperty("catch-CNzh")]
		public string catchCNzh { get; set; }
		[JsonProperty("catch-TWzh")]
		public string catchTWzh { get; set; }
		[JsonProperty("catch-JPja")]
		public string catchJPja { get; set; }
		[JsonProperty("catch-KRko")]
		public string catchKRko { get; set; }
		[JsonProperty("catch-EUru")]
		public string catchEUru { get; set; }
	}

	public class FishResponse : IResponse
	{
		public int id { get; set; }
		[JsonProperty("file-name")]
		public string filename { get; set; }
		public Name name { get; set; }
		public Availability availability { get; set; }
		public string shadow { get; set; }
		public int price { get; set; }
		[JsonProperty("price-cj")]
		public int pricecj { get; set; }
		[JsonProperty("catch-phrase")]
		public string catchphrase { get; set; }
		[JsonProperty("museum-phrase")]
		public string museumphrase { get; set; }
		public string image_uri { get; set; }
		public string icon_uri { get; set; }
	}

	public class Availability
	{
		[JsonProperty("month-northern")]
		public string monthnorthern { get; set; }
		[JsonProperty("month-southern")]
		public string monthsouthern { get; set; }
		public string time { get; set; }
		public bool isAllDay { get; set; }
		public bool isAllYear { get; set; }
		public string location { get; set; }
		public string rarity { get; set; }
		[JsonProperty("month-array-northern")]
		public int[] montharraynorthern { get; set; }
		[JsonProperty("month-array-southern")]
		public int[] montharraysouthern { get; set; }
		[JsonProperty("time-array")]
		public int[] timearray { get; set; }
	}


	public class SeaCreaturesResponse : IResponse
	{
		public int id { get; set; }
		[JsonProperty("file-name")]
		public string filename { get; set; }
		public Name name { get; set; }
		public SeaCreatureAvailability availability { get; set; }
		public string speed { get; set; }
		public string shadow { get; set; }
		public int price { get; set; }
		[JsonProperty("catch-phrase")]
		public string catchphrase { get; set; }
		public string image_uri { get; set; }
		public string icon_uri { get; set; }
		[JsonProperty("museum-phrase")]
		public string museumphrase { get; set; }
	}

	public class SeaCreatureAvailability
	{
		[JsonProperty("month-northern")]
		public string monthnorthern { get; set; }
		[JsonProperty("month-southern")]
		public string monthsouthern { get; set; }
		public string time { get; set; }
		public bool isAllDay { get; set; }
		public bool isAllYear { get; set; }
		[JsonProperty("month-array-northern")]
		public int[] montharraynorthern { get; set; }
		[JsonProperty("month-array-southern")]
		public int[] montharraysouthern { get; set; }
		[JsonProperty("time-array")]
		public int[] timearray { get; set; }
	}

	public class BugsResponse : IResponse
	{
		public int id { get; set; }
		[JsonProperty("file-name")]
		public string filename { get; set; }
		public Name name { get; set; }
		public Availability availability { get; set; }
		public int price { get; set; }
		[JsonProperty("price-flick")]
		public int priceflick { get; set; }
		[JsonProperty("catch-phrase")]
		public string catchphrase { get; set; }
		[JsonProperty("museum-phrase")]
		public string museumphrase { get; set; }
		public string image_uri { get; set; }
		public string icon_uri { get; set; }
	}


	public class FossilsResponse : IResponse
	{
		public string filename { get; set; }
		public Name name { get; set; }
		public int price { get; set; }
		[JsonProperty("museum-phrase")]
		public string museumphrase { get; set; }
		public string image_uri { get; set; }
		[JsonProperty("part-of")]
		public string partof { get; set; }
	}

}
