using WebsiteForms.API.v1.Models.Requests;
using WebsiteForms.Database;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories;
using WebsiteForms.Services.PolicyService;

namespace WebsiteForms.Services.RequestService
{
    public class RequestService : IRequestService
    {
        private readonly IPolicyService _policyService;

        public RequestService(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        
        public async Task Create(Request request, IFormFile file, int requestTypeId)
        {
            using (var unitOfWork = new UnitOfWork(new WebsiteFormsContext()))
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    var requestType = unitOfWork.RequestTypes.GetById(requestTypeId);
                    request.RequestType = requestType;

                    unitOfWork.Requests.Add(request);
                    unitOfWork.Save();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Add(Request request)
        {
            using (var unitOfWork = new UnitOfWork(new WebsiteFormsContext()))
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    var requestType = unitOfWork.RequestTypes.GetById(request.RequestType.Id);
                    request.RequestType = requestType;

                    unitOfWork.Requests.Add(request);
                    unitOfWork.Save();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
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
