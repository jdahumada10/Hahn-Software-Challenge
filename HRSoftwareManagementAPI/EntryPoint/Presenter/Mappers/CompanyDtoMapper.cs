using AutoMapper;
using Core.UseCases.Entities;
using EntryPoint.DTOs;

namespace EntryPoint.Presenter.Mappers;

public class CompanyDtoMapper : Profile
{
    public CompanyDtoMapper()
    {
        CreateMap<Company, CompanyDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<CompanyDto, Company>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}