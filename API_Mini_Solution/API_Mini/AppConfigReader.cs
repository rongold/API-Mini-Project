using System.Configuration;

namespace API_Mini
{
	public static class AppConfigReader
	{
		public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
	}
}
