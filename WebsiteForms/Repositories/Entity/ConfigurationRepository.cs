using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;

namespace WebsiteForms.Repositories.Entity
{
    public class ConfigurationRepository : EntityRepository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(DbContext context) : base(context)
        {
        }
    }
}
