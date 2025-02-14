namespace Application.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(int id, T entity, CancellationToken cancellationToken); 
    Task AddAsync(T entity, CancellationToken cancellationToken);
}