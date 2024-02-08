using MediatR;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Services.Interfaces;

namespace TodoApi.Todo.Mediators.Commands;

public class CreateTodoByUserIdCommand
{
    public record Request(string userId, TodoCreateRequestDTO createRequest): IRequest<TodoDTO>;

    public class Handler : IRequestHandler<Request, TodoDTO>
    {
        private readonly ITodoService _todoService;

        public Handler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<TodoDTO> Handle(Request request, CancellationToken cancellationToken)
        {
            return await _todoService.CreateTodoAsync(request.userId, request.createRequest);
        }
    }
}