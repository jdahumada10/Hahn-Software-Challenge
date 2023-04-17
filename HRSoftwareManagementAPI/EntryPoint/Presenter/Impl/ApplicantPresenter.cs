using AutoMapper;
using Core.UseCases;
using Core.UseCases.Entities;
using EntryPoint.DTOs;

namespace EntryPoint.Presenter.Impl;

public class ApplicantPresenter : IApplicantPresenter
{
    private readonly IReadApplicantUseCase _readApplicantUseCase;
    private readonly ISaveApplicantUseCase _saveApplicantUseCase;
    private readonly IDeleteApplicantUseCase _deleteApplicantUseCase;

    private readonly IMapper _mapper;

    public ApplicantPresenter(IReadApplicantUseCase readApplicantUseCase, IMapper mapper,
        ISaveApplicantUseCase saveApplicantUseCase, IDeleteApplicantUseCase deleteApplicantUseCase)
    {
        _readApplicantUseCase = readApplicantUseCase;
        _mapper = mapper;
        _saveApplicantUseCase = saveApplicantUseCase;
        _deleteApplicantUseCase = deleteApplicantUseCase;
    }

    public List<ApplicantDto> GetApplicantsByCompanyId(int companyId)
    {
        return _mapper.Map<List<ApplicantDto>>(_readApplicantUseCase.GetApplicantsByCompanyId(companyId));
    }

    public ApplicantDto CreateApplicant(ApplicantDto applicant)
    {
        return _mapper.Map<ApplicantDto>(_saveApplicantUseCase.CreateApplicant(_mapper.Map<Applicant>(applicant)));
    }

    public ApplicantDto UpdateApplicant(ApplicantDto applicant)
    {
        return _mapper.Map<ApplicantDto>(_saveApplicantUseCase.UpdateApplicant(_mapper.Map<Applicant>(applicant)));
    }

    public void DeleteApplicantWithId(int applicantId)
    {
        _deleteApplicantUseCase.DeleteApplicantWithId(applicantId);
    }
}