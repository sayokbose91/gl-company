using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Queries.GetCompany;

public record GetAllCompanyQuery: IRequest<IList<Company>>;
