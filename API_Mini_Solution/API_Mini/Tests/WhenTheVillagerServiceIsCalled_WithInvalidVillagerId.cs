using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    public class WhenTheVillagerServiceIsCalled_WithInvalidVillagerId
    {
        VillagerService _villagerService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _villagerService = new VillagerService();
            await _villagerService.MakeRequestAsync(600);
        }

        [Test]
        public void StatusIs404()
        {
            Assert.That(_villagerService.CallManager.StatusCode, Is.EqualTo(404));
            
        }

        [Test]
        public void JsonResponseIsNull()
        {
            Assert.That(_villagerService.Json_response, Is.Null);
        }

        [Test]
        public void VillagerResponseMessageIsVillagerNotFound()
        {
            Assert.That(_villagerService.VillagerResponse, Is.EqualTo("Villager not found"));
        }
    }
}