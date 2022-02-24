using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteForms.API.v1.Authenticate.Models;
using WebsiteForms.Services.UserService;
using WebsiteForms.Authorization;
using WebsiteForms.Helpers;

namespace WebsiteForms.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [JwtAuthorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtUtils _jwtUtils;
        public UsersController(IUserService userService, JwtUtils jwtUtils)
        {
            _userService = userService;
            _jwtUtils = jwtUtils;
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

            return Ok(new AuthenticateResponse() { Token = _jwtUtils.Generate(user.Id) });
        }
    }
}
