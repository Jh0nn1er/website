using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Services.RequestTypeService
{
    public class RequestTypeService : IRequestTypeService
    {
        private readonly IRequestTypeRepository _requestTypeRepository;
        public RequestTypeService(IUnitOfWork unitOfWork)
        {
            _requestTypeRepository = unitOfWork.RequestTypes;
        }

        public RequestType GetById(int id)
        {
            return _requestTypeRepository.GetById(id);
        }

        public IEnumerable<RequestType> GetAll()
        {
            return _requestTypeRepository.GetAll();
        }
    }
}
