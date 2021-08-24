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
            request.Resource = $"ACNHVillagers/{villagerId}";
            var response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }


        public async Task<string> MakeSeaCreatureRequestAsync(string seaCreatureId)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"sea/{seaCreatureId}";
            var response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }

            public async Task<string> MakeFishRequestAsync(string fishId)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"ACNHFish/{fishId}";
            var response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }

        public async Task<string> MakeBugRequestAsync(string bugId)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"ACNHBugs/{bugId}";
            var response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }

        public async Task<string> MakeFossilRequestAsync(string fossilSelected)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"fossils/{fossilSelected.ToLower().Replace(" ","")}";
            var response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }
    }
}
