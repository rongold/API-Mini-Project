using API_Mini.AnimalCrossingIOService;
using NUnit.Framework;
using System.Threading.Tasks;

namespace API_Mini.Tests
{
	[Category("Happy Path")]

	public class WhenTheBugServiceIsCalled_WithValidBugId
	{
		BugService _bugService;

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			_bugService = new BugService();
			await _bugService.MakeRequestAsync("6");
		}

		[Test]
		public void StatusCodeIs200()
		{
			Assert.That(_bugService.CallManager.StatusCode, Is.EqualTo(200));
		}

		[Test]
		public void Name_USen_Is_paper_kite_butterfly()
		{
			Assert.That(_bugService.BugDTO.Response.Name.NameUSen, Is.EqualTo("paper kite butterfly"));
		}

		[Test]
		public void Rarity_Is_Common()
		{
			Assert.That(_bugService.BugDTO.Response.Availability.Rarity, Is.EqualTo("Common"));
		}

		
	}
}
