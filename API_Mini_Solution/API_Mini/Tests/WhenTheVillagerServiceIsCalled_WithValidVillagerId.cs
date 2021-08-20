using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    public class WhenTheVillagerServiceIsCalled_WithValidVillagerId
    {
        VillagerService _villagerService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _villagerService = new VillagerService();
            await _villagerService.MakeRequestAsync(64);
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_villagerService.CallManager.StatusCode, Is.EqualTo(200));
        }

        
    }
}
