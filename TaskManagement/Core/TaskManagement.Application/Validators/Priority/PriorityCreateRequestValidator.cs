using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators
{
    public class PriorityCreateRequestValidator : AbstractValidator<PriorityCreateRequest>
    {
        public PriorityCreateRequestValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition can not be empty.");
        }
    }
}
