using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Queries.GetCompanyById;

public record GetCompanyByIdQuery(int Id) : IRequest<Company?>;
