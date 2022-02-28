using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.RequestService
{
    public interface IRequestService
    {
        int? Add(Request request);
        Task<string> SaveFile(IFormFile file);
        Task<int?> AddWithFile(Request request, IFormFile file);
        FileStream? GetFileByRoute(string route);
        FileStream? GetFileById(int id);
    }
}
