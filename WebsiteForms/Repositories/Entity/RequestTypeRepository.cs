using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class RequestTypeRepository : EntityConsultRepository<RequestType>, IRequestTypeRepository
    {
        public RequestTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
