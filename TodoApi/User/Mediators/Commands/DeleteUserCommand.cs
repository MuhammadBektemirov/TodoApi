using MediatR;
using TodoApi.User.DTOs;
using TodoApi.User.Services.Interfaces;

namespace TodoApi.User.Mediators.Commands;

public class DeleteUserCommand
{
    public record Request(string id) : IRequest;

    public class Handler : IRequestHandler<Request>
    {
        private readonly IUserService _userService;

        public Handler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task? Handle(Request request, CancellationToken cancellationToken)
        {
            await _userService.DeleteUserAsync(request.id);
        }
    }
}