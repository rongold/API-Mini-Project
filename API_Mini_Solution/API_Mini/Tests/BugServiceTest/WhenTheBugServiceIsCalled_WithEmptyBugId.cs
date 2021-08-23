using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Happy Path")]
    public class WhenTheBugServiceIsCalled_WithEmptyBugId
    {
        BugService _bugService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _bugService = new BugService();
            await _bugService.MakeRequestAsync("");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_bugService.CallManager.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void CheckTotalBugsMatchToCount()
        {
            Assert.That(_bugService.Json_response.Count, Is.EqualTo(80));
        }

        [Test]
        public void CheckBugsExistsInResponse()
        {
            Assert.That(_bugService.Json_response["earth-boring_dung_beetle"], Is.Not.Null);
            Assert.That(_bugService.Json_response["brown_cicada"], Is.Not.Null);
            Assert.That(_bugService.Json_response["common_butterfly"], Is.Not.Null);
        }
    }
}
