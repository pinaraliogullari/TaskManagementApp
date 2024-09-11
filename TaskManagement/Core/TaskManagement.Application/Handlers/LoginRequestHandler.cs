using MediatR;
using TaskManagement.Application.Dtos;
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
                return new Result<LoginResponseDto?>(new LoginResponseDto("","",1),true,null,null);
            }
            else
            {
                var errors = validationResult.Errors.ToList();
                var errorList= new List<ValidationError>();
                foreach ( var error in errors)
                {
                    errorList.Add(new ValidationError
                    (
                        error.PropertyName,
                        error.ErrorMessage
                    ));
                }
                    return new Result<LoginResponseDto?>(null, false, "An error occured", errorList);
               
            }

           
        }
    }
}
