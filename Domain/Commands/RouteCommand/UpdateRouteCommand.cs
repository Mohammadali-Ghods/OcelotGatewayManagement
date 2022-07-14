
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
    public class UpdateRouteCommand : RouteCommand,
         IRequestHandler<UpdateRouteCommand, Result>
    {

        private readonly ISwaggerEndPointRepository _repository;
        private readonly IMediator _mediator;

        public UpdateRouteCommand(ISwaggerEndPointRepository repository
            , IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public UpdateRouteCommand(string downstreamPathTemplate,
             string downstreamScheme,
              string downstreamHost,
              int downstreamPort,
              string upstreamPathTemplate,
              string upstreamHttpMethod,
              string swaggerid,
              int position
             )
        {
            DownstreamPathTemplate = downstreamPathTemplate;
            DownstreamScheme = downstreamScheme;
            DownstreamHost = downstreamHost;
            DownstreamPort = downstreamPort;
            UpstreamPathTemplate = upstreamPathTemplate;
            UpstreamHttpMethod = upstreamHttpMethod;
            SwaggerID = swaggerid;
            Position=position;
        }

        public async Task<Result> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            var swagger = await _repository.Get(request.SwaggerID);

            if (swagger == null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("The specific swagger not found " +
                    "" + Guid.NewGuid().ToString(), "The specific swagger not found"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            swagger.Routes[request.Position].UpdateDownstreamHostAndPorts
                (request.DownstreamHost,request.DownstreamPort);
            swagger.Routes[request.Position].UpdateDownstreamPathTemplate(request.DownstreamPathTemplate);
            swagger.Routes[request.Position].UpdateDownstreamScheme(request.DownstreamScheme);
            swagger.Routes[request.Position].UpdateUpstreamHttpMethod(request.UpstreamHttpMethod);
            swagger.Routes[request.Position].UpdateUpstreamPathTemplate(request.UpstreamPathTemplate);

            await _repository.Update(swagger);

            return new Result();
        }
        public bool IsValid()
        {
            ValidationResult = new UpdateRouteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
