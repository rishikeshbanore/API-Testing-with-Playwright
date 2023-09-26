using API_Testing_with_Playwright;
using FluentAssertions;
using Microsoft.Playwright;
using System.Text.Json;
using Xunit;

namespace APITestingWithPlaywright
{
    public class GetAndPassToken : IClassFixture<PlaywrightDriver>
    {
 
        private readonly PlaywrightDriver _playwrightDriver;
        public GetAndPassToken(PlaywrightDriver playwrightDriver)
        {
            _playwrightDriver = playwrightDriver;
        }

        [Fact]
        public async Task GetProduct()
        {
            var token = await GetToken();
            var GetProductPhone = await _playwrightDriver.APIRequestContext?.GetAsync("/products/search?q=phone", new APIRequestContextOptions()
            {
                Headers = new Dictionary<string, string>
                {
                    //{"Authorization", $"Bearer {GetToken()}"}
                    {"Authorization", $"{token}"}
                }
            })!;

            var getProductResponse = await GetProductPhone.JsonAsync();

            var getProductResponseDeserialised = getProductResponse?.Deserialize<Authenticate>();

            getProductResponseDeserialised.Should().NotBeNull();

        }

        private async Task<string?> GetToken()
        {

            var LoginDetails = await _playwrightDriver.APIRequestContext?.PostAsync("/auth/login", new APIRequestContextOptions()
            {
                DataObject = new
                {

                    username = "kminchelle",
                    password = "0lelplR",
                }
            })!;

            var Tokenresponse = await LoginDetails.JsonAsync();

            return Tokenresponse?.Deserialize<Authenticate>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true

            })?.Token;
;
        }

        public class Authenticate
        {
            public string Token { get; set; }
        }
    }
}