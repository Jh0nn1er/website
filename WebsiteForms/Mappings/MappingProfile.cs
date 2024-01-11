using AutoMapper;
using WebsiteForms.Database.Entities;
using WebsiteForms.Models.ViewModels;

namespace WebsiteForms.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InformationGroup, InformationGroupVm>();
            CreateMap<Document, DocumentVm>();
            CreateMap<InformationGroup, InformationGroupMainVm>();
        }
    }
}
