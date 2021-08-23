using API_Mini.AnimalCrossingIOService;
using NUnit.Framework;
using System.Threading.Tasks;

namespace API_Mini.Tests
{
	[Category("Happy Path")]
	public class WhenTheFossilServiceIsCalled_WithEmptyId
	{
		FossilService _fossilService;

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			_fossilService = new FossilService();
			await _fossilService.MakeRequestAsync("");
		}

		[Test]
		public void StatusCodeIs200()
		{
			Assert.That(_fossilService.CallManager.StatusCode, Is.EqualTo(200));
		}

		[Test]
		public void FossilJson_Contains_MultipleFossils() 
		{
			Assert.That(_fossilService.Json_response["ophthalmo_torso"], Is.Not.Null);
			Assert.That(_fossilService.Json_response["pachy_skull"], Is.Not.Null);
			Assert.That(_fossilService.Json_response["pachy_tail"], Is.Not.Null);
		}

		[Test]
		public void CountOfFossils_Is73()
		{
			Assert.That(_fossilService.Json_response.Count, Is.EqualTo(73));
		}
	}
}
