using Domain.ResultModel;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteLimitationCommand
{
    public class RateLimitationCommand : IRequest<Result>
    {
        public string Period { get; protected set; }
        public int PeriodTimeSpan { get; protected set; }
        public int Limit { get; protected set; }
        public int Position { get; protected set; }
        public string SwaggerID { get; protected set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
