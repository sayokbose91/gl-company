using Application.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Common;

/// <summary>

/// The unit of work class.

/// </summary>

public class UnitOfWork(CompanyDbContext dbContext,ILogger<UnitOfWork> logger) :IUinitOfWork
{
    /// <summary>
    /// Disposes this instance.
    /// </summary>
    public void Dispose()
    {
        dbContext.Dispose();
    }

    /// <summary>
    /// Commits the changes using the specified cancellation token.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <exception cref="Exception">An error occurred while saving changes to the database. </exception>
    /// <exception cref="Exception">An unexpected error occurred. </exception>
    /// <returns>A task containing the int.</returns>
    public async Task<int> CommitChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError("An error occurred while saving changes to the database.");
            throw new Exception("An unexpected error occurred.", ex);
        }
    }
}