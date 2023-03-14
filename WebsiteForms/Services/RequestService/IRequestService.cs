using WebsiteForms.Database.Entities;

namespace WebsiteForms.Services.RequestService
{
    public interface IRequestService
    {
        int? Add(Request request);
        Task<string> SaveFile(IFormFile file);
        Task<int?> AddFiles(List<IFormFile> files, int requestId);
        Task<int?> AddWithFile(Request request, List<IFormFile> files);
        FileStream? GetFileByRoute(string route);
        FileStream? GetFileById(int id);
        int? AddWithHabeasData(HabeasData habeasData);
    }
}
