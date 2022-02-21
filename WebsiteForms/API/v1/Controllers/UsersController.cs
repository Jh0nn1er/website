using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteForms.API.v1.Authenticate.Models;
using WebsiteForms.Services.UserService;
using WebsiteForms.Authorization;
using WebsiteForms.Helpers;
using WebsiteForms.Repositories.UserRepository;

namespace WebsiteForms.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [JwtAuthorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate(AuthenticateRequest req)
        {
            var user = _userService.Authenticate(req.Username, req.Password);
            if (user == null)
                return BadRequest(new
                {
                    msg = "Username or password incorrect"
                });

            return Ok(new AuthenticateResponse() { Token = JwtUtils.Generate(user.UserID) });
        }
    }
}
