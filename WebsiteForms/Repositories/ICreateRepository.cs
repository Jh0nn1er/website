namespace WebsiteForms.Repositories
{
    public interface ICreateRepository<T>
    {
        void Create(T entity);
    }
}
