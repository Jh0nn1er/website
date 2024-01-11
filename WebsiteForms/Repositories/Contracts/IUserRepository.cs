using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface IUserRepository : ISimpleConsultRepository<User>, ILambdaConsultRepository<User>
    {
        User? GetByUsername(string username);
    }
}
