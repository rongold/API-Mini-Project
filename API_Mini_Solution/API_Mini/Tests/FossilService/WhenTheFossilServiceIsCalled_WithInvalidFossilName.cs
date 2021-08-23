using API_Mini.AnimalCrossingIOService;
using NUnit.Framework;
using System.Threading.Tasks;

namespace API_Mini.Tests
{
	[Category("Sad Path")]
	public class WhenTheFossilServiceIsCalled_WithInvalidFossilName
	{
		FossilService _fossilService;

		[OneTimeSetUp]
		public async Task OneTimeSetUpAsync()
		{
			_fossilService = new FossilService();
			await _fossilService.MakeRequestAsync("cheese");
		}

		[Test]
		public void StatusIs404()
		{
			Assert.That(_fossilService.CallManager.StatusCode, Is.EqualTo(404));
		}

		[Test]
		public void Json_Response_Is_Null()
		{
			Assert.That(_fossilService.Json_response, Is.Null);
		}

		[Test]
		public void DTO_Is_Null()
		{
			Assert.That(_fossilService.FossilDTO.Response, Is.Null);
		}
		[Test]
		public void FossilResponseMessageIsFossilNotFound()
		{
			Assert.That(_fossilService.FossilResponse, Is.EqualTo("Fossil not found"));
		}
	}
}
