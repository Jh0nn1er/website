using WebsiteForms.Services.UserService;

namespace WebsiteForms.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtUtils _jwtUtils;

        public JwtMiddleware(RequestDelegate next, JwtUtils jwtUtils)
        {
            _next = next;
            _jwtUtils = jwtUtils;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtUtils.Verify(token);

            if (userId != null)
            {
                context.Items["User"] = userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
