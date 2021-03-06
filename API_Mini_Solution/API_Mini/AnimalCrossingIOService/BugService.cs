using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using API_Mini.AnimalCrossingIOService.DataHandling;

namespace API_Mini.AnimalCrossingIOService
{
	public class BugService
	{
		#region Property
		public CallManager CallManager { get; set; }
		public JObject Json_response { get; set; }
		public DTO<BugsResponse> BugDTO { get; set; }
		public string BugResponse { get; set; }
		public string BugSelected { get; set; }
		#endregion

		public BugService()
		{
			CallManager = new CallManager();
			BugDTO = new DTO<BugsResponse>();
		}

		//Method that defines and makes the API request and stores the responses
		public async Task MakeRequestAsync(string BugId)
		{
			BugSelected = BugId;
			BugResponse = await CallManager.MakeBugRequestAsync(BugSelected);
			if (CallManager.StatusCode == 200)
			{
				Json_response = JObject.Parse(BugResponse);
				BugDTO.DeserializeReponse(BugResponse);
			}
		}
	}
}
