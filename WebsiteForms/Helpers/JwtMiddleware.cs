using WebsiteForms.Repositories.UserRepository;

namespace WebsiteForms.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = JwtUtils.Verify(token);

            if (userId != null)
            {
                context.Items["User"] = userRepository.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
