using MediatR;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Services.Interfaces;

namespace TodoApi.Todo.Mediators.Queries;

public class GetAllTodosQuery
{
    public record Request(string UserId) : IRequest<List<TodoDTO>>;
    
    public class Handler : IRequestHandler<Request, List<TodoDTO>>
    {
        private readonly ITodoService _todoService;
        
        public Handler(ITodoService todoService)
        {
            _todoService = todoService;
        }
        
        public async Task<List<TodoDTO>> Handle(Request request, CancellationToken cancellationToken)
        {
            return await _todoService.GetTodosAsync(request.UserId);
        }
    }
}