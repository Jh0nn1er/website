using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories
{
    public class EntityRepository<TEntity> : ISimpleConsultRepository<TEntity>, ILambdaConsultRepository<TEntity>, ICreateRepository<TEntity>, IUpdateRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public EntityRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
            return entity;

        }
    }
}
