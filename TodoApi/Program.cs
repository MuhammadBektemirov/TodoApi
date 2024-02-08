using System.Reflection;
using TodoApi.Services;
using TodoApi.Shared.Extensions;
using TodoApi.Shared.Middlewares;
using TodoApi.Todo.Repositories;
using TodoApi.Todo.Repositories.Interfaces;
using TodoApi.Todo.Services;
using TodoApi.Todo.Services.Interfaces;
using TodoApi.User.Repositories;
using TodoApi.User.Repositories.Interfaces;
using TodoApi.User.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterMongoClientWithOptions(builder.Configuration);

builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers().AddJsonOptions(opt => { opt.JsonSerializerOptions.IgnoreNullValues = true; });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseMiddleware<ExceptionHandler>();

app.Run();