using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Swagger;
using AutoMapper;
using Domain.Commands.SwaggerEndPointCommand;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SwaggerAppService : ISwaggerAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ISwaggerEndPointRepository _repository;

        public SwaggerAppService(IMapper mapper,
                                  IMediator mediator,
                                  ISwaggerEndPointRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<ResultModel> Delete(SwaggerIDModel input)
        {
            var command = await _mediator.Send(new DeleteSwaggerEndPointCommand(input.SwaggerID));
            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public async Task<ResultModel> Disable(SwaggerIDModel input)
        {
            var command = await _mediator.Send(new DisableSwaggerEndPointCommand(input.SwaggerID));
            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel> Enable(SwaggerIDModel input)
        {
            var command = await _mediator.Send(new EnableSwaggerEndPointCommand(input.SwaggerID));
            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public async Task<List<Domain.Models.SwaggerEndPoint>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Domain.Models.SwaggerEndPoint> GetById(string id)
        {
            return await _repository.Get(id);
        }

        public async Task<ResultModel> Insert(SwaggerInsertUpdateModel input)
        {
            input.SwaggerID = Guid.NewGuid().ToString();

            var command = await _mediator.Send(new InsertSwaggerEndPointCommand(input.SwaggerID,
                input.Name,input.Version,input.Url));

            return new ResultModel() { FailedResults = command.FailedResults };
        }

        public async Task<ResultModel> Update(SwaggerInsertUpdateModel input)
        {
            var command = await _mediator.Send(new UpdateSwaggerEndPointCommand(input.SwaggerID,
               input.Name, input.Version, input.Url));

            return new ResultModel() { FailedResults = command.FailedResults };
        }
    }
}
