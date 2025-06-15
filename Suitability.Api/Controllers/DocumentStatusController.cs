using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Suitability.Domain.Interfaces.Service;

namespace Suitability.Api.Controllers
{
    [ApiController]
    [EnableCors("All")]
    public class DocumentStatusController : ControllerBase
    {
        private readonly IDocumentService _docstService;
        public DocumentStatusController(IDocumentService docstService)
        {
            _docstService = docstService;
        }

        [HttpGet("GetDocumentStatus")]
        public async Task<IActionResult> GetSteamIdByName(string Document_number)
        {
            var user = await _docstService.GetById(Document_number);
            return Ok(user);
        }

        [HttpPost("InsertDocumentStatus")]
        public async Task<IActionResult> InsertUser(Domain.Entities.Document user)
        {
            await _docstService.Insert(user);

            return Ok(user);
        }
    }
}
