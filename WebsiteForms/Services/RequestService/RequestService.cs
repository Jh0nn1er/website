using WebsiteForms.API.v1.Models.Requests;
using WebsiteForms.Database;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories;
using WebsiteForms.Repositories.Contracts;
using WebsiteForms.Services.PolicyService;

namespace WebsiteForms.Services.RequestService
{
    public class RequestService : IRequestService
    {
        private readonly AppSettings _appSettings;
        private readonly IPolicyService _policyService;
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(AppSettings appSettings, IUnitOfWork unitOfWork, IPolicyService policyService)
        {
            _appSettings = appSettings;
            _unitOfWork = unitOfWork;
            _policyService = policyService;
        }
        public FileStream? GetFileById(int id)
        {
            //TODO ajustar  de donde se trae la url del archivo
            //var route = _unitOfWork.Requests.GetById(id)?.FileURL;
            var route = _unitOfWork.RequestFiles.GetById(id)?.Id.ToString();
            if (route == null) return null;

            return GetFileByRoute(route);
        }
        public FileStream? GetFileByRoute(string route)
        {
            var absolutePath = route.Replace("~", _appSettings.RootPath);
            var fileStream = _policyService.Get(absolutePath);

            return fileStream;
        }
        public int? Add(Request request)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                var requestType = _unitOfWork.RequestTypes.GetById(request.RequestType.Id);
                request.RequestType = requestType;

                _unitOfWork.Requests.Add(request);
                _unitOfWork.Save();

                transaction.Commit();

                return request.Id;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }

        public async Task<int?> AddFiles(List<IFormFile> files, int requestId)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var requestFiles = new RequestFiles();

            try
            {
                foreach (IFormFile file in files)
                {
                    string savedPath = await SaveFile(file);
                    string dbPath = savedPath.Replace(_appSettings.RootPath, $"~{Path.DirectorySeparatorChar}");
                    requestFiles.RequestId = requestId;
                    requestFiles.FileURL = dbPath;
                    requestFiles.CreatedAt = DateTime.Now;
                    _unitOfWork.RequestFiles.Add(requestFiles);
                    _unitOfWork.Save();
                }

                transaction.Commit();

                return requestFiles.Id;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }

        public async Task<int?> AddWithFile(Request request, List<IFormFile> files)
        {
            
            var requestFiles = new RequestFiles();

            try
            {
                foreach (IFormFile file in files)
                {
                    string savedPath = await SaveFile(file);
                    string dbPath = savedPath.Replace(_appSettings.RootPath, $"~{Path.DirectorySeparatorChar}");
                    requestFiles.RequestId = request.Id;
                    requestFiles.FileURL = dbPath;
                }
                return 0;
            }
            catch (Exception)
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string name = Guid.NewGuid().ToString();
            string ext = Path.GetExtension(file.FileName);
            string fileName = $"{name}{ext}";

            return await _policyService.Save(file, fileName);
        }

        public int? AddWithHabeasData(HabeasData habeasData)

        {
            using var transaction = _unitOfWork.BeginTransaction();
            try 
            {
                _unitOfWork.HabeasData.Add(habeasData);
                _unitOfWork.Save();

                transaction.Commit();

                return habeasData.Id;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }
    }
}
