using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators;

namespace TaskManagement.Application.Handlers
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, Result<NoData>>
    {
        private readonly IUserRepository _userRepository;

        public RegisterRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<NoData>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var validator = new RegisterRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var rowCount = await _userRepository.CreateUserAsync(request.ToMap());
                if (rowCount > 0)
                    return new Result<NoData>(new NoData(), true, null, null);
                return new Result<NoData>(new NoData(), false, "An error occured", null);
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(),false,null,errorList);
            }

        }
    }
}
