using Domain.Commands.RouteLimitationCommand.Validations;
using Domain.Interfaces;
using Domain.ResultModel;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.RouteLimitationCommand
{
    public class UpdateLimitationCommand : RateLimitationCommand,
         IRequestHandler<UpdateLimitationCommand, Result>
    {
        private readonly ISwaggerEndPointRepository _repository;
        private readonly IMediator _mediator;

        public UpdateLimitationCommand(ISwaggerEndPointRepository repository
            , IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public UpdateLimitationCommand(string swaggerid,int periodtimespan,int limit,int position,string period)
        {
            SwaggerID = swaggerid;
            PeriodTimeSpan = periodtimespan;
            Limit = limit;
            Position = position;
            Period = period;
        }
        public async Task<Result> Handle(UpdateLimitationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            var swagger = await _repository.Get(request.SwaggerID);

            if (swagger == null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("The specific swagger not found " +
                    "" + Guid.NewGuid().ToString(), "The specific swagger not found"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            swagger.Routes[request.Position].
                UpdateRateLimitOptions(request.Period, request.Limit, request.Position);

            await _repository.Update(swagger);

            return new Result();
        }

        public bool IsValid()
        {
            ValidationResult = new UpdateLimitationCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
