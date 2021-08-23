using API_Mini.AnimalCrossingIOService;
using NUnit.Framework;
using System.Threading.Tasks;

namespace API_Mini.Tests
{
	[Category("Happy Path")]
	public class WhenTheFishServiceIsCalled_WithValidFishId
	{
		FishService _fishService;

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			_fishService = new FishService();
			await _fishService.MakeRequestAsync("16");
		}

		[Test]
		public void StatusCodeIs200()
		{
			Assert.That(_fishService.CallManager.StatusCode, Is.EqualTo(200));
		}

		[Test]
		public void Name_USen_Is_paper_kite_butterfly()
		{
			Assert.That(_fishService.FishDTO.Response.name.nameUSen, Is.EqualTo("freshwater goby"));
		}

		[Test]
		public void Rarity_Is_Common()
		{
			Assert.That(_fishService.FishDTO.Response.availability.rarity, Is.EqualTo("Common"));
		}

		[Test]
		public void TimeArrayValues_Are_Expected()
		{
			var actual = _fishService.FishDTO.Response.availability.timearray;
			Assert.That(actual[0], Is.EqualTo(16));
			Assert.That(actual[7], Is.EqualTo(23));
			Assert.That(actual[16], Is.EqualTo(8));

		}
	}
}
