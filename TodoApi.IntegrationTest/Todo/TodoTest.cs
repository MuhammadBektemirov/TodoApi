using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using MongoDB.Bson;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Models;

namespace TodoApi.IntegrationTest.Todo;

[TestClass]
public class TodoTest : TodoTestClassInitialize
{
    private const string DOMAIN_ADDRESS = "api/v1";

    [TestMethod]
    public async Task GetTodos_ReturnsTodos()
    {
        // Arrange
        var userId = "659fbc65c552cb85535f60a3";

        // Act
        var response = await _client.GetAsync($"{DOMAIN_ADDRESS}/users/{userId}/todos");

        // Assert
        Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
    }

    [TestMethod]
    public async Task GetTodo_ReturnTodo()
    {
        // Arrange
        var todoId = "659feb17d10598d7a55f75b6";

        // Act
        var response = await _client.GetAsync($"{DOMAIN_ADDRESS}/todo/{todoId}");
        var body = await response.Content.ReadFromJsonAsync<TodoDTO>();

        // Assert
        Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        Assert.AreEqual("updatedTodoById", body.Title);
        Assert.AreEqual("string", body.Description);
        Assert.AreEqual(1704979223, body.CreatedAt);
        Assert.AreEqual(TodoStatus.NEW, body.Status);
        Assert.AreEqual("659fbc65c552cb85535f60a3", body.UserId);
    }

    [TestMethod]
    public async Task CreateTodoAsync_ShouldCreateTodo()
    {
        // Arrange
        var userId = "659fbc65c552cb85535f60a3";
        var createRequestDTO = new TodoCreateRequestDTO()
        {
            Description = "testing Description",
            Status = 0,
            Title = "testing Title"
        };

        var json = JsonSerializer.Serialize(createRequestDTO);
        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync($"{DOMAIN_ADDRESS}/{userId}/todo/", content);
        var body = await response.Content.ReadFromJsonAsync<TodoDTO>();

        // Assert
        Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        Assert.IsNotNull(body);
        Assert.AreEqual("testing Description", body.Description);
        Assert.AreEqual("testing Title", body.Title);
        Assert.AreEqual(TodoStatus.NEW, body.Status);
        Assert.AreEqual(userId, body.UserId);
        
    }

    [TestMethod]
    public async Task UpdateTodoAsync_ShouldUpdateTodo()
    {
        // Arrange
        var todoId = "65b121b92f4c452eda58fa79";
        var updateRequestDTO = new TodoUpdateRequestDTO()
        {
            Description = "updated by testing",
            Status = 0,
            Title = "updated by testing Title"
        };
        var json = JsonSerializer.Serialize(updateRequestDTO);
        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"{DOMAIN_ADDRESS}/todo/{todoId}", content);
        var body = await response.Content.ReadFromJsonAsync<TodoDTO?>();
        
        // Assert
        Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        Assert.AreEqual("updated by testing", body.Description);
        Assert.AreEqual(TodoStatus.NEW, body.Status);
        Assert.AreEqual("updated by testing Title", body.Title);
    }
}