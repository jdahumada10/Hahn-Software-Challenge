using AutoMapper;
using Core.UseCases.Entities;
using DataProvider.Database.Models;

namespace DataProvider.Adapters.Mappers;

public class CompanyModelMapper : Profile
{
    public CompanyModelMapper()
    {
        CreateMap<CompanyModel, Company>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<Company, CompanyModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}