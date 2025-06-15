using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Suitability.Domain.Interfaces.Service;

namespace Suitability.Api.Controllers
{
    [ApiController]
    [EnableCors("All")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accService;
        public AccountController(IAccountService accService)
        {
            _accService = accService;
        }

        [Route("health")]
        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {            
            return Ok(new[] {"Account Service Health Sucess"});
        }

        [HttpGet("GetAccount")]
        public async Task<IActionResult> GetSteamIdByName(string account_number)
        {
            var user = await _accService.GetSingleById(account_number);
            return Ok(user);
        }

        [HttpPost("InsertAccount")]
        public async Task<IActionResult> InsertUser(Domain.Entities.Account user)
        {
            await _accService.Insert(user);

            return Ok(user);
        }
    }
}
