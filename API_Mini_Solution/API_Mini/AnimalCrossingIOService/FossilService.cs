using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using API_Mini.AnimalCrossingIOService.DataHandling;



namespace API_Mini.AnimalCrossingIOService
{
	public class FossilService
	{
		#region Property
		public CallManager CallManager { get; set; }
		public JObject Json_response { get; set; }
		public DTO<FossilsResponse> FossilDTO { get; set; }
		public string FossilResponse { get; set; }
		public string FossilSelected { get; set; }
		#endregion

		public FossilService()
		{
			CallManager = new CallManager();
			FossilDTO = new DTO<FossilsResponse>();
		}

		//Method that defines and makes the API request and stores the responses
		public async Task MakeRequestAsync(string FossilName)
		{
			FossilSelected = FossilName;
			FossilResponse = await CallManager.MakeFossilRequestAsync(FossilSelected);
			Json_response = JObject.Parse(FossilResponse);
			FossilDTO.DeserializeReponse(FossilResponse);
		}
	}
}
