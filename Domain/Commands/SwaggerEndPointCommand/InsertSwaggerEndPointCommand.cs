using Domain.Commands.SwaggerEndPointCommand.Validations;
using Domain.Interfaces;
using Domain.Models;
using Domain.ResultModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.SwaggerEndPointCommand
{
    public class InsertSwaggerEndPointCommand : SwaggerEndPointCommand,
        IRequestHandler<InsertSwaggerEndPointCommand, Result>
    {
        private readonly ISwaggerEndPointRepository _repository;
        private readonly IMediator _mediator;

        public InsertSwaggerEndPointCommand(ISwaggerEndPointRepository repository
            , IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public InsertSwaggerEndPointCommand(string swaggerid, string name, string version, string url)
        {
            SwaggerID = swaggerid;
            Name = name;
            Version = version;
            Url = url;
        }
        public bool IsValid()
        {
            ValidationResult = new InsertSwaggerEndPointCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public async Task<Result> Handle(InsertSwaggerEndPointCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

            await _repository.Insert(new SwaggerEndPoint(request.SwaggerID, request.Name, request.Version,
                request.Url));

            return new Result() { };
        }
    }
}
