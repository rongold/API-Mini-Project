using System.Configuration;

namespace API_Mini
{
	public class AppConfigReader
	{
		public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
	}
}
