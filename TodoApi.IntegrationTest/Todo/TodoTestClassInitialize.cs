namespace TodoApi.IntegrationTest.Todo;

[TestClass]
public class TodoTestClassInitialize : AssemblyInitialize
{
    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static async Task ClassInitializeAsync(TestContext context)
    {
        
    }
    
    [ClassCleanup(InheritanceBehavior.BeforeEachDerivedClass)]
    public static async Task ClassDisposeAsync()
    {
        
    }
    
}