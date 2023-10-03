using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class RequestFilesRepository : EntityRepository<RequestFiles>, IRequestFilesRepository
    {
        public RequestFilesRepository(DbContext context) : base(context)
        {
        }
    }
}
