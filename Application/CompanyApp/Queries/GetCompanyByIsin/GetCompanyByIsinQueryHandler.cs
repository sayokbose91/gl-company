using Application.CompanyApp.Queries.GetCompanyById;
using Application.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Queries.GetCompanyByIsin;


public class GetCompanyByIsinQueryHandler(ICompanyRepository companyRepository) :IRequestHandler<GetCompanyByIsinQuery, Company?>
{
    public async Task<Company?> Handle(GetCompanyByIsinQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        return await companyRepository.GetByIsin(request.Isin, cancellationToken);
    }
}