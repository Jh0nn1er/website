using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface IRequestTypeRepository : ISimpleConsultRepository<RequestType>, ILambdaConsultRepository<RequestType>
    {
    }
}
