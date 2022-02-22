using System.Data.Entity;
using WebsiteForms.Database;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class UserRepository : EntityConsultRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return DbSet.Where(u => u.Username == username).FirstOrDefault();
        }
    }
}
