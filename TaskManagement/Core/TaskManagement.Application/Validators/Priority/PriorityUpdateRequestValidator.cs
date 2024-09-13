using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators.Priority
{
    public class PriorityUpdateRequestValidator : AbstractValidator<PriorityUpdateRequest>
    {
        public PriorityUpdateRequestValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition cannot be empty");
        }
    }
}
