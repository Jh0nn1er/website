using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface INewRepository : ISimpleConsultRepository<New>, ILambdaConsultRepository<New>, ICreateRepository<New>, IUpdateRepository<New>
    {
    }
}
