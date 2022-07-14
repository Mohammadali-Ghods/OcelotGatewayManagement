using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PublishAppService : IPublishAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ISwaggerEndPointRepository _repository;

        public PublishAppService(IMapper mapper,
                                  IMediator mediator,
                                  ISwaggerEndPointRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<ResultModel> CreateFinalGatewayJson()
        {
            var AllRouting= await _repository.GetAll();

            GatewayViewModel finalmodel = new GatewayViewModel();
            finalmodel.GlobalConfiguration = new GlobalConfiguration();
            finalmodel.GlobalConfiguration.BaseUrl = "https://gateway.diffancy.com";
            finalmodel.Routes = new List<RouteViewModel>();
            finalmodel.SwaggerEndPoints = new List<SwaggerEndPoint>();

            for (int i = 0; i <= AllRouting.Count - 1; i++) 
            {
                finalmodel.SwaggerEndPoints.Add(new SwaggerEndPoint()
                {
                    Config = AllRouting[i].Config,
                    Key = AllRouting[i].ID
                });

                for (int j = 0; j <= AllRouting[i].Routes.Count - 1; j++) 
                {
                    finalmodel.Routes.Add(new RouteViewModel() 
                    {
                        SwaggerKey= AllRouting[i].ID,
                        DownstreamScheme= AllRouting[i].Routes[j].DownstreamScheme,
                        DownstreamHostAndPorts= AllRouting[i].Routes[j].DownstreamHostAndPorts,
                        DownstreamPathTemplate= AllRouting[i].Routes[j].DownstreamPathTemplate,
                        RateLimitOptions= AllRouting[i].Routes[j].RateLimitOptions,
                        UpstreamHttpMethod = AllRouting[i].Routes[j].UpstreamHttpMethod,
                        UpstreamPathTemplate= AllRouting[i].Routes[j].UpstreamPathTemplate
                    });
                }
            }

            return new ResultModel() {FinalJson= JsonConvert.SerializeObject(finalmodel) };
        }
    }
}
