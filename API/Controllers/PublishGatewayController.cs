using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishGatewayController : ApiController
    {
        private readonly IPublishAppService _publishAppService;

        public PublishGatewayController(IPublishAppService publishAppService)
        {
            _publishAppService = publishAppService;
        }

        [HttpPost("publish")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post()
        {
            var result = await _publishAppService.CreateFinalGatewayJson();
            System.IO.File.WriteAllText("Ocelot/ocelot.json", result.FinalJson);
            return Ok();
        }
    }
}
