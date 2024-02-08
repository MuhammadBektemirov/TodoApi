using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Todo.DTOs;
using TodoApi.Todo.Mediators.Commands;
using TodoApi.Todo.Mediators.Queries;
using TodoApi.Todo.Services.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{userId:length(24)}/todo")]
        public async Task<TodoDTO> CreateTodoAsync(string userId,
            [FromBody] TodoCreateRequestDTO request
        )
        {
            var query = new CreateTodoByUserIdCommand.Request(userId, request);

            return await _mediator.Send(query);
        }

        [HttpGet("users/{userId:length(24)}/todos")]
        public async Task<List<TodoDTO>> GetTodosAsync(string userId)
        {
            var query = new GetAllTodosQuery.Request(userId);
            
            return await _mediator.Send(query);
        }

        [HttpGet("todo/{id:length(24)}")]
        public async Task<TodoDTO?> GetTodoAsync(string id)
        {
            var query = new GetTodoByIdQuery.Request(id);

            return await _mediator.Send(query);
        }

        [HttpPut("todo/{id:length(24)}")]
        public async Task<TodoDTO?> UpdateTodoAsync(string id, TodoUpdateRequestDTO request)
        {
            var query = new UpdateTodoByIdCommand.Request(id, request);

            return await _mediator.Send(query);
        }

        [HttpDelete("todo/{id:length(24)}")]
        public async Task? DeleteTodoAsync(string id)
        {
            var query = new DeleteTodoByIdCommand.Request(id);

            await _mediator.Send(query);
        }
    }
}