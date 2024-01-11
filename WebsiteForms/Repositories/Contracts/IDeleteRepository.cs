namespace WebsiteForms.Repositories.Contracts
{
    public interface IDeleteRepository<TEntity> where TEntity : class
    {
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
