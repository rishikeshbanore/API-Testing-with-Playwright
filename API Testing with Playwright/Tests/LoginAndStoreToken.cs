using FluentAssertions;
using Microsoft.Playwright;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace APITestingWithPlaywright
{
    public class LoginAndStoreToken
    {
        [Fact]
        public async Task StoreTokenDetails()
        {
            var playwright = await Playwright.CreateAsync();

            var requestcontext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://dummyjson.com"
            });

            var LoginDetails = await requestcontext.PostAsync("/auth/login", new APIRequestContextOptions()
            {
                DataObject = new {

                    username = "kminchelle",
                    password = "0lelplR",
                }
            });

            var Tokenresponse = await LoginDetails.JsonAsync();

            var AuthTokenResponse = Tokenresponse?.Deserialize<Authenticate>(new JsonSerializerOptions
            {

                PropertyNameCaseInsensitive = true

            });

            AuthTokenResponse?.Token.Should().NotBeNull();

            AuthTokenResponse?.Token.Should().NotBe(string.Empty);
        }
        public class Authenticate
        {
            public string Token { get; set; }
        }
    }
}