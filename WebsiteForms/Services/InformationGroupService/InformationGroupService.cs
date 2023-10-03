using AutoMapper;
using WebsiteForms.Database.Entities;
using WebsiteForms.Models.ViewModels;
using WebsiteForms.Repositories.Contracts;
using WebsiteForms.Repositories.Entity;

namespace WebsiteForms.Services.InformationGroupService
{
    public class InformationGroupService : IInformationGroupService
    {
        private readonly IInformationGroupRepository _informationGroupRepository;
        private readonly IMapper _mapper;
        public InformationGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _informationGroupRepository = unitOfWork.InformationGroups;
            _mapper = mapper;
        }

        public List<InformationGroupVm> GetAll()
        {
            var informationGroups = _informationGroupRepository.GetAll();
            return _mapper.Map<List<InformationGroupVm>>(informationGroups).ToList();
        }

        public List<InformationGroupVm> GetByParentId(int parentId)
        {
            var informationGroups = _informationGroupRepository.FindAndInclude(ig => ig.ParentInformationGroupId == parentId, ig => ig.Documents);
            return _mapper.Map<List<InformationGroupVm>>(informationGroups).ToList();
        }

        public InformationGroup GetById(int id)
        {
            return _informationGroupRepository.GetById(id);
        }

        public List<InformationGroupMainVm> GetMainGroups()
        {
            var mainGroups = _informationGroupRepository.Find(ig => ig.ParentInformationGroupId == null).OrderBy(ig => ig.Order).ToList();
            return _mapper.Map<List<InformationGroupMainVm>>(mainGroups);
        }
    }
}
