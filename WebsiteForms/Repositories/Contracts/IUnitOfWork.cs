namespace WebsiteForms.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabaseTransaction BeginTransaction();
        int Save();
        IUserRepository Users { get; }
        IRequestRepository Requests { get; }
        IRequestTypeRepository RequestTypes { get; }
    }
}
