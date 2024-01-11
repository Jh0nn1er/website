namespace WebsiteForms.Repositories.Contracts
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
