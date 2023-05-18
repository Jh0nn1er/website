using WebsiteForms.Database.Entities;
using WebsiteForms.Models.ViewModels;

namespace WebsiteForms.Services.InformationGroupService
{
    public interface IInformationGroupService
    {
        InformationGroup GetById(int id);
        List<InformationGroupVm> GetAll();
        List<InformationGroupMainVm> GetMainGroups();
        List<InformationGroupVm> GetByParentId(int id);
    }
}
