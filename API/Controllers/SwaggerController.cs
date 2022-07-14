using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Swagger;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class SwaggerController : ApiController
    {
        private readonly ISwaggerAppService _swaggerAppService;

        public SwaggerController(ISwaggerAppService swaggerAppService)
        {
            _swaggerAppService = swaggerAppService;
        }

        [HttpGet("swagger")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Domain.Models.SwaggerEndPoint>> Get()
        {
            return await _swaggerAppService.GetAll();
        }

        [HttpGet("swagger/{id:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<Domain.Models.SwaggerEndPoint> Get(string id)
        {
            return await _swaggerAppService.GetById(id);
        }

        [HttpPost("swagger")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Post([FromBody] SwaggerInsertUpdateModel input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
               : CustomResponse(await _swaggerAppService.Insert(input));
        }

        [HttpPut("swagger")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Update([FromBody] SwaggerInsertUpdateModel
          input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _swaggerAppService.Update(input));
        }

        [HttpDelete("swagger")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Delete([FromBody] SwaggerIDModel
        input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _swaggerAppService.Delete(input));
        }

        [HttpPost("swagger/enable")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Enable([FromBody] SwaggerIDModel
      input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _swaggerAppService.Enable(input));
        }

        [HttpPost("swagger/disable")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Disable([FromBody] SwaggerIDModel
      input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _swaggerAppService.Disable(input));
        }
    }
}
