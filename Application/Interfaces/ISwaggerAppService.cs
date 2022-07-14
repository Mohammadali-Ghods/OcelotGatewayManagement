using Application.ViewModel;
using Application.ViewModel.Swagger;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISwaggerAppService : IDisposable
    {
        Task<List<Domain.Models.SwaggerEndPoint>> GetAll();
        Task<Domain.Models.SwaggerEndPoint> GetById(string id);
        Task<ResultModel> Insert(SwaggerInsertUpdateModel input);
        Task<ResultModel> Update(SwaggerInsertUpdateModel input);
        Task<ResultModel> Delete(SwaggerIDModel input);
        Task<ResultModel> Enable(SwaggerIDModel input);
        Task<ResultModel> Disable(SwaggerIDModel input);
    }
}
