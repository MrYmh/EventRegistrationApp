using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EventRegistrationApp.Pages;

public class Index_Tests : EventRegistrationAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
