using Application.Interfaces;
using Application.Services;
using Domain.Events;
using Domain.Interfaces;
using Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Entities;
using Bus;
using MassTransit;
using System;
using Domain.ResultModel;
using Microsoft.Extensions.Options;
using Domain.Events.EventsHandler;
using StackExchange.Redis;
using ExternalApi.TokenService;
using Domain.Models;
using Domain.Commands.RouteCommand;
using Domain.Commands.RouteLimitationCommand;
using Domain.Commands.SwaggerEndPointCommand;

namespace IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ISwaggerAppService, SwaggerAppService>();
            services.AddScoped<IRouteAppService, RouteAppService>();
            services.AddScoped<IRouteLimitionAppService, RouteLimitionAppService>();
            services.AddScoped<IPublishAppService, PublishAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<SMSRequestedEvent>, NotificationEventsHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<DeleteRouteCommand, Result>, DeleteRouteCommand>();
            services.AddScoped<IRequestHandler<DisableRouteCommand, Result>, DisableRouteCommand>();
            services.AddScoped<IRequestHandler<EnableRouteCommand, Result>, EnableRouteCommand>();
            services.AddScoped<IRequestHandler<InsertNewRouteCommand, Result>, InsertNewRouteCommand>();
            services.AddScoped<IRequestHandler<UpdateRouteCommand, Result>, UpdateRouteCommand>();
            services.AddScoped<IRequestHandler<UpdateLimitationCommand, Result>, UpdateLimitationCommand>();
            services.AddScoped<IRequestHandler<DeleteSwaggerEndPointCommand, Result>, DeleteSwaggerEndPointCommand>();
            services.AddScoped<IRequestHandler<DisableSwaggerEndPointCommand, Result>, DisableSwaggerEndPointCommand>();
            services.AddScoped<IRequestHandler<EnableSwaggerEndPointCommand, Result>, EnableSwaggerEndPointCommand>();
            services.AddScoped<IRequestHandler<InsertSwaggerEndPointCommand, Result>, InsertSwaggerEndPointCommand>();
            services.AddScoped<IRequestHandler<UpdateSwaggerEndPointCommand, Result>, UpdateSwaggerEndPointCommand>();

            // Infra - Data
            services.AddScoped<ISwaggerEndPointRepository, SwaggerEndPointRepository>();
           
            //Infra - ExternalAPI
            services.AddScoped<ISwtToken, SwtToken>();

            // Infra - Bus
            services.AddScoped<IMessageBus, RabbitMQMessageHandler>();
            // Infra - ExternalAPI


        }
    }
}