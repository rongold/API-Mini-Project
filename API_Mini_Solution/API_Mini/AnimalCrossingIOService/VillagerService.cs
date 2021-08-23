using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using API_Mini.AnimalCrossingIOService.DataHandling;
using Moq;

namespace API_Mini.AnimalCrossingIOService
{
    public class VillagerService
    {
        public CallManager CallManager { get; set; }
        public DTO<VillagerResponse> VillagerDTO { get; set; }
        public JObject Json_response { get; set; }
        public string VillagerResponse { get; set; }
        public VillagerService()
        {
            CallManager = new CallManager();
            VillagerDTO = new DTO<VillagerResponse>();
        }

        public async Task MakeRequestAsync(string villagerId)
        {
            if (villagerId == "")
            {
            VillagerResponse = await CallManager.MakeVillagerRequestAsync("");
            }
            else
            {
                VillagerResponse = await CallManager.MakeVillagerRequestAsync(villagerId);
            }           
            if (CallManager.StatusCode == 200)
            {
                Json_response = JObject.Parse(VillagerResponse);
                VillagerDTO.DeserializeReponse(VillagerResponse);
            }            
        }
    }
}
