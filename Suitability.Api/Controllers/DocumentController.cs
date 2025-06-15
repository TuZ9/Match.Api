using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Suitability.Domain.Interfaces.Service;

namespace Suitability.Api.Controllers
{
    [ApiController]
    [EnableCors("All")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _docService;
        public DocumentController(IDocumentService docService)
        {
            _docService = docService;
        }

        [HttpGet("GetDocument")]
        public async Task<IActionResult> GetSteamIdByName(string Document_number)
        {
            var user = await _docService.GetById(Document_number);
            return Ok(user);
        }

        [HttpPost("InsertDocument")]
        public async Task<IActionResult> InsertUser(Domain.Entities.Document user)
        {
            await _docService.Insert(user);

            return Ok(user);
        }
    }
}
