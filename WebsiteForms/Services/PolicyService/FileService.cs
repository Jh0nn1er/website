namespace WebsiteForms.Services.PolicyService
{
    public class FileService : IPolicyService
    {
        private string _path;
        public FileService(AppSettings appSettings)
        {
            _path = appSettings.FilesPath;
        }

        public async Task<string> Save(IFormFile file, string fileName = null)
        {
            string newFileName = fileName ?? file.FileName;

            string filePath = Path.Combine(_path, newFileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }

        public FileStream Get(string path)
        {
            var stream = new FileStream(path, FileMode.Open);
            return stream;
        }
    }
}
