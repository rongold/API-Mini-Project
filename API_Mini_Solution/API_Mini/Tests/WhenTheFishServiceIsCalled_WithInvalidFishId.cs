using API_Mini.AnimalCrossingIOService;
using NUnit.Framework;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
	[Category("Sad Path")]
	public class WhenTheFishServiceIsCalled_WithInvalidFishId
	{
		FishService _fishService;

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			_fishService = new FishService();
			await _fishService.MakeRequestAsync(9999);
		}

		[Test]
		public void StatusIs404()
		{
			Assert.That(_fishService.CallManager.StatusCode, Is.EqualTo(404));
		}

		[Test]
		public void Json_Response_Is_Null()
		{
			Assert.That(_fishService.Json_response, Is.Null);
		}

		[Test]
		public void DTO_Is_Null()
		{
			Assert.That(_fishService.FishDTO.Response, Is.Null);
		}
	}
}
