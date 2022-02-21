using WebsiteForms.Database;
using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.RequestRepository
{
    public class RequestRepository : IRequestRepository
    {
        public void Create(Request entity)
        {
            using var db = new WebsiteFormsContext();
            db.Requests.Add(entity);
            db.SaveChanges();
        }
    }
}
