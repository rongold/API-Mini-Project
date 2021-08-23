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
		public int Id { get; set; }
		public string Filename { get; set; }
		public Name Name { get; set; }
		public string Personality { get; set; }
		[JsonProperty("Birthday-string")]
		public string Birthdaystring { get; set; }
		public string Birthday { get; set; }
		public string Species { get; set; }
		public string Gender { get; set; }
		public string Subtype { get; set; }
		public string Hobby { get; set; }
		[JsonProperty("Catch-phrase")]
		public string Catchphrase { get; set; }
		public string Icon_uri { get; set; }
		public string Image_uri { get; set; }
		[JsonProperty("Bubble-color")]
		public string Bubblecolor { get; set; }
		[JsonProperty("Text-color")]
		public string Textcolor { get; set; }
		public string Saying { get; set; }
		[JsonProperty("Catch-translations")]
		public CatchTranslations Catchtranslations { get; set; }
	}

	public class Name
	{
		[JsonProperty("Name-USen")]
		public string NameUSen { get; set; }
		[JsonProperty("Name-EUen")]
		public string NameEUen { get; set; }
		[JsonProperty("Name-EUde")]
		public string NameEUde { get; set; }
		[JsonProperty("Name-EUes")]
		public string NameEUes { get; set; }
		[JsonProperty("Name-USes")]
		public string NameUSes { get; set; }
		[JsonProperty("Name-EUfr")]
		public string NameEUfr { get; set; }
		[JsonProperty("Name-USfr")]
		public string NameUSfr { get; set; }
		[JsonProperty("Name-EUit")]
		public string NameEUit { get; set; }
		[JsonProperty("Name-EUnl")]
		public string NameEUnl { get; set; }
		[JsonProperty("Name-CNzh")]
		public string NameCNzh { get; set; }
		[JsonProperty("Name-TWzh")]
		public string NameTWzh { get; set; }
		[JsonProperty("Name-JPja")]
		public string NameJPja { get; set; }
		[JsonProperty("Name-KRko")]
		public string NameKRko { get; set; }
		[JsonProperty("Name-EUru")]
		public string NameEUru { get; set; }
	}

	public class CatchTranslations
	{
		[JsonProperty("Catch-USen")]
		public string CatchUSen { get; set; }
		[JsonProperty("Catch-EUen")]
		public string CatchEUen { get; set; }
		[JsonProperty("Catch-EUde")]
		public string CatchEUde { get; set; }
		[JsonProperty("Catch-EUes")]
		public string CatchEUes { get; set; }
		[JsonProperty("Catch-USes")]
		public string CatchUSes { get; set; }
		[JsonProperty("Catch-EUfr")]
		public string CatchEUfr { get; set; }
		[JsonProperty("Catch-USfr")]
		public string CatchUSfr { get; set; }
		[JsonProperty("Catch-EUit")]
		public string CatchEUit { get; set; }
		[JsonProperty("Catch-EUnl")]
		public string CatchEUnl { get; set; }
		[JsonProperty("Catch-CNzh")]
		public string CatchCNzh { get; set; }
		[JsonProperty("Catch-TWzh")]
		public string CatchTWzh { get; set; }
		[JsonProperty("Catch-JPja")]
		public string CatchJPja { get; set; }
		[JsonProperty("Catch-KRko")]
		public string CatchKRko { get; set; }
		[JsonProperty("Catch-EUru")]
		public string CatchEUru { get; set; }
	}

	public class FishResponse : IResponse
	{
		public int Id { get; set; }
		public string Filename { get; set; }
		public Name Name { get; set; }
		public Availability Availability { get; set; }
		public string Shadow { get; set; }
		public int Price { get; set; }
		[JsonProperty("Price-cj")]
		public int Pricecj { get; set; }
		[JsonProperty("Catch-phrase")]
		public string Catchphrase { get; set; }
		[JsonProperty("Museum-phrase")]
		public string Museumphrase { get; set; }
		public string Image_uri { get; set; }
		public string Icon_uri { get; set; }
	}

	public class Availability
	{
		[JsonProperty("Month-northern")]
		public string Monthnorthern { get; set; }
		[JsonProperty("Month-southern")]
		public string Monthsouthern { get; set; }
		public string Time { get; set; }
		public bool IsAllDay { get; set; }
		public bool IsAllYear { get; set; }
		public string Location { get; set; }
		public string Rarity { get; set; }
		[JsonProperty("Month-array-northern")]
		public int[] Montharraynorthern { get; set; }
		[JsonProperty("Month-array-southern")]
		public int[] Montharraysouthern { get; set; }
		[JsonProperty("Time-array")]
		public int[] Timearray { get; set; }
	}


	public class SeaCreaturesResponse : IResponse
	{
		public int Id { get; set; }
		public string Filename { get; set; }
		public Name Name { get; set; }
		public SeaCreatureAvailability Availability { get; set; }
		public string Speed { get; set; }
		public string Shadow { get; set; }
		public int Price { get; set; }
		[JsonProperty("Catch-phrase")]
		public string Catchphrase { get; set; }
		public string Image_uri { get; set; }
		public string Icon_uri { get; set; }
		[JsonProperty("Museum-phrase")]
		public string Museumphrase { get; set; }
	}

	public class SeaCreatureAvailability
	{
		[JsonProperty("Month-northern")]
		public string Monthnorthern { get; set; }
		[JsonProperty("Month-southern")]
		public string Monthsouthern { get; set; }
		public string Time { get; set; }
		public bool IsAllDay { get; set; }
		public bool IsAllYear { get; set; }
		[JsonProperty("Month-array-northern")]
		public int[] Montharraynorthern { get; set; }
		[JsonProperty("Month-array-southern")]
		public int[] Montharraysouthern { get; set; }
		[JsonProperty("Time-array")]
		public int[] Timearray { get; set; }
	}

	public class BugsResponse : IResponse
	{
		public int Id { get; set; }
		public string Filename { get; set; }
		public Name Name { get; set; }
		public Availability Availability { get; set; }
		public int Price { get; set; }
		[JsonProperty("Price-flick")]
		public int Priceflick { get; set; }
		[JsonProperty("Catch-phrase")]
		public string Catchphrase { get; set; }
		[JsonProperty("Museum-phrase")]
		public string Museumphrase { get; set; }
		public string Image_uri { get; set; }
		public string Icon_uri { get; set; }
	}


	public class FossilsResponse : IResponse
	{
		public string Filename { get; set; }
		public Name Name { get; set; }
		public int Price { get; set; }
		[JsonProperty("Museum-phrase")]
		public string Museumphrase { get; set; }
		public string Image_uri { get; set; }
		[JsonProperty("Part-of")]
		public string Partof { get; set; }
	}

}
