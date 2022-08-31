using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface IRequestRepository : ISimpleConsultRepository<Request>, ILambdaConsultRepository<Request>, ICreateRepository<Request>
    {
    }
}
