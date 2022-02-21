using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.UserService
{
    public interface IUserService
    {
        User? Authenticate(string username, string password);
    }
}
