using WebsiteForms.Services.UserService;

namespace WebsiteForms.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = JwtUtils.Verify(token);

            if (userId != null)
            {
                context.Items["User"] = userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
