﻿using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}
