namespace WebsiteForms.Services.PolicyService
{
    public class FileService : IPolicyService
    {
        private readonly string _path;
        public FileService(string path = null)
        {
            var basePath = path ?? Environment.GetEnvironmentVariable("BASE_PATH");
            if (basePath == null)
                throw new Exception("Base path is required to save files");

            _path = basePath;
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
    }
}
