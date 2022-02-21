using WebsiteForms.Database;

namespace WebsiteForms.Repositories
{
    public interface IConsultRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
