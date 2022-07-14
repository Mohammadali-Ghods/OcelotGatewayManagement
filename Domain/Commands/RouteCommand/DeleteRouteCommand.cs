
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
    public class DeleteRouteCommand : RouteCommand,
         IRequestHandler<DeleteRouteCommand, Result>
    {
        private readonly ISwaggerEndPointRepository _repository;
        private readonly IMediator _mediator;

        public DeleteRouteCommand(ISwaggerEndPointRepository repository
            , IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public DeleteRouteCommand(int position,
            string swaggerid
           )
        {
            SwaggerID = swaggerid;
            Position = position;
        }

        public async Task<Result> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            var swagger = await _repository.Get(request.SwaggerID);

            if (swagger == null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("The specific swagger not found " +
                    "" + Guid.NewGuid().ToString(), "The specific swagger not found"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            swagger.Routes.RemoveAt(request.Position);

            await _repository.Update(swagger);

            return new Result();
        }
        public bool IsValid()
        {
            ValidationResult = new DeleteRouteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
