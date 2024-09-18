using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators;

public class AppTaskCreateRequestValidator : AbstractValidator<AppTaskCreateRequest>
{
    public AppTaskCreateRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be empty.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty.");
    }
}
