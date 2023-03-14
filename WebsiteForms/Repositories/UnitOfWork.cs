using WebsiteForms.Database;
using WebsiteForms.Repositories.Contracts;
using WebsiteForms.Repositories.Entity;

namespace WebsiteForms.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebsiteFormsContext _context;
        public IUserRepository Users { get; private set; }
        public IRequestRepository Requests { get; private set; }
        public IRequestTypeRepository RequestTypes { get; set; }
        public IHabeasDataRepository HabeasData { get; set; }
        public IConfigurationRepository Configuration { get; set; }
        public IRequestFilesRepository RequestFiles { get; set; }

        public UnitOfWork(WebsiteFormsContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Requests = new RequestRepository(_context);
            RequestTypes = new RequestTypeRepository(_context);
            HabeasData = new HabeasDataRepository(_context);
            Configuration = new ConfigurationRepository(_context);
            RequestFiles = new RequestFilesRepository(_context);
        }

        public UnitOfWork() : this(new WebsiteFormsContext())
        {
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
