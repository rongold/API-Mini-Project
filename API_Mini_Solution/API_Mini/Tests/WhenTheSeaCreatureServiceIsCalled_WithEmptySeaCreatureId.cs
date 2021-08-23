using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Happy Path")]
    public class WhenTheSeaCreatureServiceIsCalled_WithEmptySeaCreatureId
    {
        SeaCreatureService _seaCreatureService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _seaCreatureService = new SeaCreatureService();
            await _seaCreatureService.MakeRequestAsync("");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_seaCreatureService.CallManager.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void CheckTotalSeaCreaturesMatchToCount()
        {
            Assert.That(_seaCreatureService.Json_response.Count, Is.EqualTo(40));
        }

        [Test]
        public void CheckSeaCreaturesExistsInResponse()
        {
            Assert.That(_seaCreatureService.Json_response["seaweed"], Is.Not.Null);
            Assert.That(_seaCreatureService.Json_response["gigas_giant_clam"], Is.Not.Null);
            Assert.That(_seaCreatureService.Json_response["venus_flower_basket"], Is.Not.Null);
        }
    }
}
