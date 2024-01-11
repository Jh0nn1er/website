using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class NewRepository : EntityRepository<New>, INewRepository
    {
        public NewRepository(DbContext context) : base(context)
        {
        }

    }
}
