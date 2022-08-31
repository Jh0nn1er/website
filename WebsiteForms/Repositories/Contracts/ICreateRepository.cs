namespace WebsiteForms.Repositories.Contracts
{
    public interface ICreateRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
    }
}
