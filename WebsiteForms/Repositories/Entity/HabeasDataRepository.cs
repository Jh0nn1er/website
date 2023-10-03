using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class HabeasDataRepository : EntityRepository<HabeasData>, IHabeasDataRepository
    {
        public HabeasDataRepository(DbContext context) : base(context)
        {
        }
    }
}
