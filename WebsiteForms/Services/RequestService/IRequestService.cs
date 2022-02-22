using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.RequestService
{
    public interface IRequestService
    {
        void Add(Request request);
        Task<string> SaveFile(IFormFile file);
    }
}
