namespace WebsiteForms.Services.PolicyService
{
    public class FileService : IPolicyService
    {
        private string _path;
        public FileService(AppSettings appSettings)
        {
            _path = appSettings.FilesPath;

            CreateFolderIfNotExists(_path);
        }

        public async Task<string> Save(IFormFile file, string fileName = null)
        {
            string newFileName = fileName ?? file.FileName;

            //string filePath = Path.Combine(_path, newFileName);

            string folderPath = Path.Combine(Environment.CurrentDirectory, "Files");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            
            string filePath = Path.Combine(folderPath, newFileName);
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

        private bool CreateFolderIfNotExists(string path)
        {
            try
            {
                if(Directory.Exists(path)) return true;

                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
