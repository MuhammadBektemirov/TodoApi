using MediatR;
using TodoApi.User.DTOs;
using TodoApi.User.Services.Interfaces;

namespace TodoApi.User.Mediators.Queries;

public class GetUserByIdQuery
{
    public record Request(UserSignInRequestDTO RequestDto) : IRequest<UserDTO?>;
    
    public class Handler : IRequestHandler<Request, UserDTO?>
    {
        private readonly IUserService _userService;

        public Handler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO?> Handle(Request request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserAsync(request.RequestDto);
        }
    }
}