using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class InformationGroupRepository : EntityConsultRepository<InformationGroup>, IInformationGroupRepository
    {
        public InformationGroupRepository(DbContext context) : base(context)
        {
        }
    }
}
