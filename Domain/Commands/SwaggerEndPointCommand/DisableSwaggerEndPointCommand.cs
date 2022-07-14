using Domain.Commands.SwaggerEndPointCommand.Validations;
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

namespace Domain.Commands.SwaggerEndPointCommand
{
    public class DisableSwaggerEndPointCommand:SwaggerEndPointCommand,
        IRequestHandler<DisableSwaggerEndPointCommand, Result>
    {
        private readonly ISwaggerEndPointRepository _repository;
        private readonly IMediator _mediator;

        public DisableSwaggerEndPointCommand(ISwaggerEndPointRepository repository
            , IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public DisableSwaggerEndPointCommand(string swaggerid) 
        {
            SwaggerID = swaggerid;
        }
        public async Task<Result> Handle(DisableSwaggerEndPointCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            var swagger = await _repository.Get(request.SwaggerID);
            if (swagger == null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("The specific swagger not found " +
                    "" + Guid.NewGuid().ToString(), "The specific swagger not found"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            swagger.Disable();

            await _repository.Update(swagger);

            return new Result() { };
        }

        public bool IsValid()
        {
            ValidationResult = new DisableSwaggerEndPointCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
