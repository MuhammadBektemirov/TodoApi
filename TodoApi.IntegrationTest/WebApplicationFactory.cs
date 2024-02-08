using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MongoDB.Driver;

namespace TodoApi.IntegrationTest;

internal class WebApplicationFactory : WebApplicationFactory<Program>
{
    private const string ASPNETCORE_ENVIRONMENT = "Testing";
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment(ASPNETCORE_ENVIRONMENT);

        builder.ConfigureTestServices(services =>
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
        });
    }
}