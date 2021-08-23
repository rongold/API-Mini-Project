using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Happy Path")]
    public class WhenTheVillagerServiceIsCalled_WithValidVillagerId
    {
        VillagerService _villagerService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _villagerService = new VillagerService();
            await _villagerService.MakeRequestAsync("64");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_villagerService.CallManager.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void CheckDetailsOfVillagerMatchToExpected()
        {
            Assert.That(_villagerService.VillagerDTO.Response.name.nameUSen, Is.EqualTo("Raymond"));
            Assert.That(_villagerService.VillagerDTO.Response.personality, Is.EqualTo("Smug"));
            Assert.That(_villagerService.VillagerDTO.Response.saying, Is.EqualTo("Stay on brand!"));
            Assert.That(_villagerService.VillagerDTO.Response.birthdaystring, Is.EqualTo("October 1st"));

        }

        
    }
}
