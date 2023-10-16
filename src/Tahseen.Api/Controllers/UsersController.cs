using Microsoft.AspNetCore.Mvc;
using Tahseen.Service.Interfaces.IUsersService;

namespace Tahseen.Api.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService UserService)
        {
            this._userService = UserService;
        }

        ///
        ///

    }
}
