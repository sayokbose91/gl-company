using System.ComponentModel.DataAnnotations;
using Application.CompanyApp.Validators;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.CompanyApp.Commands.UpdateCompany;

public class UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IUinitOfWork uinitOfWork)
    : IRequestHandler<UpdateCompanyCommand, Company>
{
    public async Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var existingCompany  = await companyRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingCompany  == null)
        {
            throw new KeyNotFoundException($"The CompanyApp with {request.Id} not found");
        }

        var validator = new CompanyValidator();
        var result = await validator.ValidateAsync(request.Company, cancellationToken);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors[0].ErrorMessage);
        }
        
        existingCompany.Name = request.Company.Name;
        existingCompany.Exchange = request.Company.Exchange;
        existingCompany.Ticker = request.Company.Ticker;
        existingCompany.Isin = request.Company.Isin;
        existingCompany.Website = request.Company.Website;

        await companyRepository.UpdateAsync(request.Id, existingCompany, cancellationToken);
        await uinitOfWork.CommitChangesAsync(cancellationToken);

        return request.Company;
    }
}