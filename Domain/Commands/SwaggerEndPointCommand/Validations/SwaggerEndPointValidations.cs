using FluentValidation;
using System;
using System.Collections.Generic;

namespace Domain.Commands.SwaggerEndPointCommand.Validations
{
    public class SwaggerEndPointValidations<T> : AbstractValidator<T> where T : SwaggerEndPointCommand
    {
        protected void ValidateID()
        {
            RuleFor(c => c.SwaggerID)
               .NotNull()
              .NotEmpty().WithMessage("Please ensure you have entered the ID")
              .Length(36, 40).WithMessage("ID format is incorrect");
        }
    }
}
