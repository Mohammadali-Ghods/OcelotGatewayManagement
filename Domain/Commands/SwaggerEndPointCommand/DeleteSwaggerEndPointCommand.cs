using Domain.Commands.SwaggerEndPointCommand.Validations;
using Domain.Interfaces;
using Domain.Models;
using Domain.ResultModel;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.SwaggerEndPointCommand
{
    public class DeleteSwaggerEndPointCommand : SwaggerEndPointCommand,
         IRequestHandler<DeleteSwaggerEndPointCommand, Result>
    {
        private readonly ISwaggerEndPointRepository _repository;
        private readonly IMediator _mediator;

        public DeleteSwaggerEndPointCommand(ISwaggerEndPointRepository repository
            , IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public DeleteSwaggerEndPointCommand(string swaggerid) 
        {
            SwaggerID= swaggerid;
        }
        public async Task<Result> Handle(DeleteSwaggerEndPointCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            var swagger = await _repository.Get(request.SwaggerID);
            if (swagger == null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("The specific gift not found " +
                    "" + Guid.NewGuid().ToString(), "The specific gift not found"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            if (swagger.Routes != null && swagger.Routes.Count != 0) 
            {
                request.ValidationResult.Errors.Add(new ValidationFailure("This swagger has routes and " +
                   "you cannot delete it" + Guid.NewGuid().ToString(), "This swagger has routes and cannot delete it"));
                return new Result() { FailedResults = request.ValidationResult };
            }

            await _repository.Delete(swagger);
            return new Result() { };
        }

        public bool IsValid()
        {
            ValidationResult = new DeleteSwaggerEndPointCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
