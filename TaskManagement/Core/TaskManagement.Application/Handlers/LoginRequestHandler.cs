using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators;

namespace TaskManagement.Application.Handlers
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, Result<LoginResponseDto?>>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<LoginResponseDto?>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var validator = new LoginRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _userRepository.GetByFilter(x => x.Password == request.Password && x.Username == request.Username);
                if (user is not null)
                    return new Result<LoginResponseDto?>(new LoginResponseDto(user.Name, user.Surname, user.AppRoleId), true, null, null);

                return new Result<LoginResponseDto?>(null, false, "Username or password incorrect", null);
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Result<LoginResponseDto?>(null, false, null, errorList);

            }


        }
    }
}
