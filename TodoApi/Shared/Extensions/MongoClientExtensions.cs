using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using TodoApi.Models;

namespace TodoApi.Shared.Extensions;

public static class MongoClientExtensions
{
    private const string SECTION_NAME = "MongoClientOptions";
    
    public static IServiceCollection RegisterMongoClientWithOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var conventionPack = new ConventionPack()
        {
            new IgnoreIfNullConvention(true),
            new CamelCaseElementNameConvention(),
            new EnumRepresentationConvention(BsonType.String)
        };
        
        ConventionRegistry.Register("EnumStringConvention", conventionPack, t => true);
        ConventionRegistry.Register("camelCase", conventionPack, t => true);

        services.Configure<MongoClientOptions>(configuration.GetSection(SECTION_NAME));
        services.AddSingleton<IMongoClient>(_ =>
        {
            var mongoOptions = configuration.GetSection(SECTION_NAME).Get<MongoClientOptions>();
            var mongoUrl = MongoUrl.Create(mongoOptions!.ConnectionString);
            var settings = MongoClientSettings.FromUrl(mongoUrl);

            return new MongoClient(settings);
        });

        return services;
    }
}