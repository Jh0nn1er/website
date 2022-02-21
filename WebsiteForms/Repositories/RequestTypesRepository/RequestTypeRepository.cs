using WebsiteForms.Database;
using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.RequestTypesRepository
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        public IEnumerable<RequestType> GetAll()
        {
            using var db = new WebsiteFormsContext();
            var requestTypes = db.RequestTypes.ToList();
            return requestTypes;
        }

        public RequestType GetById(int id)
        {
            using var db = new WebsiteFormsContext();
            var requestType = db.RequestTypes.Find(id);
            return requestType;
        }
    }
}
