namespace WebsiteForms.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabaseTransaction BeginTransaction();
        int Save();
        IUserRepository Users { get; }
        IRequestRepository Requests { get; }
        IRequestFilesRepository RequestFiles { get; }
        IRequestTypeRepository RequestTypes { get; }
        IHabeasDataRepository HabeasData { get; }
        IConfigurationRepository Configuration { get; }
    }
}
