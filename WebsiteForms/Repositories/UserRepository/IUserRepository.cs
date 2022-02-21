using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.UserRepository
{
    public interface IUserRepository: IConsultRepository<User>
    {
        User? GetByUsername(string username);
    }
}
