using WebsiteForms.Database;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.RequestRepository;
using WebsiteForms.Services.PolicyService;

namespace WebsiteForms.Services.RequestService
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IPolicyService _policyService;

        public RequestService(IRequestRepository requestRepository, IPolicyService policyService)
        {
            _requestRepository = requestRepository;
            _policyService = policyService;
        }
        
        public async Task Create(Request request, IFormFile file)
        {
            string name = request.FullName.Replace(" ", "_").ToUpper();
            string date = DateTime.Now.ToString("ddMMyyyy-HH.mm.ss.fff"); 
            string ext = Path.GetExtension(file.FileName);

            var fileName = $"{name}_POLIZA_{date}{ext}";

            string filePath = await _policyService.Save(file, fileName);
            request.PolicyPDFURL = filePath;

            _requestRepository.Create(request);
        }
    }
}
