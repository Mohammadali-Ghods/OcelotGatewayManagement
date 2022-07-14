using Domain.Commands.RouteCommand.Validations;
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

namespace Domain.Commands.RouteCommand
{
    public class EnableRouteCommand : RouteCommand,
         IRequestHandler<EnableRouteCommand, Result>
    {
        private readonly ISwaggerEndPointRepository _repository;
        private readonly IMediator _mediator;

        public EnableRouteCommand(ISwaggerEndPointRepository repository
            , IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public EnableRouteCommand(int position,
            string swaggerid
           )
        {
            SwaggerID = swaggerid;
            Position = position;
        }

        public async Task<Result> Handle(EnableRouteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            var swagger = await _repository.Get(request.SwaggerID);

            if (swagger == null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("The specific swagger not found " +
                    "" + Guid.NewGuid().ToString(), "The specific swagger not found"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            swagger.Routes[request.Position].Enable();

            await _repository.Update(swagger);

            return new Result();
        }
        public bool IsValid()
        {
            ValidationResult = new EnableRouteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
