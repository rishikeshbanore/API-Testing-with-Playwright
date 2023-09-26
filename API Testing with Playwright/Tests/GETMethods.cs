using API_Testing_with_Playwright;
using Microsoft.Playwright;
using Xunit;
using static System.Net.WebRequestMethods;

namespace APITestingWithPlaywright
{
    public class GETMethods : IClassFixture<PlaywrightDriver>
    {
        private readonly PlaywrightDriver _playwrightDriver;
        public GETMethods(PlaywrightDriver playwrightDriver)
        {
            _playwrightDriver = playwrightDriver;
        }

        [Fact]
        public async Task GetCartOfUser_5()
        {
            var GetUSerCartResponse = await _playwrightDriver?.APIRequestContext?.GetAsync("/carts/user/5");
            var UserCartResponseData = await GetUSerCartResponse.JsonAsync();
        }

        [Fact]
        public async Task GetSingleCart()
        {
            var GetUSerCartResponse = await _playwrightDriver?.APIRequestContext?.GetAsync("/carts/1");
            var UserCartResponseData = await GetUSerCartResponse.JsonAsync();

        }
    }
}