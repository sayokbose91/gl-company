using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Commands.CreateCompany;

public record CreateCompanyCommand(Company Company) : IRequest<Company>;
