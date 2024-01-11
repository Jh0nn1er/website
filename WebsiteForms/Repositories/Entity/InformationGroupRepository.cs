using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class InformationGroupRepository : EntityConsultRepository<InformationGroup>, IInformationGroupRepository
    {
        public InformationGroupRepository(DbContext context) : base(context)
        {
        }

        public List<InformationGroup> GetAll()
        {
            var informationGroups = DbSet.Where(ig => ig.ParentInformationGroupId == null)
                .Include(ig => ig.InformationGroups)
                .Include(ig => ig.Documents)
                .OrderBy(ig => ig.Order)
                .ToList();

            foreach (var informationGroup in informationGroups)
            {
                informationGroup.InformationGroups = Order(informationGroup.InformationGroups);
            }

            return informationGroups.ToList();
        }

        private ICollection<InformationGroup> Order(ICollection<InformationGroup> informationGroups)
        {
            if (informationGroups == null || !informationGroups.Any())
                return informationGroups;

            var orderedGroups = informationGroups.OrderBy(ig => ig.Order).ToList();

            foreach (var orderedGroup in orderedGroups)
            {
                orderedGroup.InformationGroups = Order(orderedGroup.InformationGroups);
                orderedGroup.Documents = orderedGroup.Documents.OrderBy(ig => ig.Order).ToList();
            }

            return orderedGroups;
        }
    }
}
