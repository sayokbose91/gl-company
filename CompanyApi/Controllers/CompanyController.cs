using Application.CompanyApp.Commands.CreateCompany;
using Application.CompanyApp.Commands.UpdateCompany;
using Application.CompanyApp.Queries.GetCompany;
using Application.CompanyApp.Queries.GetCompanyById;
using Application.CompanyApp.Queries.GetCompanyByIsin;
using AutoMapper;
using Contracts.Models;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController(ISender mediator, IMapper mapper, ILogger<CompanyController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies(CancellationToken cancellationToken)
        {
            var getAllQuery = new GetAllCompanyQuery();
            var companies = await mediator.Send(getAllQuery, cancellationToken);
            return Ok(mapper.Map<IList<CompanyDto>>(companies));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetCompanyByIdQuery(id);
            var company = await mediator.Send(query, cancellationToken);
            if (company == null)
            {
                logger.LogInformation($"company with ID {id} not found.");   
                return NotFound($"company with ID {id} not found.");
            }
            return Ok(mapper.Map<CompanyDto>(company));
        }
        
        [HttpGet("GetByIsin/{isin}")]
        public async Task<IActionResult> GetByIsin(string isin, CancellationToken cancellationToken)
        {
            var query = new GetCompanyByIsinQuery(isin);
            var company = await mediator.Send(query, cancellationToken);
            if (company == null)
            {
                logger.LogInformation($"company with ID {isin} not found.");   
                return NotFound($"company with ID {isin} not found.");
            }
            return Ok(mapper.Map<CompanyDto>(company));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto company, CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateCompanyCommand(mapper.Map<Company>(company)), cancellationToken);
            return CreatedAtAction(nameof(CreateCompany), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyDto company,CancellationToken cancellationToken)
        {
            await mediator.Send(new UpdateCompanyCommand(id,mapper.Map<Company>(company)), cancellationToken);
            return Ok(company);
        }
    }
}
