﻿using FluentValidation.Results;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Extensions
{
    public static class ValidationExtension
    {
        public static List<ValidationError> ToMap(this List<ValidationFailure> errors)
        {
            var errorList = new List<ValidationError>();
            foreach (var error in errors)
            {
                errorList.Add(new ValidationError
                (
                    error.PropertyName,
                    error.ErrorMessage
                ));
            }
            return errorList;
        }
    }
}
