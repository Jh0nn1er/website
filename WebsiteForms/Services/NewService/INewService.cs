
using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.NewService
{
    public interface INewService
    {
        int? Add(New news);
        int? Update(New news);
        New GetById(int id);
        IEnumerable<New> GetAll();

    }
}
