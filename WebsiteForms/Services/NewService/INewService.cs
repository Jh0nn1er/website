
using System.Linq.Expressions;
using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.NewService
{
    public interface INewService
    {
        int? Add(New news);
        int? Update(New news);
        New GetById(int id);
        List<New> GetAsync(Expression<Func<New, bool>> predicate);
        IEnumerable<New> GetAll();

    }
}
