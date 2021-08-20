using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace API_Mini.AnimalCrossingIOService
{
	public class CallManager
	{
		private readonly IRestClient _client;
		public int StatusCode { get; set; }

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }

        public async Task<string> MakeVillagerRequestAsync(string villagerId)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"villagers/{villagerId.ToLower().Replace(" ", "")}";
            var response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }
        public async Task<string> MakeFishRequestAsync(int fishId)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"fish/{fishId}";
            var response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }
    }
}
