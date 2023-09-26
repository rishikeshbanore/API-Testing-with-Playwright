using API_Testing_with_Playwright;
using FluentAssertions;
using Microsoft.Playwright;
using Xunit;
using static System.Net.WebRequestMethods;

namespace APITestingWithPlaywright
{
    public class LoginAndGetToken :IClassFixture<PlaywrightDriver>
    {
        private readonly PlaywrightDriver _playwrightDriver;
        public LoginAndGetToken(PlaywrightDriver playwrightDriver)
        {
            _playwrightDriver = playwrightDriver;
        }

        [Fact]
        public async Task GLoginGetToken()
        {
            var LoginDetails = await _playwrightDriver.APIRequestContext?.PostAsync("/auth/login", new APIRequestContextOptions()
            {
                DataObject = new {

                    username = "kminchelle",
                    password = "0lelplR",
                }
            })!;

            var Tokenresponse = await LoginDetails.JsonAsync();

            var AuthToken = Tokenresponse?.GetProperty("token").ToString();

            Tokenresponse.Should().NotBe(string.Empty);
        }
    }
}