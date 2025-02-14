using Application.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Queries.GetCompany;

public class GetAllCompanyQueryHandler(ICompanyRepository companyRepository) :IRequestHandler<GetAllCompanyQuery, IList<Company>>
{
    public async Task<IList<Company>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
    {
        var companies = await companyRepository.GetAllAsync(cancellationToken);
        return companies.ToList<Company>();
    }
}