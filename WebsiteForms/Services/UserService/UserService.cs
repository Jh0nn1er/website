using WebsiteForms.Database.Entities;
using WebsiteForms.Helpers;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User? Authenticate(string username, string password)
        {
            var user = _unitOfWork.Users.GetByUsername(username);
            if (user == null) return null;

            bool isValid = Hashing.Verify(password, user.Password);
            if (!isValid) return null;
            
            return user;
        }

        public User? GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public User? GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
