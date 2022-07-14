using Domain.Interfaces;
using Domain.Models;
using Domain.ResultModel;
using Domain.ValueObject;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;

namespace Domain.Commands.SwaggerEndPointCommand
{
    public class SwaggerEndPointCommand : IRequest<Result>
    {
        public string SwaggerID { get; protected set; }
        public string Name { get; protected set; }
        public string Version { get; protected set; }
        public string Url { get; protected set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
