namespace WebsiteForms.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabaseTransaction BeginTransaction();
        IUserRepository Users { get; }
        IRequestRepository Requests { get; }
        IRequestTypeRepository RequestTypes { get; }
    }
}
