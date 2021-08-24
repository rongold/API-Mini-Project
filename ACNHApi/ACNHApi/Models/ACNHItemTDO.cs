
	public class VillagerResponseTDO
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
		//public string NameUSes { get; set; }
		//public string NameEUfr { get; set; }
		//public string NameUSfr { get; set; }
		//public string NameEUit { get; set; }
		//public string NameEUnl { get; set; }
		//public string NameCNzh { get; set; }
		//public string NameTWzh { get; set; }
		//public string NameJPja { get; set; }
		//public string NameKRko { get; set; }
		//public string NameEUru { get; set; }
	}

	public class CatchTranslations
	{
		public int Id { get; set; }
		public string CatchUSen { get; set; }
		public string CatchEUen { get; set; }
		public string CatchEUde { get; set; }
		public string CatchEUes { get; set; }
		//public string CatchUSes { get; set; }
		//public string CatchEUfr { get; set; }
		//public string CatchUSfr { get; set; }
		//public string CatchEUit { get; set; }
		//public string CatchEUnl { get; set; }
		//public string CatchCNzh { get; set; }
		//public string CatchTWzh { get; set; }
		//public string CatchJPja { get; set; }
		//public string CatchKRko { get; set; }
		//public string CatchEUru { get; set; }
	}

	public class FishResponseTDO
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


	public class SeaCreaturesResponseTDO 
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

	public class BugsResponseTDO 
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


	public class FossilsResponseTDO
	{
		public string Filename { get; set; }
		public Name Name { get; set; }
		public int Price { get; set; }
		public string Museumphrase { get; set; }
		public string Image_uri { get; set; }
		public string Partof { get; set; }
	}
