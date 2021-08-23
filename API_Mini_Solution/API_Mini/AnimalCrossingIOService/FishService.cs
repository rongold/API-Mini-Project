using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using API_Mini.AnimalCrossingIOService.DataHandling;

namespace API_Mini.AnimalCrossingIOService
{
	public class FishService
	{
		#region Property
		public CallManager CallManager { get; set; }
		public JObject Json_response { get; set; }
		public DTO<FishResponse> FishDTO { get; set; }
		public string FishResponse { get; set; }
		public string FishSelected { get; set; }
		#endregion

		public FishService()
		{
			CallManager = new CallManager();
			FishDTO = new DTO<FishResponse>();
		}

		//Method that defines and makes the API request and stores the responses
		public async Task MakeRequestAsync(string FishId)
		{
			FishSelected = FishId;
			FishResponse = await CallManager.MakeFishRequestAsync(FishSelected);
			if (CallManager.StatusCode == 200) 
			{
				Json_response = JObject.Parse(FishResponse);
				FishDTO.DeserializeReponse(FishResponse);
			}
		}
	}
}
