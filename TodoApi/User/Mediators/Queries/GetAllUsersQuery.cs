using MediatR;
using TodoApi.User.DTOs;
using TodoApi.User.Services.Interfaces;

namespace TodoApi.User.Mediators.Queries;

public class GetAllUsersQuery
{
    public record Request() : IRequest<List<UserDTO>>;

    public class Handler : IRequestHandler<Request, List<UserDTO>>
    {
        private readonly IUserService _userService;

        public Handler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<List<UserDTO>> Handle(Request request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsersAsync();
        }
    }
}