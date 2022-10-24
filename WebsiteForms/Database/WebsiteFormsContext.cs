using System.Data.Entity;
using WebsiteForms.Database.Entities;
using WebsiteForms.Loging.Models;

namespace WebsiteForms.Database
{
    public class WebsiteFormsContext : DbContext
    {
        public WebsiteFormsContext() : base(DbSettings.GetConnectionString())
        {
        }

        public virtual DbSet<RequestType> RequestTypes { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
