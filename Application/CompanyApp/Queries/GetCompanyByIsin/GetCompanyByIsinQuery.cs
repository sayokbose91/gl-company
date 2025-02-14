using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Queries.GetCompanyByIsin;

public record GetCompanyByIsinQuery(string Isin) : IRequest<Company?>;
