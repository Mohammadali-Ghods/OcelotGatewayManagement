
using Domain.Commands.RouteCommand.Validations;
using Domain.Interfaces;
using Domain.Models;
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
    public class InsertNewRouteCommand : RouteCommand,
          IRequestHandler<InsertNewRouteCommand, Result>
    {
        private readonly ISwaggerEndPointRepository _swaggerrepository;
        private readonly IMediator _mediator;

        public InsertNewRouteCommand( IMediator mediator
            ,ISwaggerEndPointRepository swaggerrepository)
        {
            _mediator = mediator;
            _swaggerrepository = swaggerrepository;
        }

        public InsertNewRouteCommand(string downstreamPathTemplate,
            string downstreamScheme,
             string downstreamHost,
             int downstreamPort,
             string upstreamPathTemplate,
             string upstreamHttpMethod,
             string swaggerKey
            )
        {
            DownstreamPathTemplate = downstreamPathTemplate;
            DownstreamScheme = downstreamScheme;
            DownstreamHost = downstreamHost;
            DownstreamPort = downstreamPort;
            UpstreamPathTemplate = upstreamPathTemplate;
            UpstreamHttpMethod = upstreamHttpMethod;
            SwaggerID = swaggerKey;
        }
        public async Task<Result> Handle(InsertNewRouteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            var swagger= await _swaggerrepository.Get(request.SwaggerID);

            if (swagger == null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("The specific swagger not found " +
                    "" + Guid.NewGuid().ToString(), "The specific swagger not found"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            swagger.Routes.Add(new Route(request.DownstreamPathTemplate, request.DownstreamScheme,
                request.DownstreamHost, request.DownstreamPort, request.UpstreamPathTemplate,
                request.UpstreamHttpMethod));

            await _swaggerrepository.Update(swagger);

            return new Result();
        }
        public bool IsValid()
        {
            ValidationResult = new InsertNewRouteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

}
