namespace WebsiteForms.Repositories.Contracts
{
    public interface IUpdateRepository<TEntity> where TEntity : class
    {
        TEntity Update(TEntity entity);
    }
}
