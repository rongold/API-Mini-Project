using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Happy Path")]
    public class WhenTheSeaCreatureServiceIsCalled_WithValidSeaCreatureId
    {
        SeaCreatureService _seaCreatureService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _seaCreatureService = new SeaCreatureService();
            await _seaCreatureService.MakeRequestAsync("20");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_seaCreatureService.CallManager.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void CheckDetailsOfSeaCreatureMatchToExpected()
        {
            Assert.That(_seaCreatureService.SeaCreatureDTO.Response.Filename, Is.EqualTo("octopus"));
            Assert.That(_seaCreatureService.SeaCreatureDTO.Response.Price, Is.EqualTo(1200));
            Assert.That(_seaCreatureService.SeaCreatureDTO.Response.Image_uri, Is.EqualTo("https://acnhapi.com/v1/images/sea/20"));

        }

        
    }
}
