using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.UserRepository;
using WebsiteForms.Helpers;

namespace WebsiteForms.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) return null;

            bool isValid = Hashing.Verify(password, user.Password);
            if (!isValid) return null;

            return user;
        }
    }
}
