using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RouteController : ApiController
    {
        private readonly IRouteAppService _routeAppService;

        public RouteController(IRouteAppService routeAppService)
        {
            _routeAppService = routeAppService;
        }

        [HttpPost("route")]
        [Authorize]
        public async Task<ActionResult<ResultModel>> Post([FromBody] RouteInsertUpdateModel input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
               : CustomResponse(await _routeAppService.Insert(input));
        }

        [HttpPut("route")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Update([FromBody] RouteInsertUpdateModel
          input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _routeAppService.Update(input));
        }

        [HttpDelete("route")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Delete([FromBody] RouteIDPositionModel
        input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _routeAppService.Delete(input));
        }

        [HttpPost("route/enable")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Enable([FromBody] RouteIDPositionModel
      input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _routeAppService.Enable(input));
        }

        [HttpPost("route/disable")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Disable([FromBody] RouteIDPositionModel
      input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _routeAppService.Disable(input));
        }
    }
}
