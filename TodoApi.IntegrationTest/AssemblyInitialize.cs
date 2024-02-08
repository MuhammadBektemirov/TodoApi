namespace TodoApi.IntegrationTest;

[TestClass]
public class AssemblyInitialize
{
    protected readonly HttpClient _client = new WebApplicationFactory().CreateClient();

    [AssemblyInitialize]
    public static async Task InitializeAsync(TestContext context)
    {
        
    }

    [AssemblyCleanup]
    public static async Task DisposeAsync()
    {
        
    }
}