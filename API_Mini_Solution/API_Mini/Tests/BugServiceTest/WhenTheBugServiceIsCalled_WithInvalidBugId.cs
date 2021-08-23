using API_Mini.AnimalCrossingIOService;
using NUnit.Framework;
using System.Threading.Tasks;

namespace API_Mini.Tests
{
	[Category("Sad Path")]

	public class WhenTheBugServiceIsCalled_WithInvalidBugId
	{
		BugService _bugService;

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			_bugService = new BugService();
			await _bugService.MakeRequestAsync("9999");
		}

		[Test]
		public void StatusIs404()
		{
			Assert.That(_bugService.CallManager.StatusCode, Is.EqualTo(404));
		}

		[Test]
		public void Json_Response_Is_Null()
		{
			Assert.That(_bugService.Json_response, Is.Null);
		}

		[Test]
		public void DTO_Is_Null()
		{
			Assert.That(_bugService.BugDTO.Response, Is.Null);

		}
		[Test]
		public void BugResponseMessageIsBugNotFound()
		{
			Assert.That(_bugService.BugResponse, Is.EqualTo("Bug not found"));
		}
	}
}
