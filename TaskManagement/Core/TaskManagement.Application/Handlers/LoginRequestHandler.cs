using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, Result<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Result<LoginResponseDto>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
