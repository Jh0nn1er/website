using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class RequestRepository : EntityRepository<Request>, IRequestRepository
    {
        public RequestRepository(DbContext context) : base(context)
        {
        }
    }
}
