using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.RequestService
{
    public interface IRequestService
    {
        bool Add(Request request);
        Task<string> SaveFile(IFormFile file);
        Task<bool> AddWithFile(Request request, IFormFile file);
        FileStream? GetFileByRoute(string route);
        FileStream? GetFileById(int id);
    }
}
