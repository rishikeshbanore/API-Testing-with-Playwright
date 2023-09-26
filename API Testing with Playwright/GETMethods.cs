using Microsoft.Playwright;
using static System.Net.WebRequestMethods;

namespace APITestingWithPlaywright
{
    public class GETMethods
    {
        [Fact]
        public async Task GetCartOfUser_5()
        {
            var playwright = await Playwright.CreateAsync();
            var requestcontext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://dummyjson.com"
            });

            var GetUSerCartResponse = await requestcontext.GetAsync("/carts/user/5");
            var UserCartResponseData = await GetUSerCartResponse.JsonAsync();
        }

        [Fact]
        public async Task GetSingleCart()
        {
            var playwright = await Playwright.CreateAsync();
            var requestcontext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://dummyjson.com"
            });

            var GetUSerCartResponse = await requestcontext.GetAsync("/carts/1");
            var UserCartResponseData = await GetUSerCartResponse.JsonAsync();


        }
    }
}