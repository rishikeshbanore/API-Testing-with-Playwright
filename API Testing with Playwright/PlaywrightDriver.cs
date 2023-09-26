using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_with_Playwright
{
    public class PlaywrightDriver : IDisposable
    {
        private readonly Task<IAPIRequestContext>? _requestContext = null;

        public PlaywrightDriver()
        { 
            _requestContext = CreateContext();

        }

        public IAPIRequestContext? APIRequestContext => _requestContext?.GetAwaiter().GetResult();

     
        private async Task<IAPIRequestContext> CreateContext()
        {
            var playwright = await Playwright.CreateAsync();

            return await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://dummyjson.com"
            });

        }
        public void Dispose()
        {
            _requestContext?.Dispose();
        }
    }
}
