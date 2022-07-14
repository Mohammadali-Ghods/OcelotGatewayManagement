using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteCommand.Validations
{
    public class RouteCommandValidation<T> : AbstractValidator<T> where T : RouteCommand
    {
        protected void ValidateDownStreamPathTemplate()
        {
            RuleFor(c => c.DownstreamPathTemplate)
              .MinimumLength(4).MaximumLength(100).WithMessage("Lenght should" +
              "between 4 and 100");
        }
        protected void ValidateUpStreamPathTemplate()
        {
            RuleFor(c => c.UpstreamPathTemplate)
              .MinimumLength(4).MaximumLength(100).WithMessage("Lenght should" +
              "between 4 and 100");
        }
        protected void ValidateDownstreamPort()
        {
            RuleFor(c => c.DownstreamPort)
             .GreaterThanOrEqualTo(1000).LessThanOrEqualTo(60000).WithMessage("port should " +
             "between 1000 and 60000");
        }
        protected void ValidateUpStreamHttpMethod()
        {
            List<string> conditionforhttpmethod = new List<string>() { "Post", "Get", "Put", "Delete" };

            RuleFor(x1 => x1.UpstreamHttpMethod).Must(x1 =>
            conditionforhttpmethod.Contains(x1)).NotEmpty().NotNull().WithMessage("UpStreamHttpMethod invalid");
        }
        protected void ValidateDownStreamScheme()
        {
            List<string> conditionfordownstreamscheme = new List<string>() { "http", "https"};

            RuleFor(x1 => x1.DownstreamScheme).Must(x1 =>
            conditionfordownstreamscheme.Contains(x1)).NotEmpty().NotNull().WithMessage("DownstreamScheme invalid");
        }
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
