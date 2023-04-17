using AutoMapper;
using Core.UseCases.Entities;
using DataProvider.Database.Models;

namespace DataProvider.Adapters.Mappers;

public class ApplicantModelMapper : Profile
{
    public ApplicantModelMapper()
    {
        CreateMap<ApplicantModel, Applicant>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(a => a.Company, opt => opt.MapFrom(o => new Company(o.CompanyId)));
        CreateMap<Applicant, ApplicantModel>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}