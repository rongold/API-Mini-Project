using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Sad Path")]
    public class WhenTheVillagerServiceIsCalled_WithInvalidVillagerId
    {
        VillagerService _villagerService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _villagerService = new VillagerService();
            await _villagerService.MakeRequestAsync("9999");
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
        public void DTO_Is_Null()
        {
            Assert.That(_villagerService.VillagerDTO.Response, Is.Null);

        }
        [Test]
        public void VillagerResponseMessageIsVillagerNotFound()
        {
            Assert.That(_villagerService.VillagerResponse, Does.Contain("Villager not found"));
        }
    }
}