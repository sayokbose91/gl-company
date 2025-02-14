using Domain.Models;

namespace Application.Interfaces.Repositories;

/// <summary>
/// The company repository interface.
/// </summary>
/// <seealso cref="IRepository{CompanyApp}"/>
public interface ICompanyRepository : IRepository<Company>
{
    Task<Company?> GetByIsin(string isin, CancellationToken cancellationToken);
}