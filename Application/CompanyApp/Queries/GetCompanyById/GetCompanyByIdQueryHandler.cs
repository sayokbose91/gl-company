using Application.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Queries.GetCompanyById;


public class GetCompanyByIdQueryHandler(ICompanyRepository companyRepository) :IRequestHandler<GetCompanyByIdQuery, Company?>
{
    public async Task<Company?> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var company = await companyRepository.GetByIdAsync(request.Id, cancellationToken);
        return company;
    }
}