using Application.CompanyApp.Queries.GetCompanyById;
using Application.Interfaces.Repositories;
using Domain.Models;
using FluentAssertions;
using Moq;

namespace Application.UnitTests.CompanyTests.Queries;

public class GetCompanyByIdQueryTest
{
    [Fact]
    public async Task GetByIdAsync_ValidId_ShouldReturnCompany()
    {
        var companyId = 1;
        var expectedCompany = new Company
        {
            Id = companyId,
            Name = "Acme Corporation",
            Exchange = "NASDAQ",
            Ticker = "ACME",
            Isin = "US0378331005",
            Website = "https://www.acme.com"
        };
    
        var companyRepository = new Mock<ICompanyRepository>();
        companyRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((int id, CancellationToken _) => id == companyId ? expectedCompany : null);
    
        var request = new GetCompanyByIdQuery(companyId);
        var sut = new GetCompanyByIdQueryHandler(companyRepository.Object);
        var result = await sut.Handle(request, CancellationToken.None);
        
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedCompany);
    
        companyRepository.Verify(repo => repo.GetByIdAsync(companyId, It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async Task GetByIdAsync_InvalidId_ShouldReturnNull()
    {
        var invalidCompanyId = 999;
    
        var companyRepository = new Mock<ICompanyRepository>();
        companyRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((int id, CancellationToken _) => null);
    
        var request = new GetCompanyByIdQuery(invalidCompanyId);
        var sut = new GetCompanyByIdQueryHandler(companyRepository.Object);
        var result = await sut.Handle(request, CancellationToken.None);
        result.Should().BeNull();
    
        companyRepository.Verify(repo => repo.GetByIdAsync(invalidCompanyId, It.IsAny<CancellationToken>()), Times.Once);
    }
}