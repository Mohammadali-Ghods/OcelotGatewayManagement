using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.RouteLimition;
using AutoMapper;
using Domain.Commands.RouteLimitationCommand;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RouteLimitionAppService : IRouteLimitionAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ISwaggerEndPointRepository _repository;

        public RouteLimitionAppService(IMapper mapper,
                                  IMediator mediator,
                                  ISwaggerEndPointRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel> Update(RouteLimitationInsertUpdateModel input)
        {
            var command = await _mediator.Send(new UpdateLimitationCommand(input.SwaggerID,
                input.PeriodTimeSpan,input.Limit,input.Position,input.Period));

            return new ResultModel() { FailedResults = command.FailedResults };
        }
    }
}
