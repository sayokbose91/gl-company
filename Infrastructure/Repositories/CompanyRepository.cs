using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// The company repository class.
/// </summary>
public class CompanyRepository(CompanyDbContext companyDbContext) : Repository<Company>(companyDbContext), ICompanyRepository
{
    private readonly CompanyDbContext _companyDbContext = companyDbContext;

    public async Task<Company?> GetByIsin(string isin, CancellationToken cancellationToken)
    {
        return await _companyDbContext.Set<Company>()
            .FirstOrDefaultAsync(c => c.Isin == isin, cancellationToken);
    }
}