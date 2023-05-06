using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface IInformationGroupRepository : ISimpleConsultRepository<InformationGroup>, ILambdaConsultRepository<InformationGroup>
    {
    }
}
