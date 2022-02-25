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
        private readonly IPolicyService _policyService;
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork, IPolicyService policyService)
        {
            _unitOfWork = unitOfWork;
            _policyService = policyService;
        }

        public void Add(Request request)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                var requestType = _unitOfWork.RequestTypes.GetById(request.RequestType.Id);
                request.RequestType = requestType;

                _unitOfWork.Requests.Add(request);
                _unitOfWork.Save();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public FileStream? GetFileById(int id)
        {
            var route = _unitOfWork.Requests.GetById(id)?.PolicyPDFURL;
            if (route == null) return null;

            var fileStream = _policyService.Get(route);
            return fileStream;
        }

        public FileStream? GetFileByRoute(string route)
        {
            var fileStream = _policyService.Get(route);

            return fileStream;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string name = Guid.NewGuid().ToString();
            string ext = Path.GetExtension(file.FileName);
            string fileName = $"{name}{ext}";

            return await _policyService.Save(file, fileName);
        }
    }
}
