using System;
using Newtonsoft.Json;

namespace API_Mini.AnimalCrossingIOService.DataHandling
{
	public class DTO<ResponseType> where ResponseType: IResponse, new()
	{
        public ResponseType Response { get; set; }
        //method that creates the above object using the response from the API
        public void DeserializeReponse(string response)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(response);
        }
    }
}
