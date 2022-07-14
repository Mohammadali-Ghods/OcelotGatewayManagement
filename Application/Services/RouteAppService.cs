using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Routing;
using AutoMapper;
using Domain.Commands.RouteCommand;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RouteAppService : IRouteAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ISwaggerEndPointRepository _repository;

        public RouteAppService(IMapper mapper,
                                  IMediator mediator,
                                  ISwaggerEndPointRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<ResultModel> Delete(RouteIDPositionModel input)
        {
            var command = await _mediator.Send(new DeleteRouteCommand(input.Position,input.SwaggerID));
            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public async Task<ResultModel> Disable(RouteIDPositionModel input)
        {
            var command = await _mediator.Send(new DisableRouteCommand(input.Position, input.SwaggerID));
            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel> Enable(RouteIDPositionModel input)
        {
            var command = await _mediator.Send(new EnableRouteCommand(input.Position, input.SwaggerID));
            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public async Task<ResultModel> Insert(RouteInsertUpdateModel input)
        {
            var command = await _mediator.Send(new InsertNewRouteCommand(input.DownstreamPathTemplate
                , input.DownstreamScheme,input.DownstreamHost,input.DownstreamPort,input.UpstreamPathTemplate,
                input.UpstreamHttpMethod,input.SwaggerID));

            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public async Task<ResultModel> Update(RouteInsertUpdateModel input)
        {
            var command = await _mediator.Send(new UpdateRouteCommand(input.DownstreamPathTemplate
                , input.DownstreamScheme, input.DownstreamHost, input.DownstreamPort, input.UpstreamPathTemplate,
                input.UpstreamHttpMethod, input.SwaggerID,input.Position));

            return new ResultModel() { FailedResults = command.FailedResults };
        }
    }
}
