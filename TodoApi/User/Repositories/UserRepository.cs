using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoApi.Models;
using TodoApi.Shared;
using TodoApi.User.Models;
using TodoApi.User.Repositories.Interfaces;


namespace TodoApi.User.Repositories;

public class UserRepository : AbstractMongoDB<UserModel>, IUserRepository
{
    private const string COLLECTION_NAME = "planets";

    public UserRepository(
        IOptions<MongoClientOptions> settings,
        IMongoClient mongoClient) : base(settings.Value, mongoClient, COLLECTION_NAME)
    {
    }

    public async Task<UserModel> CreateUserAsync(UserModel user)
    {
        await _collection.InsertOneAsync(user);

        return user;
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        return await _collection.FindAsync(_ => true).Result.ToListAsync();
    }

    public async Task<UserModel?> GetUserAsync(UserModel userModel)
    {
        return await _collection.FindAsync(u => u.Sign == userModel.Sign).Result.FirstOrDefaultAsync();
    }

    public async Task<UserModel?> GetUserById(string id)
    {
        return await _collection.FindAsync(u => u.Id == id).Result.FirstOrDefaultAsync();
    }

    public async Task<UserModel?> UpdateUserAsync(string id, UserModel user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == id, user);

        return user;
    }
    
    public async Task? DeleteUserAsync(string id)
    {
        await _collection.DeleteOneAsync(u => u.Id == id);
    }
}


