using System.ComponentModel.DataAnnotations;
using Application.CompanyApp.Validators;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Commands.CreateCompany;

public class CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUinitOfWork uinitOfWork)
    : IRequestHandler<CreateCompanyCommand, Company>
{
    public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var company = request.Company;

        var existingCompany  = await companyRepository.GetByIdAsync(company.Id, cancellationToken);
        if (existingCompany  != null)
        {
            throw new KeyNotFoundException($"The CompanyTests with Id : {company.Id} already exists.");
        }
        var validator = new CompanyValidator();
        var result = await validator.ValidateAsync(company, cancellationToken);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors[0].ErrorMessage);
        }
        
        await companyRepository.AddAsync(request.Company, cancellationToken);
        await uinitOfWork.CommitChangesAsync(cancellationToken);

        return request.Company;
    }
}