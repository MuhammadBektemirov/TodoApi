using MediatR;
using TodoApi.User.DTOs;
using TodoApi.User.Services.Interfaces;

namespace TodoApi.User.Mediators.Commands;

public class UpdateUserCommand
{
    public record Request(string id, UserUpdateRequestDTO UserUpdateRequestDto) : IRequest<UserDTO?>;

    public class Handler : IRequestHandler<Request, UserDTO?>
    {
        private readonly IUserService _userService;

        public Handler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO?> Handle(Request request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUserAsync(request.id, request.UserUpdateRequestDto);
        }
    }
}