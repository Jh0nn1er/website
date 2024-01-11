namespace WebsiteForms.Repositories.Contracts
{
    public interface ISimpleConsultRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
