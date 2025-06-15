using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Suitability.Domain.Interfaces.Service;

namespace Suitability.Api.Controllers
{
    [ApiController]
    [EnableCors("All")]
    public class DocumentStatusController : ControllerBase
    {
        private readonly IDocumentService _accService;
        public DocumentStatusController(IDocumentService accService)
        {
            _accService = accService;
        }

        [Route("health")]
        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {            
            return Ok(new[] {"Document Service Health Sucess"});
        }

        [HttpGet("GetDocument")]
        public async Task<IActionResult> GetSteamIdByName(string Document_number)
        {
            var user = await _accService.GetById(Document_number);
            return Ok(user);
        }

        [HttpPost("InsertDocument")]
        public async Task<IActionResult> InsertUser(Domain.Entities.Document user)
        {
            await _accService.Insert(user);

            return Ok(user);
        }
    }
}
