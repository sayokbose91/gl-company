namespace Application.Interfaces;

public interface IUinitOfWork : IDisposable
{
    Task<int> CommitChangesAsync(CancellationToken cancellationToken);
}