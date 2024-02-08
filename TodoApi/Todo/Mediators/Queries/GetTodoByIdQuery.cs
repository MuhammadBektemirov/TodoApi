using Amazon.Runtime.Internal;
using MediatR;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Services.Interfaces;

namespace TodoApi.Todo.Mediators.Queries;

public class GetTodoByIdQuery
{
    public record Request(string userId) : IRequest<TodoDTO>;
    
    public class Handler : IRequestHandler<Request, TodoDTO?>
    {
        private readonly ITodoService _todoService;

        public Handler(ITodoService todoService)
        {
            _todoService = todoService;
        }


        public async Task<TodoDTO?> Handle(Request request, CancellationToken cancellationToken)
        {
            return await _todoService.GetTodoAsync(request.userId);
        }
    }
    
}