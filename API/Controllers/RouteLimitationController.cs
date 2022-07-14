using Application.Interfaces;
using Application.ViewModel;
using Application.ViewModel.RouteLimition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteLimitationController : ApiController
    {
        private readonly IRouteLimitionAppService _routeLimitationAppService;

        public RouteLimitationController(IRouteLimitionAppService routeLimitationAppService)
        {
            _routeLimitationAppService = routeLimitationAppService;
        }

        [HttpPut("routelimitation")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResultModel>> Update([FromBody] RouteLimitationInsertUpdateModel
         input)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
              : CustomResponse(await _routeLimitationAppService.Update(input));
        }
    }
}
