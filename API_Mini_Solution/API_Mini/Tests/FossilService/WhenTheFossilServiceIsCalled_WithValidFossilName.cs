using API_Mini.AnimalCrossingIOService;
using NUnit.Framework;
using System.Threading.Tasks;

namespace API_Mini.Tests
{
	[Category("Happy Path")]
	public class WhenTheFossilServiceIsCalled_WithValidFossilName
	{
		FossilService _fossilService;

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			_fossilService = new FossilService();
			await _fossilService.MakeRequestAsync("myllokunmingia");
		}

		[Test]
		public void StatusCodeIs200()
		{
			Assert.That(_fossilService.CallManager.StatusCode, Is.EqualTo(200));
		}

		[Test]
		public void Name_USen_Is_myllokunmingia()
		{
			Assert.That(_fossilService.FossilDTO.Response.Name.NameUSen, Is.EqualTo("myllokunmingia"));
		}

		[Test]
		public void Price_Is_1500()
		{
			Assert.That(_fossilService.FossilDTO.Response.Price, Is.EqualTo(1500));
		}

		[Test]
		public void Part_Of_Is_myllokunmingia()
		{
			Assert.That(_fossilService.FossilDTO.Response.Partof, Is.EqualTo("myllokunmingia"));
		}
	}
}
