using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Sad Path")]
    public class WhenTheSeaCreatureServiceIsCalled_WithInvalidSeaCreatureId
    {
        SeaCreatureService _seaCreatureService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _seaCreatureService = new SeaCreatureService();
            await _seaCreatureService.MakeRequestAsync("9999");
        }

        [Test]
        public void StatusIs404()
        {
            Assert.That(_seaCreatureService.CallManager.StatusCode, Is.EqualTo(404));
            
        }

        [Test]
        public void JsonResponseIsNull()
        {
            Assert.That(_seaCreatureService.Json_response, Is.Null);
        }

        [Test]
        public void VillagerResponseMessageIsVillagerNotFound()
        {
            Assert.That(_seaCreatureService.SeaCreatureResponse, Is.EqualTo("Sea Creature not found"));
        }
    }
}