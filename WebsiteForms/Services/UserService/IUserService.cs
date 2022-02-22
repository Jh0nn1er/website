using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.UserService
{
    public interface IUserService
    {
        User? Authenticate(string username, string password);
        User? GetById(int id);
        User? GetByUsername(string username);
    }
}
