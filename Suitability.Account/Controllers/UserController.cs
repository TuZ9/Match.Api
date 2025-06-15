using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Suitability.Account.Domain.Interfaces.Service;

namespace Suitability.Account.Api.Controllers
{
    [ApiController]
    [EnableCors("All")]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accService;
        public UserController(IAccountService accService) 
        {
            _accService = accService;
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
