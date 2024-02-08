using MediatR;
using TodoApi.Todo.Services.Interfaces;

namespace TodoApi.Todo.Mediators.Commands;

public class DeleteTodoByIdCommand
{
    public record Request(string id) : IRequest;

    public class Handler : IRequestHandler<Request>
    {
        private readonly ITodoService _todoService;

        public Handler(ITodoService todoService)
        {
            _todoService = todoService;
        }


        public async Task? Handle(Request request, CancellationToken cancellationToken)
        {
            await _todoService.DeleteTodoAsync(request.id);
        }
    }
}