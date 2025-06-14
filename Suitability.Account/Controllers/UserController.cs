using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Suitability.Account.Api.Controllers
{
    [ApiController]
    [EnableCors("All")]
    public class UserController : ControllerBase
    {
        public UserController() { }
    }
}
