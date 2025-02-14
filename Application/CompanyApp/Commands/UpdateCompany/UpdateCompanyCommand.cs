using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Commands.UpdateCompany;

public record UpdateCompanyCommand(int Id, Company Company) : IRequest<Company>;