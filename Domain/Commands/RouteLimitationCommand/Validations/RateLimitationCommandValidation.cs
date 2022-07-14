using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteLimitationCommand.Validations
{
    public class RateLimitationCommandValidation<T> : AbstractValidator<T> where T : RateLimitationCommand
    {
        protected void ValidateSwaggerID()
        {
            RuleFor(c => c.SwaggerID)
             .NotNull()
            .NotEmpty().WithMessage("Please ensure you have entered the SwaggerID")
            .Length(36, 40).WithMessage("SwaggerID format is incorrect");
        }
        protected void ValidatePosition()
        {
            RuleFor(c => c.Position)
              .GreaterThanOrEqualTo(0).LessThanOrEqualTo(50).WithMessage("position should " +
             "between 0 and 50");
        }
    }
}
