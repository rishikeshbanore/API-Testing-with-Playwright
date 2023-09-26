using FluentAssertions;
using Microsoft.Playwright;
using static System.Net.WebRequestMethods;

namespace APITestingWithPlaywright
{
    public class LoginAndGetToken
    {
        [Fact]
        public async Task GLoginGetToken()
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

            var AuthToken = Tokenresponse?.GetProperty("token").ToString();

            Tokenresponse.Should().NotBe(string.Empty);
        }
    }
}