using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.Contracts
{
    public interface IHabeasDataRepository: ISimpleConsultRepository<HabeasData>, ILambdaConsultRepository<HabeasData>, ICreateRepository<HabeasData>
    {
    }
}
