using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface IRequestFilesRepository : ISimpleConsultRepository<RequestFiles>, ILambdaConsultRepository<RequestFiles>, ICreateRepository<RequestFiles>
    {
    }
}
