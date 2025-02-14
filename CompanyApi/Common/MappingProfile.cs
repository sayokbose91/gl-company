using Contracts.Models;
using Domain.Models;

namespace CompanyApi.Common;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>().ReverseMap();
    }
}
