using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface IConfigurationRepository : ISimpleConsultRepository<Configuration>, ILambdaConsultRepository<Configuration>, ICreateRepository<Configuration>
    {
    }
}
