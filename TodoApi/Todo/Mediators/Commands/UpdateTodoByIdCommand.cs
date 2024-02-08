using MediatR;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Services.Interfaces;

namespace TodoApi.Todo.Mediators.Commands;

public class UpdateTodoByIdCommand
{
    public record Request(string id, TodoUpdateRequestDTO UpdateRequest) : IRequest<TodoDTO?>;
    
    public class Handler : IRequestHandler<Request, TodoDTO?>
    {
        private readonly ITodoService _todoService;

        public Handler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<TodoDTO?> Handle(Request request, CancellationToken cancellationToken)
        {
            return await _todoService.UpdateTodoAsync(request.id, request.UpdateRequest);
        }
    }
}