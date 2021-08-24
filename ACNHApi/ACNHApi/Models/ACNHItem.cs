namespace ACNHApi.Models
{
		public class VillagerResponse
		{
			public int Id { get; set; }
			public string Filename { get; set; }
			public Name Name { get; set; }
			public string Personality { get; set; }
			public string Birthdaystring { get; set; }
			public string Birthday { get; set; }
			public string Species { get; set; }
			public string Gender { get; set; }
			public string Subtype { get; set; }
			public string Hobby { get; set; }
			public string Catchphrase { get; set; }
			public string Icon_uri { get; set; }
			public string Image_uri { get; set; }
			public string Bubblecolor { get; set; }
			public string Textcolor { get; set; }
			public string Saying { get; set; }
			public CatchTranslations Catchtranslations { get; set; }
		}

		public class Name
		{
			public int Id { get; set; }
			public string NameUSen { get; set; }
			public string NameEUen { get; set; }
			public string NameEUde { get; set; }
			public string NameEUes { get; set; }
			
		}

		public class CatchTranslations
		{
			public int Id { get; set; }
			public string CatchUSen { get; set; }
			public string CatchEUen { get; set; }
			public string CatchEUde { get; set; }
			public string CatchEUes { get; set; }
			
		}

		public class FishResponse
		{
			public int Id { get; set; }
			public string Filename { get; set; }
			public Name Name { get; set; }
			public Availability Availability { get; set; }
			public string Shadow { get; set; }
			public int Price { get; set; }
			public int Pricecj { get; set; }
			public string Catchphrase { get; set; }
			public string Museumphrase { get; set; }
			public string Image_uri { get; set; }
			public string Icon_uri { get; set; }
		}

		public class Availability
		{
			public int Id { get; set; }
			public string Monthnorthern { get; set; }
			public string Monthsouthern { get; set; }
			public string Time { get; set; }
			public bool IsAllDay { get; set; }
			public bool IsAllYear { get; set; }
			public string Location { get; set; }
			public string Rarity { get; set; }
			public int[] Montharraynorthern { get; set; }
			public int[] Montharraysouthern { get; set; }
			public int[] Timearray { get; set; }
		}


		public class SeaCreaturesResponse
		{
			public int Id { get; set; }
			public string Filename { get; set; }
			public Name Name { get; set; }
			public SeaCreatureAvailability Availability { get; set; }
			public string Speed { get; set; }
			public string Shadow { get; set; }
			public int Price { get; set; }
			public string Catchphrase { get; set; }
			public string Image_uri { get; set; }
			public string Icon_uri { get; set; }
			public string Museumphrase { get; set; }
		}

		public class SeaCreatureAvailability
		{
			public int Id { get; set; }
			public string Monthnorthern { get; set; }
			public string Monthsouthern { get; set; }
			public string Time { get; set; }
			public bool IsAllDay { get; set; }
			public bool IsAllYear { get; set; }
			public int[] Montharraynorthern { get; set; }
			public int[] Montharraysouthern { get; set; }
			public int[] Timearray { get; set; }
		}

		public class BugsResponse
		{
			public int Id { get; set; }
			public string Filename { get; set; }
			public Name Name { get; set; }
			public Availability Availability { get; set; }
			public int Price { get; set; }
			public int Priceflick { get; set; }
			public string Catchphrase { get; set; }
			public string Museumphrase { get; set; }
			public string Image_uri { get; set; }
			public string Icon_uri { get; set; }
		}


		public class FossilsResponse
		{
			public string Filename { get; set; }
			public Name Name { get; set; }
			public int Price { get; set; }
			public string Museumphrase { get; set; }
			public string Image_uri { get; set; }
			public string Partof { get; set; }
		}
}