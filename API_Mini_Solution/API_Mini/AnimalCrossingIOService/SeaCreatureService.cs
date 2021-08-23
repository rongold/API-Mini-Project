using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using API_Mini.AnimalCrossingIOService.DataHandling;

namespace API_Mini.AnimalCrossingIOService
{
    public class SeaCreatureService
    {
        public CallManager CallManager { get; set; }
        public DTO<SeaCreaturesResponse> SeaCreatureDTO { get; set; }
        public JObject Json_response { get; set; }
        public string SeaCreatureResponse { get; set; }
        public SeaCreatureService()
        {
            CallManager = new CallManager();
            SeaCreatureDTO = new DTO<SeaCreaturesResponse>();
        }

        public async Task MakeRequestAsync(string seaCreatureId)
        {
            SeaCreatureResponse = await CallManager.MakeSeaCreatureRequestAsync(seaCreatureId);
            if (CallManager.StatusCode == 200)
            {
                Json_response = JObject.Parse(SeaCreatureResponse);
                SeaCreatureDTO.DeserializeReponse(SeaCreatureResponse);
            }           
        }
    }
}
