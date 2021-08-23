using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Happy Path")]
    public class WhenTheFishServiceIsCalled_WithEmptyFishId
    {
        FishService _fishService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _fishService = new FishService();
            await _fishService.MakeRequestAsync("");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_fishService.CallManager.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void CheckTotalFishMatchToCount()
        {
            Assert.That(_fishService.Json_response.Count, Is.EqualTo(80));

        }
        [Test]
        public void CheckFishExistsInResponse()
        {
            Assert.That(_fishService.Json_response["bitterling"], Is.Not.Null);
            Assert.That(_fishService.Json_response["betta"], Is.Not.Null);
            Assert.That(_fishService.Json_response["coelacanth"], Is.Not.Null);
        }
    }
}
