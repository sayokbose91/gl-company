using System.ComponentModel.DataAnnotations;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.CompanyApp.Commands.CreateCompany;
using Domain.Models;
using Moq;
using Domain.Models;
using Moq;
using FluentAssertions;


namespace Application.UnitTests.CompanyTests.Commands;

public class CreateCompanyCommandTest
{
    [Fact]
    public async Task Handle_ValidRequest_ShouldCreateCompany()
    {
        var company = new Company
        {
            Name = "Acme Corporation",
            Exchange = "NASDAQ",
            Ticker = "ACME",
            Isin = "US0378331005",
            Website = "https://www.acme.com"
        };
        var request = new CreateCompanyCommand(company);
        
        var companyRepository = new Mock<ICompanyRepository>();
        
        companyRepository.Setup(repo => repo.AddAsync(company, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
    
        var unitOfWork = new Mock<IUinitOfWork>();
        unitOfWork.Setup(uow => uow.CommitChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);
        
        var sut = new CreateCompanyCommandHandler(companyRepository.Object,unitOfWork.Object);
        var resultCompany = await sut.Handle(request, CancellationToken.None);
        
        resultCompany.Should().NotBeNull();
        resultCompany.Should().Be(request.Company);
        
        companyRepository.Verify(x => x.AddAsync(company, It.IsAny<CancellationToken>()), Times.Once);
        unitOfWork.Verify(x => x.CommitChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async Task Handle_InvalidISIN_ShouldThrowValidationException()
    {
        var company = new Company
        {
            Name = "Invalid ISIN Inc.",
            Exchange = "NASDAQ",
            Ticker = "INV",
            Isin = "123456",
            Website = "https://invalidisin.com"
        };
        var request = new CreateCompanyCommand(company);

        var companyRepository = new Mock<ICompanyRepository>();
        companyRepository
            .Setup(repo => repo.AddAsync(company, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var unitOfWork = new Mock<IUinitOfWork>();
        unitOfWork
            .Setup(uow => uow.CommitChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var sut = new CreateCompanyCommandHandler(companyRepository.Object, unitOfWork.Object);
        var exception = await Assert.ThrowsAsync<ValidationException>(
            () => sut.Handle(request, CancellationToken.None));
        exception.Message.Should().Be("ISIN must be exactly 12 characters long and start with two letters.");
    }
}