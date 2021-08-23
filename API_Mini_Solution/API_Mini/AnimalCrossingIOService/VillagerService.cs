using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using API_Mini.AnimalCrossingIOService.DataHandling;

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
            VillagerResponse = await CallManager.MakeVillagerRequestAsync(int.Parse(villagerId));
            if (CallManager.StatusCode == 200)
            {
                Json_response = JObject.Parse(VillagerResponse);
                VillagerDTO.DeserializeReponse(VillagerResponse);
            }            
        }

        public int VillagerCount()
        {
            var count = 0;
            foreach (var villager in Json_response["id"])
            {
                count++;
            }
            return count;
        }
    }
}
