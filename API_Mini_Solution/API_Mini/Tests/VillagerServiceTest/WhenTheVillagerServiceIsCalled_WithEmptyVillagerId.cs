﻿using NUnit.Framework;
using API_Mini.AnimalCrossingIOService;
using System.Threading.Tasks;


namespace API_Mini.Tests
{
    [Category("Happy Path")]
    public class WhenTheVillagerServiceIsCalled_WithEmptyVillagerId
    {
        VillagerService _villagerService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _villagerService = new VillagerService();
            await _villagerService.MakeRequestAsync("");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_villagerService.CallManager.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void CheckTotalVillagersMatchToCount()
        {
            Assert.That(_villagerService.Json_response.Count, Is.EqualTo(391));

        }
    }
}