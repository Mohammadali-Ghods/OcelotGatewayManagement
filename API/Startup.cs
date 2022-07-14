using API.Configurations;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Entities;
using System;
using Bus.ConfigurationModel;
using GreenPipes;
using Domain.Events;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Text;
using Application.Services;
using ExternalApi.ConfigurationModel;
using StackExchange.Redis;
using ExternalApi.TokenService;

namespace API
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath)
                   .AddJsonFile("AppSetting/appsettings.json", true, true)
                   .AddJsonFile($"AppSetting/appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Authentication DI
            var key= Encoding.ASCII.GetBytes(Configuration.GetSection("Keys")["Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = false;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });



            //Configuration Models
            services.Configure<RabbitMQModel>(Configuration.GetSection("RabbitMQ"));
            services.Configure<ExretnalApiModel>(Configuration.GetSection("ExternalApi"));
            services.Configure<SecretKeyModel>(Configuration.GetSection("Keys"));
            // MongoDB
            string DatabaseName = Configuration.GetSection("Database")["DatabaseName"];
            string DatabaseAddress = Configuration.GetSection("Database")["DatabaseAddress"];
            string DatabasePort = Configuration.GetSection("Database")["DatabasePort"];
            DB.InitAsync(DatabaseName, DatabaseAddress, int.Parse(DatabasePort));

            //RabbitMQ
            string RabbitMQUserName = Configuration.GetSection("RabbitMQ")["UserName"];
            string RabbitMQPassword = Configuration.GetSection("RabbitMQ")["Password"];
            string RabbitMQAddress = Configuration.GetSection("RabbitMQ")["Address"];

            //services.AddMassTransit(x =>
            //{
            //    x.AddBus(provider => MassTransit.Bus.Factory.CreateUsingRabbitMq(confige =>
            //    {
            //        confige.Host(new Uri(RabbitMQAddress), h =>
            //        {
            //            h.Username(RabbitMQUserName);
            //            h.Password(RabbitMQPassword);
            //        });
            //    }));
                
            //});

            //services.AddMassTransitHostedService();
            // WebAPI Config
            services.AddControllers();

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}
