using AutoMapper;
using Core.UseCases.Entities;
using EntryPoint.DTOs;

namespace EntryPoint.Presenter.Mappers;

public class ApplicantDtoMapper : Profile
{
    public ApplicantDtoMapper()
    {
        CreateMap<Applicant, ApplicantDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(a => a.CompanyId, opt => opt.MapFrom(o => o.Company.Id));
        CreateMap<ApplicantDto, Applicant>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(a => a.Company, opt => opt.MapFrom(o => new Company(o.CompanyId)));
    }
}