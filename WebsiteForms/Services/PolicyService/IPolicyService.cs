namespace WebsiteForms.Services.PolicyService
{
    public interface IPolicyService
    {
        Task<string> Save(IFormFile file, string filename = null);
        FileStream Get(string path);
    }
}
