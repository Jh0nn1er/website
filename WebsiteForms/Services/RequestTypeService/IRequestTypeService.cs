using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.RequestTypeService
{
    public interface IRequestTypeService
    {
        RequestType GetById(int id);
        IEnumerable<RequestType> GetAll();
    }
}
