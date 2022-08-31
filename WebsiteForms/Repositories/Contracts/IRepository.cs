namespace WebsiteForms.Repositories.Contracts
{
    public interface IRepository<TEntity>
        : ISimpleConsultRepository<TEntity>, ILambdaConsultRepository<TEntity>, ICreateRepository<TEntity>, IUpdateRepository<TEntity>, IDeleteRepository<TEntity>
        where TEntity : class
    {
    }
}
