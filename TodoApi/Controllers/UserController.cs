using System.Security.Cryptography;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;
using TodoApi.User.DTOs;
using TodoApi.User.Mediators.Commands;
using TodoApi.User.Mediators.Queries;
using TodoApi.User.Models;
using TodoApi.User.Services.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("user")]
        public async Task<UserDTO> CreateUserAsync(UserSignInRequestDTO request)
        {
            var query = new CreateUserCommand.Request(request);

            return await _mediator.Send(query);
        }

        [HttpPut("user/{id:length(24)}")]
        public async Task<UserDTO?> UpdateUserAsync(string id, UserUpdateRequestDTO request)
        {
            var query = new UpdateUserCommand.Request(id, request);
        
            return await _mediator.Send(query);
        }

        [HttpGet("users")]
        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var query = new GetAllUsersQuery.Request();

            return await _mediator.Send(query);
        }

        [HttpPost("user/verify")]
        public async Task<UserDTO?> GetUserAsync(UserSignInRequestDTO requestDto)
        {
            var query = new GetUserByIdQuery.Request(requestDto);

            return await _mediator.Send(query);
        }

        [HttpDelete("user/{id:length(24)}")]
        public async Task? DeleteUserAsync(string id)
        {
            var query = new DeleteUserCommand.Request(id);
        
            await _mediator.Send(query);
        }
    }
}