using System.Linq.Expressions;

namespace WebsiteForms.Repositories.Contracts
{
    public interface ILambdaConsultRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAndInclude(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> includeExpression);
    }
}
