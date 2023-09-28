using Xunit;
using FluentAssertions;


namespace API_Testing_with_Playwright.Tests
{
        public class DELETEMethod : IClassFixture<PlaywrightDriver>
        {
            private readonly PlaywrightDriver _playwrightDriver;
            public DELETEMethod(PlaywrightDriver playwrightDriver)
            {
                _playwrightDriver = playwrightDriver;
            }

             [Fact]
             public async Task GetCartOfUser_5()
             {
                   var DeleteProducttResponse = await _playwrightDriver?.APIRequestContext?.DeleteAsync("/products/1");
                   var DeleteProductResponseData = await DeleteProducttResponse.JsonAsync();

                    DeleteProducttResponse.Status.Should().Be(200);
              }
        }
}
